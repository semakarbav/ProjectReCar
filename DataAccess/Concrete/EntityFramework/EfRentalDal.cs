using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarDatabaseContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalsDetail(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            using (CarDatabaseContext context=new CarDatabaseContext())
            {
                var result = from re in context.Rentals
                             join cu in context.Customers on re.CustomerId equals cu.Id
                             join ca in context.Cars on re.CarId equals ca.Id
                             join us in context.Users on cu.UserId equals us.Id
                             join br in context.Brands  on ca.BrandId equals br.Id
                             join co in context.Colors on ca.ColorId equals co.Id
                             select new RentalDetailDto
                             {
                                 Id = re.Id,
                                 CustomerId = cu.Id,
                                 CompanyName = cu.CompanyName,
                                 CarId=ca.Id,
                                 BrandId=ca.BrandId,
                                 UserId = cu.UserId,
                                 FirstName = us.FirstName,
                                 LastName = us.LastName,
                                 Email = us.Email,
                                 CarName = ca.CarName,
                                 BrandName = br.Name,
                                 ColorId = ca.ColorId,
                                 ColorName = co.Name,
                                 ModelYear = ca.ModelYear,
                                 DailyPrice = ca.DailyPrice,
                                 RentDate = re.RentDate,
                                 ReturnDate = re.ReturnDate



                             };

                return filter == null
              ? result.ToList() : result.Where(filter).ToList();


            }
        }

  
    }
}
