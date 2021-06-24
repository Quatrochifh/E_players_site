using System;

namespace E_players_mvc.Models
{
    public class Partida
    {
        public int Idpartida { get; set; }
        public int Idjogador1 { get; set; }
        public int Idjogador2 { get; set; }
        public DateTime HoraInicio{ get; set; }
        public DateTime HoraTermino{ get; set; }
    }
}