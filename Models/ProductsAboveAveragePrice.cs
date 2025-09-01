using System;
using System.Collections.Generic;

namespace Northwind_2_14_Question.Models;

public partial class ProductsAboveAveragePrice
{
    public string ProductName { get; set; } = null!;

    public decimal? UnitPrice { get; set; }
}
