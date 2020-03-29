using System.Data.SqlClient;

namespace AppNFSe
{
    public class ConexaoBanco
    {
        protected void EfetuaConexaoBanco()
        {
            // pensar aqui como vamos fazer, arquivo de conexão tipo alias ou outra sugestão
            string connectionString = "Data Source";

            // cria um novo objeto de conexão usando a string de conexão
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            // Abre conexão com o banco
            sqlConnection.Open();

            // Fecha conexão com o banco
            sqlConnection.Close();
        }
    }
}
