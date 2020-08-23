using curso1_alura.TestDrive.Models;
using curso1_alura.TestDrive.Repositorios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace curso1_alura.TestDrive.ViewModels
{
    public class ListagemViewModel : ViewModelBase
    {
        private Veiculo _veiculoSelecionado;
        private readonly VeiculoRepositorio _repositorio;

        public ObservableCollection<Veiculo> Veiculos { get; set; }

        public Veiculo VeiculoSelecionado
        {
            get => _veiculoSelecionado;
            set
            {
                _veiculoSelecionado = value;
                if (value != null)
                    MessagingCenter.Send(_veiculoSelecionado, "VeiculoSelecionado");
            }
        }

        public ListagemViewModel()
        {
            this.Veiculos = new ObservableCollection<Veiculo>();
            _repositorio = new VeiculoRepositorio();
        }

        public async void ObterVeiculos()
        {
            Ocupado = true;
            var resposta = await _repositorio.Obter();

            ValidarResposta(resposta);

            var convertido = await resposta.Content.ReadAsStringAsync();

            var veiculos = JsonConvert.DeserializeObject<List<Veiculo>>(convertido);
            veiculos.ForEach(v => this.Veiculos.Add(new Veiculo { Nome = v.Nome, Preco = v.Preco }));
            Ocupado = false;
        }

        private void ValidarResposta(HttpResponseMessage resposta)
        {
            if (resposta.IsSuccessStatusCode)
                return;
            else MessagingCenter.Send(new ArgumentException(), "erroObter");
        }
    }
}
