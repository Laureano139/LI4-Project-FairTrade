using FairTrade.Pages.Vendedores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace FairTrade.Pages
{
    public class ProdutoModel : PageModel
    {
        public ProdutoInfo produtoInfo = new ProdutoInfo();
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
                    String sql = "SELECT * FROM Produtos WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
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
