using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace M17_Modelo_T1
{
    public partial class venda : System.Web.UI.Page
    {
        BaseDados bd = new BaseDados();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //atualizar lista clientes
                DataTable clientes = bd.devolveConsulta("SELECT id,nome FROM cliente");
                if (clientes == null || clientes.Rows.Count == 0) return;
                foreach(DataRow linha in clientes.Rows)
                {
                    ListItem novo = new ListItem(linha[1].ToString(), linha[0].ToString());
                    ddCliente.Items.Add(novo);
                }
                //atualizar lista produtos
                DataTable produtos = bd.devolveConsulta("SELECT id,descricao FROM produto");
                if (produtos == null || produtos.Rows.Count == 0) return;
                foreach (DataRow linha in produtos.Rows)
                {
                    ListItem novo = new ListItem(linha[1].ToString(), linha[0].ToString());
                    ddProduto.Items.Add(novo);
                }
                atualizaGrelha();
            }
        }
        //registar a venda
        protected void Button1_Click(object sender, EventArgs e)
        {
            string stridProduto = ddProduto.SelectedValue;
            int idProduto = int.Parse(stridProduto);
            string stridCliente = ddCliente.SelectedValue;
            int idCliente = int.Parse(stridCliente);
            decimal preco = decimal.Parse(tbPreco.Text);
            DateTime data = DateTime.Parse(tbData.Text);
            float quantidade = float.Parse(tbQuantidade.Text);
            bd.adicionarVenda(idProduto, idCliente, quantidade, preco, data);
            //atualizar grelha
            atualizaGrelha();
            //limpar form

        }
        //autopostback==true
        protected void ddProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            //recolher da bd o preço do produto
            string strid = ddProduto.SelectedValue;
            int id = int.Parse(strid);
            DataTable produto = bd.devolveProduto(id);
            tbPreco.Text = produto.Rows[0][2].ToString();
        }
        void atualizaGrelha()
        {
            string sql = "SELECT cliente.nome,produto.descricao,venda.id, ";
            sql += " venda.preco_venda,venda.quantidade,venda.datavenda ";
            sql += " FROM Venda inner join cliente on cliente.id=venda.id_cliente ";
            sql += " inner join produto on produto.id=venda.id_produto;";
            GridView1.DataSource = bd.devolveConsulta(sql);
            GridView1.DataBind();
        }
    }
}