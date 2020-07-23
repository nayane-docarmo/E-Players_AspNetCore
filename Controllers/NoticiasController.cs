using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using E_Players_AspNetCore.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

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
           
            /// <summary>
          /// Puxar imagem dos arquivos do computador
          /// </summary>
            var file    = form.Files[0];
            var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Noticias");

            if(file != null)
            {
                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);  
                }
                novaNoticia.Imagem   = file.FileName;
            }
            else
            {
                novaNoticia.Imagem   = "padrao.png";
            }
            // Upload Final

            noticiasModel.Create(novaNoticia);            
            ViewBag.Noticias = noticiasModel.ReadAll();

            return LocalRedirect("~/Noticias");
        }
 /// <summary>
/// excluir imagens 
/// </summary>
/// <param name="IdNoticias"></param>
/// <returns>Apagar Arquivos/Notcias</returns>

          [Route("[controller]/{idn}")]
          public IActionResult Excluir(int idn)
        {
            noticiasModel.Delete(idn);
            ViewBag.Noticias = noticiasModel.ReadAll();
            return LocalRedirect("~/Noticias");
        }
    }
}