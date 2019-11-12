using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteVM1011.Model
{
    public class NoteCatalogSingleton
    {
        public ObservableCollection<Note> Notes { get; set; }


        private static NoteCatalogSingleton _instance = new NoteCatalogSingleton();

        public static NoteCatalogSingleton Instance
        {
            get { return _instance; }
           
        }


        private NoteCatalogSingleton()
        {
            Notes = new ObservableCollection<Note>();
            Notes.Add(new Note("Vandring", "Husk sko", 1));
            Notes.Add(new Note("Cykling", "Husk også cykel!", 2));
            Notes.Add(new Note("Svømning", "Samt våddragt", 3));
        }

        public void Add(Note newNote)
        {

            Notes.Add(newNote);
        }

        //private bool nrAllreadyExist(int nr)
        //{
        //    foreach (Note note in Notes)
        //    {
        //        if (note.Nr == nr)
        //            return true;

        //    }

        //    return false;
        //}

        public void RemoveAt(int index)
        {
            Notes.RemoveAt(index);
        }


        public void Update(int index, Note noteToUpdate)
        {
            Notes[index] = noteToUpdate;

        }

    }
}
