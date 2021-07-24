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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            
            if (isThatCarDeliveried(rental.CarId))
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
            return new ErrorResult(Messages.RentalProblem);

        }

        public IResult Delete(Rental rental)
        {
            try
            {
                _rentalDal.Delete(rental);
                return new SuccessResult(Messages.RentalDeleted);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.RentalCantDeledet);
            }
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        public IDataResult<Rental> GetByCustomerId(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(rental => rental.CustomerId == id), Messages.RentalListed);
        }

        public IResult Update(Rental rental)
        {
            try
            {
                _rentalDal.Update(rental);
                return new SuccessResult(Messages.RentalUpdated);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.RentalCantUpdated);
            }
        }
        public bool isThatCarDeliveried(int id)
        {
            var result = _rentalDal.Get(r => r.CarId ==id && r.ReturnDate==null); // parametre olarak aldıgın id ye göre rentali getir. ve gelen ilanın returndate i boş olanı getir
            if (result == null)
            {
                return true; // demek ki hiçbir ilan gelmemiş, demek ki return tarihi boş değil yani araç teslim edilmiş.
            }
            return false;
        }
    }
}
