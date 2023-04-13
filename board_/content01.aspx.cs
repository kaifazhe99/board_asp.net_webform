using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace board_
{
    public partial class content01 : System.Web.UI.Page
    {
        SqlConnection conn;

        string type = "전체";
        string searchType = "통합검색";
        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {
                //
               
                conn = new SqlConnection(strConn);
                conn.Open();



                getData(type, searchType);


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



        private void getData(string type, string searchType)
        {



            string sql;
            if (type == "전체")
            {
                sql = "select site_seq,site_kind,site_code,site_name,site_cdatetime,use_yn from PLASPO.T_SITE_INFO2";

                if (searchType == "사이트명")
                {
                    sql += " WHERE site_name LIKE '%" + searchTxt.Text + "%'";
                }
                else if (searchType == "제품코드")
                {
                    sql += " WHERE site_code LIKE '%" + searchTxt.Text + "%'";
                }

                else if (searchType == "통합검색")
                {
                    sql += " WHERE site_name LIKE '%" + searchTxt.Text + "%'";
                }

            }
            else
            {
                sql = "select site_seq,site_kind,site_code,site_name,site_cdatetime,use_yn from PLASPO.T_SITE_INFO2 "
                      + "WHERE (site_name LIKE '%" + searchTxt.Text + "%' OR site_code LIKE '%" + searchTxt.Text + "%' OR site_manager LIKE '%" + searchTxt.Text + "%') AND site_kind = '" + type + "'";

                if (searchType == "사이트명")
                {
                    sql += " OR site_name LIKE '%" + searchTxt.Text + "%'";
                }
                else if (searchType == "제품코드")
                {
                    sql += " OR site_code LIKE '%" + searchTxt.Text + "%'";
                }
                else if (searchType == "고객사")
                {
                    sql += " OR site_manager LIKE '%" + searchTxt.Text + "%'";
                }


            }




            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns["site_seq"].ColumnName = "사이트번호";
            dt.Columns["site_kind"].ColumnName = "사이트구분";
            dt.Columns["site_code"].ColumnName = "제품코드";
            dt.Columns["site_name"].ColumnName = "사이트명";
            dt.Columns["site_cdatetime"].ColumnName = "등록일";
            dt.Columns["use_yn"].ColumnName = "사용여부";





            dataGridView1.DataSource = dt;




            dataGridView1.DataBind();

        }


        public void typeSort(Object sender,
                      EventArgs e)
        {
            type = DropDownList1.SelectedValue;
            searchType = DropDownList1.SelectedValue;
            getData(type, searchType);

        }

        public void searchTypeSelect(Object sender,
                    EventArgs e)
        {
            searchType = DropDownList2.SelectedValue;
        }

        public void btnSearch_Click(Object sender,
                    EventArgs e)
        {
            type = DropDownList1.SelectedValue;
            searchType = DropDownList2.SelectedValue;
            getData(type, searchType);
        }

        public void btnWrite_Click(Object sender,
                    EventArgs e)
        {
            Response.Redirect(string.Format("create.aspx?"));
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //페이지 인덱스 변경
            dataGridView1.PageIndex = e.NewPageIndex;


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
                TableCell cell5 = e.Row.Cells[5];



                // 사이트명 셀에 링크 추가
                HyperLink link0 = new HyperLink();
                HyperLink link1 = new HyperLink();
                HyperLink link2 = new HyperLink();
                HyperLink link3 = new HyperLink();
                HyperLink link4 = new HyperLink();
                HyperLink link5 = new HyperLink();

                link0.Text = cell0.Text;
                link1.Text = cell1.Text;
                link2.Text = cell2.Text;
                link3.Text = cell3.Text;
                link4.Text = cell4.Text;
                link5.Text = cell5.Text;

                link0.NavigateUrl = "detail01.aspx?num=" + DataBinder.Eval(e.Row.DataItem, "사이트번호").ToString();
                link1.NavigateUrl = "detail01.aspx?num=" + DataBinder.Eval(e.Row.DataItem, "사이트번호").ToString();
                link2.NavigateUrl = "detail01.aspx?num=" + DataBinder.Eval(e.Row.DataItem, "사이트번호").ToString();
                link3.NavigateUrl = "detail01.aspx?num=" + DataBinder.Eval(e.Row.DataItem, "사이트번호").ToString();
                link4.NavigateUrl = "detail01.aspx?num=" + DataBinder.Eval(e.Row.DataItem, "사이트번호").ToString();
                link5.NavigateUrl = "detail01.aspx?num=" + DataBinder.Eval(e.Row.DataItem, "사이트번호").ToString();



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
                cell5.Controls.Clear();
                cell5.Controls.Add(link5);


            }
        }
    }
}