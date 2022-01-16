namespace Lab01.Infrastructure.DataStructures
{
    /// <summary>
    /// Definición de una respuesta fallida
    /// </summary>
    public class Fail : Response
    {
        #region Constructor

        /// <summary>
        /// Preestablece fallo
        /// </summary>
        public Fail()
        {
            this.Success = false;
        }

        #endregion
    }
}
