using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginDemo
{
    public partial class FormMain : Form
    {

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=classtime;Persist Security Info=True;User ID=sa;Password=admin");
        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“classtimeDataSet1.teacher”中。您可以根据需要移动或删除它。
            this.teacherTableAdapter.Fill(this.classtimeDataSet1.teacher);
            // TODO: 这行代码将数据加载到表“classtimeDataSet.clatime”中。您可以根据需要移动或删除它。
            this.clatimeTableAdapter.Fill(this.classtimeDataSet.clatime);
            // TODO: 这行代码将数据加载到表“tESTDataSet.Student”中。您可以根据需要移动或删除它。
            this.studentTableAdapter.Fill(this.tESTDataSet.Student);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string select_week = textBox1.Text.Trim(); ;//选择的当前行第一列的值，也就是ID
            string num = textBox2.Text.Trim(); ;
            string cno = textBox3.Text.Trim();
            string tno = textBox4.Text.Trim();
            int num1;
            con.Open();


            try
            {
                if (select_week != String.Empty && num == String.Empty && cno == String.Empty && tno == String.Empty)
                {
                    
                    String select_by_id = "select * from clatime where weektime='" + select_week + "'";
                    SqlCommand sqlCommand = new SqlCommand(select_by_id, con);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;
                    dataGridView1.DataSource = bindingSource;
                }
                else if (select_week == String.Empty && num != String.Empty && cno == String.Empty && tno == String.Empty)
                {
                    num1 = int.Parse(num);
                    String select_by_id = "select * from clatime where classnumber='" + num1 + "'";
                    SqlCommand sqlCommand = new SqlCommand(select_by_id, con);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;
                    dataGridView1.DataSource = bindingSource;
                }
                else if (select_week == String.Empty && num == String.Empty && cno != String.Empty && tno == String.Empty)
                {

                    String select_by_id = "select * from clatime where scno='" + cno + "'";
                    SqlCommand sqlCommand = new SqlCommand(select_by_id, con);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;
                    dataGridView1.DataSource = bindingSource;
                }
                else if (select_week == String.Empty && num == String.Empty && cno == String.Empty && tno != String.Empty)
                {
                    String select_by_id = "select * from clatime where stno='" + tno + "'";
                    SqlCommand sqlCommand = new SqlCommand(select_by_id, con);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;
                    dataGridView1.DataSource = bindingSource;
                }
                else if (select_week != String.Empty && num != String.Empty && cno == String.Empty && tno == String.Empty)
                {
                    num1 = int.Parse(num);
                    String select_by_id = "select * from clatime where classnumber='" + num1 + "'and weektime='"+select_week+"'";
                    SqlCommand sqlCommand = new SqlCommand(select_by_id, con);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;
                    dataGridView1.DataSource = bindingSource;
                }
                else if (select_week != String.Empty && num == String.Empty && cno != String.Empty && tno == String.Empty)
                {

                    String select_by_id = "select * from clatime where weektime='" + select_week + "' and scno='"+cno+"'";
                    SqlCommand sqlCommand = new SqlCommand(select_by_id, con);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;
                    dataGridView1.DataSource = bindingSource;
                }
                else if (select_week != String.Empty && num == String.Empty && cno == String.Empty && tno != String.Empty)
                {

                    String select_by_id = "select * from clatime where weektime='" + select_week + "' and stno='" + tno + "'";
                    SqlCommand sqlCommand = new SqlCommand(select_by_id, con);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;
                    dataGridView1.DataSource = bindingSource;
                }
                else if (select_week == String.Empty && num != String.Empty && cno != String.Empty && tno == String.Empty)
                {

                    String select_by_id = "select * from clatime where classnumber='" + num + "' and scno='" + cno + "'";
                    SqlCommand sqlCommand = new SqlCommand(select_by_id, con);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;
                    dataGridView1.DataSource = bindingSource;
                }
                else if (select_week == String.Empty && num != String.Empty && cno == String.Empty && tno != String.Empty)
                {

                    String select_by_id = "select * from clatime where classnumber='" + num + "' and stno='" + tno + "'";
                    SqlCommand sqlCommand = new SqlCommand(select_by_id, con);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;
                    dataGridView1.DataSource = bindingSource;
                }
                else if (select_week == String.Empty && num == String.Empty && cno != String.Empty && tno != String.Empty)
                {

                    String select_by_id = "select * from clatime where scno='" + cno + "' and stno='" + tno + "'";
                    SqlCommand sqlCommand = new SqlCommand(select_by_id, con);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;
                    dataGridView1.DataSource = bindingSource;
                }
                else if (select_week != String.Empty && num != String.Empty && cno != String.Empty && tno == String.Empty)
                {

                    String select_by_id = "select * from clatime where scno='" + cno + "'  " +
                        "and weektime='" + select_week + "' and classnumber='"+num+"'";
                    SqlCommand sqlCommand = new SqlCommand(select_by_id, con);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;
                    dataGridView1.DataSource = bindingSource;
                }
                else if (select_week != String.Empty && num != String.Empty && cno == String.Empty && tno != String.Empty)
                {

                    String select_by_id = "select * from clatime where  stno='" + tno + "' " +
                        "and weektime='" + select_week + "' and classnumber='" + num + "'";
                    SqlCommand sqlCommand = new SqlCommand(select_by_id, con);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;
                    dataGridView1.DataSource = bindingSource;
                }
                else if (select_week != String.Empty && num == String.Empty && cno != String.Empty && tno != String.Empty)
                {

                    String select_by_id = "select * from clatime where scno='" + cno + "' and stno='" + tno + "' " +
                        "and weektime='" + select_week + "' ";
                    SqlCommand sqlCommand = new SqlCommand(select_by_id, con);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;
                    dataGridView1.DataSource = bindingSource;
                }
                else if (select_week == String.Empty && num != String.Empty && cno != String.Empty && tno != String.Empty)
                {

                    String select_by_id = "select * from clatime where scno='" + cno + "' and stno='" + tno + "' " +
                        " and classnumber='" + num + "'";
                    SqlCommand sqlCommand = new SqlCommand(select_by_id, con);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;
                    dataGridView1.DataSource = bindingSource;
                }
                else if (select_week != String.Empty && num != String.Empty && cno != String.Empty && tno != String.Empty)
                {

                    String select_by_id = "select * from clatime where scno='" + cno + "' and stno='" + tno + "' " +
                        "and weektime='" + select_week + "' and classnumber='" + num + "'";
                    SqlCommand sqlCommand = new SqlCommand(select_by_id, con);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;
                    dataGridView1.DataSource = bindingSource;
                }
            }
            catch
            {
                MessageBox.Show("查询语句有误，请认真检查SQL语句!");
            }
            finally
            {
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int classno;
            String weektime = textBox1.Text.Trim();
            String classnumber = textBox2.Text.Trim();
            String scno = textBox3.Text.Trim();
            String stno = textBox4.Text.Trim();

            try
            {
                classno = int.Parse(classnumber);
                con.Open();
                string insertStr = "INSERT INTO  clatime (weektime,classnumber,scno,stno)    " +
                    "VALUES ('" + weektime + "','" + classno + "','" + scno + "','" + stno + "')";
                SqlCommand cmd = new SqlCommand(insertStr, con);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("输入数据违反要求!");
            }
            finally
            {
                con.Close();
            }
            this.clatimeTableAdapter.Fill(this.classtimeDataSet.clatime);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string select_week = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//选择的当前行第一列的值，也就是ID
                string num = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                int select_no;
                select_no = int.Parse(num);
                string delete_by_id = "delete from clatime where weektime='" + select_week +"' and classnumber='"+ select_no +"'";//sql删除语句
                SqlCommand cmd = new SqlCommand(delete_by_id, con);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("请正确选择行!");
            }
            finally
            {
                con.Close();
            }
            this.clatimeTableAdapter.Fill(this.classtimeDataSet.clatime);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int classno;
            String weektime = textBox1.Text.Trim();
            String classnumber = textBox2.Text.Trim();
            String scno = textBox3.Text.Trim();
            String stno = textBox4.Text.Trim();

            try
            {
                classno = int.Parse(classnumber);
                string select_week = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//选择的当前行第一列的值，也就是ID
                string num = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                int select_no;
                select_no = int.Parse(num);
                con.Open();
                string insertStr = "UPDATE clatime SET weektime = '" + weektime + "',classnumber='"+classno+"'" +
                    ",scno='"+scno+"',stno='"+stno+"' WHERE weektime = '" + select_week + "' and classnumber = '"+select_no+"'";
                SqlCommand cmd = new SqlCommand(insertStr, con);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("输入数据违反要求!");
            }
            finally
            {
                con.Close();
            }
            this.clatimeTableAdapter.Fill(this.classtimeDataSet.clatime);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            TeacherInfo teacherInfo = new TeacherInfo();
            teacherInfo.Show();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                String select_by_id = "select * from clatime";
                SqlCommand sqlCommand = new SqlCommand(select_by_id, con);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = sqlDataReader;
                dataGridView1.DataSource = bindingSource;
            }
            catch
            {
                MessageBox.Show("查询语句有误，请认真检查SQL语句!");
            }
            finally
            {
                con.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ClassInfo classinfo = new ClassInfo();
            classinfo.Show();
            this.Hide();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

        }
    }
}
