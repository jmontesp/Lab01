using Lab01.Infrastructure.DataStructures;

/// <summary>
/// Delegado que define la firma de los eventos de persistencia de datos
/// </summary>
/// <param name="response">respuesta</param>

public delegate void DataPersistenceChange(Response response);