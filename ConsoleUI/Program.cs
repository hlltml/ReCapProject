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
            //carManager'ı ICarService interface'inden örnekledim. Tek iş sınıfı olduğu için doğrudan CarManager'dan da oluşturabilirdim.
            ICarService carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("\n-------Markaya Göre Listeleme-------");
            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
