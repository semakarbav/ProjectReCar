using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>>GetAll();
        IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetById(int carId);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IResult AddTransactionTest(Car car);
    }
}
