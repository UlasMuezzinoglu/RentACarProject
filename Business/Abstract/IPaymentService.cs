using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IDataResult<Payment> GetById(int id);
        IDataResult<List<Payment>> GetAll();
        IDataResult<List<Payment>> GetAllByUserId(int userId);

        IResult Add(Payment payment);

        IResult Delete(Payment payment);
    }
}
