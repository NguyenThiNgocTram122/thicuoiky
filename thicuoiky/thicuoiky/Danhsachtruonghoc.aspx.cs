using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace thicuoiky
{
    public partial class Danhsachtruonghoc : System.Web.UI.Page
    {
       
             public static string tram = "Data Source=LAPTOP-00N9N4JN\\SQLEXPRESS;Initial Catalog=QL_SINHVIEN;Integrated Security=True";
        public static SqlConnection cn = new SqlConnection(tram);
        protected void Page_Load(object sender, EventArgs e)
        {
            HienThi();
        }
        void HienThi()
        {
            try
            {
                string chuoiSQL = "SELECT * FROM tbl_truong";
                SqlDataAdapter da = new SqlDataAdapter(chuoiSQL, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;

                GridView1.DataBind();
            }
            catch (Exception)
            {
                lbtthongbao.Text = "Lỗi kết nối";
            }
        }
        void ThucThi(string caulenh)
        {
            SqlCommand cm = new SqlCommand(caulenh, cn);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
        }
        Boolean kiemtra(string caulenh)
        {
            SqlDataAdapter sql = new SqlDataAdapter(caulenh, cn);
            DataTable data = new DataTable();
            sql.Fill(data);
            if (data.Rows.Count > 0)
            {
                return true;
            }
            else { return false; }
        }
        protected void btnthem_Click(object sender, EventArgs e)
        {
            txtmatruong.Text = "";
            txttentruong.Text = "";
        }
        protected void btnluu_Click(object sender, EventArgs e)
        {
            string khaibao = "select * from tbl_truong where MaTruong = '" + txtmatruong.Text + "' or TenTruong = N'" + txttentruong.Text + "'";

            if (kiemtra(khaibao))
            {

                lbtthongbao.Text = "Tên môn học đã tồn tại";
            }
            else
            {

                string them = "insert into tbl_truong values ('" + txtmatruong.Text + "' , N'" + txttentruong.Text + "')";
                ThucThi(them);
                HienThi();
            }
        }
        protected void btnsua_Click(object sender, EventArgs e)
        {
            string sua = "update tbl_truong set TenTruong = N'" + txttentruong.Text + "' where MaTruong = '" + txtmatruong.Text + "'";
            ThucThi(sua);
            HienThi();
        }
        protected void btnxoa_Click(object sender, EventArgs e)
        {
            string truyen = "delete tbl_truong where MaTruong = '" + txtmatruong.Text + "'";
            ThucThi(truyen);
            HienThi();
            txtmatruong.Text = "";
            txttentruong.Text = "";
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ngoctram = "select * from tbl_truong";
            SqlDataAdapter sqldata = new SqlDataAdapter(ngoctram, cn);
            DataTable dttable = new DataTable();
            sqldata.Fill(dttable);
            int dong = GridView1.SelectedIndex;
            int page = GridView1.PageIndex;
            txtmatruong.Text = dttable.Rows[page * 3 + dong][0].ToString();
            txttentruong.Text = dttable.Rows[page * 3 + dong][1].ToString();
        }

    }
}
    