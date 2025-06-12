using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.mapeamento;
using MySql.Data.MySqlClient;

//baixar pacote Nuget, para conectar com o banco de dados = MySql.data


namespace CRUD.utilitario
{
    internal class Conexao
    {

       public static MySqlConnection conexao;

        public static MySqlConnection Conectar()
        {
            try
            {
                

                string strconexao = "server=localhost;uid=root;pwd=root;port=3360;database=FitnessTraining";
                conexao = new MySqlConnection(strconexao);
                conexao.Open();
                return conexao;

            }
            catch (Exception ex)
            {
                throw new Exception("ERRO AO CONECTAR COM O BANCO DE DADOS" + ex.Message);
            }

        }
        public static void FecharConexao()
        {
            conexao.Close();
        }



    }
}
