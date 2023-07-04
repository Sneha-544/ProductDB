using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using ProductDatabase1.model;
using System.Data;
using System.Data.SqlClient;
using ProductDatabase1.model;

namespace ProductDatabase1.CustomerDb
{ 
   
    public class CustomerDb
        {

            private string _connectionStrings;
            public CustomerDb(string connectionStrings)
            {

                _connectionStrings = connectionStrings;
            }

            public List<Customer> Getallcustomers()
            {
                List<Customer> customers = new List<Customer>();//obj,model cs
                using (SqlConnection con = new SqlConnection(_connectionStrings))//to establish connection

                {
                    con.Open();
                    SqlCommand getcustomerCommand = new SqlCommand("select * from   customer", con);
                    SqlDataReader CustomerDataReader = getcustomerCommand.ExecuteReader();//read

                    while (CustomerDataReader.Read())
                    {
                        Customer customer = new Customer();
                        customer.customer_Id = CustomerDataReader.GetInt32(0);
                        customer.customer_Name = CustomerDataReader.GetString(1);
                        customer.customer_location = CustomerDataReader.GetString(2);

                        customer.phonenumber = CustomerDataReader.GetInt32(3);

                        customers.Add(customer);
                    }
                    con.Close();
                }
                return customers;
            }

            public Customer GetById(int customer_Id)
            {


                Customer customer = new Customer();
                using (SqlConnection con = new SqlConnection(_connectionStrings))
                {
                    con.Open();

                    SqlCommand getidcustomerCommand = new SqlCommand("select * From    customer  where cust_id = " + customer_Id, con);
                    SqlDataReader CustomerDataReader = getidcustomerCommand.ExecuteReader();

                    while (CustomerDataReader.Read())
                    {

                        customer.customer_Id = CustomerDataReader.GetInt32(0);
                        customer.customer_Name = CustomerDataReader.GetString(1);
                        customer.customer_location = CustomerDataReader.GetString(2);
                        customer.phonenumber = CustomerDataReader.GetInt32(3);



                    }
                    con.Close();
                }

                return customer;

            }



            public bool Addcustomer(Customer customer)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(_connectionStrings))
                    {
                        string Addcustomerquery = "insert into   customer ( cust_id, cust_name,  cust_location,phonenumber) Values ("
                            + customer.customer_Id + ",'" + customer.customer_Name + "','" + customer.customer_location + "','" + customer.phonenumber + "')";
                        con.Open();
                        SqlCommand createCustomerCommand = new SqlCommand(Addcustomerquery, con);
                        int result = createCustomerCommand.ExecuteNonQuery();
                        con.Close();

                        if (result == 1)
                        {
                            return true;

                        }
                        else
                        {
                            return false;
                        }
                    }

                }
                catch
                {
                    return false;
                }

            }





            public bool Deletecustomer(int customer_Id)
            {

                using (SqlConnection con = new SqlConnection(_connectionStrings))
                {
                    string Deletecustomerquery = "Delete From   customer  where  cust_id=" + customer_Id;
                    con.Open();
                    SqlCommand deleteCustomerCommand = new SqlCommand(Deletecustomerquery, con);
                    int result = deleteCustomerCommand.ExecuteNonQuery();
                    con.Close();



                    if (result == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            public bool Updatecustomer(int customer_Id, Customer customer)
            {
                using (SqlConnection con = new SqlConnection(_connectionStrings))
                {
                    string updateDataQuery = "UPDATE  customer SET   cust_name = '" + customer.customer_Name + "',cust_location = '" + customer.customer_location + "',phonenumber='" + customer.phonenumber + "' where cust_id=" + customer.customer_Id;
                    con.Open();
                    SqlCommand updateCommand = new SqlCommand(updateDataQuery, con);
                    int result = updateCommand.ExecuteNonQuery();
                    con.Close();

                    if (result == 1)
                    {
                        return true;

                    }
                    else
                    {
                        return false;

                    }
                }
            }

        
    }
}
