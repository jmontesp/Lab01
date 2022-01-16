using System;

namespace Lab01.Infrastructure.Models
{
    /// <summary>
    /// Modelo de un item
    /// </summary>
    public class TodoItem
    {
        /// <summary>
        /// Identificador
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Título
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Indicador de si la tarea se ha completado
        /// </summary>
        public bool Completed { get; set; }

        /// <summary>
        /// Fecha de vencimiento
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Duración
        /// </summary>
        public decimal Duration { get; set; }
    }
}
