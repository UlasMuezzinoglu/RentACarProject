using Core.Entities.Concrete;
using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationsRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.FirstName).MinimumLength(2);
            RuleFor(user => user.FirstName).NotEmpty();
            RuleFor(user => user.LastName).MinimumLength(2);
            RuleFor(user => user.LastName).NotEmpty();
            //RuleFor(user => user.Password).MinimumLength(8);
            //RuleFor(user => user.Password).NotEmpty();
            RuleFor(user => user.Email).EmailAddress();
            RuleFor(user => user.Email).NotEmpty();



        }
    }
}
