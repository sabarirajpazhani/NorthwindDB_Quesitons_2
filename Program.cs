using Northwind;
using Northwind_2_14_Question.Models;
using Northwind_2_14_Question.Services;

namespace Northwind_2_14_Question
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            using(NorthwndContext context = new NorthwndContext())
            {
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("============================================================================================");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("                          Choose the Operation Northwind database                           ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("============================================================================================");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine("1.\tList each employee’s full name along with all the territories they are responsible for (comma-separated). \r\n2.\tFind all orders in the system that do not have any related OrderDetails. \r\n3.\tFind the product category with the highest total quantity ordered across all orders. \r\n4.\tFor each customer, calculate the average number of days between their orders. \r\n5.\tDisplay all shippers with the total order value they handled (based on Freight + sum of order details).\r\n6.\tFind all products that were never included in any order. \r\n7.\tRank employees by their total sales amount in 1998. \r\n8.\tGenerate a report of total sales per month for the year 1997, grouped by month. \r\n9.\tFind the customer who had the longest gap between two consecutive orders. \r\n10.\tFind all products where the current stock (UnitsInStock) + units on order is less than the reorder level. \r\n11.\tFor each product, list the top 3 other products most frequently ordered together with it. \r\n12.\tGive a 10% discount to all orders placed by customers from \"Germany\" in 1997. (Update via EF Core).\r\n13.\tDelete all orders that were never shipped (ShippedDate IS NULL). (Handle cascading deletes safely).\r\n14.\tInsert a new order for an existing customer with at least 2 order details, making sure EF Core correctly saves both the order and its details.\r\n");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("============================================================================================");
                    Console.ResetColor();

                    int Choice = 0;

                choice:
                    try
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Enter the Choice : ");
                        Console.ResetColor();
                        int choice = int.Parse(Console.ReadLine());
                        if (ValidationMethods.isChoice(choice))
                        {
                            Choice = choice;
                        }
                        else
                        {
                            goto choice;
                        }
                    }
                    catch (OverflowException ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalide Choice! Please Enter the Correct Choice!");
                        Console.ResetColor();
                        goto choice;
                    }
                    catch (FormatException ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Choice! Please Enter the Choice in Digit");
                        Console.ResetColor();
                        goto choice;
                    }

                    switch (Choice)
                    {
                        case 1:
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("1.\tList each employee’s full name along with all the territories they are responsible for (comma-separated). Output: EmployeeID | EmployeeName | Territories");
                            Console.ResetColor();
                            Console.WriteLine();

                            Service_Methodscs.case1_EmployeeTerritories(context);


                            break;

                        case 2:
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("2.\tFind all orders in the system that do not have any related OrderDetails. Output: OrderID | CustomerID | OrderDate.");
                            Console.ResetColor();
                            Console.WriteLine();

                            Service_Methodscs.case2_OrderOrderDetails(context); 
                            break;

                        case 3:
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("3.\tFind the product category with the highest total quantity ordered across all orders. Output: CategoryName | TotalQuantityOrdered.");
                            Console.ResetColor();
                            Console.WriteLine();

                            Service_Methodscs.case3_highestOrderProductCategory(context);   

                            break;

                        case 4:
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("4.\tFor each customer, calculate the average number of days between their orders. Output: CustomerID | CompanyName | AvgDaysBetweenOrders.");
                            Console.ResetColor();
                            Console.WriteLine();

                            break;

                        case 5:
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("5.\tDisplay all shippers with the total order value they handled (based on Freight + sum of order details). Output: ShipperName | TotalRevenueHandled.");
                            Console.ResetColor();
                            Console.WriteLine();

                            Service_Methodscs.case5_ShipperTotalOrders(context);    

                            break;
                        
                        case 6:
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("6.\tFind all products that were never included in any order. Output: ProductID | ProductName | CategoryName.");
                            Console.ResetColor();
                            Console.WriteLine();

                            Service_Methodscs.case6_ProductEverOrder(context);

                            break;

                        case 7:
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("7.\tRank employees by their total sales amount in 1998. Output: EmployeeName | TotalSales | Rank.");
                            Console.ResetColor();
                            Console.WriteLine();

                            Service_Methodscs.case7_EmployeeRank(context);  

                            break;

                        case 8:
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("8.\tGenerate a report of total sales per month for the year 1997, grouped by month. Output: Month | TotalSales.");
                            Console.ResetColor();
                            Console.WriteLine();

                            Service_Methodscs.case8_TotalSalesReport(context);  

                            break;

                        case 9:
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("9.\tFind the customer who had the longest gap between two consecutive orders. Output: CustomerID | CompanyName | MaxGapDays");
                            Console.ResetColor();
                            Console.WriteLine();

                            Service_Methodscs.case9_OrderGap(context);  

                            break;

                        case 10:
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("10.\tFind all products where the current stock (UnitsInStock) + units on order is less than the reorder level. Output: ProductID | ProductName | UnitsInStock | UnitsOnOrder | ReorderLevel");
                            Console.ResetColor();
                            Console.WriteLine();

                            Service_Methodscs.case10_allProducts(context);      

                            break;

                        case 11:
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("11.\tFor each product, list the top 3 other products most frequently ordered together with it. Output: ProductName | AlsoBoughtProductName | Frequency");
                            Console.ResetColor();
                            Console.WriteLine();



                            break;

                        case 12:
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("12.\tGive a 10% discount to all orders placed by customers from \"Germany\" in 1997. (Update via EF Core).");
                            Console.ResetColor();
                            Console.WriteLine();

                            Service_Methodscs.case12_discountForGermeny(context);   

                            break;

                        case 13:
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("13.\tDelete all orders that were never shipped (ShippedDate IS NULL). (Handle cascading deletes safely).");
                            Console.ResetColor();
                            Console.WriteLine();

                            Service_Methodscs.case13_DeleteAllOrder(context);

                            break;
                    }

                }
            }
        }
    }
}
