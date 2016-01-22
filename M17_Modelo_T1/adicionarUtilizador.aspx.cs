using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17_Modelo_T1
{
    public partial class adicionarUtilizador : System.Web.UI.Page
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
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //confirmar se as duas passwords são iguais
            if (tbPass1.Text != tbPass2.Text)
            {
                Response.Write("<script>alert('As palavras passe não são iguais!');</script>");
                return;
            }
            //adicionar utilizador à bd
            string nome = tbNome.Text;
            string password = tbPass1.Text;
            int perfil = int.Parse(tbPerfil.Text);
            bd.adicionarUtilizador(nome, password, perfil);

        }
    }
}