using SAPrueba.Resources;
using System.ComponentModel.DataAnnotations;



namespace SAPrueba.Areas.Participantes.Models.Jugadores
{
    [Serializable]
    public class JugadorVM
    {
        public string? NombreJugador { get; set; }

        [Display(Name = nameof(JugadorStrings.NombreJugador), ResourceType = typeof(JugadorStrings))]
        [Required(ErrorMessageResourceName = nameof(JugadorStrings.ErrorNombreObligatorio), ErrorMessageResourceType = typeof(JugadorStrings))]
        [MaxLength(200, ErrorMessageResourceName = nameof(JugadorStrings.ErrorLongitudNombre), ErrorMessageResourceType = typeof(JugadorStrings))]
        public string? Nombre { get; set; }

        [Display(Name = nameof(JugadorStrings.Nick), ResourceType = typeof(JugadorStrings))]
        [Required(ErrorMessageResourceName = nameof(JugadorStrings.ErrorNickObligatorio), ErrorMessageResourceType = typeof(JugadorStrings))]
        [MaxLength(200, ErrorMessageResourceName = nameof(JugadorStrings.ErrorLongitudNick), ErrorMessageResourceType = typeof(JugadorStrings))]
        public string? Nick { get; set; }

        [Display(Name = nameof(JugadorStrings.Bando), ResourceType = typeof(JugadorStrings))]
        [Required(ErrorMessageResourceName = nameof(JugadorStrings.ErrorBandoObligatorio), ErrorMessageResourceType = typeof(JugadorStrings))]
        public List<SelectListItem>? Bando { get; set; }

        [Display(Name = nameof(JugadorStrings.PagoAbonado), ResourceType = typeof(JugadorStrings))]
        [Required(ErrorMessageResourceName = nameof(JugadorStrings.ErrorBandoObligatorio), ErrorMessageResourceType = typeof(JugadorStrings))]
        public List<SelectListItem>? PagoAbonado { get; set; }

        [Display(Name = nameof(JugadorStrings.ListaEnviada), ResourceType = typeof(JugadorStrings))]
        [Required(ErrorMessageResourceName = nameof(JugadorStrings.ErrorListaEnviadaObligatorio), ErrorMessageResourceType = typeof(JugadorStrings))]
        public List<SelectListItem>? ListaEnviada { get; set; }
    }
}
