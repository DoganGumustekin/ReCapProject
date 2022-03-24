using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
              _cars = new List<Car>
              {
                  new Car{Id=1,BrandId=1,ColorId=1,DealyPrice=1500,ModelYear="2015",Description="SEDAN CONTİNENTAL GT"},
                  new Car{Id=2,BrandId=2,ColorId=2,DealyPrice=1750,ModelYear="2020",Description="SEDAN PHANTOM"},
                  new Car{Id=3,BrandId=3,ColorId=5,DealyPrice=1300,ModelYear="2018",Description="COUPE E63"},
                  new Car{Id=4,BrandId=4,ColorId=3,DealyPrice=1700,ModelYear="2021",Description="SEDAN CT6"},
                  new Car{Id=5,BrandId=5,ColorId=6,DealyPrice=1900,ModelYear="2020",Description="SUV Q8"},
              };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void AddCar(Car car)
        {
            throw new NotImplementedException();
        }

        public void Delete(Car car)
        {
            Car CarToDelete = _cars.SingleOrDefault(p=>p.Id == car.Id);

            _cars.Remove(CarToDelete);
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

        public List<Car> GetById(int colorId)
        {
            return _cars.Where(p =>p.ColorId == colorId).ToList();
        }

        public List<CarDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p=>p.Id==car.Id);

            carToUpdate.Id = car.Id;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DealyPrice = car.DealyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
            carToUpdate.BrandId = car.BrandId;
        }
    }
}
