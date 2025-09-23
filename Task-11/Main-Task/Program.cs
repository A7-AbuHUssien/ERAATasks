using System;
using System.Linq;
using Main_Task.Models;

namespace Main_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new BikeStoresContext();

            // 1 
            var query1 = from c in context.Customers
                         join o in context.Orders on c.CustomerId equals o.CustomerId
                         select new { c.FirstName, c.LastName, o.OrderId };
            
            // 2
            var query2 = context.Orders
                .Where(o => o.StaffId == 3)
                .Select(o => new { o.OrderId, o.OrderDate });
            
            // 3 
            var query3 = from p in context.Products
                         join c in context.Categories on p.CategoryId equals c.CategoryId
                         where c.CategoryName == "Mountain Bikes"
                         select new { p.ProductName };
            
            // 4 
            var query4 = context.Orders
                .GroupBy(o => o.StoreId)
                .Select(g => new { StoreId = g.Key, OrderCount = g.Count() });
            
            // 5 
            var query5 = context.Orders
                .Where(o => o.ShippedDate == null)
                .Select(o => new { o.OrderId, o.OrderDate });
            

            // 6 
            var query6 = from c in context.Customers
                         join o in context.Orders on c.CustomerId equals o.CustomerId
                         group o by new { c.FirstName, c.LastName } into g
                         select new { g.Key.FirstName, g.Key.LastName, OrderCount = g.Count() };
            
            // 7
            var query7 = context.Products
                .Where(p => !context.OrderItems.Any(oi => oi.ProductId == p.ProductId))
                .Select(p => new { p.ProductName });
            
            // 8
            var query8 = context.Stocks
                .Where(s => s.Quantity < 5)
                .Select(s => new { s.ProductId, s.Quantity });

            // 9
            var query9 = context.Products.FirstOrDefault();
            

            // 10
            var query10 = context.OrderItems
                .GroupBy(oi => oi.ProductId)
                .Select(g => new { ProductId = g.Key, TimesOrdered = g.Count() });
            
            // 11
            int year = 2022;
            var query11 = context.Products
                .Where(p => p.ModelYear == year)
                .Select(p => new { p.ProductName, p.ModelYear });
            

            // 12 
            var query12 = context.Products
                .GroupBy(p => p.CategoryId)
                .Select(g => new { CategoryId = g.Key, ProductCount = g.Count() });
            

            // 13 
            var query13 = context.Products.Average(p => p.ListPrice);
            

            // 14 
            int productId = 10;
            var query14 = context.Products.FirstOrDefault(p => p.ProductId == productId);
            

            // 15 
            var query15 = context.OrderItems
                .Where(oi => oi.Quantity > 3)
                .Select(oi => new { oi.ProductId, oi.Quantity });
            

            // 16 
            var query16 = context.Orders
                .GroupBy(o => o.StaffId)
                .Select(g => new { StaffId = g.Key, OrdersProcessed = g.Count() });
            

            // 17 
            var query17 = context.Staffs
                .Where(s => s.Active)
                .Select(s => new { s.FirstName, s.LastName, s.Phone });
            
            
            // 18 
            var query18 = context.Products
                .Select(p => new { p.ProductName });
            

            // 19
            var query19 = context.Orders
                .Where(o => o.OrderStatus == 4)
                .Select(o => new { o.OrderId, o.OrderDate });
            

            // 20 
            var query20 = context.OrderItems
                .GroupBy(oi => oi.ProductId)
                .Select(g => new { ProductId = g.Key, TotalQuantitySold = g.Sum(oi => oi.Quantity) });
            
        }
    }
}
