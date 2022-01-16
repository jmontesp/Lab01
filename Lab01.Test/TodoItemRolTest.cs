using Lab01.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab01.Test
{
    internal class TodoItemRolTest
    {
        public string MethodToTest { get; set; }

        public string Description { get; set; }

        public TodoItem Params { get; set; }

        public bool Expected { get; set; }
    }
}
