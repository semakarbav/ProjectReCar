using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Transaction;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConserns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {

           // ValidationTool.Validate(new CarValidator(), car);
           

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
            
        }
        [TransactionScopeAspect]
        public IResult AddTransactionTest(Car car)
        {
            Add(car);


            if (car.DailyPrice<100)
            {
                throw new Exception("");
            }
            return Add(car);
            //return null;

        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {

            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }
        [CacheAspect]
        [PerformanceAspect(3)]
        public IDataResult<List<CarDetailDto>> GetById(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.Id == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>> (_carDal.GetCarDetails());
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandId == id), Messages.CarListed);
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>> (_carDal.GetCarDetails(c => c.ColorId == colorId));
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
