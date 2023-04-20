using SAPrueba.Resources;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;



namespace SAPrueba.Areas.Participantes.Models.Jugadores
{
    [Serializable]
    public class JugadorIndexVM
    {
        public List<JugadorGridVM>? Jugadores { get; set; }
        public JugadorVM JugadorVM { get; set; } = new();
    }
}
