using Microsoft.EntityFrameworkCore;
using Northwind_2_14_Question.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind_2_14_Question.Services
{
    public class Service_Methodscs
    {
        public static void case1_EmployeeTerritories(NorthwndContext context)
        {

            var employeeTerritories = context.Employees.Select(x => new
            {
                EmployeeID = x.EmployeeId,
                EmployeeName = x.FirstName + " " + x.LastName,
                Territories = x.Territories.Where(xe => xe.Employees.Any(xe => xe.EmployeeId == x.EmployeeId)).ToList()
            });

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine($"| {"EmployeeID",-6} | {"EmployeeName",-40} | {"Territories"} |");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ResetColor();

            foreach (var p in employeeTerritories)
            {
                string territories = "".Trim();
                foreach (var x in p.Territories)
                {
                    territories += x.TerritoryDescription.Trim() + ", ";

                }
                Console.WriteLine($"| {p.EmployeeID,-6} | {p.EmployeeName,-40} | {territories}");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ResetColor();
            Console.ReadKey();




        }

        public static void case2_OrderOrderDetails(NorthwndContext context)
        {
            var orderOrderDetails = context.Orders.Where(x => !x.OrderDetails.Any()).Select(x => new
            {
                OrderID = x.OrderId,
                CustomerID = x.CustomerId,
                OrderDate = x.OrderDate
            });


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine($"| {"OrdreID",-6} | {"CustomerID",-40} | {"OrderDate",-12} |");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ResetColor();

            if (orderOrderDetails.Count() > 0)
            {
                foreach (var p in orderOrderDetails)
                {
                    Console.WriteLine($"| {p.OrderID,-6} | {p.CustomerID,-40} | {p.OrderDate,-12} |");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                                 No data Found                              ");
                Console.ResetColor();
            }


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ResetColor();
            Console.ReadKey();

        }

        public static void case3_highestOrderProductCategory(NorthwndContext context)
        {
            var highestProductCategory = context.Products.GroupBy(x => x.Category.CategoryName).Select(x => new
            {
                CategoryName = x.Key,
                TotalQuantity = x.SelectMany(x => x.OrderDetails).Sum(x => x.Quantity)
            }).OrderByDescending(x => x.TotalQuantity).Take(1);


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine($"| {"CategoryName",-30} | {"TotalQuantity",-15} |");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ResetColor();

            foreach (var p in highestProductCategory)
            {
                Console.WriteLine($"| {p.CategoryName,-30} | {p.TotalQuantity,-15} |");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ResetColor();

        }

        public static void case4_AverageNumberOfDays(NorthwndContext context)
        {

        }

        public static void case5_ShipperTotalOrders(NorthwndContext context)
        {
            var shipperTotalOrder = context.Shippers.Select(x => new
            {
                ShipperName = x.CompanyName,
                TotalRevenue = x.Orders.Sum(x => x.Freight + x.OrderDetails.Sum(x => x.UnitPrice * x.Quantity * 1 - (decimal)x.Discount))
            });


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine($"| {"CategoryName",-30} | {"TotalQuantity",-15} |");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ResetColor();

            foreach (var p in shipperTotalOrder)
            {
                Console.WriteLine($"| {p.ShipperName,-30} | {p.TotalRevenue,-15} |");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ResetColor();
            Console.ReadKey();

        }

        public static void case6_ProductEverOrder(NorthwndContext context)
        {
            var productOrder = context.Products.Where(x => !x.OrderDetails.Any()).Select(x => new
            {
                ProductName = x.ProductName,
                CategoryName = x.Category.CategoryName
            });

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine($"| {"ProeductName",-30} | {"CategoryName",-15} |");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ResetColor();

            foreach (var p in productOrder)
            {
                Console.WriteLine($"| {p.ProductName,-30} | {p.CategoryName,-15} |");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ResetColor();
            Console.ReadKey();
        }

        public static void case7_EmployeeRank(NorthwndContext context)
        {
            var employeeRank = context.Employees.Where(x => x.Orders.Any(x => x.OrderDate.Value.Year == 1998)).Select(x => new
            {
                EmployeeName = x.FirstName + " " + x.LastName,
                TotalSales = x.Orders.Where(x => x.OrderDate.Value.Year == 1998).Sum(x => x.OrderDetails.Sum(x => x.UnitPrice * x.Quantity * (1 - (decimal)x.Discount)))
            }).OrderByDescending(x => x.TotalSales);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine($"| {"EmployeeName",-30} | {"TotalSales",-20} | {"Rank",-5} |");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.ResetColor();

            int rank = 1;
            foreach (var p in employeeRank)
            {
                Console.WriteLine($"| {p.EmployeeName,-30} | {p.TotalSales,-20} | {rank,-5} |");
                rank++;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.ResetColor();
            Console.ReadKey();

        }

        public static void case8_TotalSalesReport(NorthwndContext context)
        {
            var totalSales = context.Orders.Where(x => x.OrderDate.Value.Year == 1997).GroupBy(x=>x.OrderDate.Value.Month).Select(x => new
            {
                Month = x.Key,
                TotalSales = x.SelectMany(x=>x.OrderDetails).Where(x => x.Order.OrderDate.Value.Year == 1997).Sum(x => x.UnitPrice * x.Quantity * (1 - (decimal)x.Discount))
            }).OrderBy(x => x.Month);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine($"| {"Month",-30} | {"TotalSales",-15} |");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ResetColor();

            Hashtable months = new Hashtable()
            {
                {1,"January" },
                {2, "Febrary" },
                {3, "March" },
                {4, "April" },
                {5, "May" },
                {6, "June" },
                {7, "July" },
                {8, "August" },
                {9, "September" },
                {10, "Octomber" },
                {11, "November" },
                {12, "December" }

            };


            foreach (var p in totalSales)
            {
                Console.WriteLine($"| {months[p.Month],-30} | {p.TotalSales,-15} |");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ResetColor();
            Console.ReadKey();
        }

        public static void case9_OrderGap(NorthwndContext context)
        {
            var orderGap = context.Customers.Select(x => new
            {
                CustomerID = x.CustomerId,
                CompanyName = x.CompanyName,
                MaxGap = EF.Functions.DateDiffDay(x.Orders.OrderByDescending(o => o.OrderDate).Skip(1).Take(1).Select(o=>o.OrderDate).FirstOrDefault(), x.Orders.OrderByDescending(o => o.OrderDate).Take(1).Select(o=>o.OrderDate).FirstOrDefault())
            }).OrderByDescending(x=>x.MaxGap).Take(1);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine($"| {"CustomerID",-30} | {"CompanyName",-20} | {"MaxGap",-5} |");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.ResetColor();

            foreach (var p in orderGap)
            {
                Console.WriteLine($"| {p.CustomerID,-30} | {p.CompanyName,-20} | {p.MaxGap,-5} |");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.ResetColor();
            Console.ReadKey();
        }

        public static void case10_allProducts(NorthwndContext context)
        {
            var products = context.Products.Select(x => new
            {
                ProductID = x.ProductId,
                ProductName = x.ProductName,
                UnitInStock = x.UnitsInStock,
                UnitsOnOrder = x.UnitsOnOrder,
                ReorderLevel = x.ReorderLevel
            }).Where(x => x.ReorderLevel > x.UnitInStock + x.UnitsOnOrder);


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine($"| {"ProductID",-27} | {"ProductName",-30} | {"UnitInStock",-10} | {"UnitsOnOrder",-10} | {"ReorderLevel",-10}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();

            foreach (var p in products)
            {
                Console.WriteLine($"| {p.ProductID,-27} | {p.ProductName,-30} | {p.UnitInStock,-10} | {p.UnitsOnOrder,-10} | {p.ReorderLevel,-10} |");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();
            Console.ReadKey();
        }

        public static void case11_FrequentlyOrder(NorthwndContext context)
        {

        }

        public static void case12_discountForGermeny(NorthwndContext context)
        {
            using(var transaction  = context.Database.BeginTransaction())
            {
                try
                {
                    //context.OrderDetails.Where(x => x.Order.Customer.Country == "Germany" && x.Order.OrderDate.Value.Year == 1997)
                    //.ExecuteUpdate(s => s.SetProperty(x => x.UnitPrice, x => x.UnitPrice * 0.9m));

                    var customer = context.OrderDetails.Where(x => x.Order.Customer.Country == "Germany" && x.Order.OrderDate.Value.Year == 1997);

                    foreach (var c in customer)
                    {
                        c.Discount = 0.1f;
                    }

                    context.SaveChanges();


                    transaction.Commit();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Successfully Updated!");
                    Console.ResetColor();

                }
                catch(Exception ex) 
                {
                    transaction.Rollback();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ohhh no! Something Went Wrong Please Try Again!!");
                    Console.ResetColor();
                }
            }
        }
    }
}


