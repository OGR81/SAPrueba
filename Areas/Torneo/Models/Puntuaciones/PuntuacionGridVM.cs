using SAPrueba.Resources;
using System.ComponentModel.DataAnnotations;


namespace SAPrueba.Areas.Torneo.Models.Puntuaciones
{
    [Serializable]
    public class PuntuacionGridVM
    {
        [Display(Name = nameof(PuntuacionStrings.PtoPartida), ResourceType = typeof(PuntuacionStrings))]
        public int PtoPartida { get; set; }

        [Display(Name = nameof(PuntuacionStrings.PtoConseguido), ResourceType = typeof(PuntuacionStrings))]
        public int PtoConseguido { get; set; }
        
        [Display(Name = nameof(PuntuacionStrings.PtoCedido), ResourceType = typeof(PuntuacionStrings))]
        public int PtoCedido { get; set; }
        
        [Display(Name = nameof(PuntuacionStrings.DiferenciaPto), ResourceType = typeof(PuntuacionStrings))]
        public int DiferenciaPto { get; set; }

        [Display(Name = nameof(PuntuacionStrings.LiderAbatido), ResourceType = typeof(PuntuacionStrings))]
        public int LiderAbatidoo { get; set; }
        
        [Display(Name = nameof(PuntuacionStrings.Opciones), ResourceType = typeof(PuntuacionStrings))]
        public string? Opciones { get; set; }

    }
}
