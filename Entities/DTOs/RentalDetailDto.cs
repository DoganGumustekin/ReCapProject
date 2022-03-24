using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RentalDetailDto:IDto
    {
        public string Description { get; set; }
        public string RentDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ReturnDate { get; set; }
    }
}
