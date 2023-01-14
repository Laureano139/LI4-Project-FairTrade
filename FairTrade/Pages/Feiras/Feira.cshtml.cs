using FairTrade.Pages.Vendedores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace FairTrade.Pages.Feiras
{
    public class FeiraModel : PageModel
    {
        public List<VendedorInfo> listVendedores = new List<VendedorInfo>();
        public String erro = "";
        public String sucesso = "";
        public void OnGet()
        {
            String id = Request.Query["id"];

            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=BD;Integrated Security=True;Encrypt=False";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Vendedores WHERE id_feira=@id_feira";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id_feira", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                VendedorInfo vendedorInfo = new VendedorInfo();
                                vendedorInfo.id = "" + reader.GetInt32(0);
                                vendedorInfo.username = reader.GetString(1);
                                vendedorInfo.nome = reader.GetString(2);
                                vendedorInfo.email = reader.GetString(3);
                                vendedorInfo.password = reader.GetString(4);
                                vendedorInfo.rating = reader.GetInt32(5);
                                vendedorInfo.metodo_pagamento = reader.GetString(6);
                                vendedorInfo.funcionario = reader.GetString(7);
                                vendedorInfo.id_feira = reader.GetInt32(8);

                                listVendedores.Add(vendedorInfo);
                            }



                        }


                    }



                }




            }
            catch (Exception ex)
            {
                erro = ex.Message;

            }
        }

    }
}
