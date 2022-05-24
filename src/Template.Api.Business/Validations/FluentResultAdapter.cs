using Template.Api.Core.Domain.Constants;
using Template.Api.Core.Error;
using Template.Api.Core.Exceptions;
using FluentValidation.Results;

namespace Template.Api.Core.Validations
{
    public static class FluentResultAdapter
    {
        public static void VerificaErros(ValidationResult result)
        {
            if (!(result?.IsValid ?? true))
            {
                Problem problem = new Problem
                {
                    Instance = result.GetType().FullName
                };

                if (result.Errors != null)
                {
                    problem.Erros = new List<ErrorField>();

                    foreach (var erro in result.Errors)
                    {
                        if (!problem.Erros.Any(e => e.FieldName == erro.PropertyName))
                            problem.Erros.Add(new ErrorField(erro.PropertyName, new List<string>()));

                        problem.Erros.FirstOrDefault(e => e.FieldName == erro.PropertyName).FieldErros.Add(erro.ErrorMessage);
                    }
                }

                problem.Status = 400;
                throw new BusinessException(problem);
            }
        }
    }
}
