using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17_Modelo_T1
{
    public partial class produtos : System.Web.UI.Page
    {
        BaseDados bd = new BaseDados();
        protected void Page_Load(object sender, EventArgs e)
        {
            atualizaGrelha();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try {
                string desc = tbDesc.Text;
                float quant = float.Parse(tbQuant.Text);
                decimal preco = Decimal.Parse(tbPreco.Text);
                //guarda na bd
                int id=bd.adicionarProduto(desc, quant, preco);
                //guardar a imagem
                if (FileUpload1.HasFile == true)
                {
                    if (FileUpload1.PostedFile.ContentLength > 0)
                    {
                        string caminho = Server.MapPath(@"~\Imagens");
                        caminho += "\\" + id + ".jpg";
                        FileUpload1.SaveAs(caminho);
                    } 
                }
            }catch(Exception erro)
            {
                Label1.Text = "Ocorreu o seguinte erro: " + erro.Message;
                return;
            }
            //atualiza grelha
            atualizaGrelha();
            //limpar form
        }

        private void atualizaGrelha() 
        {
            DataTable dados = bd.devolveConsulta("SELECT * FROM produto");
            //limpar grelha
            GridView1.Columns.Clear();

            if (dados == null) return;
            //adicionar coluna remover
            DataColumn cRemover = new DataColumn();
            cRemover.ColumnName = "Remover";
            cRemover.DataType = Type.GetType("System.String");
            dados.Columns.Add(cRemover);
            //adicionar coluna editar
            DataColumn cEditar = new DataColumn();
            cEditar.ColumnName = "Editar";
            cEditar.DataType = Type.GetType("System.String");
            dados.Columns.Add(cEditar);
            //associar datatable
            GridView1.DataSource = dados;
            GridView1.AutoGenerateColumns = false;

            //definir colunas
            //remover
            HyperLinkField lnkRemover = new HyperLinkField();
            lnkRemover.HeaderText = "Remover";
            lnkRemover.DataTextField = "Remover";
            lnkRemover.Text = "Remover";
            lnkRemover.DataNavigateUrlFormatString = "removerproduto.aspx?id={0}";
            lnkRemover.DataNavigateUrlFields = new string[] { "id" };
            GridView1.Columns.Add(lnkRemover);

            //editar
            HyperLinkField lnkEditar = new HyperLinkField();
            lnkEditar.HeaderText = "Editar";
            lnkEditar.DataTextField = "Editar";
            lnkEditar.Text = "Editar";
            lnkEditar.DataNavigateUrlFormatString = "editarproduto.aspx?id={0}";
            lnkEditar.DataNavigateUrlFields = new string[] { "id" };
            GridView1.Columns.Add(lnkEditar);
            //id
            BoundField bfId = new BoundField();
            bfId.DataField = "id";
            bfId.HeaderText = "ID";
            GridView1.Columns.Add(bfId);

            //descrição
            BoundField bfDesc = new BoundField();
            bfDesc.DataField = "descricao";
            bfDesc.HeaderText = "Descrição";
            GridView1.Columns.Add(bfDesc);
            //preço
            BoundField bfPreco = new BoundField();
            bfPreco.DataField = "preco";
            bfPreco.HeaderText = "Preço";
            GridView1.Columns.Add(bfPreco);
            //quantidade
            BoundField bfQuant = new BoundField();
            bfQuant.DataField = "quantidade";
            bfQuant.HeaderText = "Quantidade";
            GridView1.Columns.Add(bfQuant);
            //imagem
            ImageField imagem = new ImageField();
            imagem.DataImageUrlFormatString = "~/Imagens/{0}.jpg";
            imagem.DataImageUrlField = "id";
            imagem.HeaderText = "Imagem";
            imagem.ControlStyle.Width = 100;
            GridView1.Columns.Add(imagem);

            //refresh da gridview
            GridView1.DataBind();
        }
    }
}