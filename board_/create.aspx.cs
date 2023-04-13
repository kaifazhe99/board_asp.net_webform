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
    public partial class create : System.Web.UI.Page
    {
        public string strConnect;
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        public void post(Object sender,
                         EventArgs e)
        {

            try
            {
                strConnect = ConfigurationManager.AppSettings.Get("Connection");

                conn = new SqlConnection(strConnect);
                conn.ConnectionString = strConnect;

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(null, conn);
                    cmd.CommandText =
                        "INSERT INTO PLASPO.T_SITE_INFO2 " +
                        "([site_kind],[site_code],[site_name],[site_manager],[use_yn]) " +
                        "VALUES" +
                        "(@site_kind,@site_code,@site_name,@site_manager,@use_yn)";

                    //SqlParameter 객체 생성

                    SqlParameter site_kind_para = new SqlParameter("@site_kind", System.Data.SqlDbType.Text, 100);
                    SqlParameter site_code_para = new SqlParameter("@site_code", System.Data.SqlDbType.Text, 100);
                    SqlParameter site_name_para = new SqlParameter("@site_name", System.Data.SqlDbType.Text, 100);
                    SqlParameter site_manager_para = new SqlParameter("@site_manager", System.Data.SqlDbType.Text, 100);
                    SqlParameter use_yn_para = new SqlParameter("@use_yn", System.Data.SqlDbType.Text, 100);



                    //생성된 파라메터에 데이터 입력하기





                    site_kind_para.Value = site_kind.Text;
                    site_code_para.Value = site_code.Text;
                    site_name_para.Value = site_name.Text;
                    site_manager_para.Value = site_manager.Text;
                    use_yn_para.Value = use_yn.Text;



                    //파라메터 값 대입          


                    cmd.Parameters.Add(site_kind_para);
                    cmd.Parameters.Add(site_code_para);
                    cmd.Parameters.Add(site_name_para);
                    cmd.Parameters.Add(site_manager_para);
                    cmd.Parameters.Add(use_yn_para);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();


                }





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
                    Response.Redirect(string.Format("content01.aspx?"));

                }
            }
        }
    }
}