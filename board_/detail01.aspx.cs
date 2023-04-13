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
    public partial class detail01 : System.Web.UI.Page
    {
        public string strConnect;
        SqlConnection conn;
        private string strHTML = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            int num = (int)Convert.ToInt64(Request.QueryString["num"]);
            try
            {
                strConnect = ConfigurationManager.AppSettings.Get("Connection");

                conn = new SqlConnection(strConnect);
                conn.ConnectionString = strConnect;

                Page.DataBind();
                if (conn.State != ConnectionState.Open)
                    conn.Open();



                getDate(num);



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


        public void getDate(int num)
        {

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(" select * from  PLASPO.T_SITE_INFO2 WHERE site_seq=" + num, conn);
            da.Fill(ds);



            Page.DataBind();

            strHTML = "";
            strHTML = strHTML + "<table>";
            strHTML = strHTML + "<thead>";

            strHTML = strHTML + "<tr>";
            strHTML = strHTML + " <td>순번</td>";
            strHTML = strHTML + " <td>타입</td>";
            strHTML = strHTML + " <td>제품코드</td>";
            strHTML = strHTML + " <td>사이트명</td>";
            strHTML = strHTML + " <td>등록일</td>";
            strHTML = strHTML + " <td>사용여부</td>";
            strHTML = strHTML + "</tr>";
            strHTML = strHTML + "</thead>";

            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                strHTML = strHTML + "<tr>";
                strHTML = strHTML + "<td>" + dr["site_seq"].ToString() + " </td>";
                strHTML = strHTML + "<td>" + dr["site_kind"].ToString() + " </td>";
                strHTML = strHTML + "<td>" + dr["site_code"].ToString() + " </td>";
                strHTML = strHTML + "<td>" + dr["site_name"].ToString() + " </td>";
                strHTML = strHTML + "<td>" + dr["site_cdatetime"].ToString() + " </td>";
                strHTML = strHTML + "<td>" + dr["use_yn"].ToString() + " </td>";
                strHTML = strHTML + "</tr>";

            }


            strHTML = strHTML + "</table>";
            litTable.Text = strHTML;
            litTable.Mode = LiteralMode.PassThrough;




        }


        public void delete(Object sender,
                           EventArgs e)
        {
            int num = (int)Convert.ToInt64(Request.QueryString["num"]);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("DELETE FROM PLASPO.T_SITE_INFO2 WHERE site_seq=" + num, conn);
            da.Fill(ds);

            Response.Redirect(string.Format("content01.aspx?"));
        }

        public void update(Object sender,
                           EventArgs e)
        {
            int num = (int)Convert.ToInt64(Request.QueryString["num"]);
            Response.Redirect(string.Format("update01.aspx?num=" + num));

        }

        public void home(Object sender,
                           EventArgs e)
        {

            Response.Redirect(string.Format("content01.aspx?isSidebarVisible=" + true));
        }

    }
}