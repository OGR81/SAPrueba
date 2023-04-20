using SAPrueba.Areas.Participantes.Models.Jugador;
using SAPrueba.BL;
using SAPrueba.DA.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SAPrueba.Areas.Participantes.Controller
{
    [Area("Participantes")]
    public class JugadorController : Controller
    {
        private readonly JugadorBL jugadorBL;

        public JugadorController(JugadorBL jugadorBL)
        {
            this.jugadorBL = jugadorBL;
        } 

        public IActionResult Index()
        {
            JugadorIndexVM model = new();

            List<Jugador> jugadores = JugadorBL.ObtenerJugadores().Result;

            model.Jugadores = MapearToGrid(jugadores);

            return Wiew(model);
        }

        [HttpGet]

        public async Task<IActionResult> ObtenerJugador(string nombreJugador)
        {
            try
            {
                Jugador? jugador = await JugadorBL.ObtenerPorNombre(nombreJugador);
                JugadorVM jugadorVM = MapearJugadorToVM(jugador);

                return Json(jugadorVM);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Grabar(JugadorVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new { success = false });

                Jugador? jugador = await MapearJugadorVMToEntity(model);

                await JugadorBL.Guardar(jugador);

                return Json(new {success=true});

            }
            catch(Exception ex)
            {
                return Json(new {success=false, message= ex });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(string nombreJugador)
        {
            try
            {
                await JugadorBL.Eliminar(nombreJugador);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpGet]
        
        private async Task<Jugador> MapearJugadorVMToEntity(JugadorVM model)
        {
            Jugador? jugador = new();

            if (model.NombreJugador != 0)
            {
                jugador = await JugadorBL.ObtenerPorNombre((string)model.NombreJugador);
                
            }
            
            jugador.Nombre = model.Nombre;
            jugador.Nick = model.Nick;
            jugador.Bando = model.Bando;
            jugador.PagoAbonado = model.PagoAbonado;
            jugador.ListaEnviada = model.ListaEnviada;

            return jugador;
        }

        private static JugadorVM MapearJugadorToVM(Jugador? jugador)
        {
            JugadorVM jugadorVM = new();
            jugadorVM.NombreJugador = jugador!.NombreJugador;
            jugadorVM.Nick = jugador.Nick;
            jugadorVM.Bando = jugador.Bando;
            jugadorVM.PagoAbonado = jugador.PagoAbonado;
            jugadorVM.ListaEnviada = jugador.ListaEnviada;

            return jugadorVM;
        }

        private static List<JugadorGridVM>? MapearJugadoresToGrid(List<Jugador> jugadores)
        {
            List<JugadorGridVM> model = new();

            jugadores.ForEach(i =>
            {
                JugadorGridVM jugador = new();
                jugador.Nombre = i.NombreJugador;
                jugador.Nick = i.Nick;
                jugador.Bando = i.Bando;
                jugador.PagoAbonado = i.PagoAbonado;
                jugador.ListaEnviada = i.ListaEnviada;
                
                
                model.Add(jugador);
            });

            return model;
        }
    }
}
