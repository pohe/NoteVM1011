using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteVM1011.Model
{
    public class Note
    {
        public int Nr { get; set; }
        public string Emne { get; set; }
        public string Tekst { get; set; }
        public DateTime Dato { get; set; }


        public Note()
        {
            Nr = 0;
            Emne = "";
            Tekst = "";
            Dato = DateTime.Now;
        }

        public Note(string emne, string tekst, int nr)
        {
            Nr = nr;
            Emne = emne;
            Tekst = tekst;
            Dato = DateTime.Now;
        }

        public override string ToString()
        {
            return string.Format("Nr: {0}, Emne: {1}, Tekst: {2}, Dato: {3}", Nr, Emne, Tekst, Dato);
        }
    }

}
