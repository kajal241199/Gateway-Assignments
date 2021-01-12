using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductManagement.Models;

namespace ProductManagement.Controllers
{
    public class ProductCrudController : ApiController
    {
        
        LoginDBEntities db = new LoginDBEntities();

        public IHttpActionResult GetProduct()
        {
            var results = db.Products.ToList();
            return Ok(results);
        }
        [HttpPost]
        public IHttpActionResult PostProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            /* try {
                 db.SaveChanges();
             }

             catch (DbEntityValidationException dbEx)
             {
                 foreach (var validationErrors in dbEx.EntityValidationErrors)
                 {
                     foreach (var validationError in validationErrors.ValidationErrors)
                     {
                         Trace.TraceInformation("Property: {0} Error: {1}",
                                                 validationError.PropertyName,
                                                 validationError.ErrorMessage);
                     }
                 }
             }*/
            return Ok();
        }

        public IHttpActionResult GetId(int id)
        {
            ProductClass productdetails = null;
            productdetails = db.Products.Where(x => x.Id == id).Select(x => new ProductClass()
            {
                Id = x.Id,
                Name = x.Name,
                Category = x.Category,
                Price = x.Price,
                Quantity = x.Quantity,
                Short_Description = x.Short_Description,
                Long_Description = x.Long_Description,
               



            }).FirstOrDefault<ProductClass>();
            if(productdetails == null)
            {
                return NotFound();
            }
            return Ok(productdetails);
            

        }

        public IHttpActionResult Put(ProductClass pc)
        {
            var updateproduct = db.Products.Where(x => x.Id == pc.Id).FirstOrDefault<Product>();
            if(updateproduct !=null)
            {
                updateproduct.Id = pc.Id;
                updateproduct.Name = pc.Name;
                updateproduct.Category = pc.Category;
                updateproduct.Price = pc.Price;
                updateproduct.Quantity = pc.Quantity;
                updateproduct.Short_Description = pc.Short_Description;
                updateproduct.Long_Description = pc.Long_Description;
                db.SaveChanges();
                
                /*try
                {
                    db.SaveChanges();
                }

                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("Property: {0} Error: {1}",
                                                    validationError.PropertyName,
                                                    validationError.ErrorMessage);
                        }
                    }
                }*/
            }
            else
            {
                return NotFound();
            }
            return Ok();


        }
        public IHttpActionResult Delete(int id)
        {
            var productdel = db.Products.Where(x => x.Id == id).FirstOrDefault();
            db.Entry(productdel).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();






        }
        
    }
}


    

