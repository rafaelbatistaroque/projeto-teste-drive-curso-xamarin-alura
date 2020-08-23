using System;
using System.Collections.Generic;
using System.Text;

namespace curso1_alura.TestDrive.Models
{
    public class Veiculo
    {
        public const int FREIO_ABS = 800;
        public const int AR_CONDICIONADO = 500;
        public const int AIR_BAG = 650;

        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public bool TemABS { get; set; }
        public bool TemAR { get; set; }
        public bool TemAirBag { get; set; }
        public string SomaTotalAcessoriosFormatado { get => SomarValorAcessorios(); }
        
        private string SomarValorAcessorios()
        {
            decimal valoresSomado = this.Preco;

            valoresSomado += TemABS ? FREIO_ABS : 0;
            valoresSomado += TemAR ? AR_CONDICIONADO : 0;
            valoresSomado += TemAirBag ? AIR_BAG : 0;

            return $"TOTAL: R$ {valoresSomado}";
        }
    }
}
