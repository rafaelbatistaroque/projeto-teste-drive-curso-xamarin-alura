using curso1_alura.TestDrive.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace curso1_alura.TestDrive.Repositorios
{
    public class VeiculoRepositorio
    {
        private const string OBTER_VEICULOS_URL = "https://aluracar.herokuapp.com/";
        private const string SALVAR_VEICULOS_URL = "https://aluracar.herokuapp.com/salvaragendamento";

        public async Task<HttpResponseMessage> Obter()
        {
            HttpResponseMessage resposta;
            using (var requisicao = new HttpClient())
            {
                resposta = await requisicao.GetAsync(OBTER_VEICULOS_URL);
            }
            return resposta;
        }

        public async Task<HttpResponseMessage> Salvar(StringContent agendamento)
        {
            HttpResponseMessage resposta;
            using (var requisicao = new HttpClient())
            {
                resposta = await requisicao.PostAsync(SALVAR_VEICULOS_URL, agendamento);
            }
            return resposta;
        }
    }
}
