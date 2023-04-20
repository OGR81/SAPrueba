using SAPrueba.Resources;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace SAPrueba.Areas.Torneo.Models.Puntuaciones
{
    [Serializable]
    public class PuntuacionIndexVM
    {
        public List<PuntuacionGridVM>? Puntuaciones { get; set; }
        public PuntuacionVM PuntuacionVM { get; set; } = new();
    }
}
