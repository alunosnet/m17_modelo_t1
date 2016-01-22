using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace M17_Modelo_T1
{
    public partial class editarproduto : System.Web.UI.Page
    {
        BaseDados bd = new BaseDados();
        protected void Page_Load(object sender, EventArgs e)
        {
            //verifica se tem login feito
            if (Session["nome"] == null)
            {
                Response.Redirect("login.aspx");
                return;
            }
            //verifica se é admin
            if (Session["perfil"].Equals("0") == false)
            {
                Response.Redirect("index.aspx");
                return;
            }

            if (!IsPostBack)
            {
                try
                {
                    string strid = Request["id"].ToString();
                    int id = int.Parse(strid);
                    DataTable produto = bd.devolveProduto(id);
                    if (produto == null || produto.Rows.Count == 0)
                    {
                        Response.Redirect("produtos.aspx");
                        return;
                    }
                    lbId.Text = "Id: " + produto.Rows[0][0].ToString();
                    tbDesc.Text = produto.Rows[0][1].ToString();
                    tbPreco.Text = produto.Rows[0][2].ToString();
                    tbQuant.Text =  produto.Rows[0][3].ToString();
                    //imagem do produto
                    string ficheiro = @"~\Imagens\" + produto.Rows[0][0].ToString() + ".jpg";
                    Image1.ImageUrl = ficheiro;
                    Image1.Width = 100;
                }
                catch (Exception erro)
                {
                    Response.Redirect("produtos.aspx");
                }
            }
        }
        //atualizar
        protected void Button1_Click(object sender, EventArgs e)
        {
            //validar dados dor webform
            string strid = Request["id"].ToString();
            int id = int.Parse(strid);
            string descricao = tbDesc.Text;
            decimal preco = decimal.Parse(tbPreco.Text);
            float quantidade = float.Parse(tbQuant.Text);
            //atualizar bd
            bd.atualizarProduto(id, descricao, quantidade, preco);
            //atualizar imagem
            if (FileUpload1.HasFile == true)
            {
                if (FileUpload1.PostedFile.ContentLength > 0)
                {
                    string caminho = Server.MapPath(@"~\Imagens");
                    caminho += "\\" + id + ".jpg";
                    FileUpload1.SaveAs(caminho);
                }
            }
            //voltar
            Response.Redirect("produtos.aspx");
        }
        //voltar
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("produtos.aspx");
        }
    }
}