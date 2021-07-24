using Business.Abstract;
using Business.Constraints;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        string errorMsg;
        public IResult Add(Car car)
        {
            
            if (car.Description.Length <= 2 )
            {
                errorMsg = Messages.CarDescInvalidLetterLenght;
                return new ErrorResult(errorMsg);
            }
            if (car.DailyPrice <=0)
            {
                errorMsg += Messages.CarPriceInvalidCost;
                return new ErrorResult(errorMsg);

            }
            else
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
            
        }

        public IResult Delete(Car car)
        {
            try
            {
                _carDal.Delete(car);
                return new SuccessResult(Messages.CarDeleted);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.CarCantDeleted);
            }
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(car => car.BrandId == id),Messages.CarListedByBrand);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(car => car.ColorId == id),Messages.CarListedByColor);
        }

        public IResult Update(Car car)
        {
            try
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.CarUpdated);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.CarCantUpdated);
            }
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(car => car.Id == id),Messages.CarListed);
            
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsDto()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.CarsListedDetailDto);
        }
    }
}
