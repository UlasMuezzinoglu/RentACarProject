using Core.DataAccess;
using Entity.Concrete;
using Entity.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();
        List<CarDetailDto> GetCarDetailsDtoWithCarId(int carId);

        List<CarDetailDto> GetCarDetailDtosWithBrandId(int id);
        List<CarDetailDto> GetCarDetailDtosWithColorId(int id);

        List<CarDetailDto> GetCarDetailDtosWithColorIdAndBrandId(int colorId, int brandId);

    }
}
