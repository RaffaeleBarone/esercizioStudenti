using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizioStudenti
{
    internal class Studente
    {
        public int id {  get; set; }
        public string nome { get; set; }
        public string cognome { get; set; }
        public int eta { get; set; }
        public double mediaVoti { get; set; }

        public Studente(int id, string nome, string cognome, int eta, double mediaVoti)
        {
            this.id = id;
            this.nome = nome;
            this.cognome = cognome;
            this.eta = eta;
            this.mediaVoti = mediaVoti;
        }
    }
}
