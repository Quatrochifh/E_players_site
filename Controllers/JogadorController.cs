using System;
using E_players_mvc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_players_mvc.Controllers
{
     [Route("Jogador")]
    public class JogadorController : Controller
    {
         Jogador jogadorModel = new Jogador();

         [Route("Listar")]
          public IActionResult Index(){
            ViewBag.Jogadores = jogadorModel.LerTodos();
            return View();
        }

        [Route("Cadastrar")]
            public IActionResult Cadastrar(IFormCollection form)
        {
            Jogador novoJogador = new Jogador();
            novoJogador.IdJogador = Int32.Parse(form["IdJogador"]);
            novoJogador.Idequipe  = Int32.Parse(form["Idequipe"]);
            novoJogador.Nome  = form["Nome"];
            novoJogador.Email  = form["Email"];
            novoJogador.Senha  = form["Senha"];

            jogadorModel.Criar(novoJogador);            
            ViewBag.Jogadores = jogadorModel.LerTodos();

            return LocalRedirect("~/Jogador/Listar");
        }
    [Route("Excluir/{id}")]
        public IActionResult Excluir(int id){
            jogadorModel.Deletar(id);
            ViewBag.Equipes = jogadorModel.LerTodos();
            return LocalRedirect("~/Jogador/Listar");
        }

    }
}