using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQDemo
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Company { get; set; }

        public int Price { get; set; }

        public override string ToString()
        {
            return $"ID={Id}, Name={Name}, Company={Company}, Price={Price}";
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
           List<Product> products = new List<Product>()
                {
                    new Product { Id = 1, Name = "Laptop", Company = "HP", Price = 40000 },
                    new Product { Id = 2, Name = "Mouse", Company = "Dell", Price = 300 },
                    new Product { Id = 3, Name = "KeyBord", Company = "Apple", Price = 599 },
                    new Product { Id = 4, Name = "Moniter", Company = "HP", Price = 20000 },
                    new Product { Id = 5, Name = "CPU", Company = "Apple", Price = 35000 },
                    new Product { Id = 6, Name = "PenDrive", Company = "HP", Price = 600 },
                    new Product { Id = 7, Name = "HardDisk", Company = "Dell", Price = 4000 },
                    new Product { Id = 8, Name = "SSD", Company = "Apple", Price = 6999 },
                    new Product { Id= 9,  Name="Laptop",Company="Dell",Price=45000},
                    new Product { Id= 10,  Name="Laptop",Company="Microsoft",Price=55000},
                    new Product { Id = 11, Name = "Mouse", Company = "Apple", Price = 1500 }

                };

            //display Product whose price is >1000
            var qry= from p in products
                     where p.Price>1000
                     select p;

            foreach(var p in qry)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();
            //display Product Whose Company Name is Dell
            var qry1=from p in products
                     where p.Company.Contains("Dell")
                     select p;
            foreach(var p in qry1)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();
            //display Product Whose Company Name i starts with A
            var qry2 = from p in products
                       where p.Company.StartsWith("A")
                       select p;
            foreach(var p in qry2)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();

            //LAMDA
            Console.WriteLine("---------LAMDA---------");
            Console.WriteLine();
            var qry4= products.Where(x=>x.Price>1000).ToList();
            foreach(var p in qry4)
            {
                Console.WriteLine(p);
            }
            //Var qry = employee.where(x => x.Id == 1).FirstOrDefault();
            Console.WriteLine();

            var qry5 = products.Where(x => x.Company == "Apple").ToList();
            foreach(var p in qry5)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("-------------------Q1-----------------------");
            //Display all products using LINQ query
            var q1 =from p in products
                    select p;
            foreach (var p in q1)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("-------------------Q2-----------------------");
            //Display products whose price is greater than 1500
            var q2 = from p in products
                     where p.Price>1500
                     select p;
            foreach(var p2 in q2)
            {
                Console.WriteLine(p2);
            }
            Console.WriteLine("-------------------Q3-----------------------");
            //Display products whose price is in between 10000 to 40000
            var q3 = from p in products
                     where p.Price > 10000 && p.Price < 40000
                     select p;
             foreach(var item in q3)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------Q4-----------------------");
            //Display products of Dell company
            var q4 = from p in products
                       where p.Company.Contains("Dell")
                       select p;
            foreach (var p in q4)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("-------------------Q5-----------------------");
            //Display all company laptops
            var q5 = from p in products
                     where p.Name.Contains("Laptop")
                     select p;
            foreach(var item in q5)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------Q6-----------------------");

            //Display products whose company name start with ‘M’
            var q6 = from p in products
                     where p.Name.StartsWith("M")
                     select p;
            foreach( var item in q6)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------Q7-----------------------");

            //Display all company mouse whose price is less than 1000
            var q7 = from p in products
                     where p.Name.Contains("Mouse") && p.Price < 1000
                     select p;
            foreach( var item in q7)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------Q8-----------------------");

            //Display all products descending order by their price
            var q8= from p in products
                    orderby p.Price descending
                    select p;
            foreach (var item in q8)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------Q9-----------------------");
            //Display all products accessing order by their company name
            var q9= from p in products
                    orderby p.Company ascending
                    select p;
            foreach(var item in q9)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------Q10-----------------------");
            //Display all keyboards accessing order by their price
            var q10 = from p in products
                      where p.Name.Contains("KeyBord")
                      orderby p.Price ascending
                      select p;
            foreach(var item in q10)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine("---------------Using LAMDA--------------------- ");
            Console.WriteLine();

            Console.WriteLine("-------------------Q1-----------------------");

            //Display all products descending order by their price
            //Var qry = employee.where(x => x.Id == 1).FirstOrDefault();

            var l1 = products.OrderByDescending(x => x.Price);
            foreach( var item in l1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------Q2-----------------------");
            //Display product whose Id is 5
            var l2 = products.Where(x => x.Id == 5);
            foreach( var item in l2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------Q3-----------------------");
            //Display all products whose price less than 5000
            var l3 = products.Where(x => x.Price < 5000);
            foreach( var item in l3)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------Q4-----------------------");
            //Display 3 products which have maximum price
            var l4 = products.OrderByDescending(x=>x.Price).Take(3);
            foreach (var item in l4)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------Q5-----------------------");
            //Display 5 products which have minimum price
            var l5 = products.OrderBy(x=>x.Price).Take(5);
            foreach (var item in l5)
            {
                Console.WriteLine(item);
            }

        }
    }
}
