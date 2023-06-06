using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouseApp.Classes;

namespace WareHouseApp.Interfaces
{
    internal interface IReport 
    {
        public Guid Id { get; set; }

        public Product? ProductInfo { get; set; }
        public string Description { get; set; }

        public bool IsDeleted { get; set; }
        public void PrintReport();
    }
}
