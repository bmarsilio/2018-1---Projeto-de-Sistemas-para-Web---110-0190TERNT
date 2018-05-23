using System;
using blogNetCore.Dominio.Entidades.Categorias;
using blogNetCore.Dominio.Entidades.Posts;
using blogNetCore.Dominio.Interfaces;
using MySql.Data.MySqlClient;

namespace blogNetCore.Repositorio
{
    public class PostRepositorio : IPostRepositorio
    {
        string connectionString;

        public PostRepositorio(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Inserir(Post post)
        {
            using (MySqlConnection conexao = new MySqlConnection(this.connectionString))
            {
                conexao.Open();

                MySqlCommand comando = new MySqlCommand();

                comando.CommandText = "INSERT INTO post (id, categoria_id, titulo, conteudo, resumo, tag) VALUES (@id, @categoria_id, @titulo, @conteudo, @resumo, @tag)";

                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", post.id);
                comando.Parameters.AddWithValue("categoria_id", post.categoria_id);
                comando.Parameters.AddWithValue("titulo", post.titulo);
                comando.Parameters.AddWithValue("conteudo", post.conteudo);
                comando.Parameters.AddWithValue("resumo", post.resumo);
                comando.Parameters.AddWithValue("tag", post.tag);

                comando.ExecuteNonQuery();
            }
        }

        public void Alterar(Post post)
        {
            /*
            using (MySqlConnection conexao = new MySqlConnection(this.connectionString))
            {
                conexao.Open();

                MySqlCommand comando = new MySqlCommand();

                comando.CommandText = "UPDATE categoria SET descricao = @descricao WHERE id = @id";

                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", categoria.id);
                comando.Parameters.AddWithValue("descricao", categoria.descricao);

                comando.ExecuteNonQuery();
            }
            */
        }

        public void Excluir(Guid id)
        {
            /*
            using (MySqlConnection conexao = new MySqlConnection(this.connectionString))
            {
                conexao.Open();

                MySqlCommand comando = new MySqlCommand();

                comando.CommandText = "DELETE FROM categoria WHERE id = @id";

                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", id);

                comando.ExecuteNonQuery();
            }
            */
        }

        public Post Procurar(Guid id)
        {
            /*
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
            */
            return null;
        }
    }
}