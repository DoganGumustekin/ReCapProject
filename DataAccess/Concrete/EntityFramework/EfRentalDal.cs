using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRespositoryBase<Rental, CarContext>, IRentalDal
    {
        //public List<RentalDetailDto> GetRentalDetails()
        //{
        //    using (CarContext context = new CarContext())
        //    {
        //        var result = from r in context.Rentals
        //                     join c in context.Cars
        //                     on r.CarId equals c.Id
        //                     join cm in context.Customers
        //                     on r.CustomerId equals cm.Id
        //                     join u in context.Users
        //                     on cm.UserId equals u.Id
        //                     select new RentalDetailDto
        //                     {
        //                         Description = c.Description,
        //                         FirstName = u.FirstName,
        //                         LastName = u.LastName,
        //                         RentDate = r.RentDate,
        //                         ReturnDate = r.ReturnDate
        //                     };
        //        return result.ToList();
          //  }
        //}
    }
}
