using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizioStudenti
{
    internal class Esame
    {
        public string studenteID {  get; set; }
        public string materia {  get; set; }
        public DateTime data { get; set; }
        public int voto { get; set; }

  

        public override string ToString()
        {
            return $"Materia: {materia}, Data: {data}, Voto: {voto}";
        }
    }
}
