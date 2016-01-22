using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//sqlserver
using System.Data.SqlClient;
//configuração
using System.Configuration;
//datatable
using System.Data;

namespace M17_Modelo_T1
{
    public class BaseDados
    {
        string strligacao;
        SqlConnection ligacaoBD;

        //construtor
        public BaseDados()
        {
            strligacao = ConfigurationManager.ConnectionStrings["sql"].ToString();
            ligacaoBD = new SqlConnection(strligacao);
            try
            {
                ligacaoBD.Open();
            }catch(Exception erro)
            {
                Console.Write(erro.Message);
            }
        }
        //destrutor
        ~BaseDados()
        {
            try
            {
                ligacaoBD.Close();
                ligacaoBD.Dispose();
            }catch(Exception erro)
            {
                Console.Write(erro.Message);
            }
        }
        //consultas
        public DataTable devolveConsulta(string sql)
        {
            SqlCommand comando = new SqlCommand(sql, ligacaoBD);
            DataTable registos = new DataTable();

            SqlDataReader dados = comando.ExecuteReader();
            registos.Load(dados);
            comando.Dispose();
            return registos;
        }
        public DataTable devolveConsulta(string sql,List<SqlParameter> parametros)
        {
            SqlCommand comando = new SqlCommand(sql, ligacaoBD);
            comando.Parameters.AddRange(parametros.ToArray());
            DataTable registos = new DataTable();

            SqlDataReader dados = comando.ExecuteReader();
            registos.Load(dados);
            comando.Dispose();
            return registos;
        }
        //comandos sql
        public bool executaComando(string sql)
        {
            try {
                SqlCommand comando = new SqlCommand(sql, ligacaoBD);
                comando.ExecuteNonQuery();
                comando.Dispose();
            }catch(Exception erro)
            {
                Console.Write(erro.Message);
                return false;
            }
            return true;
        }
        public bool executaComando(string sql,List<SqlParameter> parametros)
        {
            try {
                SqlCommand comando = new SqlCommand(sql, ligacaoBD);
                comando.Parameters.AddRange(parametros.ToArray());
                comando.ExecuteNonQuery();
                comando.Dispose();
            }catch(Exception erro)
            {
                Console.Write(erro.Message);
                return false;
            }
            return true;
        }
        #region Cliente
        public void adicionarCliente(string nome,string morada,string cp,DateTime data,string email)
        {
            string sql = "INSERT INTO cliente(nome,morada,cp,data_nascimento,email) VALUES ";
            sql += "(@nome,@morada,@cp,@data,@email);";
            //parâmetros
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nome",SqlDbType=System.Data.SqlDbType.VarChar,Value= nome},
                new SqlParameter() {ParameterName="@morada",SqlDbType=System.Data.SqlDbType.VarChar,Value= morada},
                new SqlParameter() {ParameterName="@cp",SqlDbType=System.Data.SqlDbType.VarChar,Value= cp},
                new SqlParameter() {ParameterName="@data",SqlDbType=System.Data.SqlDbType.Date,Value= data},
                new SqlParameter() {ParameterName="@email",SqlDbType=System.Data.SqlDbType.VarChar,Value= email}
            };
            executaComando(sql, parametros);
        }
        public bool removerCliente(int id)
        {
            string sql = "DELETE FROM cliente WHERE id=@id ";
           
            //parâmetros
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id",SqlDbType=System.Data.SqlDbType.Int,Value= id}
            };
            return executaComando(sql, parametros);
        }
        public void atualizarCliente(int id,string nome, string morada, string cp, DateTime data, string email)
        {
            string sql = "UPDATE cliente SET nome=@nome,morada=@morada,cp=@cp,";
            sql += "data_nascimento=@data,email=@email WHERE id=@id;";
            //parâmetros
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nome",SqlDbType=System.Data.SqlDbType.VarChar,Value= nome},
                new SqlParameter() {ParameterName="@morada",SqlDbType=System.Data.SqlDbType.VarChar,Value= morada},
                new SqlParameter() {ParameterName="@cp",SqlDbType=System.Data.SqlDbType.VarChar,Value= cp},
                new SqlParameter() {ParameterName="@data",SqlDbType=System.Data.SqlDbType.Date,Value= data},
                new SqlParameter() {ParameterName="@email",SqlDbType=System.Data.SqlDbType.VarChar,Value= email},
                new SqlParameter() {ParameterName="@id",SqlDbType=System.Data.SqlDbType.Int,Value= id}
            };
            executaComando(sql, parametros);
        }
        #endregion
        #region Produto
        public int adicionarProduto(string descricao,float quantidade,decimal preco)
        {
            string sql = "INSERT INTO produto(descricao,quantidade,preco) VALUES ";
            sql += "(@descricao,@quantidade,@preco);SELECT CAST(scope_identity() as int)";
            //parâmetros
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@descricao",SqlDbType=System.Data.SqlDbType.VarChar,Value= descricao},
                new SqlParameter() {ParameterName="@quantidade",SqlDbType=System.Data.SqlDbType.Float,Value= quantidade},
                new SqlParameter() {ParameterName="@preco",SqlDbType=System.Data.SqlDbType.Decimal,Value= preco}
            };
            //executaComando(sql, parametros);
            SqlCommand comando = new SqlCommand(sql, ligacaoBD);
            comando.Parameters.AddRange(parametros.ToArray());
            int id = (int)comando.ExecuteScalar();
            comando.Dispose();
            return id;
        }
        public DataTable devolveProduto(int id)
        {
            string sql = "SELECT * FROM Produto WHERE id=@id";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id",SqlDbType=System.Data.SqlDbType.Int,Value= id}
            };

            return devolveConsulta(sql, parametros);
        }
        public void removerProduto(int id)
        {
            string sql = "DELETE FROM Produto WHERE id=@id";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id",SqlDbType=System.Data.SqlDbType.Int,Value= id}
            };

            executaComando(sql, parametros);
            return;
        }
        public void atualizarProduto(int id,string descricao, float quantidade, decimal preco)
        {
            string sql = "UPDATE produto SET descricao=@descricao,quantidade=@quantidade, ";
            sql += " preco=@preco WHERE id=@id";
            //parâmetros
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@descricao",SqlDbType=System.Data.SqlDbType.VarChar,Value= descricao},
                new SqlParameter() {ParameterName="@quantidade",SqlDbType=System.Data.SqlDbType.Float,Value= quantidade},
                new SqlParameter() {ParameterName="@preco",SqlDbType=System.Data.SqlDbType.Decimal,Value= preco},
                new SqlParameter() {ParameterName="@id",SqlDbType=System.Data.SqlDbType.Int,Value= id}
            };
            executaComando(sql, parametros);
            
            return;
        }
        /* public bool removerCliente(int id)
         {
             string sql = "DELETE FROM cliente WHERE id=@id ";

             //parâmetros
             List<SqlParameter> parametros = new List<SqlParameter>()
             {
                 new SqlParameter() {ParameterName="@id",SqlDbType=System.Data.SqlDbType.Int,Value= id}
             };
             return executaComando(sql, parametros);
         }
         public void atualizarCliente(int id, string nome, string morada, string cp, DateTime data, string email)
         {
             string sql = "UPDATE cliente SET nome=@nome,morada=@morada,cp=@cp,";
             sql += "data_nascimento=@data,email=@email WHERE id=@id;";
             //parâmetros
             List<SqlParameter> parametros = new List<SqlParameter>()
             {
                 new SqlParameter() {ParameterName="@nome",SqlDbType=System.Data.SqlDbType.VarChar,Value= nome},
                 new SqlParameter() {ParameterName="@morada",SqlDbType=System.Data.SqlDbType.VarChar,Value= morada},
                 new SqlParameter() {ParameterName="@cp",SqlDbType=System.Data.SqlDbType.VarChar,Value= cp},
                 new SqlParameter() {ParameterName="@data",SqlDbType=System.Data.SqlDbType.Date,Value= data},
                 new SqlParameter() {ParameterName="@email",SqlDbType=System.Data.SqlDbType.VarChar,Value= email},
                 new SqlParameter() {ParameterName="@id",SqlDbType=System.Data.SqlDbType.Int,Value= id}
             };
             executaComando(sql, parametros);
         }*/
        #endregion
        #region venda
        public void adicionarVenda(int idproduto, int idcliente, float quantidade, decimal preco, DateTime data)
        {
            //iniciar transação
            string sql = "";
            SqlTransaction transacao = ligacaoBD.BeginTransaction();
            try
            {
                //registar venda
                sql = "INSERT INTO venda(id_cliente,id_produto,preco_venda,quantidade,datavenda) ";
                sql += " VALUES (@idCliente,@idProduto,@preco,@quantidade,@data);";
                SqlCommand comando = new SqlCommand(sql, ligacaoBD);
                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@idCliente",SqlDbType=SqlDbType.Int,Value= idcliente},
                    new SqlParameter() {ParameterName="@idProduto",SqlDbType=SqlDbType.Int,Value= idproduto},
                    new SqlParameter() {ParameterName="@preco",SqlDbType=SqlDbType.Decimal,Value= preco},
                    new SqlParameter() {ParameterName="@quantidade",SqlDbType=SqlDbType.Float,Value= quantidade},
                    new SqlParameter() {ParameterName="@data",SqlDbType=SqlDbType.Date,Value= data}
                };
                comando.Parameters.AddRange(parametros.ToArray());
                comando.Transaction = transacao;
                comando.ExecuteNonQuery();
                comando.Dispose();
                //atualizar quantidade produto
                sql = "UPDATE produto SET quantidade=quantidade-@quantidade WHERE id=@id";
                comando = new SqlCommand(sql, ligacaoBD);
                parametros.Clear();
                parametros = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@quantidade",SqlDbType=SqlDbType.Float,Value= quantidade},
                    new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value= idproduto}
                };
                comando.Parameters.AddRange(parametros.ToArray());
                comando.Transaction = transacao;
                comando.ExecuteNonQuery();
                comando.Dispose();
                //terminar commit
                transacao.Commit();
            }
            catch (Exception erro)
            {
                transacao.Rollback();
            }
        }
        #endregion
        #region Utilizadores
        public void adicionarUtilizador(string nome,string password,int perfil)
        {
            string sql = "INSERT INTO utilizador(nome,palavra_passe,perfil) VALUES ";
            sql += " (@nome,HASHBYTES('SHA1',@password),@perfil)";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nome",SqlDbType=SqlDbType.VarChar,Value= nome},
                new SqlParameter() {ParameterName="@password",SqlDbType=SqlDbType.VarChar,Value= password},
                new SqlParameter() {ParameterName="@perfil",SqlDbType=SqlDbType.Int,Value= perfil}
            };

            executaComando(sql, parametros);
            return;
        }
        public DataTable verificarLogin(string nome,string password)
        {
            string sql = "SELECT * FROM utilizador WHERE nome=@nome AND ";
            sql += " palavra_passe=cast(HASHBYTES('SHA1',@password) as varchar)";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nome",SqlDbType=SqlDbType.VarChar,Value= nome},
                new SqlParameter() {ParameterName="@password",SqlDbType=SqlDbType.VarChar,Value= password}
            };
            DataTable utilizador = devolveConsulta(sql, parametros);
            if (utilizador == null || utilizador.Rows.Count == 0)
                return null;
            return utilizador;
        }
        #endregion
    }
}