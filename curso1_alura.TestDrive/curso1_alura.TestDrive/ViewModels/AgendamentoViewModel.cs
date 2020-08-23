using curso1_alura.TestDrive.Models;
using curso1_alura.TestDrive.Repositorios;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace curso1_alura.TestDrive.ViewModels
{
    public class AgendamentoViewModel : ViewModelBase
    {
        private const string APP_JSON = "application/json";

        private ICommand _envioAgendamentoComando;
        private readonly VeiculoRepositorio _repositorio;

        public Agendamento Agendamento { get; set; }

        public Veiculo Veiculo
        {
            get => Agendamento.Veiculo;
            set => Agendamento.Veiculo = value;
        }
        public string Nome
        {
            get => Agendamento.Nome;
            set
            {
                Agendamento.Nome = value;
                OnPropertyChanged();
                ((Command)SolicitarEnvioAgendamentoComando).ChangeCanExecute();
            }
        }
        public string Telefone
        {
            get => Agendamento.Telefone;
            set
            {
                Agendamento.Telefone = value;
                OnPropertyChanged();
                ((Command)SolicitarEnvioAgendamentoComando).ChangeCanExecute();
            }
        }
        public string Email
        {
            get => Agendamento.Email;
            set
            {
                Agendamento.Email = value;
                OnPropertyChanged();
                ((Command)SolicitarEnvioAgendamentoComando).ChangeCanExecute();
            }
        }
        public DateTime DataAgendamento
        {
            get => Agendamento.DataAgendamento;
            set => Agendamento.DataAgendamento = value;
        }
        public TimeSpan HoraAgendamento
        {
            get => Agendamento.HoraAgendamento;
            set => Agendamento.HoraAgendamento = value;
        }

        public ICommand SolicitarEnvioAgendamentoComando => _envioAgendamentoComando
            ?? (_envioAgendamentoComando = new Command(
                () => MessagingCenter.Send(Agendamento, "EnvioAgendamento"),
                () => TratamentoDeCamposFormularios()
            ));

        public AgendamentoViewModel(Veiculo veiculo)
        {
            this.Agendamento = new Agendamento { Veiculo = veiculo };
            _repositorio = new VeiculoRepositorio();
        }

        public async void SalvarAgendamento()
        {
            Ocupado = true;
            var agendamentoJson = JsonConvert.SerializeObject(new
            {
                nome = Nome,
                fone = Telefone,
                email = Email,
                carro = Veiculo.Nome,
                preco = Veiculo.Preco,
                dataAgendamento = DataAgendamento.Date
            });

            var agendamentoContent = new StringContent(agendamentoJson, Encoding.UTF8, APP_JSON);

            var resposta = await _repositorio.Salvar(agendamentoContent);

            ValidarResposta(resposta);
            Ocupado = false;
        }

        private void ValidarResposta(HttpResponseMessage resposta)
        {
            if (resposta.IsSuccessStatusCode)
                MessagingCenter.Send(this.Agendamento, "sucessoSalvar");
            else MessagingCenter.Send(new ArgumentException(), "erroSalvar");
        }

        private bool TratamentoDeCamposFormularios()
        {
            return !string.IsNullOrWhiteSpace(this.Nome)
                && !(this.Nome.Length < 3)
                && !string.IsNullOrWhiteSpace(this.Telefone)
                && !string.IsNullOrWhiteSpace(this.Email);
        }
    }
}
