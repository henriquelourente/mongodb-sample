using FluentValidation;
using Project4T.Domain.Entities;

namespace Project4T.Domain.Contracts
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.Name).MinimumLength(5).WithMessage("Nome deve ter ao menos 5 letras");
            RuleFor(customer => customer.Name).MaximumLength(60).WithMessage("Nome deve ter no máximo 60 letras");
            RuleFor(customer => customer.Email).EmailAddress().WithMessage("Endereço de e-mail inválido");
            RuleFor(customer => customer.CPF).Must(BeAValidCPF).WithMessage("CPF inválido");
        }

        private bool BeAValidCPF(string cpf)
        {
            var multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            var tempCpf = cpf.Substring(0, 9);
            var soma = 0;

            for (var i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            var resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            var digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (var i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}
