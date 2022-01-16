using Lab01.Infrastructure.DataStructures;
using Lab01.Infrastructure.Models;
using System.Threading.Tasks;

namespace Lab01.Infrastructure.Interfaces
{
    /// <summary>
    /// Interfaz de manejo de tareas
    /// </summary>
    public interface ITodoItem
    {

        #region Events

        /// <summary>
        /// Se lanza al crear una tarea
        /// </summary>
        event DataPersistenceChange ItemCreated;

        /// <summary>
        /// Se lanza al borrar una tarea
        /// </summary>
        event DataPersistenceChange ItemDeleted;

        /// <summary>
        /// Se lanza al actualizar una tarea
        /// </summary>
        event DataPersistenceChange ItemUpdated;

        #endregion

        /// <summary>
        /// Crea una tarea
        /// </summary>
        /// <param name="item">tarea a crear</param>
        /// <returns>Success si crea el item, Fail en otro caso</returns>
        /// <raised_event>ItemCreated</raised_event>
        Response CreateTodoItem(TodoItem item);

        /// <summary>
        /// Borra una tarea
        /// </summary>
        /// <param name="item">tarea a borrar</param>
        /// <returns>Success si borra la tarea, Fail en otro caso</returns>
        /// <raised_event>ItemDeleted</raised_event>
        Response DeleteTodoItem(int id);

        /// <summary>
        /// Lee todas las tareas
        /// </summary>
        /// <returns>Success con una lista de tareas</returns>
        Response ReadAllTodoItems();

        /// <summary>
        /// Lee una tarea
        /// </summary>
        /// <param name="id">identificador de la tarea a leer</param>
        /// <returns>Succes si la tarea existe, Fail en otro caso</returns>
        Response ReadTodoItem(int id);

        /// <summary>
        /// Actualiza una tarea
        /// </summary>
        /// <param name="item">tarea a actualizar</param>
        /// <returns>Success si actualiza la tarea, Fail en otro caso</returns>
        /// <raised_event>ItemUpdated</raised_event>
        Response UpdateTodoItem(TodoItem item);
    }
}
