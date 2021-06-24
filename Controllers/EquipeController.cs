using System;
using System.IO;
using E_players_mvc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//Folder = Pasta
//Path = Caminho
//File = Arquivo
namespace E_players_mvc.Controllers
{
    [Route("Equipe")]
    public class EquipeController : Controller
    {
        Equipe equipeModels = new Equipe();

        [Route("Listar")]
        public IActionResult Index(){

            ViewBag.Equipes = equipeModels.LerTodas();
            return View();
        }

        [Route("Cadastrar")]
         public IActionResult Cadastrar(IFormCollection form){
            Equipe novaEquipe = new Equipe();
            novaEquipe.Idequipe = Int32.Parse(form["Idequipe"]);
            novaEquipe.Nome = form["Nome"];
            // novaEquipe.Imagem = form["Idequipe"];

            //imagem
            if(form.Files.Count > 0)
            {
                // Upload Início
                var file    = form.Files[0];
                var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");

                if(!Directory.Exists(folder))
                {
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

            equipeModels.Criar(novaEquipe);
            
            ViewBag.Equipes = equipeModels.LerTodas();
            return LocalRedirect("~/Equipe/Listar");
        }

        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id){
            equipeModels.Deletar(id);
            ViewBag.Equipes = equipeModels.LerTodas();
            return LocalRedirect("~/Equipe/Listar");
        }
    }
}