using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using NoteVM1011.Annotations;
using NoteVM1011.Common;
using NoteVM1011.Model;

namespace NoteVM1011.ViewModel
{
    public class NoteVM : INotifyPropertyChanged
    {
        public NoteCatalogSingleton NoteCatalog { get; set; }

        private Note _selectedNote;

        public Note SelectedNote
        {
            get { return _selectedNote; }
            set
            {
                _selectedNote = value;
                if (_selectedNote == null)
                {
                    _selectedNote = new Note("", "", 0);
                }

                OnPropertyChanged();
                ((RelayCommand)_addCommand).RaiseCanExecuteChanged();
                ((RelayCommand)_removeCommand).RaiseCanExecuteChanged();
                ((RelayCommand)_updateCommand).RaiseCanExecuteChanged();
            }
        }

        public int SelectedIndex { get; set; }

        private ICommand _removeCommand;

        public ICommand RemoveCommand
        {
            get { return _removeCommand; }
            set { _removeCommand = value; }
        }


        //Lav en UpdateCommand og bind til den i MainPAge
        private ICommand _updateCommand;

        public ICommand UpdateCommand
        {
            get { return _updateCommand; }
            set { _updateCommand = value; }
        }

        private ICommand _addCommand;

        public ICommand AddCommand
        {
            get { return _addCommand; }
            set { _addCommand = value; }
        }

        public NoteVM()
        {
            //NoteCatalog = new NoteCatalog();
            NoteCatalog = NoteCatalogSingleton.Instance;
            _removeCommand = new RelayCommand(RemoveAt, SelectedIsDefined);
            _updateCommand = new RelayCommand(Update, SelectedIsDefined);
            _addCommand = new RelayCommand(Add, NoteIsSelected);
            
            //Lav en instans af RealyCommand og angiv en action og en Func

        }

        //  <Bool> Func
        public bool NoteIsSelected()
        {
            return SelectedNote != null ;
        }

        public bool SelectedIsDefined()
        {
            return SelectedIndex != -1;
        }




        public void Add()
        {
            
                NoteCatalog.Add(SelectedNote);
                SelectedNote = null;
        }

        
        //Action
        public void RemoveAt()
        {
            NoteCatalog.RemoveAt(SelectedIndex);
           
        }

        //LAv en Update metode af typen Action
        // og kald en metode i NoteCatalog som skal opdatere en note
        public void Update()
        {
            NoteCatalog.Update(SelectedIndex, SelectedNote);
            
        }


       

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
