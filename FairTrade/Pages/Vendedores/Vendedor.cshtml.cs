using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;


namespace FairTrade.Pages.Vendedores
{
    public class VendedorModel : PageModel
    {
        public List<ProdutoInfo> listProdutos = new List<ProdutoInfo>();
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
                    String sql = "SELECT * FROM Vendedores WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
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
                                vendedorInfo.foto = reader.GetString(9);

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
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=BD;Integrated Security=True;Encrypt=False";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Produtos WHERE id_vendedor=@id_vendedor";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id_vendedor", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ProdutoInfo produtoInfo = new ProdutoInfo();
                                produtoInfo.id = "" + reader.GetInt32(0);
                                produtoInfo.descricao = reader.GetString(1);
                                produtoInfo.preco = reader.GetInt32(2);
                                produtoInfo.rating = reader.GetInt32(3);
                                produtoInfo.nome = reader.GetString(4);
                                produtoInfo.tipo = reader.GetString(5);
                                produtoInfo.stock = reader.GetInt32(6);
                                produtoInfo.numprodstock = reader.GetInt32(7);
                                produtoInfo.id_vendedor = reader.GetInt32(8);
                                produtoInfo.id_feira = reader.GetInt32(9);
                                produtoInfo.foto = reader.GetString(10);

                                listProdutos.Add(produtoInfo);
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
        public class ProdutoInfo
        {
            public string id;
            public string descricao;
            public int preco;
            public int rating;
            public string nome;
            public string tipo;
            public int stock;
            public int numprodstock;
            public int id_vendedor;
            public int id_feira;
            public string foto;
        }


}


