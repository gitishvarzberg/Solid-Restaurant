using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string NameClient { get; set; }
        public DateTime Date { get; set; }
        public int DosesCount { get; set; }
        public List<Dose> Doses { get; set; }
        public List<Employee> Employes { get; set; }

        //public Order()
        //{
        //    Doses = new List<Dose>();
        //}

    }
}
