using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationsRules.FluentValidation
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {

        }
    }
}
