using System;
using System.Collections.Generic;
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

                using (var transacao = conexao.BeginTransaction())
                {
                    try
                    {
                        MySqlCommand comando = new MySqlCommand();

                        comando.CommandText = "INSERT INTO post (id, categoria_id, titulo, conteudo, resumo, tag) VALUES (@id, @categoria_id, @titulo, @conteudo, @resumo, @tag)";

                        comando.Connection = conexao;
                        comando.Transaction = transacao;

                        comando.Parameters.AddWithValue("id", post.id);
                        comando.Parameters.AddWithValue("categoria_id", post.categoria_id);
                        comando.Parameters.AddWithValue("titulo", post.titulo);
                        comando.Parameters.AddWithValue("conteudo", post.conteudo);
                        comando.Parameters.AddWithValue("resumo", post.resumo);
                        comando.Parameters.AddWithValue("tag", post.tag);

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

        public void Alterar(Post post)
        {
            using (MySqlConnection conexao = new MySqlConnection(this.connectionString))
            {
                conexao.Open();
                using (var transacao = conexao.BeginTransaction())
                {
                    try
                    {
                        MySqlCommand comando = new MySqlCommand();

                        comando.CommandText = "UPDATE post SET categoria_id = @categoria_id, titulo = @titulo, conteudo = @conteudo, resumo = @resumo, tag = @tag WHERE id = @id";

                        comando.Connection = conexao;

                        comando.Parameters.AddWithValue("id", post.id);
                        comando.Parameters.AddWithValue("categoria_id", post.categoria_id);
                        comando.Parameters.AddWithValue("titulo", post.titulo);
                        comando.Parameters.AddWithValue("conteudo", post.conteudo);
                        comando.Parameters.AddWithValue("resumo", post.resumo);
                        comando.Parameters.AddWithValue("tag", post.tag);

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

                using (var transacao = conexao.BeginTransaction())
                {
                    try
                    {
                        MySqlCommand comando = new MySqlCommand();

                        comando.CommandText = "DELETE FROM post WHERE id = @id";

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

        public Post Procurar(Guid id)
        {
            Post post = null;
            
            using (MySqlConnection conexao = new MySqlConnection(this.connectionString))
            {
                conexao.Open();

                MySqlCommand comando = new MySqlCommand();

                comando.CommandText = "SELECT * FROM post WHERE id = @id";

                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", id);

                MySqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    post = new Post();
                    
                    while (reader.Read())
                    {
                        post.id = reader.GetGuid(0);
                        post.categoria_id = reader.GetGuid(1);
                        post.titulo = reader.GetString(2);
                        post.conteudo = reader.GetString(3);
                        post.resumo = reader.GetString(4);
                        post.tag = reader.GetString(5);
                    }
                }
            }

            return post;
        }
        
        public List<Post> Listar()
        {
            List<Post> posts = new List<Post>();
            
            using (MySqlConnection conexao = new MySqlConnection(this.connectionString))
            {
                conexao.Open();

                MySqlCommand comando = new MySqlCommand();

                comando.CommandText = "SELECT * FROM post";

                comando.Connection = conexao;

                MySqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                { 
                    while (reader.Read())
                    {
                        var post = new Post();
                        
                        post.id = Guid.Parse(reader["id"].ToString());
                        post.categoria_id = Guid.Parse(reader["categoria_id"].ToString());
                        post.titulo = reader["titulo"].ToString();
                        post.conteudo = reader["conteudo"].ToString();
                        post.resumo = reader["resumo"].ToString();
                        post.tag = reader["tag"].ToString();
                        
                        posts.Add(post);
                    }
                }
            }

            return posts;
        }
    }
}