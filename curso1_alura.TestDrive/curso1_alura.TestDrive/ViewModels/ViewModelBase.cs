using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace curso1_alura.TestDrive.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool _ocupado;

        public bool Ocupado
        {
            get => _ocupado;
            set
            {
                _ocupado = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Desocupado));
            }
        }

        public bool Desocupado { get => !_ocupado; }

        public void OnPropertyChanged([CallerMemberName] string nomePropriedade = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomePropriedade));
        }
    }
}
