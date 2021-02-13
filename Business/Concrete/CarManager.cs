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

        public void Add()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            //Doğrudan tüm ürünleri döndük. Ancak burada if'ler ile bazı kontroller yapabiliriz öncesinde. (Yetkisi var mı vb.)
            return _carDal.GetAll();
        }

        public List<Car> GetById(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }
    }
}
