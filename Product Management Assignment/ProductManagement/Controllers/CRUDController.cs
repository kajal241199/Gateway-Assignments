using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductManagement.Models;
using System.Net.Http;
using System.IO;
using PagedList;
using PagedList.Mvc;


namespace ProductManagement.Controllers
{
    public class CRUDController : Controller
    {
        LoginDBEntities db = new LoginDBEntities();
        // GET: CRUD
        public ActionResult Index(string searchBy, string search, int? page,string sortBy)
        {

            ViewBag.SortEmpnameParameter = string.IsNullOrEmpty(sortBy) ? "Name desc" : "";
            ViewBag.SortEmplocationParameter = sortBy == "Category " ? "Category  desc" : "Category ";
            var products = db.Products.AsQueryable();

            //search by  Product category
            if (searchBy == "Name")
            {
                products = products.Where(x => x.Name == search || search == null);
            }
            else
            {
                //search by Product name
                products = products.Where(x => x.Category== search || search == null);

            }
            switch (sortBy)
            {
                // sorting name n descending order
                case "Name desc":
                    products = products.OrderByDescending(x => x.Name);
                    break;

                // sorting category in descending order
                case "Category desc":
                    products = products.OrderByDescending(x => x.Category);
                    break;
                //sorting category in ascending order
                case "Category":
                    products = products.OrderBy(x => x.Category);
                    break;
                default:
                    products = products.OrderBy(x => x.Name);
                    break;
            }
            return View(products.ToPagedList(page ?? 1, 3));

            IEnumerable<Product> productobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44369/api/ProductCrud");
            var consumeapi = hc.GetAsync("ProductCrud");
            consumeapi.Wait();

            var readdata = consumeapi.Result;





            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<Product>>();
                displaydata.Wait();

                productobj = displaydata.Result;
            }
            return View(productobj);








        }
        // GET Method
        public ActionResult Create()
        {
            return View();
        }

        //Create a Product
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file,Product product)
        {
           


            if (ModelState.IsValid == true)
            {
                if (file != null)
                {
                    product.Small_Image = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Image//") + product.file);


                }
            }
            else
            {
                return View();
            }
            




            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44369/api/ProductCrud");

            var insertrecord = hc.PostAsJsonAsync("ProductCrud",product);
            insertrecord.Wait();
            var savedata = insertrecord.Result;
           

            

            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");






        }
        //GET Method to display the details of the product with given id
        public ActionResult Details( int id)
        {
            ProductClass productobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44369/api/ProductCrud");

            var consumeapi = hc.GetAsync("ProductCrud?id=" + id.ToString());
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<ProductClass>();
                displaydata.Wait();
                productobj = displaydata.Result;
            }
            return View(productobj);


        }
        //GET Method to edit the product details

        public ActionResult Edit(int id)
        {
            ProductClass productobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44369/api/ProductCrud");

            var consumeapi = hc.GetAsync("ProductCrud?id=" + id.ToString());
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<ProductClass>();
                displaydata.Wait();
                productobj = displaydata.Result;
            }
            return View(productobj);

        }

        //POST METHOD
        [HttpPost]
        public ActionResult Edit(ProductClass pc)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44369/api/ProductCrud");

            var insertrecord = hc.PutAsJsonAsync<ProductClass>("ProductCrud", pc);
            insertrecord.Wait();
            var savedata = insertrecord.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.message = "Product details not updated";
            }
            return View(pc);

        }

        //GET METHOD to delete a product of the given id
        public ActionResult Delete(int id)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44369/api/ProductCrud");

            var delrecord = hc.DeleteAsync("ProductCrud/" + id.ToString());
            delrecord.Wait();

            var displaydata = delrecord.Result;
            if(displaydata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Index");
        }
    }
}