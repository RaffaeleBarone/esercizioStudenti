using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        public List<Esame> Esami { get; set; }


        public Studente(int id, string nome, string cognome, int eta, double mediaVoti)
        {
            this.id = id;
            this.nome = nome;
            this.cognome = cognome;
            this.eta = eta;
            this.mediaVoti = mediaVoti;
        }

        public Studente()
        {
        }

        public static List<Esame> GetEsami(List<Esame> listaEsami)
        {
           Esame esame = new Esame();
            return listaEsami; ;
        }

        public void AggiungiEsame(int studenteID, int index, string materia, DateTime data, int voto)
        {
            Esame esame = new Esame(studenteID, materia, data, voto);
            Esami.Add(esame);                  
        }

        public void ModificaEsame(string nuovaMateria, DateTime nuovaData, int nuovoVoto)
        {
            Console.WriteLine("Inserire l'indice dell'esame da modificare:");
            int index = int.Parse(Console.ReadLine());
            Esami[index].materia = nuovaMateria;
            Esami[index].data = nuovaData;
            Esami[index].voto = nuovoVoto;
        }

        public void RimuoviEsame()
        {
            Console.WriteLine("Inserire l'indice dell'esame da rimuovere:");
            int index = int.Parse(Console.ReadLine());

            if (index >= 0 && index < Esami.Count)
            {
                Esami.RemoveAt(index);
            }
            else
            {
                throw new IndexOutOfRangeException("Indice esame non valido");
            }
        }
        public override string ToString()
        {
            return $"ID: {id}, Nome: {nome}, Cognome: {cognome}, Età: {eta}, Media voti: {mediaVoti}";
        }
    }
}
