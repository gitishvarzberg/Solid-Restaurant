using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.DTOs
{
    public class OrderDTOs
    {
        public int OrderId { get; set; }
        public string NameClient { get; set; }
        public DateTime Date { get; set; }
        public int DosesCount { get; set; }
    }
}
