using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ThePresidents.Models;
using ThePresidents.Services;

namespace ThePresidents.ViewModels
{
    public class PresidentListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<President> AllPresidents { get; } = new ObservableCollection<President>();
        private President _presidentToDisplay;
        public President PresidentToDisplay
        {
            get { return _presidentToDisplay; }
            set
            {
                _presidentToDisplay = value;
                RaisePropertyChanged("PresidentToDisplay");
            }
        }
        public PresidentListViewModel()
        {
            DataService ds = new DataService();
            var presidents = ds.GetAllPresidents();

            foreach (var pres in presidents)
            {
                AllPresidents.Add(pres);
            }
            PresidentToDisplay = AllPresidents[0];
        }

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public President GoToAnother(int offset)
        {
            int index = DisplayPresidentIndex();
            index += offset;
            if (index < 0)
                index = 0;
            var newPres = AllPresidents[index];
            PresidentToDisplay = newPres;
            return newPres;
        }

        internal void Refresh()
        {
            AllPresidents.Clear();
            DataService ds = new DataService();
            var presidents = ds.GetAllPresidents();

            foreach (var pres in presidents)
            {
                AllPresidents.Add(pres);
            }
        }

        private int DisplayPresidentIndex()
        {
            var presidentIndex = 0;
            if (_presidentToDisplay != null)
                presidentIndex = AllPresidents.IndexOf(_presidentToDisplay);
            return presidentIndex;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
