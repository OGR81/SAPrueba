using SAPrueba.Areas.Torneo.Models.Puntuacion;
using SAPrueba.BL;
using SAPrueba.DA.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SAPrueba.Areas.Torneo.Controller
{
    [Area("Torneo")]
    public class PuntuacionController : Controller
    {
        private readonly PuntuacionBL puntuacionBL;

        public PuntuacionController(PuntuacionBL puntuacionBL)
        {
            this.puntuacionBL = puntuacionBL;
        }

        public IActionResult Index()
        {
            PuntuacionIndexVM model = new();

            List<Puntuacion> puntuaciones = PuntuacionBL.ObtenerPuntuaciones().Result;

            model.Puntuaciones = MapearToGrid(puntuaciones);

            return Wiew(model);
        }

        [HttpGet]

        public async Task<IActionResult> ObtenerPuntuacion(int valorPuntuacion)
        {
            try
            {
                Puntuacion? puntuacion = await PuntuacionBL.ObtenerPorValor(valorPuntuacion);
                PuntuacionVM puntuacionVM = MapearPuntuacionToVM(puntuacion);

                return Json(puntuacionVM);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Grabar(PuntuacionVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new { success = false });

                Puntuacion? puntuacion = await MapearPuntuacionVMToEntity(model);

                await PuntuacionBL.Guardar(puntuacion);

                return Json(new { success = true });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(string valorPuntuacion)
        {
            try
            {
                await PuntuacionBL.Eliminar(valorPuntuacion);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpGet]

        private async Task<Puntuacion> MapearPuntuacionVMToEntity(PuntuacionVM model)
        {
            Puntuacion? puntuacion = new();

            if (model.ValorPuntuacion != 0)
            {
                puntuacion = await PuntuacionBL.ObtenerPorValor((int)model.ValorPuntuacion);

            }

            puntuacion.PtoPartida = model.PtoPartida;
            puntuacion.PtoConseguido = model.PtoConseguido;
            puntuacion.PtoCedido = model.PtoCedido;
            puntuacion.DiferenciaPto = model.DiferenciaPto;
            puntuacion.LiderAbatido = model.LiderAbatido;
            puntuacion.NumeroPartida = model.NumeroPartida;

            return puntuacion;
        }

        private static PuntuacionVM MapearPuntuacionToVM(Puntuacion? puntuacion)
        {
            PuntuacionVM puntuacionVM = new();
            puntuacionVM.PtoPartida = puntuacion.PtoPartida;
            puntuacionVM.PtoConseguido = puntuacion.PtoConseguido;
            puntuacionVM.PtoCedido = puntuacion.PtoCedido;
            puntuacionVM.DiferenciaPto = puntuacion.DiferenciaPto;
            puntuacionVM.LiderAbatido = puntuacion.LiderAbatido;
            puntuacionVM.NumeroPartida = puntuacion.NumeroPartida;

            return puntuacionVM;
        }

        private static List<PuntuacionGridVM>? MapearPuntuacionesToGrid(List<Puntuacion> puntuaciones)
        {
            List<PuntuacionGridVM> model = new();

            puntuaciones.ForEach(i =>
            {
                PuntuacionGridVM puntuacion = new();
                puntuacion.PtoPartida = i.PtoPartida;
                puntuacion.PtoConseguido = i.PtoConseguido;
                puntuacion.PtoCedido = i.PtoCedido;
                puntuacion.DiferenciaPto = i.DiferenciaPto;
                puntuacion.LiderAbatido = i.LiderAbatido;
                puntuacion.NumeroPartida = i.NumeroPartida;

                model.Add(puntuacion);
            });

            return model;
        }
    }
}
