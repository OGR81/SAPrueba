using SAPrueba.Resources;
using System.ComponentModel.DataAnnotations;


namespace SAPrueba.Areas.Participantes.Models.Jugadores
{
    [Serializable]
    public class JugadorGridVM
    {
        [Display(Name = nameof(JugadorStrings.NombreGrid), ResourceType = typeof(JugadorStrings))]
        public string? Nombre { get; set; }

        [Display(Name = nameof(JugadorStrings.NickGrid), ResourceType = typeof(JugadorStrings))]
        public string? Nick { get; set; }

        [Display(Name = nameof(JugadorStrings.BandoGrid), ResourceType = typeof(JugadorStrings))]
        public string? Bando { get; set; }

        [Display(Name = nameof(JugadorStrings.PagoAbonadoGrid), ResourceType = typeof(JugadorStrings))]
        public string? PagoAbonado { get; set; }

        [Display(Name = nameof(JugadorStrings.ListaEnviadaGrid), ResourceType = typeof(JugadorStrings))]
        public string? ListaEnviada { get; set; }

        [Display(Name = nameof(JugadorStrings.Opciones), ResourceType = typeof(JugadorStrings))]
        public string? Opciones { get; set; }

    }
    
}
