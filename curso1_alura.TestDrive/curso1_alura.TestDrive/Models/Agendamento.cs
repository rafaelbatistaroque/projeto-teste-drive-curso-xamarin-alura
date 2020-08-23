using System;

namespace curso1_alura.TestDrive.Models
{
    public class Agendamento
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public Veiculo Veiculo { get; set; }
        public DateTime DataAgendamento { get; set; } = DateTime.Today;
        public TimeSpan HoraAgendamento { get; set; }
    }
}
