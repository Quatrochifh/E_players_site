using System;
using System.Collections.Generic;
using System.IO;
using E_players_mvc.interfaces;

namespace E_players_mvc.Models
{
    public class Equipe : EplayersBase, Iequipe
    {
        public int Idequipe { get; set; }       
        public string Nome { get; set; }
        public string Imagem { get; set; }
        private const string CAMINHO = "Database/equipe.csv"; // CSV é um ARQUIVO de texto
//-------------------

        public Equipe(){
            CriarPastaEArquivo(CAMINHO);
        }
        private string Preparar(Equipe e){
            
            return $@"{e.Idequipe};{e.Nome};{e.Imagem}";
        }

        public void Criar(Equipe e)
        {
            string[] linha = {Preparar(e)};
            File.AppendAllLines(CAMINHO,linha);
        }
        public void Alterar(Equipe e)
        {
            List<string> linhas = LerTodasAsLinhasCSV(CAMINHO); 
             //1;Nome da equipe;Caminho da imagem
             //X significa Cada item
            linhas.RemoveAll(x => x.Split(";")[0] == e.Idequipe.ToString());
            linhas.Add(Preparar(e));
            ReescreverCSV(CAMINHO, linhas);
        }

        public void Deletar(int id)
        {
            List<string> linhas = LerTodasAsLinhasCSV(CAMINHO); 
             //1;Nome da equipe;Caminho da imagem
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            ReescreverCSV(CAMINHO, linhas);
        }

        public List<Equipe> LerTodas()
        {
            List<Equipe> equipes = new List<Equipe>();

            //1;Nome da equipe;Caminho da imagem
            string[] linhas = File.ReadAllLines(CAMINHO);

            foreach (var item in linhas)
            {
                //1;
                //Nome da equipe;
                //Caminho da imagem
                string[] linha = item.Split(";");

                Equipe equipe = new Equipe();
                equipe.Idequipe = Int32.Parse(linha[0]);
                equipe.Nome = linha[1];
                equipe.Imagem = linha[2];

                equipes.Add(equipe);
            }
            return equipes;
        }
    }
}