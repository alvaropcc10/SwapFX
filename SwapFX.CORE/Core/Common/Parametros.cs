namespace SwapFX.CORE.Core.Common;
public static class Parametros
{
    public const decimal MontoMinimoUSD = 20m;
    public const decimal MontoMinimoEUR = 20m;
    public const decimal MontoMinimoPEN = 50m;
    public const decimal MontoMaximoSinVerificacion = 1000m;
    public const decimal MontoMaximoConVerificacion = 10000m;
    public const double HorasPagoTransaccion = 24;
    public const double HorasConfirmacionPago = 48;
    public const double HorasAceptacionTransaccion = 1;
    public const decimal ToleranciaMatchingPorcentaje = 0.5m;
    public const int MaxOfertasActivas = 5;

    public static class EstadosOferta
    {
        public const string Publicada = "PUBLICADA";
        public const string Emparejada = "EMPAREJADA";
        public const string EnProceso = "EN_PROCESO";
        public const string Agotada = "AGOTADA";
        public const string Expirada = "EXPIRADA";
        public const string Eliminada = "ELIMINADA";
    }

    public static class EstadosTransaccion
    {
        public const string Iniciada = "INICIADA";
        public const string PendientePago = "PENDIENTE_PAGO";
        public const string PagoReportado = "PAGO_REPORTADO";
        public const string PagoConfirmado = "PAGO_CONFIRMADO";
        public const string Finalizada = "FINALIZADA";
        public const string Cancelada = "CANCELADA";
        public const string EnDisputa = "EN_DISPUTA";
        public const string Resuelta = "RESUELTA";
    }

    public static class Roles
    {
        public const string Admin = "A";
        public const string Usuario = "U";
    }
}
