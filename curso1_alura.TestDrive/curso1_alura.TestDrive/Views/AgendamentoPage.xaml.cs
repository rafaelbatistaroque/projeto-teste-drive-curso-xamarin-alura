using curso1_alura.TestDrive.Models;
using curso1_alura.TestDrive.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace curso1_alura.TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgendamentoPage : ContentPage
    {
        public AgendamentoViewModel ViewModel { get; set; }
        public AgendamentoPage(Veiculo veiculo)
        {
            InitializeComponent();
            ViewModel = new AgendamentoViewModel(veiculo);
            this.BindingContext = ViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Agendamento>(this, "EnvioAgendamento", async (envioAgendamento) =>
            {
                var resposta = await DisplayAlert("Salvar", "Deseja salvar o agendamento?", "SIM", "NÃO");

                if (resposta)
                    this.ViewModel.SalvarAgendamento();
            });

            MessagingCenter.Subscribe<Agendamento>(this, "sucessoSalvar", (msg) => {
                DisplayAlert("Sucesso", "O agendamento foi salvo", "OK");
            });

            MessagingCenter.Subscribe<ArgumentException>(this, "erroSalvar", (msg) => {
                DisplayAlert("Erro", "O registro não foi salvo", "OK");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "EnvioAgendamento");
            MessagingCenter.Unsubscribe<Agendamento>(this, "sucessoSalvar");
            MessagingCenter.Unsubscribe<ArgumentException>(this, "erroSalvar");
        }
    }
}