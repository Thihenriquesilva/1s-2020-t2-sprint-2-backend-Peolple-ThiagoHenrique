using senai.peoples.webapi.Domains;
using senai.peoples.webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.peoples.webapi.Repositories
{
    public class FuncionarioRepository :IFuncionarioRepository 
    {
        //private string  stringConexao = "Data Source=LAPTOP-OMA8SO3J\\SQLEXPRESS; initial catalog=M_Peoples; user Id=sa; pwd=thi@132";
        private string StringConexao = "Data Source=DEV1201\\SQLEXPRESS; initial catalog=M_Peoples; user Id=sa; pwd=sa@132";

        public List<FuncionariosDomain> Listar()
        {
            List<FuncionariosDomain> funcionarios = new List<FuncionariosDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryView = "SELECT IdFuncionario, Nome, Sobrenome, DataNascimento FROM TBL_Funcionario;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryView, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FuncionariosDomain f = new FuncionariosDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString(),
                            SobreNome = rdr["Sobrenome"].ToString(),
                            DtNascimento = Convert.ToDateTime(rdr[3])
                        };

                        funcionarios.Add(f);
                    }
                }
            }
            return funcionarios;
        }

        public  void AdicionarFuncionario(FuncionariosDomain fu)
        {

            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                string queryAdd = "INSERT INTO TBL_Funcionario(Nome, Sobrenome) VALUES (@Nome, @Sobrenome)";

                try
                {
                    SqlCommand cmd = new SqlCommand(queryAdd, con);
                    cmd.Parameters.AddWithValue("@Nome", fu.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", fu.SobreNome);
                    con.Open();
                    cmd.ExecuteNonQuery();

                }
                catch(Exception e)
                {
                    Console.WriteLine("============================");
                    Console.WriteLine("O erro é : " + e);
                    Console.WriteLine("============================");
                }
            }


        }

        public FuncionariosDomain BuscarPorId(int id)


        

        {
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string querrySelectId = "SELECT IdFuncionario, Nome, Sobrenome FROM TBL_Funcionario WHERE IdFuncionario = @ID";

                con.Open();

                SqlDataReader rdr;

                using(SqlCommand cmd = new SqlCommand(querrySelectId,con
))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FuncionariosDomain func = new FuncionariosDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),
                            Nome = rdr["Nome"].ToString(),
                            SobreNome = rdr["Sobrenome"].ToString()
                        };
                        return func;
                    }

                    return null;
                }



            }
        }

        public void AtualizarPorIdCorpo(FuncionariosDomain funcionario)
        {
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string querryAtualizar = "UPDATE TBL_Funcionario SET Nome = @Nome, Sobrenome = @Sobrenome WHERE IdFuncionario = @ID";

                using (SqlCommand cmd = new SqlCommand(querryAtualizar, con))
                {
                    cmd.Parameters.AddWithValue("@ID", funcionario.IdFuncionario);
                    cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionario.SobreNome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void AtualizarPorIdUrl(int id, FuncionariosDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querryAtualizarByID = "UPDATE TBL_Funcionario SET Nome = @Nome, Sobrenome = @Sobrenome WHERE IdFuncionario = @ID";

                using (SqlCommand cmd = new SqlCommand(querryAtualizarByID, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionario.SobreNome);

                    con.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con= new SqlConnection(StringConexao))
            {
                string querryDelete = "DELETE FROM TBL_Funcionario WHERE IdFuncionario = @ID";

                using(SqlCommand cmd = new SqlCommand(querryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }









    }
}
