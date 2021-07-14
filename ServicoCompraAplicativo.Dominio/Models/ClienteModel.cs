using System;

namespace ServicoCompraAplicativo.Dominio.Models
{
    public class ClienteModel : Entity
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public char Sexo { get; set; }
        public string Endereco { get; set; }
    }
}
