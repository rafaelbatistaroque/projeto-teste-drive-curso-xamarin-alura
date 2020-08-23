using curso1_alura.TestDrive.Models;
using curso1_alura.TestDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace curso1_alura.TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalhePage : ContentPage
    {
        public Veiculo Veiculo { get; set; }
        public DetalhePage(Veiculo veiculo)
        {
            InitializeComponent();
            this.Veiculo = veiculo;
            this.BindingContext = new DetalheViewModel(veiculo);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Veiculo>(this, "AbrirPaginaAgendamento", (veiculo) =>
            {
                Navigation.PushAsync(new AgendamentoPage(veiculo));
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "AbrirPaginaAgendamento");
        }
    }
}