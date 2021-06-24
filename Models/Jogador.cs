using E_players_mvc.interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace E_players_mvc.Models
{
    public class Jogador : EplayersBase, Ijogador
    {
        public int IdJogador { get; set; }
        public int Idequipe { get; set; }
        public string Nome { get; set; }  
        public string Email { get; set; }
        public string Senha {get; set;}

       private const string CAMINHO = "Database/jogador.csv";

        public Jogador(){
            CriarPastaEArquivo(CAMINHO);
        }

       private string PrepararLinha(Jogador j)
        {
            return $"{j.IdJogador};{j.Nome};{Idequipe};{j.Email};{j.Senha}";
        }
        public void Criar(Jogador j)
        {
            string[] linha = { PrepararLinha(j) };
            File.AppendAllLines(CAMINHO, linha);
        }

        public List<Jogador> LerTodos()
        {
             List<Jogador> jogadores = new List<Jogador>();
            
            string[] linhas = File.ReadAllLines(CAMINHO);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");

                Jogador novojogador = new Jogador();
                novojogador.IdJogador = int.Parse(linha[0]);
                novojogador.Nome = linha[1];
                novojogador.Idequipe = int.Parse(linha[2]);
                novojogador.Email = linha[3];
                novojogador.Senha = linha[4];

                jogadores.Add(novojogador);
            }
            return jogadores;
        }
        

        public void Alterar(Jogador j)
        {
            List<string> linhas =   LerTodasAsLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == j.IdJogador.ToString());
            linhas.Add( PrepararLinha(j) );                        
            ReescreverCSV(CAMINHO, linhas); 
        }

        public void Deletar(int id)
        {
             List<string> linhas =  LerTodasAsLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());                        
            ReescreverCSV(CAMINHO, linhas);
        }

    }
}