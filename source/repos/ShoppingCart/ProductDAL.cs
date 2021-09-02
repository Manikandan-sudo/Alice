using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ShoppingCart
{
    class ProductDAL
    {
        private string _connectionString;
        public ProductDAL(IConfiguration iconfiguration)
        {
            _connectionString = iconfiguration.GetConnectionString("DefaultConnection");
        }
        public List<Product> GetList()
        {
            var listProduct = new List<Product>();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_PRODUCT_GET_LIST", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        listProduct.Add(new Product
                        {
                            Id = Convert.ToInt32(rdr[0]),
                            ProductName = rdr[1].ToString(),
                            ProductCost = Convert.ToInt32(rdr[2]),
                            Active = Convert.ToBoolean(rdr[3])
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listProduct;
        }
    }
}

