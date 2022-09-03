using FluentValidation;
using Mc2.CrudTest.Application.Responses;
using PhoneNumbers;
using System.Text.RegularExpressions;

namespace Mc2.CrudTest.Application.Validation
{
    public class StoreValidator : AbstractValidator<StoreResponse>
    {

        public StoreValidator()
        {
            RuleFor(Store => Store.Title).NotNull();
            RuleFor(Store => Store.Address).NotNull();
        }
    }
   
}
