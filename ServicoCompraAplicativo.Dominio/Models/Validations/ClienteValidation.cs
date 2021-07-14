using FluentValidation;
using System.Collections.Generic;

namespace ServicoCompraAplicativo.Dominio.Models.Validations
{
    public class ClienteValidation : AbstractValidator<ClienteModel>
    {
        private bool IsCpf(string cpf)
        {
            if (cpf == null) return false;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;

            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                    return false;

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCpf += digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito += resto.ToString();

            return cpf.EndsWith(digito);
        }
        public ClienteValidation()
        {
            CascadeMode = CascadeMode.Continue;

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome do cliente é obrigatório");

            RuleFor(x => x.Cpf)
                .NotEmpty()
                .WithMessage("Favor informar o número do CPF")
                .Must(s => IsCpf(s))
                .WithMessage("CPF inválido");

            RuleFor(x => x.DataNascimento)
                .NotEmpty()
                .WithMessage("A data de nascimento do cliente é obrigatória");

            List<string> opcoesSexo = new List<string> { "M", "F" };
            RuleFor(x => x.Sexo)
                .NotEmpty()
                .WithMessage("O indicador do sexo do cliente é obrigatório")
                .Must(s => opcoesSexo.Contains(s.ToString()))
                .WithMessage(string.Format("O valores permitidos para o atributo indicador do sexo são: {0}", string.Join(" ou ", opcoesSexo)));

            RuleFor(x => x.Endereco)
                .NotEmpty()
                .WithMessage("O endereço é obrigatório");
        }
    }
}
