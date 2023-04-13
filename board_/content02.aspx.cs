using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace board_
{
    public partial class content02 : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //

                conn = new SqlConnection(strConn);
                conn.Open();


                getData();


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


        private void getData()
        {



            string sql = "select user_id,user_name,user_email,user_phone,user_cdatetime from PLASPO.T_USER_INFO";





            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns["user_id"].ColumnName = "아이디";
            dt.Columns["user_name"].ColumnName = "이름";
            dt.Columns["user_email"].ColumnName = "이메일";
            dt.Columns["user_phone"].ColumnName = "전화번호";
            dt.Columns["user_cdatetime"].ColumnName = "가입일";






            dataGridView1.DataSource = dt;




            dataGridView1.DataBind();

        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // 사이트명 셀 가져오기
                TableCell cell0 = e.Row.Cells[0];
                TableCell cell1 = e.Row.Cells[1];
                TableCell cell2 = e.Row.Cells[2];
                TableCell cell3 = e.Row.Cells[3];
                TableCell cell4 = e.Row.Cells[4];




                // 사이트명 셀에 링크 추가
                HyperLink link0 = new HyperLink();
                HyperLink link1 = new HyperLink();
                HyperLink link2 = new HyperLink();
                HyperLink link3 = new HyperLink();
                HyperLink link4 = new HyperLink();


                link0.Text = cell0.Text;
                link1.Text = cell1.Text;
                link2.Text = cell2.Text;
                link3.Text = cell3.Text;
                link4.Text = cell4.Text;


                link0.NavigateUrl = "detail02.aspx?id=" + DataBinder.Eval(e.Row.DataItem, "아이디").ToString();
                link1.NavigateUrl = "detail02.aspx?id=" + DataBinder.Eval(e.Row.DataItem, "아이디").ToString();
                link2.NavigateUrl = "detail02.aspx?id=" + DataBinder.Eval(e.Row.DataItem, "아이디").ToString();
                link3.NavigateUrl = "detail02.aspx?id=" + DataBinder.Eval(e.Row.DataItem, "아이디").ToString();
                link4.NavigateUrl = "detail02.aspx?id=" + DataBinder.Eval(e.Row.DataItem, "아이디").ToString();




                cell0.Controls.Clear();
                cell0.Controls.Add(link0);
                cell1.Controls.Clear();
                cell1.Controls.Add(link1);
                cell2.Controls.Clear();
                cell2.Controls.Add(link2);
                cell3.Controls.Clear();
                cell3.Controls.Add(link3);
                cell4.Controls.Clear();
                cell4.Controls.Add(link4);



            }
        }
    }
}