using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, NorthwindContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from r in context.Rentals
                             join c in context.Customers on r.CustomerId equals c.Id
                             join car in context.Cars on r.CarId equals car.CarId
                             join u in context.Users on c.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 RentalId = r.Id,
                                 CustomerId = c.Id,
                                 CustomerName = u.FirstName + " " + u.LastName,
                                 CarName = car.CarName,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 RentDate = r.RentDate,
                                 ReturnDate = (DateTime)r.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
