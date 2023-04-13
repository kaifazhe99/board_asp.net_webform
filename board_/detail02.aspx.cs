using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace board_
{
    public partial class detail02 : System.Web.UI.Page
    {
        public string strConnect;
        SqlConnection conn;
        private string strHTML = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            try
            {
                strConnect = ConfigurationManager.AppSettings.Get("Connection");

                conn = new SqlConnection(strConnect);
                conn.ConnectionString = strConnect;

                Page.DataBind();
                if (conn.State != ConnectionState.Open)
                    conn.Open();



                getDate(id);



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

        }


        public void getDate(string id)
        {

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(" select * from  PLASPO.T_USER_INFO WHERE user_id= '" + id + "'", conn);
            da.Fill(ds);



            Page.DataBind();

            strHTML = "";
            strHTML = strHTML + "<table>";
            strHTML = strHTML + "<thead>";

            strHTML = strHTML + "<tr>";
            strHTML = strHTML + " <td>아이디</td>";
            strHTML = strHTML + " <td>이름</td>";
            strHTML = strHTML + " <td>이메일</td>";
            strHTML = strHTML + " <td>폰번호</td>";
            strHTML = strHTML + " <td>등록일</td>";

            strHTML = strHTML + "</tr>";
            strHTML = strHTML + "</thead>";

            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                strHTML = strHTML + "<tr>";
                strHTML = strHTML + "<td>" + dr["user_id"].ToString() + " </td>";
                strHTML = strHTML + "<td>" + dr["user_name"].ToString() + " </td>";
                strHTML = strHTML + "<td>" + dr["user_email"].ToString() + " </td>";
                strHTML = strHTML + "<td>" + dr["user_phone"].ToString() + " </td>";
                strHTML = strHTML + "<td>" + dr["user_cdatetime"].ToString() + " </td>";
                strHTML = strHTML + "</tr>";

            }


            strHTML = strHTML + "</table>";
            litTable.Text = strHTML;
            litTable.Mode = LiteralMode.PassThrough;




        }


        public void delete(Object sender,
                           EventArgs e)
        {
            string id = Request.QueryString["id"];
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("DELETE FROM PLASPO.T_USER_INFO WHERE user_id= '" + id + "'", conn);
            da.Fill(ds);

            Response.Redirect(string.Format("content01.aspx?"));
        }

        public void update(Object sender,
                          EventArgs e)
        {
            string id = Request.QueryString["id"];
            Response.Redirect(string.Format("update02.aspx?id=" + id));

        }



        public void home(Object sender,
                           EventArgs e)
        {
            Response.Redirect(string.Format("content02.aspx?isSidebarVisible=" + true));
        }

    }
}