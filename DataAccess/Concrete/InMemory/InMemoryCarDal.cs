using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car() {Id=1,BrandId=1,ColorId=2,ModelYear=2014,DailyPrice=150,Description="Çicek Gibi Araba" },
                new Car() {Id=2,BrandId=3,ColorId=1,ModelYear=2020,DailyPrice=300,Description="Param Olsaaaaa daaaaa ben binsemmmm" },
                new Car() {Id=3,BrandId=4,ColorId=4,ModelYear=2021,DailyPrice=350,Description="Doktordan temiz" },
                new Car() {Id=4,BrandId=2,ColorId=3,ModelYear=2013,DailyPrice=120,Description="Programcıdan Hafif Kırık" }
            };
            Console.WriteLine("Sistem InMemory Alternatifine Geçti... SOLİD BEBEK GİBİ ÇALIŞIYOR YANİ HEEE");
        }


        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete;

            carToDelete = _cars.SingleOrDefault(item => item.Id == car.Id);
            _cars.Remove(carToDelete);
            
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(item => item.Id == id).ToList();
        }

        public List<CarDetailDto> GetCarDetailDtosWithBrandId(int id)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailDtosWithColorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate;

            carToUpdate = _cars.SingleOrDefault(item => item.Id == car.Id);

            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
