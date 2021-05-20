using apimongo.Domain.Enums;
using apimongo.Domain.ValueObject;
using FluentValidation;
using FluentValidation.Results;

namespace apimongo.Domain.Entities
{
    public class Restaurante : AbstractValidator<Restaurante>
    {
        public string Id { get; private set; }
        public string Nome { get; private set; }
        public ECozinha Cozinha { get; private set; }
        public Endereco Endereco { get; private set; }

        public Restaurante(string id, string nome, ECozinha cozinha)
        {
            Id = id;
            Nome = nome;
            Cozinha = cozinha;
        }

        public ValidationResult ValidationResult { get; set; }

        public void AtribuirEndereco(Endereco endereco)
        {
            Endereco = endereco;
        }
        public virtual bool Validar()
        {

            ValidarNome();
            ValidationResult = Validate(this);
            return ValidationResult.IsValid;

        }

        public void ValidarNome() {
            RuleFor(c => c.Nome).
                NotEmpty().
                WithMessage("Nome Não pode ser vazio.").
                MaximumLength(30).
                WithMessage("Maximo de 100 caracteres");

        }

        private void ValidarEndereco() {
            if (Endereco.Validar())
            {
                return;
            }
            else {
                foreach (var erro in Endereco.ValidationResult.Errors)
                {
                    ValidationResult.Errors.Add(erro);
                }
            }
        }


    }
}
