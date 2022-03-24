using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();
            //ColorTest();
            //CarAdd();
            //ColorGetAll();
            //CarGetById();
            //GetCarsByColorId();
            //RentalAdd();

        }

        private static void RentalAdd()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental { CarId = 2, CustomerId = 3, Id = 8, RentDate = "06.21.2020" });
            Console.WriteLine(result.Message);
        }

        private static void GetCarsByColorId()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarsByColorId(2);
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.Description);
            }
        }

        private static void CarGetById()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetById(1).Data;
            Console.WriteLine(result.Description);
        }

        private static void ColorGetAll()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName + " " + color.ColorId);
            }
        }

        private static void CarAdd()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.Add(new Car { Id = 12, BrandId = 2, ColorId = 1, DealyPrice = 575, ModelYear = "2011", Description = "BMW 1 GRAND COUPE" });
            Console.WriteLine(result.Message);
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            //colorManager.Add(new Color { ColorId = 6, ColorName = "Yellow" });
            //colorManager.Update(new Color { ColorId = 6, ColorName = "Yellow1" });
            var result = colorManager.Add(new Color { ColorId = 7, ColorName = "Gökkuşağı" });
            Console.WriteLine(result.Message);
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.Add(new Brand { BrandId = 5, BrandName = "Bugatti" });
            Console.WriteLine(result.Message);
            brandManager.Delete(new Brand { BrandId = 5, BrandName = "Bugatti" });
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetProductDetails();

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.DealyPrice + "\n");
                }
            }
            else
            {
                Console.WriteLine(result.Message + "\n");
            }
        }
    }
}
