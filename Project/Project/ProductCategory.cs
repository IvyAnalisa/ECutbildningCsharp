using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using System.Collections.Specialized;
using static System.Console;

namespace Project
{
    class ProductCategory
    {
        //use Dictionary for make list of Product
        public Dictionary<string, Product> products { get; set; }
        public string Name { get; set; }

        //constructor to create new category
        public ProductCategory()
        {
            this.Name = Name;
            this.products = new Dictionary<string, Product>();

        }


        //method to add product to category.
        public void Addproduct(Product Product)
        {
            if (!products.ContainsKey(Product.Name))
            {


                products.Add(Product.Name, Product);




            }
            else
            {
                WriteLine("This product has been already added to the category." + Environment.NewLine);
            }

        }
        public void display()
        {
            WriteLine(this.Name + " (" + products.Count.ToString() + ")");
            foreach (KeyValuePair<string, Product> keyValue in products)
            {

                WriteLine("{0,-20}{1,-10}", keyValue.Value.Name, keyValue.Value.Price);

            }
        }


    }
}