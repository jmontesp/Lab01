using Lab01.DataPersistance;
using Lab01.Infrastructure.DataStructures;
using Lab01.Infrastructure.Interfaces;
using Lab01.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using ErrorMsg = Lab01.Infrastructure.Resources.ErrorMsg;

namespace Lib01.TodoItemRol
{
    public class ManageTodoItems : IDisposable
    {
        #region Attributes

        private ITodoItem dataProvider;

        #endregion

        #region Singleton Pattern

        private static ManageTodoItems instance = null;

        public static ManageTodoItems Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ManageTodoItems();
                }
                return instance;
            }
        }

        private ManageTodoItems()
        {
            // obtiene la instancia de DataProvider
            this.dataProvider = (ITodoItem)DataProvider.Instance;

            // suscribe los eventos de persistencia de datos
            this.dataProvider.ItemCreated += this.OnDataPersistenceChanged;
            this.dataProvider.ItemUpdated += this.OnDataPersistenceChanged;
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            // des-suscribe los eventos de persistencia de datos
            this.dataProvider.ItemCreated -= this.OnDataPersistenceChanged;
            this.dataProvider.ItemUpdated -= this.OnDataPersistenceChanged;
        }

        #endregion

        #region Events

        /// <summary>
        /// Se lanza cuando la duración total de las tareas de un día excede las 8 horas
        /// </summary>

        public event DataPersistenceChange TimeExceeded;

        #endregion

        #region Event Handlers

        /// <summary>
        /// Maneja los eventos producidos en DataProvider
        /// Si algún día tiene tareas que en total duren más de 8 horas lanza una alerta
        /// </summary>
        /// <param name="args">qué causó el cambio en la persistencia de datos</param>

        private void OnDataPersistenceChanged(Response args)
        {
            Response dtResponse = this.dataProvider.ReadAllTodoItems();
            if(dtResponse.Success)
            {
                var orderedList = ((List<TodoItem>)dtResponse.Result).OrderBy(t => t.DueDate).ToList<TodoItem>();
                DateTime currentDate = orderedList[0].DueDate;
                decimal totalDuration = 0;
                foreach(TodoItem todoItem in orderedList)
                {
                    if(todoItem.DueDate.Equals(currentDate))
                    {
                        totalDuration += todoItem.Duration;
                        if(totalDuration > 8)
                        {
                            if (TimeExceeded != null) TimeExceeded(new Fail { Message = String.Format(ErrorMsg.TimeExceeded, currentDate) });
                            break;
                        }
                    }
                    else
                    {
                        currentDate = todoItem.DueDate;
                        totalDuration = todoItem.Duration;
                    }
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Crea una tarea
        /// </summary>
        /// <param name="item">tarea a crear</param>
        /// <returns>Success si se crea la tarea, Fail en otro caso</returns>
        public Response CreateTodoItem(TodoItem item)
        {
            var response = Validate(item);
            if(!response.Success) { return response; }
            return this.dataProvider.CreateTodoItem(item);
        }

        /// <summary>
        /// Borra una tarea
        /// </summary>
        /// <param name="item">tarea a borrar</param>
        /// <returns>Success si se borra la tarea, Fail en otro caso</returns>
        public Response DeleteTodoItem(int id)
        {
            return this.dataProvider.DeleteTodoItem(id);
        }

        /// <summary>
        /// Devuelve todas las tareas
        /// </summary>
        /// <returns>Una lista de tareas</returns>
        public Response GetTodoItems() => this.dataProvider.ReadAllTodoItems();

        /// <summary>
        /// Actualiza una tarea
        /// </summary>
        /// <param name="item">tarea a actualizar</param>
        /// <returns>Success si se actualiza la tarea, Fail en otro caso</returns>
        public Response UpdateTodoItem(TodoItem item)
        {
            var response = Validate(item);
            if (!response.Success) { return response; }
            return this.dataProvider.UpdateTodoItem(item);
        }

        /// <summary>
        /// Valida una tarea
        /// </summary>
        /// <param name="item">tarea a validar</param>
        /// <returns>Success si se valida la tarea, Fail en otro caso</returns>
        private Response Validate(TodoItem item)
        {
            Response response = new Response();
            int counter = 0;
            if (item == null) { response.Message += $"{++counter}. {ErrorMsg.NullTodoItem}" + "\n"; }
            else
            {
                if (item.Id <= 0) { response.Message += $"{++counter}. {ErrorMsg.EmptyTitle}" + "\n"; }
                if (string.IsNullOrEmpty(item.Title)) { response.Message += $"{++counter}." + String.Format(ErrorMsg.NotValidId, item.Id) + "\n"; }
                if (item.DueDate < DateTime.Now) { response.Message += $"{++counter}. {ErrorMsg.ExpiredDate}" + "\n"; }
                if (item.Duration < 0) { response.Message += $"{++counter}. {ErrorMsg.NegativeDuration}" + "\n"; }
                if (item.Duration > 8) { response.Message += $"{++counter}. {ErrorMsg.TooLongDuration}" + "\n"; }
            }
            response.Success = String.IsNullOrEmpty(response.Message) ? true : false;
            return response;
        }

        #endregion
    }
}
