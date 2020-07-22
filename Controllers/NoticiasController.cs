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
        Noticias noticiaModel = new Noticias();

         public IActionResult Index()
        {
            ViewBag.Noticias = noticiaModel.ReadAll();
            return View();
        }
        public IActionResult Adicionar_Noticia(IFormCollection form)
        {
           Noticias novaNoticia   = new Noticias();
            novaNoticia.IdNoticias = Int32.Parse(form["IdNoticia"]);
            novaNoticia.Titulo  = form["Tittulo"];
            novaNoticia.Texto = form["Texto"];
            novaNoticia.Imagem   = form["Imagem"];

            noticiaModel.Create(novaNoticia);            
            ViewBag.Equipes = noticiaModel.ReadAll();

            return LocalRedirect("~/Equipe");
        }
    }
}