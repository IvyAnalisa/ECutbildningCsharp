using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using System.Collections.Specialized;
using static System.Console;
using System.IO;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;

namespace Project
{
    class Program
    {

        static void Main(string[] args)
        {
            //login 
            string username, password;
            do
            {
                WriteLine("  Enter username:");
                username = Convert.ToString(ReadLine());
                WriteLine("  Enter password:");
                password = Convert.ToString(ReadLine());

                if ((username != "Admin") || (password != "13579"))
                {
                    WriteLine("Login failed.Try again...");
                }
            } while ((username != "Admin") || (password != "13579"));
            {
                WriteLine("Login succesfully");

                List<ProductCategory> categories = new List<ProductCategory>();
                List<Product> products = new List<Product>();

                Boolean Exit = false;



                WriteLine("*******************************************************");
                WriteLine("*********         Project Arbete              *********");
                WriteLine("***** Namn: IVY ANALISA LA - Webutvecklare.Net 2021****");
                WriteLine("*******************************************************");

                do
                {
                    WriteLine("********************************");
                    WriteLine("***  1. Add product          ***");
                    WriteLine("***  2. Search product       ***");
                    WriteLine("***  3. Display Product List ***");
                    WriteLine("***  4. Add Category           ***");
                    WriteLine("***  5. Add Product to Category***");
                    WriteLine("***  6. Display List Category  ***");
                    WriteLine("***  7. Delete product ***");
                    WriteLine("***  8. Exit                   ***");
                    WriteLine("********************************");
                    ConsoleKeyInfo input = ReadKey(true);

                    switch (input.Key)
                    {
                        case ConsoleKey.D1:
                            {

                                Product newProduct = new Product();


                                do
                                {
                                    Write("Article number: ");
                                    newProduct.ArticleNumber = ReadLine();

                                    Write("Product name: ");
                                    newProduct.Name = ReadLine();

                                    Write("Descritption: ");
                                    newProduct.Description = ReadLine();

                                    Write("Image URL: ");
                                    newProduct.ImageUrl = ReadLine();

                                    Write("Price (Kr): ");
                                    newProduct.Price = double.Parse(ReadLine());

                                    WriteLine("  Is this correct Y(es) N(o)" + "\n");

                                } while (ReadKey().Key == ConsoleKey.N);

                                if (products.Equals(newProduct.Name) && ReadKey().Key == ConsoleKey.Y)
                                {

                                    throw new ArgumentException(String.Format("Product exist"));
                                }
                                else
                                {

                                    products.Add(newProduct);
                                    Console.WriteLine("A new product has been added." + Environment.NewLine);

                                }
                                Thread.Sleep(2000);



                            }
                            break;
                        case ConsoleKey.D2:
                            {
                                WriteLine("*** 2.Search Product :***");
                                WriteLine("*************************");

                                WriteLine(" Write article Number of product you want to search:");
                                string searchByID = ReadLine();

                                for (int i = 0; i < categories.Count; i++)
                                {
                                    foreach (KeyValuePair<string, Product> keyValue in categories[i].products)
                                    {
                                        if (keyValue.Value.ArticleNumber.CompareTo(searchByID) == 0)
                                        {

                                            Console.WriteLine("Result of searching: " + "\n" + products[i].ArticleNumber + "   " + products[i].Name + "   " + products[i].Description + "   " + products[i].ImageUrl + "   " + products[i].Price + "   " + Environment.NewLine);
                                        }
                                        else
                                        {
                                            WriteLine("Product doesn't exist");
                                        }
                                    }
                                }

                            }
                            break;
                        case ConsoleKey.D3:
                            {
                                WriteLine("***Product List***");
                                WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-10}", "Article Number", "Name", "Description", "Image URL", "Price");
                                WriteLine("-----------------------------------------------------------------------------------");
                                for (int i = 0; i < products.Count; i++)
                                {

                                    WriteLine(products[i].ArticleNumber + "                 " + products[i].Name + "                " + products[i].Description + "                 " + products[i].ImageUrl + "                 " + products[i].Price.ToString());
                                }
                            }
                            break;
                        case ConsoleKey.D4:
                            {
                                ProductCategory newProductCategory = new ProductCategory();
                                do
                                {


                                    Console.Write("Enter a category name: ");
                                    newProductCategory.Name = Console.ReadLine();
                                    WriteLine("Is this correct (Y)es or (N)o?" + "\n");
                                } while (ReadKey().Key == ConsoleKey.N);
                                if (ReadKey().Key == ConsoleKey.Y)
                                {
                                    throw new ArgumentException(String.Format("Category aldready  exist"));
                                }
                                else
                                {
                                    categories.Add(newProductCategory);
                                    Console.WriteLine("A new category has been added." + Environment.NewLine);
                                }



                                Thread.Sleep(2000);

                            }
                            break;
                        case ConsoleKey.D5:
                            {
                                WriteLine("***Product List***");
                                WriteLine("------------------");
                                WriteLine();
                                for (int i = 0; i < products.Count; i++)
                                {

                                    WriteLine(products[i].ArticleNumber + "    " + products[i].Name + "    " + products[i].Price.ToString());
                                }

                                Write("Select product: ");
                                int selectedProduct = int.Parse(ReadLine());

                                WriteLine("***Category List***");
                                WriteLine("------------------");
                                for (int i = 0; i < categories.Count; i++)
                                {

                                    WriteLine((i + 1).ToString() + ". " + categories[i].Name);
                                }
                                Write("Select category: ");
                                int selectedCategory = int.Parse(ReadLine());
                                categories[selectedCategory - 1].Addproduct(products[selectedProduct - 1]);
                                WriteLine("A new product has been added to category." + Environment.NewLine);

                            }
                            break;
                        case ConsoleKey.D6:
                            {

                                WriteLine();
                                WriteLine("*****************************");
                                WriteLine("List of Category ");
                                WriteLine("*****************************");
                                WriteLine("{0,-20}{1,-10}", "Name", "Price");
                                WriteLine("-----------------------------");
                                for (int i = 0; i < categories.Count; i++)
                                {
                                    categories[i].display();
                                    WriteLine("-----------------------------");
                                }
                                WriteLine();
                                WriteLine();
                            }
                            break;
                        case ConsoleKey.D7:
                            {

                                Console.Write("Enter a product name to delete: ");
                                string name = Console.ReadLine();
                                for (int i = 0; i < categories.Count; i++)
                                {
                                    foreach (KeyValuePair<string, Product> keyValue in categories[i].products)
                                    {
                                        if (keyValue.Value.Name.CompareTo(name) == 0)
                                        {
                                            categories[i].products.Remove(keyValue.Key);
                                            Console.WriteLine("A new product has been deleted from the category." + Environment.NewLine);
                                        }
                                    }
                                }
                            }
                            break;
                        case ConsoleKey.D8:
                            {
                                Exit = true;
                            }
                            return;
                        default:
                            WriteLine("Wrong input");
                            break;
                    }
                }
                while (!Exit);

            }

        }


    }
}