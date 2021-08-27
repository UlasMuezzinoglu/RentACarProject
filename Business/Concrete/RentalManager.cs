﻿using Business.Abstract;
using Business.Constraints;
using Business.ValidationsRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            IResult result2 = BusinessRules.Run(controlDelivered(rental));

           if (result2 != null)
           {
                return result2;
           }
            _rentalDal.Add(rental);
           return new SuccessResult(Messages.RentalAdded);
            

        }

        [CacheRemoveAspect("ICarService.Get")]
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
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.RentalListed);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        public IDataResult<Rental> GetByCustomerId(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(rental => rental.UserId == id), Messages.RentalListed);
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

        [CacheRemoveAspect("ICarService.Get")]
        public IResult AddMultiple(Rental[] rentals)
        {
            //bool hataliMi = false;

            List<Rental> successRentals = new List<Rental>();

            foreach (var rental in rentals)
            {
                var results = _rentalDal.GetAll(re => re.CarId == rental.CarId);

                foreach (var result in results)
                {
                    if ((rental.RentDate >= result.RentDate && rental.RentDate <= result.ReturnDate) || (rental.ReturnDate >= result.RentDate && rental.RentDate <= result.ReturnDate))
                    {
                        return new ErrorResult("Kiralamaz aga");
                    }

                }
                if (rental.ReturnDate <= rental.RentDate)
                {
                    return new ErrorResult("Aga sen Nolan mısın arabayı bugün alıp, dün teslim ediyorsun ?");
                }

                successRentals.Add(rental);
                
            }
            foreach (var successRental in successRentals)
            {
                _rentalDal.Add(successRental);
            }
            return new SuccessResult(Messages.RentalAdded);

        }









        public IResult controlDelivered(Rental rental)
        {
            var results = _rentalDal.GetAll(re => re.CarId == rental.CarId);

            foreach (var result in results)
            {
                if ((rental.RentDate >= result.RentDate && rental.RentDate <= result.ReturnDate) || (rental.ReturnDate >= result.RentDate && rental.RentDate <= result.ReturnDate))
                {
                    return new ErrorResult("Kiralamaz aga");
                }

            }
            if (rental.ReturnDate <= rental.RentDate)
            {
                return new ErrorResult("Aga sen Nolan mısın arabayı bugün alıp, dün teslim ediyorsun ?");
            }
            return new SuccessResult();
        }
    }
}
