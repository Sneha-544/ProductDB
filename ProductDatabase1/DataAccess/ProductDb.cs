using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using ProductDatabase1.model;
using ProductDatabase1.model;

namespace ProductDatabase1.productDb
{
    public class productDb
    {

        private string _connectionString;
        public productDb(string connectionStrings)
        {

            _connectionString = connectionStrings;
        }

        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();//obj,model cs
            using (SqlConnection con = new SqlConnection(_connectionString))//to establish connection

            {
                con.Open();
                SqlCommand getProductCommand = new SqlCommand("select * from  product", con);
                SqlDataReader ProductDataReader = getProductCommand.ExecuteReader();//read

                while (ProductDataReader.Read())
                {
                    Product product = new Product();
                    product.product_Id = ProductDataReader.GetInt32(0);
                    product.product_name = ProductDataReader.GetString(1);
                    product.quantity = ProductDataReader.GetInt32(2);

                    product.category = ProductDataReader.GetString(3);
                    product.price = ProductDataReader.GetInt32(4);

                    products.Add(product);
                }
                con.Close();
            }
            return products;
        }


        public Product GetById(int product_Id)
        {


            Product product = new Product();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand GetIdProductCommand = new SqlCommand("select * From   product  where product_id = " + product_Id, con);
                SqlDataReader ProductDataReader = GetIdProductCommand.ExecuteReader();

                while (ProductDataReader.Read())
                {

                    product.product_Id = ProductDataReader.GetInt32(0);
                    product.product_name = ProductDataReader.GetString(1);
                    product.quantity = ProductDataReader.GetInt32(2);
                    product.category = ProductDataReader.GetString(3);
                    product.price = ProductDataReader.GetInt32(4);


                }
                con.Close();
            }

            return product;

        }



        public bool Addproducts(Product product)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string Addproductquery = "insert into  product ( product_id, product_name,  quantity,category, price) Values ("
                        + product.product_Id + ",'" + product.product_name + "','" + product.quantity + "','" + product.category + "','" + product.price + "')";
                    con.Open();
                    SqlCommand createProductCommand = new SqlCommand(Addproductquery, con);
                    int result = createProductCommand.ExecuteNonQuery();
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





        public bool DeleteProducts(int product_Id)
        {

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string DeleteProductsquery = "Delete From   product  where  product_Id=" + product_Id;
                con.Open();
                SqlCommand deleteProductCommand = new SqlCommand(DeleteProductsquery, con);
                int result = deleteProductCommand.ExecuteNonQuery();
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
