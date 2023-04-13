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
    public partial class update02 : System.Web.UI.Page
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

                Page.DataBind();
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                    if (!Page.IsPostBack)

                        DisplayData();
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
                }
            }


        }

        public void DisplayData()
        {
            string id = Request.QueryString["id"];
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(" select * from  PLASPO.T_USER_INFO WHERE user_id= '" + id + "'", conn);
            da.Fill(ds);

            Page.DataBind();


            // 바인딩 : 각각의 컨트롤
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                user_name.Text = dr["user_name"].ToString();
                user_pw.Text = dr["user_pw"].ToString();
                user_email.Text = dr["user_email"].ToString();
                user_phone.Text = dr["user_phone"].ToString();

            }

            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

        }





        public void updateData(Object sender,
                      EventArgs e)
        {
            string id = Request.QueryString["id"];
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
                      "UPDATE PLASPO.T_USER_INFO " +
                      "SET [user_name]=@user_name,[user_pw]=@user_pw,[user_email]=@user_email,[user_phone]=@user_phone " +
                      "WHERE user_id= '" + id + "'";
                    //SqlParameter 객체 생성

                    SqlParameter user_name_para = new SqlParameter("@user_name", System.Data.SqlDbType.Text, 100);
                    SqlParameter user_pw_para = new SqlParameter("@user_pw", System.Data.SqlDbType.Text, 100);
                    SqlParameter user_email_para = new SqlParameter("@user_email", System.Data.SqlDbType.Text, 100);
                    SqlParameter user_phone_para = new SqlParameter("@user_phone", System.Data.SqlDbType.Text, 100);





                    //생성된 파라메터에 데이터 입력하기

                    user_name_para.Value = user_name.Text;
                    user_pw_para.Value = user_pw.Text;
                    user_email_para.Value = user_email.Text;
                    user_phone_para.Value = user_phone.Text;




                    //파라메터 값 대입          
                    cmd.Parameters.Add(user_name_para);
                    cmd.Parameters.Add(user_pw_para);
                    cmd.Parameters.Add(user_email_para);
                    cmd.Parameters.Add(user_phone_para);

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
                    Response.Redirect(string.Format("detail02.aspx?id=" + id));

                }
            }
        }
    }
}