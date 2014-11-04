using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new CustomerService();

            var customers = service.GetCustomers();

            foreach (var customer in customers)
                System.Console.WriteLine("Id: {0}, IsVip: {1}, Credit: {2}", customer.Id, customer.IsVip, customer.Credit);

            System.Console.WriteLine("Enter customer ids to upgrade (comma separated): ");
            var input = System.Console.ReadLine();
            var ids = input
                .Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(i => int.Parse(i.Trim()));

            service.UpgradeCustomers(ids);

            customers = service.GetCustomers();

            foreach (var customer in customers)
                System.Console.WriteLine("Id: {0}, IsVip: {1}, Credit: {2}", customer.Id, customer.IsVip, customer.Credit);
        }
    }
}
