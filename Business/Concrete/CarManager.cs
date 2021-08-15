﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constraints;
using Business.ValidationsRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        [CacheRemoveAspect("ICarService.Get")]
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

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        //public IDataResult<List<Car>> GetCarsByBrandId(int id)
        //{
        //    return new SuccessDataResult<List<Car>>(_carDal.GetAll(car => car.BrandId == id), Messages.CarListedByBrand);
        //}

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailDtosWithBrandId(id), Messages.CarListedByBrand);
        }

        //[CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetailsDto()
        {
            
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarsListedDetailDto);
        }
        //public IDataResult<List<Car>> GetCarsByColorId(int id)
        //{
        //    return new SuccessDataResult<List<Car>>(_carDal.GetAll(car => car.ColorId == id), Messages.CarListedByColor);
        //}

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailDtosWithColorId(id), Messages.CarListedByColor);
        }

        [CacheRemoveAspect("ICarService.Get")]
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

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(car => car.Id == id), Messages.CarListed);

        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarsDetailDtoByCarId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsDtoWithCarId(id), Messages.CarListed);
        }


        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarsDetailDtoByBrandAndColorId(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailDtosWithColorIdAndBrandId(colorId,brandId), Messages.CarListed);
        }
    }
}
