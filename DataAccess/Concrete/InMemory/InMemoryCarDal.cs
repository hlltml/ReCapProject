using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1, BrandId=1, ColorId=1, DailyPrice=400, ModelYear=2018, Description="Beyaz Mercedes C200"},
                new Car{CarId=2, BrandId=2, ColorId=2, DailyPrice=600, ModelYear=2021, Description="Siyah BMW 3.20"},
                new Car{CarId=3, BrandId=3, ColorId=1, DailyPrice=200, ModelYear=2017, Description="Beyaz Renault Megane"},
                new Car{CarId=4, BrandId=3, ColorId=3, DailyPrice=150, ModelYear=2017, Description="Kırmızı Renault Symbol"},
                new Car{CarId=5, BrandId=2, ColorId=1, DailyPrice=400, ModelYear=2015, Description="Beyaz BMW 5.20"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            ////SingleOrDefault sayesinde _cars listesini tek tek dolaşırız. Foreach mantığı. Tek bir değer arar.
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId); 
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int BrandId)
        {
            return _cars.Where(c => c.BrandId == BrandId).ToList(); 
            //Where koşulu; içindeki şarta uyan bütün elemanları yeni bir liste haline getirir ve onu döndürür. 
            //Şarta uyan elemanları bulduktan sonra ToList() ile liste haline getiriyoruz.
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public bool Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
