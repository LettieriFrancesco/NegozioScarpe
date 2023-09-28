using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NegozioScarpe.Models
{
    public class Articolo
    {
        public int Id { get; set; }
        public string NomeArticolo { get; set; }
        public double PrezzoArticolo { get; set; }
        public string DescrizioneArticolo { get; set; }
        public string ImmagineCopertina { get; set; }
        [Display(Name = "Carica Immagine 1")]
        public string Immagine1 {  get; set; }
        public string Immagine2 { get; set; }

        public Articolo() { }
        public Articolo(int _id, string _nome, double _prezzo, string _descrzione, string _immagineCopertina, string _immagine1, string _immagine2) 
        {
            Id = _id;
            NomeArticolo = _nome;
            PrezzoArticolo = _prezzo;
            DescrizioneArticolo = _descrzione;
            ImmagineCopertina = _immagineCopertina;
            Immagine1 = _immagine1;
            Immagine2 = _immagine2;
        }
        
    }
}