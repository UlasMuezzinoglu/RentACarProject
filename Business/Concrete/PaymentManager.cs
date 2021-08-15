using Business.Abstract;
using Business.Constraints;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public IResult Add(Payment payment)
        {
            _paymentDal.Add(payment);
            return new SuccessResult(Messages.paymentAdded);
        }


        public IResult Delete(Payment payment)
        {
            _paymentDal.Delete(payment);
            return new SuccessResult(Messages.paymentDeleted);
        }

        public IDataResult<List<Payment>> GetAll()
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll());
        }

        public IDataResult<List<Payment>> GetAllByUserId(int userId)
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll(c => c.UserId == userId));
        }


        public IDataResult<Payment> GetById(int id)
        {
            return new SuccessDataResult<Payment>(_paymentDal.Get(c => c.Id == id));
        }

    }
}
