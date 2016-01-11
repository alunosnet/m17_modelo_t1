using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace M17_Modelo_T1
{
    public partial class Clientes : System.Web.UI.Page
    {
        BaseDados bd = new BaseDados();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                atualizaGrelha();
                tbDataNascimento.Text = DateTime.Now.ToShortDateString();
            }
        }
        //adicionar cliente
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Response.Write("<script>alert('olá mundo');</script>");
            //guardar dados do webform
            try
            {
                string nome = tbNome.Text;
                string morada = tbMorada.Text;
                string cp = tbCP.Text;
                DateTime data = DateTime.Parse(tbDataNascimento.Text);
                string email = tbEmail.Text;
                //validação
                //guardar dados na bd
                bd.adicionarCliente(nome, morada, cp, data, email);
            }catch(Exception erro)
            {
                //Response.Write("<script>alert("+erro.Message+");</script>");
                Label1.Text = "Ocorreu o seguinte erro: " + erro.Message;
                return;
            }

            atualizaGrelha();
            tbNome.Text = "";
            tbMorada.Text = "";
            tbCP.Text = "";
            tbDataNascimento.Text = "";
            tbEmail.Text = "";
            //redirecionar para outra página
            //Response.Redirect("index.aspx");
        }

        private void atualizaGrelha()
        {
            DataTable dados = bd.devolveConsulta("SELECT * FROM Cliente");
            if (dados == null) return;
            //adicionar uma coluna do tipo date
            DataColumn data = new DataColumn();
            data.DataType = Type.GetType("System.String");
            data.ColumnName = "Data";
            dados.Columns.Add(data);
            //copiar os dados para coluna nova
            foreach(DataRow linha in dados.Rows)
            {
                linha[6] = DateTime.Parse(linha[5].ToString()).ToShortDateString();

            }
            //retirar a coluna do tipo datetime
            dados.Columns.RemoveAt(5);
            GridView1.DataSource = dados;
            GridView1.DataBind();
        }
        //quando o utilizador clica no link para remover
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int linha = e.RowIndex;
            string id = GridView1.Rows[linha].Cells[1].Text;
            //remover da bd
            if (bd.removerCliente(int.Parse(id)) == false){
                Response.Write("<script>alert('Não foi possível remover o cliente.');</script>");
            }
            //atualizar a grelha
            atualizaGrelha();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            atualizaGrelha();
        }
        //evento chamado quando clica no link editar
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int linha = e.NewEditIndex;
            GridView1.EditIndex = linha;
            atualizaGrelha();
        }
        //evento chamada quando clica no link atualizar
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int linha = e.RowIndex;
            int id = int.Parse(GridView1.Rows[linha].Cells[1].Text);
            string nome = ((TextBox)GridView1.Rows[linha].Cells[2].Controls[0]).Text;
            string email = ((TextBox)GridView1.Rows[linha].Cells[3].Controls[0]).Text;
            string morada = ((TextBox)GridView1.Rows[linha].Cells[4].Controls[0]).Text;
            string cp = ((TextBox)GridView1.Rows[linha].Cells[5].Controls[0]).Text;
            DateTime data= DateTime.Parse(((TextBox)GridView1.Rows[linha].Cells[6].Controls[0]).Text);
            //atualizar bd
            bd.atualizarCliente(id, nome, morada, cp, data, email);
            //atualizar grelha
            GridView1.EditIndex = -1;
            atualizaGrelha();

        }
        //evento chamada quando clica no link cancelar
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            atualizaGrelha();
        }
        //evento chamado quando é adicionada uma linha nova
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            foreach(TableCell celula in e.Row.Cells)
            {
                if(celula.Text!="" && celula.Text != "&nbsp;")
                {
                    BoundField campo = (BoundField)((DataControlFieldCell)celula).ContainingField;
                    if (campo.DataField == "id")
                        campo.ReadOnly = true;
                }
            }
        }
    }
}