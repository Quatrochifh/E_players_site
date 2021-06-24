using System.Collections.Generic;
using E_players_mvc.Models;

namespace E_players_mvc.interfaces
{
    public interface Iequipe
    {
        //cadastrar
        void Criar(Equipe e);

        List<Equipe> LerTodas(); //ler todas as linhas

        void Alterar(Equipe e); //atualizar algo

        void Deletar(int id);
    }
}