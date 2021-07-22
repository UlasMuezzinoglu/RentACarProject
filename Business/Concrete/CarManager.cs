using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
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
        public void Add(Car car)
        {
            
            if (car.Description.Length <= 2 )
            {
                errorMsg = "Araç Açıklaması 2 Karakterden Büyük Olmalıdır.\n ";
            }
            if (car.DailyPrice <=0)
            {
                errorMsg += "Araç Günlük Fiyatı 0 liradan den Fazla Olmalıdır.";
                Console.WriteLine(errorMsg);
            }
            else
            {
                _carDal.Add(car);
                Console.WriteLine("Araba EntityFramework Tarafı Kullanılarak Başarı İle Eklendi " + car.Description);
            }
            
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("Araba Silindi");
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(car => car.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(car => car.ColorId == id);
        }
    }
}
