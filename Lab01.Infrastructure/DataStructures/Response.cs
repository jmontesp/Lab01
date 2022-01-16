namespace Lab01.Infrastructure.DataStructures
{
    /// <summary>
    /// Definición de una respuesta
    /// </summary>
    public class Response
    {
        #region Properties
        
        /// <summary>
        /// Indicador de éxito/fallo
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Mensaje en caso de fallo
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Resultado en caso de éxito
        /// </summary>
        public object Result { get; set; }
        
        #endregion
    }
}
