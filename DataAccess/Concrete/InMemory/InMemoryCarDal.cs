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
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {
            new Car{Id=1,BrandId=1,ColorId=1,CarName=  "AUDI A3",ModelYear="2019",DailyPrice=80,Description="2.El Otomatik"} ,
            new Car{Id=2,BrandId=2,ColorId=1,CarName=  "BMW X1",ModelYear="2017",DailyPrice=80,Description="2.El Otomatik"} ,
            new Car{Id=3,BrandId=1,ColorId=1,CarName=  "AUDI A4",ModelYear="2019",DailyPrice=80,Description="2.El Otomatik"} ,
            new Car{Id=4,BrandId=3,ColorId=1,CarName=  "CITROEN Berlingo",ModelYear="2020",DailyPrice=80,Description="2.El Otomatik"} ,
            new Car{Id=5,BrandId=3,ColorId=1,CarName=  "CITROEN C4 Picasso",ModelYear="2018",DailyPrice=80,Description="2.El Otomatik"} 
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.Id==car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.CarName = car.CarName;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            

        }
    }
}
