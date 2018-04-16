using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Models.ViewModels
{
    public class CustomerDetailVM
    {
        public CustomerDetailVM()
        {
            Orders = new List<Order>();
        }

        public Customer Customer { get; set; }
        public List<Order> Orders { get; set; }
    }
}
