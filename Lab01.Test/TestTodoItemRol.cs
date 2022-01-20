using Lab01.Infrastructure.DataStructures;
using Lab01.Infrastructure.Models;
using Lib01.TodoItemRol;
using System;
using System.Collections.Generic;


namespace Lab01.Test
{
    internal partial class Program
    {
        #region TestTodoItemRol

        private static List<TodoItemRolTest> tests = new List<TodoItemRolTest>
        {
            new TodoItemRolTest
            {
                MethodToTest = "DeleteTodoItem",
                Description ="Borrar un registro en una base de datos vacía",
                Params = new TodoItem { Id = 1 },
                Expected = false
            },
            new TodoItemRolTest
            {
                MethodToTest = "CreateTodoItem",
                Description ="Inserta un registro en una base de datos vacía",
                Params = new TodoItem { Id = 1, Title = "todo", DueDate = new DateTime(2022, 6, 30), Duration = 1, Completed = false },
                Expected = false
            },
            new TodoItemRolTest
            {
                MethodToTest = "CreateTodoItem",
                Description ="Inserta un registro en una base de datos con datos",
                Params = new TodoItem { Id = 1, Title = "todo 2", DueDate = new DateTime(2022, 6, 30), Duration = 1, Completed = false },
                Expected = false
            },
            new TodoItemRolTest
            {
                MethodToTest = "CreateTodoItem",
                Description ="Inserta un registro en una base de datos con datos",
                Params = new TodoItem { Id = 1, Title = "todo 3", DueDate = new DateTime(2022, 6, 30), Duration = 1, Completed = false },
                Expected = false
            },
            new TodoItemRolTest
            {
                MethodToTest = "DeleteTodoItem",
                Description ="Borrar un registro en una base de datos con datos",
                Params = new TodoItem { Id = 2 },
                Expected = false
            },
            new TodoItemRolTest
            {
                MethodToTest = "GetTodoItems",
                Description ="Obtener las tareas creadas",
                Expected = true
            },
            new TodoItemRolTest
            {
                MethodToTest = "UpdateTodoItem",
                Description ="Intenta actualizar un registro nulo",
                Params = null,
                Expected = false
            },
            new TodoItemRolTest
            {
                MethodToTest = "UpdateTodoItem",
                Description ="Intenta actualizar un registro con datos erróneos",
                Params = new TodoItem{ Id = -1, Duration = -1},
                Expected = false
            },
            new TodoItemRolTest
            {
                MethodToTest = "UpdateTodoItem",
                Description ="Intenta actualizar un registro con datos erróneos",
                Params = new TodoItem{ Duration = 10},
                Expected = false
            },
            new TodoItemRolTest
            {
                MethodToTest = "UpdateTodoItem",
                Description ="Intenta actualizar un registro con datos correctos",
                Params = new TodoItem { Id = 3, Title = "todo 3 modificado", DueDate = new DateTime(2022, 6, 30), Duration = 1, Completed = false },
                Expected = false
            },
            new TodoItemRolTest
            {
                MethodToTest = "GetTodoItems",
                Description ="Obtener las tareas creadas",
                Expected = true
            },
            new TodoItemRolTest
            {
                MethodToTest = "CreateTodoItem",
                Description ="Excede las horas permitidas para un día",
                Params = new TodoItem { Id = 1, Title = "todo 10", DueDate = new DateTime(2022, 6, 30), Duration = 7, Completed = false },
                Expected = false
            },
        };
        private static void TestTodoItemRol()
        {
            Console.WriteLine("Comienzo de los test");
            int counter = 0;
            int successful = 0;
            var rol = ManageTodoItems.Instance;
            rol.TimeExceeded += Program.OnTimeExceeded;

            Response response = null;
            foreach (var test in tests)
            {
                counter++;
                switch (test.MethodToTest)
                {
                    case "DeleteTodoItem":
                        response = rol.DeleteTodoItem(test.Params.Id);
                        break;
                    case "CreateTodoItem":
                        response = rol.CreateTodoItem(test.Params);
                        break;
                    case "GetTodoItems":
                        response = rol.GetTodoItems();
                        foreach(var t in (List<TodoItem>)response.Result)
                        {
                            Console.WriteLine($"\t\t{t.Id}, {t.Title}, {t.DueDate}, {t.Duration}, {t.Completed}");
                        }
                        break;
                    case "UpdateTodoItem":
                        response = rol.UpdateTodoItem(test.Params);
                        break;
                }
                if (response.Success == test.Expected) successful++;
                Console.WriteLine($"\n\t{counter}, {test.Description}, correcto = {response.Success == test.Expected}, mensaje = {response.Message}");
            }
            Console.WriteLine($"\nFin de los test, {counter} tests realizados, {successful} correctos");
        }

        private static void OnTimeExceeded(Response args)
        {
            Console.WriteLine(args.Message);
        }
        #endregion
    }
}
