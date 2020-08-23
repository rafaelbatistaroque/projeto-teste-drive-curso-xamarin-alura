using curso1_alura.TestDrive.Models;
using System.Windows.Input;
using Xamarin.Forms;

namespace curso1_alura.TestDrive.ViewModels
{
    public class DetalheViewModel : ViewModelBase
    {
        private Command _paginaDeAgendamento;

        public Veiculo Veiculo { get; set; }
        public string TextoFreioAbs { get => $"Freio ABS - R$ {Veiculo.FREIO_ABS}"; }
        public string TextoArCondicionado { get => $"Ar condicionado - R$ {Veiculo.AR_CONDICIONADO}"; }
        public string TextoAirBag { get => $"Air Bag - R$ {Veiculo.AIR_BAG}"; }
        public bool TemABS
        {
            get => Veiculo.TemABS;
            set
            {
                Veiculo.TemABS = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorAcessoriosSomados));
            }
        }
        public bool TemAR
        {
            get => Veiculo.TemAR;
            set
            {
                Veiculo.TemAR = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorAcessoriosSomados));
            }
        }
        public bool TemAirBag
        {
            get => Veiculo.TemAirBag;
            set
            {
                Veiculo.TemAirBag = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorAcessoriosSomados));
            }
        }
        public string ValorAcessoriosSomados { get => Veiculo.SomaTotalAcessoriosFormatado; }
        public ICommand SolicitarPaginaDeAgendamentoComando
            => _paginaDeAgendamento ?? (_paginaDeAgendamento = new Command(
                () => MessagingCenter.Send(Veiculo, "AbrirPaginaAgendamento")
            ));

        public DetalheViewModel(Veiculo veiculo)
        {
            Veiculo = veiculo;
        }
    }
}
