using SAPrueba.Resources;
using System.ComponentModel.DataAnnotations;

namespace SAPrueba.Areas.Torneo.Models.Puntuaciones
{
    [Serializable]
    public class PuntuacionVM
    {
        
        [Display(Name = nameof(JugadorStrings.NombreJugador), ResourceType = typeof(JugadorStrings))]
        public List<SelectListItem>? NombreJugador { get; set; }

        [Display(Name = nameof(PuntuacionStrings.PtoPartida), ResourceType = typeof(PuntuacionStrings))]
        public List<SelectListItem>? PtoPartida { get; set; }

        [Display(Name = nameof(PuntuacionStrings.PtoConseguido), ResourceType = typeof(PuntuacionStrings))]
        public List<SelectListItem>? PtoConseguido { get; set; }

        [Display(Name = nameof(PuntuacionStrings.PtoCedido), ResourceType = typeof(PuntuacionStrings))]
        public List<SelectListItem>? PtoCedido { get; set; }

        [Display(Name = nameof(PuntuacionStrings.DiferenciaPto), ResourceType = typeof(PuntuacionStrings))]
        public List<SelectListItem>? DiferenciaPto { get; set; }

        [Display(Name = nameof(PuntuacionStrings.LiderAbatido), ResourceType = typeof(PuntuacionStrings))]
        public List<SelectListItem>? LiderAbatido { get; set; }
    }
}
