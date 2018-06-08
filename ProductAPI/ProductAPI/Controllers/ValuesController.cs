using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        //This is the product where ID and Name is returned
        public List<string> Get()
        {
            NorthwindEntities db = new NorthwindEntities();

            //List<string> products = ((from p in db.Products
            //                          select new
            //                          {
            //                              p.ProductID.ToString(),
            //                              p.ProductName
            //                          }).ToList();
            //List<string> id = (from r in db.Products
            //                   select r.ProductID.ToString()).ToList();
            //List<string> names = (from o in db.Products
            //                      select o.ProductName).ToList();
            //List<string> products = new List<string>();
            //for (int i = 0; i < id.Count; i++)
            //{
            //    products.Add(id[i].);
            //    products.Add(names[i]);

            //}
            List<Product> full = db.Products.ToList();

            List<string> products = new List<string>();

            for (int i = 0; i < full.Count; i++)
            {
                products.Add(full[i].ProductID.ToString());
                products.Add(full[i].ProductName);
            }

            return products;
        }

        // GET api/values/5
        //when id is inserted it gives all product info
        public Product Get(int id)
        {
            NorthwindEntities db = new NorthwindEntities();

            Product highest = db.Products.OrderByDescending(x => x.ProductID).First();
            int limit = highest.ProductID;
            Product lowest = db.Products.OrderBy(y => y.ProductID).First();
            int lowLimit = lowest.ProductID;

            if (id >= lowLimit && id <= limit)
            {
                Product product = (from c in db.Products
                                   where c.ProductID == id
                                   select c).Single();
                return product;
            }
            else
            {
                Product product = null;
                return product;
            }

        }

        public List<Product> GetByCategoryId(int id)
        {
            NorthwindEntities db = new NorthwindEntities();

            List<Product> products = (from c in db.Products
                               where c.CategoryID == id
                               select c).ToList();
            return products;
        }

        public List<Product> GetBySupplierId(int id)
        {
            NorthwindEntities db = new NorthwindEntities();

            List < Product > products = (from c in db.Products
                               where c.SupplierID == id
                               select c).ToList();
            return products;
        }

        public List<Product> GetByMaximumPrice(int max)
        {
            NorthwindEntities db = new NorthwindEntities();

            List<Product> products = (from c in db.Products
                               where c.UnitPrice <= max
                               select c).ToList();
            return products;
        }

        public List<Product> GetByContinuedItem(int discontinued)
        {
            NorthwindEntities db = new NorthwindEntities();

            if (discontinued == 0)
            {
                List<Product> products = (from c in db.Products
                                          where c.Discontinued == false
                                          select c).ToList();
                return products;
            }
            else if (discontinued == 1)
            {
                List<Product> products = (from c in db.Products
                                          where c.Discontinued == true
                                          select c).ToList();
                return products;
            }
            else
            {
                List <Product>  products = null;
                return products;
            }
            
        }
    }
}
