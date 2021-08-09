using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationsRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(car => car.DailyPrice).NotEmpty();
            RuleFor(car => car.DailyPrice).GreaterThan(0);
            RuleFor(car => car.ModelYear).GreaterThan(2000);
            RuleFor(car => car.ModelYear).NotEmpty();
            RuleFor(car => car.Description).Length(1, 350);
            

        }
    }
}
