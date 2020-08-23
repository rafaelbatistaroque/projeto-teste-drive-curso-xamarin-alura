using curso1_alura.TestDrive.Models;
using curso1_alura.TestDrive.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace curso1_alura.TestDrive.Views
{
    [DesignTimeVisible(false)]
    public partial class ListagemPage : ContentPage
    {
        public ListagemViewModel vm { get; set; }
        public ListagemPage()
        {
            InitializeComponent();
            this.vm = new ListagemViewModel();
            this.BindingContext = this.vm;
            vm.ObterVeiculos();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado", (veiculoSelecionado) =>
            {
                Navigation.PushAsync(new DetalhePage(veiculoSelecionado));
            });

            MessagingCenter.Subscribe<ArgumentException>(this, "erroObter", (veiculo) =>
            {
                DisplayAlert("Erro", "Não foi possível obter lista de veículos", "OK");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");
            MessagingCenter.Unsubscribe<ArgumentException>(this, "erroObter");
        }
    }
}
