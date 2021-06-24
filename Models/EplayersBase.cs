using System.Collections.Generic;
using System.IO;

namespace E_players_mvc.Models
{
    public class EplayersBase
    {
        public void CriarPastaEArquivo(string _caminho){

            string pasta = _caminho.Split("/")[0];
            string arquivo = _caminho.Split("/")[1];

            if (!Directory.Exists(pasta)) //criar a pasta 
            {
                Directory.CreateDirectory(pasta);
            }

            if (!File.Exists(_caminho)) //criar o arquivo 
            {
                File.Create(_caminho).Close();
            }
        }

        public List<string> LerTodasAsLinhasCSV(string _caminho){
            List<string> linhas = new List<string>();

            using (StreamReader file = new StreamReader(_caminho))
            {
               string linha;
               while((linha = file.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }
            return linhas;
        }
        public void ReescreverCSV(string CAMINHO, List<string> linhas)
        {
            using(StreamWriter output = new StreamWriter(CAMINHO))
            {
                foreach (var item in linhas)
                {
                    output.Write(item + "\n");
                }
            }
        }
    }
}