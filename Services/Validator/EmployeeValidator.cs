using FluentValidation;
using System.Text.RegularExpressions;

namespace webapi.Services.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            this.CascadeMode = CascadeMode.Stop;
            RuleFor(x => x.EName)
                .NotNull()
                .NotEmpty()
                .Length(1, 20);
            RuleFor(x => x.LastName)
                .NotNull()
                .NotEmpty()
                .Length(1, 50);
            RuleFor(x => x.Doc)
                .NotNull()
                .NotEmpty()
                .Length(11, 11).WithMessage("'Doc' deve ter 11 caracteres.")
                .Custom((cpf, context) =>
                {
                    if (!BeAValidDoc(cpf))
                    {
                        context.AddFailure("CPF invalido.");
                    }
                });
            RuleFor(x => x.Sector)
                .NotNull()
                .NotEmpty()
                .Length(1, 50);
            RuleFor(x => x.Salary)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
            RuleFor(x => x.DtAdmission)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.HealthPlan)
                .NotNull();
            RuleFor(x => x.DentalPlan)
                .NotNull();
            RuleFor(x => x.Transport)
                .NotNull();
        }

        private bool BeAValidDoc(string cpf)
        {
            if (Regex.IsMatch(cpf, @"^[a-zA-Z]+$"))
            {
                return false;
            }
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

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
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
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
