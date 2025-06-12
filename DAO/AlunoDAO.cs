using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.mapeamento;
using MySql.Data.MySqlClient;
using CRUD.utilitario;
using Org.BouncyCastle.Crypto.Digests;

namespace CRUD.DAO
{
    internal class AlunoDAO
    {

        public void Cadastrar(Aluno aluno)
        {

            try
            {
                string dataNasc = aluno.DataNasc.ToString("yyy-MM-dd");
         
                string sql = "INSERT INTO aluno(nome, CPF, DataNasc, sexo, altura, telefone) VALUES (@nome, @CPF, @DataNasc, @sexo, @altura, @telefone)";

                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@nome", aluno.nome);
                comando.Parameters.AddWithValue("@CPF", aluno.CPF);
                comando.Parameters.AddWithValue("@DataNasc", dataNasc);
                comando.Parameters.AddWithValue("@sexo", aluno.sexo);
                comando.Parameters.AddWithValue("@altura", aluno.altura);
                comando.Parameters.AddWithValue("@telefone", aluno.telefone);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public void Alterar(Aluno aluno)
        {

            try
            {
                string dataNasc = aluno.DataNasc.ToString("yyy-MM-dd");

                string sql = "UPDATE aluno SET nome = @nome where id_aluno = 1";

                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

                comando.Parameters.AddWithValue("@nome", aluno.nome);
                
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public void Delete(Aluno aluno)
        {

            try
            {
                string dataNasc = aluno.DataNasc.ToString("yyy-MM-dd");

                string sql = "delete from aluno where id_aluno = 1";

                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

                comando.Parameters.AddWithValue("@nome", aluno.nome);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            Conexao.FecharConexao();

        }

        public List<Aluno> BuscarTodos()
        {
            List<Aluno> alunosCadastrados = new List<Aluno>();
            try
            {
                string sql = "SELECT * FROM aluno ORDER BY nome";

                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

                using(MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Aluno a = new Aluno();
                        a.id_aluno = dr.GetInt32("id_aluno");
                        a.nome = dr.GetString("nome");
                        a.CPF = dr.GetString("CPF");
                        a.altura = dr.GetDouble("altura");
                        a.telefone = dr.GetString("telefone");
                        a.sexo = dr.GetString("sexo");
                        a.DataNasc = DateOnly.FromDateTime(dr.GetDateTime("DataNasc"));
                    }
                    
                }
                Conexao.FecharConexao();
                return alunosCadastrados;

            }
            catch(Exception ex) 
            {
                    throw new Exception (ex.Message);
            }
            
                
        }

    }
}
