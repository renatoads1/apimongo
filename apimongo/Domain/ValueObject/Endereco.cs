using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace apimongo.Domain.ValueObject
{
    public class Endereco : AbstractValidator<Endereco>
    {
        public string Logradouro { get;private set; }
        public string Numero { get; private set; }
        public string Cidade { get; private set; }
        public string Uf { get; private set; }
        public string Cep { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        public virtual bool Validar() {

            ValidarLogradouro();
            ValidarNumero();
            ValidarCidade();
            ValidarUf();
            ValidarCep();

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
        private void ValidarLogradouro() {
            RuleFor(c => c.Logradouro).
                NotEmpty().
                WithMessage("Logradouro Não pode ser vazio.").
                MaximumLength(100).
                WithMessage("Maximo de 100 caracteres");
        }
        private void ValidarNumero()
        {
            RuleFor(c => c.Numero).
                NotEmpty().
                WithMessage("Numero Não pode ser vazio.").
                MaximumLength(100).
                WithMessage("Maximo de 100 caracteres");
        }
        private void ValidarCidade()
        {
            RuleFor(c => c.Cidade).
                NotEmpty().
                WithMessage("Cidade Não pode ser vazio.").
                MaximumLength(100).
                WithMessage("Maximo de 100 caracteres");
        }
        private void ValidarUf()
        {
            RuleFor(c => c.Uf).
                NotEmpty().
                WithMessage("Uf Não pode ser vazio.").
                MaximumLength(100).
                WithMessage("Maximo de 100 caracteres");
        }
        private void ValidarCep()
        {
            RuleFor(c => c.Cep).
                NotEmpty().
                WithMessage("Cep Não pode ser vazio.").
                MaximumLength(100).
                WithMessage("Maximo de 100 caracteres");
        }

    }
}
