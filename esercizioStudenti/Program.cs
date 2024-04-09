/*Quello che deve fare l'applicazione è semplicemente mostrare un menu con varie operazioni :
Aggiungi studente
Elimina studente
Modifica Studente
Mostra lista studenti (con filtro per nome e cognome)
Ordina per eta (crescente e decrescente) */

using esercizioStudenti;
using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static List<Studente> listaStudenti = new List<Studente>();
    static List<Esame> listaEsami = new List<Esame>();

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
            Console.WriteLine("5. Filtra studenti per nome");
            Console.WriteLine("6. Filtra studenti per cognome");
            Console.WriteLine("7. Ordina per età (crescente)");
            Console.WriteLine("8. Ordina per età (decrescente)");
            Console.WriteLine("9. Aggiungi un esame ad uno studente");
            Console.WriteLine("0. Esci");

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
                    FiltraStudentiNome();
                    //Console.WriteLine("1. Filtra per nome:");

                    //Console.WriteLine("2. Filtra per cognome:");
                    break;
                case "6":
                    FiltraStudentiCognome();
                    break;
                case "7":
                    OrdinaPerEtaCrescente();
                    break;
                case "8":
                    OrdinaPerEtaDecrescente();
                    break;
                case "9":
                    AggiungiEsameStudente();
                    break;
                case "0":
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
        try
        {
            //Console.Write("Inserisci id studente:");
            //int id = int.Parse(Console.ReadLine()); 
            Guid guid = Guid.NewGuid();

            Console.WriteLine("ID progressivo: " + guid);
            string guidString = guid.ToString();


            Console.WriteLine("Inserisci il nome dello studente:");
            string nome = Console.ReadLine();
            Console.WriteLine("Inserisci il cognome dello studente:");
            string cognome = Console.ReadLine();
            Console.WriteLine("Inserisci l'età dello studente:");
            int eta = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci la media dei voti dello studente:");
            double mediaVoti = double.Parse(Console.ReadLine());

            Studente nuovoStudente = new Studente(guidString, nome, cognome, eta, mediaVoti);
            listaStudenti.Add(nuovoStudente);

            Console.WriteLine("Studente aggiunto!");
        }

        catch (FormatException)
        {
            Console.WriteLine("Errore! Input non valido");
        }
    }

    static void RimuoviStudente()
    {
        //Console.Write("Inserisci l'id dello studente da eliminare:");
        //int id = int.Parse(Console.ReadLine());

        //if (id >= 0 && id < listaStudenti.Count)
        //{
        //    listaStudenti.RemoveAt(id);
        //}

        //else
        //{
        //    Console.WriteLine("Id non trovato");
        //}

        Console.Write("Inserisci l'id dello studente da eliminare:");
        string guidString = Console.ReadLine();

        //foreach(Studente studente in listaStudenti)
        //{
        //    Console.WriteLine(studente);
        //}

        //listaStudenti.Remove(id);

        //var studenteDaRimuovere = listaStudenti.Single(s => s.guidString == guidString); 
        //listaStudenti.Remove(studenteDaRimuovere);

        var studenteDaRimuovere = listaStudenti.FirstOrDefault(s => s.guidString == guidString);
        listaStudenti.Remove(studenteDaRimuovere);

    }

    static void ModificaStudente()
    {
        Console.Write("Inserisci l'id dello studente da modificare:");
        string guidString = Console.ReadLine();

        //if (id >= 0 && id < listaStudenti.Count)
        //{
        //    Console.Write("Inserisci nuovo nome: ");
        //    string nuovoNome = Console.ReadLine();
        //    Console.Write("Inserisci nuovo cognome: ");
        //    string nuovoCognome = Console.ReadLine();
        //    Console.Write("Inserisci nuova età: ");
        //    int nuovaEta = int.Parse(Console.ReadLine());
        //    Console.WriteLine("Inserisci la media dei voti del nuovo studente");
        //    double nuovaMediaVoti = double.Parse(Console.ReadLine());
        //}

        //else
        //{
        //    Console.WriteLine("Id non trovato");
        //}

        /*var studenteDaModificare = listaStudenti.Single(s => s.guidString == guidString); */
        var studenteDaModificare = listaStudenti.FirstOrDefault(s => s.guidString == guidString);



        Console.WriteLine("Inserisci il nuovo nome:");
        string nuovoNome = Console.ReadLine();

        Studente studente = new Studente();
        studenteDaModificare.nome = nuovoNome;

        Console.WriteLine("Inserisci il nuovo cognome:");
        string nuovoCognome = Console.ReadLine();

        studenteDaModificare.cognome = nuovoCognome;

        Console.WriteLine("Inserisci la nuova eta:");
        int nuovaEta = int.Parse(Console.ReadLine());

        studenteDaModificare.eta = nuovaEta;

        Console.WriteLine("Inserisci la media dei voti");
        double nuovaMediaVoti = double.Parse(Console.ReadLine());

        studenteDaModificare.mediaVoti = nuovaMediaVoti;
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

        listaStudenti.Select(s => new StudenteEsamiDTO
        {
            studenteNome = s.nome,
            Esami = listaEsami
        .Where(e => e.studenteID == s.guidString)
        .Select(e => new EsamiDTO
        {
            Voto = e.voto
        }).ToList()

        });

        var esameStudente = listaStudenti
            .Join(listaEsami,
            s => s.guidString,
            e => e.studenteID,
            (s, e) => new { Studente = s, Esame = e })
            .GroupBy(x => x.Studente)
            .Select(x => new StudenteEsamiDTO
            {
                studenteID = x.Key.nome,
                Esami = x.Select(e => new EsamiDTO
                {
                    Materia = e.Esame.materia,
                    Data = e.Esame.data,
                    Voto = e.Esame.voto
                }).OrderBy(d => d.Data).ToList()
            });

        //foreach (var item in esameStudente)
        //{
        //    Console.WriteLine($"Cognome: {item.studenteCognome}");
        //}


        //var esameStudente = from Studente in listaStudenti
        //                               join Esame in listaEsami on Studente.guidString equals Esame.studenteID                                      
        //                               select new { Studente, Esame };

    }

    static void FiltraStudentiNome() //TODO filtraggio per altri attributi oltre al nome 
    {

        Console.WriteLine("Inserire il nome che si vuole cercare:");
        //Studente studente = new Studente();
        string nomeDaCercare = "";
        nomeDaCercare = Console.ReadLine();
        //Studente studente = new Studente();
        //nome = Console.ReadLine();


        var studenteFiltratoNome = from Studente in listaStudenti
                                   where Studente.nome == nomeDaCercare
                                   select Studente;

        foreach (var studente in studenteFiltratoNome)
        {
            Console.WriteLine($"Id: {studente.guidString}, Nome: {studente.nome}, Cognome: {studente.cognome}, Età: {studente.eta}, Media Voti: {studente.mediaVoti}, Esami fatti: {studente.Esami}");
        }


        //static void FiltraPerCognome()
        //{
        //    var cognome = from Studente in listaStudenti
        //                  where Studente.cognome == Studente.cognome
        //                  select Studente;
        //}
    }

    static void FiltraStudentiCognome()
    {
        Console.WriteLine("Inserire il cognome che si vuole cercare:");
        string cognomeDaCercare = "";
        cognomeDaCercare = Console.ReadLine();

        var studenteFiltratoCognome = from Studente in listaStudenti
                                      where Studente.cognome == cognomeDaCercare
                                      select Studente;

        foreach(var studente in studenteFiltratoCognome)
        {
            Console.WriteLine($"Cognome: {studente.cognome},  Nome: {studente.nome}, Id: {studente.guidString}, Età: {studente.eta}, Media Voti: {studente.mediaVoti}, Esami fatti: {studente.Esami}");
        }
    }


    static void OrdinaPerEtaCrescente()
    {
        listaStudenti = listaStudenti.OrderBy(s => s.eta).ToList();
        Console.WriteLine("Lista degli studenti ordinata per età in ordine crescente:");
        MostraListaStudenti();
    }

    static void OrdinaPerEtaDecrescente()
    {
        listaStudenti = listaStudenti.OrderByDescending(s => s.eta).ToList();
        Console.WriteLine("Lista degli studenti ordinata per età in ordine decrescente:");
        MostraListaStudenti();
    }

    static void AggiungiEsameStudente()
    {
        Console.WriteLine("Inserire l'id dello studente al quale aggiungere l'esame:");
        /*int id = int.Parse(Console.ReadLine());*/ 
        string guidString = Console.ReadLine();
        var studenteEsame = listaStudenti.FirstOrDefault(s => s.guidString == guidString);



        if (studenteEsame != null)
        {
            Esame esame = new Esame();
            esame.studenteID = studenteEsame.guidString;




            Console.WriteLine("Inserire materia d'esame");
            esame.materia = Console.ReadLine();


            //Console.WriteLine("Inserire data dell'esame");
            //DateTime data = DateTime.Now;   

            Console.WriteLine("Inserire data dell'esame");

            var dt = DateTime.TryParse(Console.ReadLine(), out var result);
            if (dt) //FIXME FAI DO WHILE
            {

                esame.data = result;
            }

            else
            {
                Console.WriteLine("Inserire un formato di data valido!");
            }

            //do
            //{
            //    esame.data = result;
            //}

            //while (dt);

            Console.WriteLine("Inserire il voto ottenuto all'esame dallo studente"); 
            esame.voto = int.Parse(Console.ReadLine());
            if(esame.voto >= 18 && esame.voto < 30)
            {
                Console.WriteLine("Esame superato! Verrà aggiunto alla carriera dello studente!");
                listaEsami.Add(esame);
            }

            else
            {
                Console.WriteLine("Esame non superato!");
            }

            


        }

        else
        {
            Console.WriteLine("Id non trovato");
        }


    }
    }
