using System;
using blogNetCore.Dominio.Entidades.Categorias;
using blogNetCore.Dominio.Interfaces;
using MySql.Data.MySqlClient;

namespace blogNetCore.Repositorio
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        string connectionString;

        public CategoriaRepositorio(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Inserir(Categoria categoria)
        {
            using (MySqlConnection conexao = new MySqlConnection(this.connectionString))
            {
                conexao.Open();

                using (var transacao = conexao.BeginTransaction())
                {
                    try
                    {
                        MySqlCommand comando = new MySqlCommand();

                        comando.CommandText = "INSERT INTO categoria (id, descricao) VALUES (@id, @descricao)";

                        comando.Connection = conexao;

                        comando.Parameters.AddWithValue("id", categoria.id);
                        comando.Parameters.AddWithValue("descricao", categoria.descricao);

                        comando.ExecuteNonQuery();
                        
                        transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        transacao.Rollback();

                        throw new Exception(e.Message);
                    } 
                }
            }
        }

        public void Alterar(Categoria categoria)
        {
            using (MySqlConnection conexao = new MySqlConnection(this.connectionString))
            {
                conexao.Open();
                using (var transacao = conexao.BeginTransaction())
                {
                    try
                    {
                        MySqlCommand comando = new MySqlCommand();

                        comando.CommandText = "UPDATE categoria SET descricao = @descricao WHERE id = @id";

                        comando.Connection = conexao;

                        comando.Parameters.AddWithValue("id", categoria.id);
                        comando.Parameters.AddWithValue("descricao", categoria.descricao);

                        comando.ExecuteNonQuery();
                        transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        transacao.Rollback();

                        throw new Exception(e.Message);
                    } 
                }
            }
        }

        public void Excluir(Guid id)
        {
            using (MySqlConnection conexao = new MySqlConnection(this.connectionString))
            {
                conexao.Open();

                conexao.Open();
                using (var transacao = conexao.BeginTransaction())
                {
                    try
                    {
                        MySqlCommand comando = new MySqlCommand();

                        comando.CommandText = "DELETE FROM categoria WHERE id = @id";

                        comando.Connection = conexao;

                        comando.Parameters.AddWithValue("id", id);

                        comando.ExecuteNonQuery();
                        transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        transacao.Rollback();

                        throw new Exception(e.Message);
                    } 
                }
            }
        }

        public Categoria Procurar(Guid id)
        {
            Categoria categoria = null;
            
            using (MySqlConnection conexao = new MySqlConnection(this.connectionString))
            {
                conexao.Open();

                MySqlCommand comando = new MySqlCommand();

                comando.CommandText = "SELECT * FROM categoria WHERE id = @id";

                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", id);

                MySqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    categoria = new Categoria();
                    
                    while (reader.Read())
                    {
                        categoria.id = reader.GetGuid(0);
                        categoria.descricao = reader.GetString(1);
                    }
                }
            }

            return categoria;
        }
    }
}