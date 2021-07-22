using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entity.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Car araba1 = new Car() { BrandId=2,ColorId=2,ModelYear=2021,Description="Son Model Bebek Gibi Araba4",DailyPrice=10 };


            //carManager.Add(car);
            //carManager.Delete(car);
            //
            //carManager.Add(car);
            //carManager.Update(new Car() { Id = 6, BrandId = 7, ColorId = 3, ModelYear = 2000, DailyPrice = 5, Description = "Dosta Gider2" });
            //

            //List<Car> result = carManager.GetById(4);

            carManager.Add(araba1);
            //carManager.Delete(araba1);

            
        }
    }
}
