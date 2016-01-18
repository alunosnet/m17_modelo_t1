using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace M17_Modelo_T1
{
    public partial class removerproduto : System.Web.UI.Page
    {
        BaseDados bd = new BaseDados();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string strid = Request["id"].ToString();
                    int id = int.Parse(strid);
                    DataTable produto = bd.devolveProduto(id);
                    if(produto==null || produto.Rows.Count == 0)
                    {
                        Response.Redirect("produtos.aspx");
                        return;
                    }
                    lbId.Text = "Id: " + produto.Rows[0][0].ToString();
                    lbDesc.Text = "Descrição: " + produto.Rows[0][1].ToString();
                    lbPreco.Text = "Preço: " + produto.Rows[0][2].ToString();
                    lbQuant.Text = "Quantidade: " + produto.Rows[0][3].ToString();
                    //imagem do produto
                    string ficheiro = @"~\Imagens\" + produto.Rows[0][0].ToString() + ".jpg";
                    Image1.ImageUrl = ficheiro;
                    Image1.Width = 100;
                }catch(Exception erro)
                {
                    Response.Redirect("produtos.aspx");
                }
            }
        }
        //remover
        protected void Button1_Click(object sender, EventArgs e)
        {
            string strid = Request["id"].ToString();
            int id = int.Parse(strid);
            bd.removerProduto(id);
            Response.Redirect("produtos.aspx");
        }
        //cancelar
        protected void Button2_Click(object sender, EventArgs e)
        {
            //redirecionar para página produtos
            Response.Redirect("produtos.aspx");
        }
    }
}