using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using E_Players.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace E_Players.Controllers
{
    public class NoticiasController : Controller
    {
        Noticias noticiasModel = new Noticias();

        public IActionResult Index()
        {
            ViewBag.Noticias = noticiasModel.ReadAll();
            return View();
        }

        /// <summary>
        /// cadastra os dados do formulario
        /// </summary>
        /// <param name="form">formulario para o front</param>
        /// <returns>Redireciona para a url + noticias, indo para a pagina noticiase</returns>
        public IActionResult Cadastrar(IFormCollection form)
        {
            Noticias novaNoticias   = new Noticias();
            novaNoticias.IdNoticias = Int32.Parse(form["IdNoticias"]);
            novaNoticias.Titulo     = form["Titulo"];
            novaNoticias.Texto     = form["Texto"];

            //Upload de imagem
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
                novaNoticias.Imagem   = file.FileName;
            }
            else
            {
                novaNoticias.Imagem   = "padrao.png";
            }
            //final do upload

            noticiasModel.Create(novaNoticias);            
            ViewBag.Noticias = noticiasModel.ReadAll();

            return LocalRedirect("~/Noticias");
        }  

        [Route("Noticias/{id}")]
        public IActionResult Excluir(int id){
            noticiasModel.Delete(id);
            return LocalRedirect("~/Noticias");
        } 
    }
}