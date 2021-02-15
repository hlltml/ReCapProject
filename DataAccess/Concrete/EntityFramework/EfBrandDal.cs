using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, NorthwindContext>, IBrandDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
