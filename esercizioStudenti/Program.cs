﻿/*Quello che deve fare l'applicazione è semplicemente mostrare un menu con varie operazioni :
Aggiungi studente
Elimina studente
Modifica Studente
Mostra lista studenti (con filtro per nome e cognome)
Ordina per eta (crescente e decrescente) */

using esercizioStudenti;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Studente> listaStudenti = new List<Studente>();

    static void Main(string[] args)
    {
        bool continua = true;
        

        while (continua)
        {
        Console.WriteLine("Menù:");
        Console.WriteLine("1. Aggiungi studente");
        Console.WriteLine("2. Elimina studente");
        Console.WriteLine("3. Modifica studente");
        Console.WriteLine("4. Mostra lista studenti");
        Console.WriteLine("5. Ordina per età (crescente)");
        Console.WriteLine("6. Ordina per età (decrescente)");
        Console.WriteLine("7. Esci");

        Console.Write("Scelta:");
        string scelta = Console.ReadLine();


            switch (scelta)
            {
                case "1":
                    AggiungiStudente();
                    break;
                case "2":
                    RimuoviStudente();
                    break;
                case "3":
                    ModificaStudente();
                    break;
                case "4":
                    MostraListaStudenti();
                    break;
                case "5":
                    OrdinaPerEtaCrescente();
                    break;
                case "6":
                    OrdinaPerEtaDecrescente();
                    break;
                case "7":
                    continua = false;
                    break;
                default:
                    Console.WriteLine("Scelta non valida");
                    break;
            }

        }
    }

    static void AggiungiStudente()
    {
        Console.Write("Inserisci id studente:");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Inserisci il nome dello studente:");
        string nome = Console.ReadLine();
        Console.WriteLine("Inserisci il cognome dello studente:");
        string cognome = Console.ReadLine();
        Console.WriteLine("Inserisci l'età dello studente:");
        int eta = int.Parse(Console.ReadLine());
        Console.WriteLine("Inserisci la media dei voti dello studente:");
        double mediaVoti = double.Parse(Console.ReadLine());

        Studente nuovoStudente = new Studente(id, nome, cognome, eta, mediaVoti);
        listaStudenti.Add(nuovoStudente);

        Console.WriteLine("Studente aggiunto!");
    }

    static void RimuoviStudente()
    {
        Console.Write("Inserisci l'id dello studente da eliminare:");
        int id = int.Parse(Console.ReadLine());

        if(id >= 0 && id < listaStudenti.Count) {
            listaStudenti.RemoveAt(id);
        }

        else { 
         Console.WriteLine("Id non trovato");
        }
    }

    static void ModificaStudente()
    {
        Console.Write("Inserisci l'id dello studente da modificare:");
        int id = int.Parse(Console.ReadLine());

        if (id >= 0 && id < listaStudenti.Count)
        {
            Console.Write("Inserisci nuovo nome: ");
            string nuovoNome = Console.ReadLine();
            Console.Write("Inserisci nuovo cognome: ");
            string nuovoCognome = Console.ReadLine();
            Console.Write("Inserisci nuova età: ");
            int nuovaEta = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci la media dei voti del nuovo studente");
            double nuovaMediaVoti = double.Parse(Console.ReadLine());
        }

        else
        {
            Console.WriteLine("Id non trovato");
        }
    }

    static void MostraListaStudenti()
    {
        if (listaStudenti.Count == 0)
        {
            Console.WriteLine("Nessuno studente presente.");
            return;
        }

        Console.WriteLine("Lista Studenti:");
        for (int i = 0; i < listaStudenti.Count; i++)
        {
            Console.WriteLine($"{i}. {listaStudenti[i]}");
        }
    }


    static void OrdinaPerEtaCrescente()
    {
        listaStudenti = listaStudenti.OrderBy(s  => s.eta).ToList();
        Console.WriteLine("Lista degli studenti ordinata per età in ordine crescente:");
        MostraListaStudenti();
    }

    static void OrdinaPerEtaDecrescente()
    {
        listaStudenti = listaStudenti.OrderByDescending(s => s.eta).ToList();
        Console.WriteLine("Lista degli studenti ordinata per età in ordine decrescente:");
        MostraListaStudenti();
    }
}