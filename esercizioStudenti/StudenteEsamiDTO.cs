using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizioStudenti
{
    internal class StudenteEsamiDTO
    {
        public string studenteID {  get; set; }
        public string studenteNome { get; set; }
        public string studenteCognome { get; set; } 
        public List<EsamiDTO> Esami { get; set; }
        public double? mediaVoti {  get; set; } //nullable
       

    }
}
