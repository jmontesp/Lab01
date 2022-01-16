namespace Lab01.Infrastructure.DataStructures
{
    /// <summary>
    /// Definición de una respuesta exitosa
    /// </summary>
    public class Success : Response
    {
        /// <summary>
        /// Preestablece éxito
        /// </summary>
        public Success()
        {
            this.Success = true;
        }
    }
}
