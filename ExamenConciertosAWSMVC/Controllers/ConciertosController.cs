using ExamenConciertosAWSMVC.Models;
using ExamenConciertosAWSMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExamenConciertosAWSMVC.Controllers
{
    public class ConciertosController : Controller
    {
        private ServiceApiConciertos service;

        public ConciertosController(ServiceApiConciertos service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<Evento> eventos = await this.service.GetEventosAsync();
            return View(eventos);
        }

        public async Task<IActionResult> Categorias()
        {
            List<Categoria> categorias = await this.service.GetCategoriasAsync();
            return View(categorias);
        }

        public async Task<IActionResult> GetEventosCategorias(int idcategoria)
        {
            List<Evento> eventosCategorias = await this.service.GetEventoAsync(idcategoria);
            return View(eventosCategorias);
        }
    }
}
