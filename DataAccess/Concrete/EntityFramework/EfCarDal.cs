using Core.DataAccess.EntityFramework;
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
                             select new CarDetailDto
                             {
                                 Id = ca.Id, BrandName = br.Name, ColorName = co.Name, DailyPrice = ca.DailyPrice, Description = ca.Description, ModelYear = ca.ModelYear
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
                                 ModelYear = ca.ModelYear
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
                                 ModelYear = ca.ModelYear
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
                                 ModelYear = ca.ModelYear
                             };

                return result.ToList();
            }
        }
    }
}
