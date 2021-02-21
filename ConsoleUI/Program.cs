using Business.Abstract;
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
            //UserAddTest();
            //CustomerAddTest();

            RentalAddTest();



            //CarGetCarDetailsTest();
            //CarGetAllTest();
            //CarGetCarsByBrandIdTest(2);
            //CarGetByIdTest();
            //CarGetCarsByColorIdTest();
            //CarAddTest();
            //CarUpdateTest();
            //CarDeleteTest();

            //BrandAddTest();
            //BrandUpdateTest();
            //BrandDeleteTest();
            //BrandGetByIdTest();

            //ColorAddTest();
        }

        private static void RentalAddTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental { CarId = 1, CustomerId = 1, RentDate = DateTime.Now });
            Console.WriteLine(result.Message);
        }

        private static void CustomerAddTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer { UserId = 1 });
            customerManager.Add(new Customer { UserId = 3 });
        }

        private static void UserAddTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User { FirstName = "Fatih", LastName = "Korkut", Email = "fatih@korkut.com", Password = "12345" });
            userManager.Add(new User { FirstName = "Gökhan", LastName = "Gündoğan", Email = "gokhan@gundogan.com", Password = "12345" });
            userManager.Add(new User { FirstName = "Ezgi", LastName = "Akarsu", Email = "ezgi@akarsu.com", Password = "12345" });
        }

        private static void ColorAddTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorName = "Yeşil" });
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void BrandGetByIdTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine(brandManager.GetById(2003).Data.BrandName);
        }

        private static void BrandDeleteTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Delete(new Brand { BrandId = 2002 });
        }

        private static void BrandUpdateTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Update(new Brand { BrandId = 2002, BrandName = "Bmw" });
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void BrandAddTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandName = "Opel" });
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarGetByIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine(carManager.GetById(4));
        }

        private static void CarDeleteTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Delete(new Car { CarId = 8 });
        }

        private static void CarUpdateTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(new Car { CarId = 1, BrandId = 1004, ColorId = 2, CarName = "E220D", DailyPrice = 500, ModelYear = 2015, Description = "Otomatik benzin" });
        }

        private static void CarAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car
            {
                BrandId = 1004,
                ColorId = 1,
                CarName = "C200",
                ModelYear = 2020,
                DailyPrice = 700,
                Description = "Otomatik Dizel"
            });
        }
        
        private static void CarGetCarsByColorIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsByColorId(1).Data)
            {
                Console.WriteLine(car.CarName);
            }
        }

        private static void CarGetCarsByBrandIdTest(int id)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsByBrandId(id).Data)
            {
                Console.WriteLine(car.CarName);
            }
        }

        private static void CarGetAllTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetAll();
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName);
            }
            Console.WriteLine(result.Message); 
        }

        private static void CarGetCarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("{0} {1} {2} - {3} TL", car.ColorName, car.BrandName, car.CarName, car.DailyPrice);
            }
        }
    }
}