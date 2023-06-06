using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouseApp.Interfaces;
using WareHouseApp.Stores;

namespace WareHouseApp.Classes
{
    internal class Reporting : IReportingService 
    {
        private Store _store;


        public Reporting(Store store)
        {
            _store = store;
        }

        public void CreateReport(IReport report)
        {
            _store.reports.Add(report);
        }

        public void GetProfitableInvoice()
        {
            Console.WriteLine("\n-----------Profitable Invoice----------\n");
            var profInvoce = _store.reports.FindAll(r => r.IsDeleted == false);
            foreach(IReport prof in profInvoce)
            {
                prof.PrintReport();
            }
        }

        public void GetExpenseInvoice()
        {
            Console.WriteLine("\n-----------Expense Invoice----------\n");
            var profInvoce = _store.reports.FindAll(r => r.IsDeleted == true);
            foreach (var prof in profInvoce)
            {
                prof.PrintReport();
            }
        }

        public void GetProductCount()
        {
            var profInvoce = _store.reports.FindAll(r => r.IsDeleted == false);
            Console.WriteLine($"Count of products {profInvoce.Count}");
        }

        public void GetReports()
        {
            foreach (Report report in _store.reports)
            {
                report.PrintReport();
            }
        }

    }
}
