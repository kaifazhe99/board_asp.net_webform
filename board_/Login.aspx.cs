using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace board_
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string strConnect = ConfigurationManager.AppSettings.Get("Connection");
            SqlConnection conn = new SqlConnection(strConnect);
            string strQuery = "SELECT * FROM PLASPO.T_USER_INFO WHERE user_id = @id AND user_pw = @pw";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = ID.Text;
            cmd.Parameters.Add("@pw", SqlDbType.VarChar).Value = PW.Text;
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                string userId = reader["user_id"].ToString();
                string userpw = reader["user_pw"].ToString();
                Session["id"] = userId;
                Session["pw"] = userpw;
                Response.Redirect(string.Format("~/?userId=" + userId));

            }
            else
            {
                Response.Write("<script>alert('아이디or비밀번호가 틀렸습니다!')</script>");
            }
            conn.Close();
        }

        private HttpSessionState GetSession()
        {
            return Session;
        }
    }
}