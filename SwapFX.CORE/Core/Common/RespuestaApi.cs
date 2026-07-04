namespace SwapFX.CORE.Core.Common;
public class RespuestaApi<T>
{
    public bool Exito { get; set; }
    public string? Mensaje { get; set; }
    public T? Datos { get; set; }
    public string? CodigoError { get; set; }

    public static RespuestaApi<T> Ok(T datos, string mensaje = "Operación exitosa")
        => new() { Exito = true, Mensaje = mensaje, Datos = datos };

    public static RespuestaApi<T> Error(string mensaje, string codigo = "ERROR")
        => new() { Exito = false, Mensaje = mensaje, CodigoError = codigo };
}
