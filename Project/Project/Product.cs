using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using System.Collections.Specialized;
using static System.Console;
namespace Project
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string ArticleNumber { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public Product() { }
        public Product(string ArticleNumber, string Name, string Description, string ImageUrl, double Price)
        {
            this.Name = Name;
            this.Price = Price;
            this.ArticleNumber = ArticleNumber;
            this.Description = Description;
            this.ImageUrl = ImageUrl;
        }



        public override string ToString()
        {
            return String.Format("{0,-20}{1,-10}{2,-10}{3,-10}{4,-10}", ArticleNumber, Name, Description, ImageUrl, Price);
        }

    }
}