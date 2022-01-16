using Lab01.Infrastructure.DataStructures;
using Lab01.Infrastructure.Interfaces;
using Lab01.Infrastructure.Models;
using System;
using System.Linq;
using ErrorMsg = Lab01.Infrastructure.Resources.ErrorMsg;

namespace Lab01.DataPersistance
{
    /// <summary>
    /// Implementación de ITodoItem
    /// </summary>
    public partial class DataProvider : ITodoItem
    {
        #region ITodoItem

        public event DataPersistenceChange ItemCreated;
        public event DataPersistenceChange ItemDeleted;
        public event DataPersistenceChange ItemUpdated;

        public Response CreateTodoItem(TodoItem item)
        {

            Response response = null;
            try
            {
                int nextId = this.TodoItems.Count() == 0 ? 1:  this.TodoItems.Max(t => t.Id) + 1;
                item.Id = nextId;
                this.TodoItems.Add(item);
                response = new Response { Result =  SaveChanges() };
                if ((int)response.Result == 1)
                {
                    response.Result = true;
                    if (ItemCreated != null) ItemCreated(response);
                }
                else
                {
                    response.Result = false;
                    response.Message = ErrorMsg.CannotCreateItem;
                }

            }
            catch (Exception ex) { return new Fail { Message = ex.Message }; }
            return response;

        }

        public Response DeleteTodoItem(int id)
        {
            Response response = null;
            try
            {
                var todoItem = this.TodoItems.FirstOrDefault(x => x.Id == id);
                if (todoItem != null)
                {
                    this.TodoItems.Remove(todoItem);
                    response = new Response { Result = SaveChanges() };
                    if ((int)response.Result == 1)
                    {
                        response.Result = true;
                        if (ItemDeleted != null) ItemDeleted(response);
                    }
                    else
                    {
                        response.Result = false;
                        response.Message = ErrorMsg.CannotDeleteItem;
                    }
                }
                else { return new Fail { Message = ErrorMsg.CannotDeleteItem }; }

            }
            catch (Exception ex) { return new Fail { Message = ex.Message }; }
            return response;
        }

        public Response ReadAllTodoItems()
        {
            try
            {
                return new Success { Result = TodoItems.ToList<TodoItem>() };
            }
            catch (Exception ex) { return new Fail { Message = ex.Message }; }
        }

        public Response ReadTodoItem(int id)
        {
            try
            {
                TodoItem record = this.TodoItems.Find(id);
                if (record == null)
                {
                    return new Fail { Message = $"TodoItem {id} not found" };
                }
                return new Success { Result = record };
            }
            catch (Exception ex) { return new Fail { Message = ex.Message }; }
        }

        public Response UpdateTodoItem(TodoItem item)
        {
            Response response = null;
            try
            {
                TodoItem record = this.TodoItems.Find(item.Id);
                if (record != null)
                {
                    record.Title = item.Title;
                    record.DueDate = item.DueDate;
                    record.Duration = item.Duration;
                    record.Completed = item.Completed;
                    this.TodoItems.Update(record);
                    response = new Response { Result = SaveChanges() };
                    if ((int)response.Result == 1)
                    {
                        response.Result = true;
                        if (ItemUpdated != null) ItemUpdated(response);
                    }
                    else
                    {
                        response.Result = false;
                        response.Message = ErrorMsg.CannotUpdateItem;
                    }
                }
                else
                {
                    response.Message = ErrorMsg.CannotUpdateItem;
                }
            }
            catch (Exception ex) { return new Fail { Message = ex.Message }; }
            return response;
        }

        #endregion
    }
}
