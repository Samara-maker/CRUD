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
    internal class FuncionarioDAO:IDAO<Funcionario>
    {

        public void Cadastrar(Funcionario funcionario)
        {

            try
            {
                string dataNasc = funcionario.dataNasc.ToString("yyy-MM-dd");
                string dataAdmissao = funcionario.dataAdmissao.ToString("yyy-MM-dd");

                string sql = "INSERT INTO Funcionario(nome, telefone, dataAdmissao, dataNasc, email) VALUES (@nome, @telefone, @dataAdmissao, @dataNasc, @email)";

                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@nome", funcionario.nome);
                comando.Parameters.AddWithValue("@telefone", funcionario.telefone);
                comando.Parameters.AddWithValue("@dataAdmissao", dataAdmissao);
                comando.Parameters.AddWithValue("@dataNasc", dataNasc);
                comando.Parameters.AddWithValue("@email", funcionario.email);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Alterar(Funcionario funcionario)
        {

            try
            {
                string dataNasc = funcionario.dataNasc.ToString("yyy-MM-dd");
                string dataAdmissao = funcionario.dataAdmissao.ToString("yyy-MM-dd");
                string sql = "UPDATE funcionario SET nome = @nome where id_funcionario = 1";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@nome", funcionario.nome);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(Funcionario funcionario)
        {

            try
            {
                string dataNasc = funcionario.dataNasc.ToString("yyy-MM-dd");
                string dataAdmissao = funcionario.dataAdmissao.ToString("yyy-MM-dd");


                string sql = "delete from funcionario where id_funcionario = 1";

                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

                comando.Parameters.AddWithValue("@nome", funcionario.nome);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Conexao.FecharConexao();
        }

        public List<Funcionario> BuscarTodos()
        {
            List<Funcionario> funcionariosCadastrados = new List<Funcionario>();
            try
            {
                string sql = "SELECT * FROM funcionario ORDER BY nome";

                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

                using (MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Funcionario a = new Funcionario();
                        a.id_funcionario = dr.GetInt32("id_funcionario");
                        a.nome = dr.GetString("nome");
                        a.telefone = dr.GetString("telefone");
                        a.dataNasc = DateOnly.FromDateTime(dr.GetDateTime("dataNasc"));
                        a.dataAdmissao = DateOnly.FromDateTime(dr.GetDateTime("dataAdmissao"));
                        a.email = dr.GetString("email");
                    }

                }
                Conexao.FecharConexao();
                return funcionariosCadastrados;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

    }
}
