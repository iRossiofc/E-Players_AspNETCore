using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using E_Players.Models;
using Microsoft.AspNetCore.Http;

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
            novaNoticias.Imagem   = form["Imagem"];

            noticiasModel.Create(novaNoticias);            
            ViewBag.Noticias = noticiasModel.ReadAll();

            return LocalRedirect("~/Noticias");
        }   
    }
}