using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarDatabaseContext>, ICustomerDal
    {
        public Customer GetByUserId(int id)
        {
            using (CarDatabaseContext context=new CarDatabaseContext())
            {
                return context.Customers.SingleOrDefault(c => c.UserId == id);
            }
        }

        public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<CustomerDetailDto, bool>> filter = null)
        {
            using (CarDatabaseContext context=new CarDatabaseContext())
            {
                var result = from cu in context.Customers
                             join us in context.Users on cu.UserId equals us.Id
                             select new CustomerDetailDto
                             {
                                 Id = cu.Id,
                                 CompanyName = cu.CompanyName,
                                 UserId = cu.UserId,
                                 FirstName = us.FirstName,
                                 LastName = us.LastName,
                                 Email = us.Email
                             };

                return filter == null
                ? result.ToList(): result.Where(filter).ToList();

            }
          
        }
    }
}
