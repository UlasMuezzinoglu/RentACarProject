using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.Id
                             //join cs in context.Customers on r.CustomerId equals cs.Id
                             join u in context.Users on r.UserId equals u.Id
                             join b in context.Brands on c.BrandId equals b.Id


                             select new RentalDetailDto
                             {
                                 BrandName = b.Name,
                                 Id = r.Id,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear


                             };
                return result.ToList();
            }
        }
    }
}
