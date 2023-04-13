using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.Routing;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace board_
{
    public partial class SiteMaster : MasterPage
    {

        public string strConnect;
        SqlConnection conn;
        private string strHTML = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {
                strConnect = ConfigurationManager.AppSettings.Get("Connection");

                conn = new SqlConnection(strConnect);
                conn.ConnectionString = strConnect;

             
                if (conn.State != ConnectionState.Open)
                    conn.Open();


                getMenu();
                getSidebar();


            }
            catch (SqlException se)
            {
                // DB 관련 예외시 처리
                string strException = se.ErrorCode.ToString();
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }


            string userId = (string)Session["id"];

            if (userId == null)
            {
                Response.Redirect("login.aspx");
                Response.Write("<script>alert('세션만료')</script>");
            }
            else
            {
                pw.Text = (string)Session["pw"];
                id.Text = userId;
            }

            string num = (string)Convert.ToString(Request.QueryString["top"]);

            if (num != "3")
            {
                menu3.Visible = false;
              
            }





        }


        public void getMenu()
        {

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(" select * from  dbo.menu", conn);
            da.Fill(ds);



            Page.DataBind();

            strHTML = " ";



            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["top"].ToString() != "0")
                {
                    strHTML = strHTML + " <li class=\"nav-item active\">";

                    strHTML = strHTML + " <a href=\"" + dr["adress"].ToString() + "?top=" + dr["top"].ToString() + "\">" + dr["name"].ToString() + "</a></li>";

                }


            }



            Literal1.Text = strHTML;
            Literal1.Mode = LiteralMode.PassThrough;




        }


        public void getSidebar()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(" select * from  dbo.menu", conn);
            da.Fill(ds);



            Page.DataBind();

            string num = (string)Convert.ToString(Request.QueryString["top"]);

            strHTML = " ";
     

         
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["seq"].ToString() == num)
                {

                    strHTML = strHTML + " <li><a href=\"" + dr["adress"].ToString() + "?top=" + num + "\">" + dr["name"].ToString() + "</a></li>";

                }


            }
          

            Literal2.Text = strHTML;
            Literal2.Mode = LiteralMode.PassThrough;

            
        }




        public void btnLogout_Click(Object sender,
                 EventArgs e)
        {
            Session.Abandon();
            Response.AppendHeader("Refresh", "1"); // 5초 후에 페이지 새로고침 

        }
    }
}