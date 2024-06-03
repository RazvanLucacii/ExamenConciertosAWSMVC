using ExamenConciertosAWSMVC.Models;
using ExamenConciertosAWSMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExamenConciertosAWSMVC.Controllers
{
    public class ConciertosController : Controller
    {
        private ServiceApiConciertos service;
        private ServiceStorageAWS serviceStorage;

        public ConciertosController(ServiceApiConciertos service, ServiceStorageAWS serviceStorage)
        {
            this.service = service;
            this.serviceStorage = serviceStorage;
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
