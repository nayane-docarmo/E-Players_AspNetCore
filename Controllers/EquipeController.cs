using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using E_Players_AspNetCore.Models;
using System.IO;

namespace E_Players_AspNetCore.Controllers
{
    public class EquipeController : Controller
    {
        /// <summary>
        /// listar as equipes no formulario 
        /// </summary>
        /// <returns>Lista de equipes em form</returns>
        Equipe equipeModel = new Equipe();

         public IActionResult Index()
        {
            ViewBag.Equipes = equipeModel.ReadAll();
            return View();
        }
        public IActionResult Cadastrar(IFormCollection form)
        {
            Equipe novaEquipe   = new Equipe();
            novaEquipe.IdEquipe = Int32.Parse(form["IdEquipe"]);
            novaEquipe.Nome     = form["Nome"];
           
          /// <summary>
          /// Puxar imagem dos arquivos do computador
          /// </summary>
            var file    = form.Files[0];
            var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");

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
                novaEquipe.Imagem   = file.FileName;
            }
            else
            {
                novaEquipe.Imagem   = "padrao.png";
            }
            // Upload Final

            equipeModel.Create(novaEquipe);            
            ViewBag.Equipes = equipeModel.ReadAll();

            return LocalRedirect("~/Equipe");
        }
/// <summary>
/// excluir imagens 
/// </summary>
/// <param name="IdEquipe"></param>
/// <returns>Apagar Arquivos/Equipe</returns>

          [Route("[controller]/{ide}")]
          public IActionResult Excluir(int ide)
        {
            equipeModel.Delete(ide);
            ViewBag.Equipes = equipeModel.ReadAll();
            return LocalRedirect("~/Equipe");
        }
    }
}
