using System.Collections.Generic;
using E_players_mvc.Models;

namespace E_players_mvc.interfaces
{
    public interface Ijogador
    {
        void Criar(Jogador j);

        List<Jogador> LerTodos(); //ler todas as linhas

        void Alterar(Jogador j); //atualizar algo

        void Deletar(int id);
    }
}