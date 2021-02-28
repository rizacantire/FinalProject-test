using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            

            ProductManager productManager = new ProductManager(new EfProductDal());
            productManager.Add(new Product { CategoryID = 1,ProductId=1,ProductName="ürün",UnitInStock=23,UnitPrice=1566 });

        }
    }
}
