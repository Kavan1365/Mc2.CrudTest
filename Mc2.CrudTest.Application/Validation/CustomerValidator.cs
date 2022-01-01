using FluentValidation;
using Mc2.CrudTest.Application.Responses;
using PhoneNumbers;
using System.Text.RegularExpressions;

namespace Mc2.CrudTest.Application.Validation
{
    public class CustomerValidator : AbstractValidator<CustomerResponse>
    {

        public CustomerValidator()
        {
            RuleFor(customer => customer.FirstName).NotNull();
            RuleFor(customer => customer.LastName).NotNull();
            RuleFor(customer => customer.Email).NotNull().EmailAddress();
            RuleFor(customer => customer.PhoneNumber).Must(customer =>
            {
                try
                {
                    var phoneNumberUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();
                    var e164PhoneNumber = customer;
                    var phoneNumber = phoneNumberUtil.Parse(e164PhoneNumber, null);
                    return phoneNumber.HasNationalNumber;
                }
                catch (System.Exception)
                {
                    return false;
                }
             
             })
                .WithMessage("not a valid phone number.");

            RuleFor(customer => customer.PhoneNumber).NotNull();
            RuleFor(customer => customer.BankAccountNumber).NotNull();
            RuleFor(customer => customer.DateOfBirth).NotNull();
        }
    }
   
}
