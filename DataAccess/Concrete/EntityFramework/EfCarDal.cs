﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from ca in context.Cars
                             join co in context.Colors
                             on ca.ColorId equals co.Id
                             join br in context.Brands
                             on ca.BrandId equals br.Id
                             //join ci in context.CarImages
                             //on ca.Id equals ci.CarId
                             //join re in context.Rentals
                             //on ca.Id equals re.CarId
                             select new CarDetailDto
                             {
                                 Id = ca.Id,
                                 BrandName = br.Name,
                                 ColorName = co.Name,
                                 DailyPrice = ca.DailyPrice,
                                 Description = ca.Description,
                                 Model = ca.Model,
                                 ModelYear = ca.ModelYear,
                                 ImagePath = (from x in context.CarImages where x.CarId == ca.Id select x.ImagePath).FirstOrDefault(),
                                 //ReturnDate = re.ReturnDate
                                 ReturnDate = (from y in context.Rentals orderby y.ReturnDate descending where y.CarId == ca.Id select y.ReturnDate.ToString("MM/dd/yyyy")).FirstOrDefault()
                             };
                return result.ToList();
            }
        }
        public List<CarDetailDto> GetCarDetailDtosWithColorIdAndBrandId(int colorId, int brandId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from ca in context.Cars
                             join co in context.Colors
                             on ca.ColorId equals co.Id
                             where co.Id == colorId
                             join br in context.Brands
                             on ca.BrandId equals br.Id
                             where br.Id == brandId
                             //join ci in context.CarImages
                             //on ca.Id equals ci.CarId
                             //join re in context.Rentals
                             //on ca.Id equals re.CarId
                             select new CarDetailDto
                             {
                                 Id = ca.Id,
                                 BrandName = br.Name,
                                 ColorName = co.Name,
                                 DailyPrice = ca.DailyPrice,
                                 Description = ca.Description,
                                 ModelYear = ca.ModelYear,
                                 Model = ca.Model,
                                 ImagePath = (from x in context.CarImages where x.CarId == ca.Id select x.ImagePath).FirstOrDefault(),
                                 //ReturnDate = re.ReturnDate
                                 ReturnDate = (from y in context.Rentals orderby y.ReturnDate descending where y.CarId == ca.Id select y.ReturnDate.ToString("MM/dd/yyyy")).FirstOrDefault()
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailDtosWithBrandId(int id)
        {

            using (RentACarContext context = new RentACarContext())
            {
                var result = from ca in context.Cars
                             join co in context.Colors
                             on ca.ColorId equals co.Id
                             join br in context.Brands
                             on ca.BrandId equals br.Id where br.Id == id
                             select new CarDetailDto
                             {
                                 Id = ca.Id,
                                 BrandName = br.Name,
                                 ColorName = co.Name,
                                 DailyPrice = ca.DailyPrice,
                                 Description = ca.Description,
                                 ModelYear = ca.ModelYear,
                                 Model = ca.Model,
                                 ImagePath = (from x in context.CarImages where x.CarId == ca.Id select x.ImagePath).FirstOrDefault(),
                                 ReturnDate = (from y in context.Rentals orderby y.ReturnDate descending where y.CarId == ca.Id select y.ReturnDate.ToString("MM/dd/yyyy")).FirstOrDefault()

                             };
                
                return result.ToList();
            }
            



        }

        public List<CarDetailDto> GetCarDetailDtosWithColorId(int id)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from ca in context.Cars
                             join co in context.Colors
                             on ca.ColorId equals co.Id where co.Id == id
                             join br in context.Brands
                             on ca.BrandId equals br.Id
                             select new CarDetailDto
                             {
                                 Id = ca.Id,
                                 BrandName = br.Name,
                                 ColorName = co.Name,
                                 DailyPrice = ca.DailyPrice,
                                 Description = ca.Description,
                                 ModelYear = ca.ModelYear,
                                 Model = ca.Model,
                                 ImagePath = (from x in context.CarImages where x.CarId == ca.Id select x.ImagePath).FirstOrDefault(),
                                 ReturnDate = (from y in context.Rentals orderby y.ReturnDate descending where y.CarId == ca.Id select y.ReturnDate.ToString("MM/dd/yyyy")).FirstOrDefault()

                             };

                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsDtoWithCarId(int carId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from ca in context.Cars where ca.Id == carId
                             join co in context.Colors
                             on ca.ColorId equals co.Id
                             join br in context.Brands
                             on ca.BrandId equals br.Id
                             select new CarDetailDto
                             {
                                 Id = ca.Id,
                                 BrandName = br.Name,
                                 ColorName = co.Name,
                                 DailyPrice = ca.DailyPrice,
                                 Description = ca.Description,
                                 ModelYear = ca.ModelYear,
                                 Model = ca.Model,
                                 ReturnDate = (from y in context.Rentals orderby y.ReturnDate descending where y.CarId == ca.Id select y.ReturnDate.ToString("MM/dd/yyyy")).FirstOrDefault()


                             };

                return result.ToList();
            }
        }

        
        
    }
}
