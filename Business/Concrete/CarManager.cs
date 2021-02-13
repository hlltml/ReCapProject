using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        //Bir iş sınıfı başka sınıfları new'lemez. Bunun için constructor kullanırız. Bunu da interface'ler üzerinden yaparız.
        //Interface Injection
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
            }
            else if (car.Description.Length <2)
            {
                Console.WriteLine("Araba ismi en az 2 karakter olmalı");
            }
            else
            {
                Console.WriteLine("Arabanın günlük fiyatı 0'dan büyük olmalı");
            }

        }

        public List<Car> GetAll()
        {
            //Doğrudan tüm ürünleri döndük. Ancak burada if'ler ile bazı kontroller yapabiliriz öncesinde. (Yetkisi var mı vb.)
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }
    }
}
