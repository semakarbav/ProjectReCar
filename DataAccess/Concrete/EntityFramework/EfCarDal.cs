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
    public class EfCarDal : EfEntityRepositoryBase<Car, CarDatabaseContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto,bool>> filter=null)
        {
            using (CarDatabaseContext context=new CarDatabaseContext())
            {
                var result = from ca in context.Cars
                             join co in context.Colors on ca.ColorId equals co.Id
                             join br in context.Brands on ca.BrandId equals br.Id
                             select new CarDetailDto
                             {
                                 Id = ca.Id,
                                 CarName = ca.CarName,
                                 BrandId=ca.BrandId,
                                 ColorId=ca.ColorId,
                                 ColorName = co.Name,
                                 BrandName = br.Name,
                                 DailyPrice = ca.DailyPrice,
                                 ModelYear=ca.ModelYear,
                                 Description=ca.Description
                             };
                return filter == null
                  ? result.ToList() : result.Where(filter).ToList();




            }
        }
    }
}
