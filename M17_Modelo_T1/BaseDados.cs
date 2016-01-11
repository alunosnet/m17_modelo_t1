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
    }
}