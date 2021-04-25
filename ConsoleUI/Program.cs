using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // CarTest();
            //ColorTest();
            //BrandTest();
            RentalTest();
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var addrent= rentalManager.Add(new Rental {CarId=4,CustomerId=4,RentDate=DateTime.Now});
            Console.WriteLine(addrent.Message);

        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();

            if(result.Success)
            {
                foreach (var car in result.Data)
                {
                  Console.WriteLine(car.CarName + "/"+car.ColorName + "/" + car.BrandName + "/" + car.DailyPrice);
                 }
            }
            else
            {

                Console.WriteLine(result.Message);

            }
            






        }
        private static void CarDTOTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
           
           // foreach (var car in carManager.GetAll())
           // {
            //    Console.WriteLine(car.CarName);
           // }




        }
        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            // colorManager.Add(new Color { Name = "Yellow" });
            //colorManager.Delete(new Color { Id = 1006 });
            //colorManager.Update(new Color { Id = 3,Name="Yellow" });

           /* foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Name);
            }*/


        }
        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //brandManager.Add(new Brand { Name = "KIA" });
            //brandManager.Delete(new Brand { Id = 1002 });
            //brandManager.Update(new Brand { Id =5,Name = "KIA" });

           /* foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }*/


           
        }
    }
}
