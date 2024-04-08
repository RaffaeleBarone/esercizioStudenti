using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizioStudenti
{
    internal class Esame
    {
        public int studenteID {  get; set; }
        public string materia {  get; set; }
        public DateTime data { get; set; }
        public int voto { get; set; }

        public Esame(int studenteID, string materia, DateTime data, int voto)
        {
            this.studenteID = studenteID;
            this.materia = materia;
            this.data = data;
            this.voto = voto;
        }

        public Esame()
        {
        }

        public Esame(string? materia, DateTime data, int voto)
        {
            this.materia = materia;
            this.data = data;
            this.voto = voto;
        }

        public override string ToString()
        {
            return $"Materia: {materia}, Data: {data}, Voto: {voto}";
        }
    }
}
