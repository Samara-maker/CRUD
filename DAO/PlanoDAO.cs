using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.Interface;
using CRUD.mapeamento;
using MySql.Data.MySqlClient;
using CRUD.utilitario;

namespace CRUD.DAO
{
    internal class PlanoDAO:IDAO<Plano>
    {

        public void Cadastrar(Plano plano)
        {

            try
            {

                string sql = "INSERT INTO Plano(descricao, ValorSugerido, atv) VALUES (@descricao, @ValorSugerido, @atv)";

                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@descricao", plano.descricao);
                comando.Parameters.AddWithValue("@ValorSugerido", plano.ValorSugerido);
                comando.Parameters.AddWithValue("@atv", plano.atv);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Alterar(Plano plano)
        {

            try
            {
                
                string sql = "UPDATE plano SET descricao = @descricao where id_plano = 1";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@descricao", plano.descricao);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(Plano plano)
        {

            try
            {
              


                string sql = "delete from plano where id_plano = 1";

                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

                comando.Parameters.AddWithValue("@nome", plano.descricao);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Conexao.FecharConexao();
        }

        public List<Plano> BuscarTodos()
        {
            List<Plano> planosCadastrados = new List<Plano>();
            try
            {
                string sql = "SELECT * FROM plano ORDER BY descricao";

                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

                using (MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Plano a = new Plano();
                        a.id_plano = dr.GetInt32("id_plano");
                        a.descricao = dr.GetString("descricao");
                        a.atv = dr.GetBoolean("atv");
                       
                    }

                }
                Conexao.FecharConexao();
                return planosCadastrados;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

    }
}
