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
            BrandTest();
            ColorTest();
            CarTest();
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car() { BrandId = 1, ColorId = 2, ModelYear = 2019, DailyPrice = 180.00m, Description = "Programcıdan Hafif Kırık" });
            //carManager.Update(new Car() { Id = 1 ,BrandId = 1, ColorId = 2, ModelYear = 2019, DailyPrice = 180.00m, Description = "Bebek Gibi Araba" });
            //carManager.Delete(new Car() { Id = 2});
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Description);
            //}
            //Console.WriteLine(carManager.GetById(3).DailyPrice);
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            //foreach (var color in colorManager.GetAll())
            //{
            //    Console.WriteLine(color.Name);
            //}

            //Console.WriteLine(colorManager.GetById(1).Name);

            //colorManager.Add(new Color() { Name = "Mor" });
            //colorManager.Update(new Color() { Id=3, Name = "UpdatedMor" });
            //colorManager.Delete(new Color() { Id = 4});
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            //foreach (var brand in brandManager.GetAll())
            //{
            //    Console.WriteLine(brand.Name);
            //}

            //Console.WriteLine(brandManager.GetById(1).Name);

            //brandManager.Add(new Brand() { Name = "Audi" });
            //brandManager.Update(new Brand() { Id=3 ,Name = "Lamborgini" });
            //brandManager.Delete(new Brand() { Id = 7, Name = "Lamborgini" });
            
            
            
        }
    }
}
