using Microsoft.AspNetCore.Mvc;

using ProductDatabase1.model;


namespace ProductDatabase1.CustomerDb
{

    namespace productdatabase.data
        {
            [ApiController]
            [Route("customer")]
            public class CustomerController : ControllerBase
            //test
            {
                private CustomerDb _customerdb;
                public CustomerController(IConfiguration configuration)
                {
                    Configuration = configuration;
                    _customerdb = new CustomerDb(configuration.GetConnectionString("SQL"));
                }
                public IConfiguration Configuration { get; }


                [HttpGet]
                public ActionResult Getcustomers()
                {
                    List<Customer> customers = new List<Customer>();
                    customers = _customerdb.Getallcustomers();
                    try

                    {
                        return Ok(customers);

                    }

                    catch
                    {
                        return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                    }
                }
                [HttpGet("GetById")]
                public ActionResult Getcustomer(int customer_Id)
                {

                    Customer cust;
                    cust = _customerdb.GetById(customer_Id);

                    try
                    {


                        return Ok(cust);


                    }

                    catch
                    {
                        return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                    }
                }
                [HttpPost]

                public ActionResult Addcustomers(Customer customer)

                {
                    bool result = _customerdb.Addcustomer(customer);

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
                public ActionResult Deletecustomers(int customer_Id)
                {

                    try
                    {
                        bool result = _customerdb.Deletecustomer(customer_Id);
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


                [HttpPut]
                public ActionResult Updatecustomers(int customer_Id, Customer customer)

                {
                    try
                    {
                        bool result = _customerdb.Updatecustomer(customer_Id, customer);

                        if (result)
                        {
                            return Ok("  Data Updated Successfully");

                        }
                        else
                        {
                            return BadRequest("  Data Not Updated");

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
