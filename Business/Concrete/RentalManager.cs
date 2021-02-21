using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental) //Yorum satırına aldığım kod bloğu da çalışıyor. Daha uzun.
        {
            var result = _rentalDal.Get(r => r.CarId == rental.CarId && (r.ReturnDate == null || r.ReturnDate > DateTime.Now));

            if (result)
            {
                return new ErrorResult(Messages.RentIsFailed);
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentIsSuccess);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetByCarId(int carId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.GetById(r => r.Id == carId));
        }

        public IDataResult<Rental> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.GetById(r => r.Id == customerId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentDetails());
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
    }
}
