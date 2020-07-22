using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using E_Players_AspNetCore.Models;
using Microsoft.AspNetCore.Http;

namespace E_Players_AspNetCore.Controllers
{
    public class NoticiasController : Controller
    {
        Noticias noticiasModel = new Noticias();

         public IActionResult Index()
        {
            ViewBag.Noticias = noticiasModel.ReadAll();
            return View();
        }
        public IActionResult Adicionar (IFormCollection form)
        {
            Noticias novaNoticia   = new Noticias();
            novaNoticia.IdNoticias = Int32.Parse(form["IdNoticias"]);
            novaNoticia.Titulo  = form["Titulo"];
            novaNoticia.Texto = form["Texto"];
            novaNoticia.Imagem   = form["Imagem"];

            noticiasModel.Create(novaNoticia);            
            ViewBag.Noticias = noticiasModel.ReadAll();

            return LocalRedirect("~/Noticias");
        }
    }
}