using FluentValidation;
using FluentValidation.Results;
using System.Web.Mvc;

namespace web.GurselFramework.Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public class ValidatorTool
    {
        public static void FluentValidate(IValidator validator, object entity)
        {
            var result = validator.Validate(entity);

            if (result.Errors.Count > 0)
            {
                foreach (ValidationFailure failer in result.Errors)
                {

                }
            }
        }
    }
}
