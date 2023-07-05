using Microsoft.AspNetCore.Mvc;


using ProductDatabase1.model;
using ProductDatabase1.model;

namespace ProductDatabase1.productDb
{
    namespace ProductDatabase1.data
    {
        [ApiController]
        [Route("product")]
        public class productController : ControllerBase
        {
            private productDb _productdb;
            public productController(IConfiguration configuration)
            {
                Configuration = configuration;
                _productdb = new productDb(Configuration.GetConnectionString("SQL"));
            }
            public IConfiguration Configuration { get; }


            [HttpGet]
            public ActionResult GetProducts()
            {
                List<Product> products = new List<Product>();
                products = _productdb.GetAll();
                try

                {
                    return Ok(products);

                }

                catch
                {
                    return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                }
            }

            [HttpGet("GetById")]
            public ActionResult GetById(int product_Id)
            {

                Product products;
                products = _productdb.GetById(product_Id);

                try
                {


                    return Ok(products);


                }

                catch
                {
                    return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                }
            }
            [HttpPost]

            public ActionResult Addproduct(Product product)

            {
                bool result = _productdb.Addproducts(product);

                try
                {
                    if (result)
                    {
                        return Ok(result);
                    }
                    else { return BadRequest("error"); }

                }

                catch
                {
                    return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                }
            }

            [HttpDelete]
            public ActionResult DeleteProduct(int product_Id)
            {

                try
                {
                    bool result = _productdb.DeleteProducts(product_Id);
                    if (result)
                    {

                        return Ok("succesfully deleted");
                    }
                    else

                    {
                        return BadRequest(" not deleted!");
                    }

                }

                catch
                {
                    return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                }

            }


        }
    }
}
