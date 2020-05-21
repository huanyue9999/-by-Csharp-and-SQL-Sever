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
    public partial class ClassInfo : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=classtime;Persist Security Info=True;User ID=sa;Password=admin");

        public ClassInfo()
        {
            InitializeComponent();
        }

        private void ClassInfo_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“classtimeDataSet3.course”中。您可以根据需要移动或删除它。
            this.courseTableAdapter.Fill(this.classtimeDataSet3.course);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cnum = textBox1.Text.Trim(); ;
            string name = textBox2.Text.Trim();
            string time = textBox4.Text.Trim();
            string tno = textBox3.Text.Trim();
            string test = textBox5.Text.Trim();
            con.Open();
            try
            {
                if (cnum != String.Empty)
                {
                    String select_by_id = "insert into course(cno,cname,ctime,examine,ctno) values ('" + cnum + "'" +
                        ",'" + name + "','" + time + "','" + test + "','" + tno + "')";
                    SqlCommand sqlCommand = new SqlCommand(select_by_id, con);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("增加成功，请刷新查看!");
                }
                else
                    MessageBox.Show("请输入教师编号!");
            }
            catch
            {
                MessageBox.Show("插入失败!");
            }
            finally
            {
                con.Close();
            }
            this.courseTableAdapter.Fill(this.classtimeDataSet3.course);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string num = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//选择的当前行第一列的值，也就是ID


                string delete_by_id = "delete from course where cno='" + num + "'";//sql删除语句
                SqlCommand cmd = new SqlCommand(delete_by_id, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("删除成功!");
            }
            catch
            {
                MessageBox.Show("请正确选择行!");
            }
            finally
            {
                con.Close();
            }
            this.courseTableAdapter.Fill(this.classtimeDataSet3.course);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string cnum = textBox1.Text.Trim(); ;
            string name = textBox2.Text.Trim();
            string time = textBox4.Text.Trim();
            string tno = textBox3.Text.Trim();
            string test = textBox5.Text.Trim();
            try
            {
                if (cnum != String.Empty)
                {
                    string num1 = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//选择的当前行第一列的值，也就是ID

                    con.Open();
                    string insertStr = "UPDATE course SET cno = '" + cnum + "',cname='" + name + "'" +
                        ",ctime='" + time + "',examine='" + test + "',ctno='" + tno + "' WHERE cno='" + num1 + "'";
                    SqlCommand cmd = new SqlCommand(insertStr, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("修改成功!");
                }
                else
                {
                    MessageBox.Show("请先输入修改后的教师编号!");
                }

            }
            catch
            {
                MessageBox.Show("修改失败!");
            }
            finally
            {
                con.Close();
            }
            this.courseTableAdapter.Fill(this.classtimeDataSet3.course);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                String select_by_id = "select * from course";
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMain formMain = new FormMain();
            formMain.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string cnum = textBox1.Text.Trim(); ;
            string name = textBox2.Text.Trim();
            string time = textBox4.Text.Trim();
            string tno = textBox3.Text.Trim();
            string test = textBox5.Text.Trim();

            try
            {
                if (cnum != String.Empty)
                {
                    con.Open();
                    String select_by_id = "select * from course where cno='" + cnum + "'";
                    SqlCommand sqlCommand = new SqlCommand(select_by_id, con);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;
                    dataGridView1.DataSource = bindingSource;
                }
                else if (cnum == String.Empty && name != String.Empty)
                {
                    con.Open();
                    String select_by_id = "select * from course where cname like '%" + name + "%'";
                    SqlCommand sqlCommand = new SqlCommand(select_by_id, con);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;
                    dataGridView1.DataSource = bindingSource;
                }
                else if (cnum == String.Empty && name == String.Empty && time != String.Empty && tno == String.Empty&&test==String.Empty)
                {
                    con.Open();
                    String select_by_id = "select * from course where ctime='" + time + "'";
                    SqlCommand sqlCommand = new SqlCommand(select_by_id, con);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;
                    dataGridView1.DataSource = bindingSource;
                }
                else if (cnum == String.Empty && name == String.Empty && time == String.Empty && tno != String.Empty && test == String.Empty)
                {
                    con.Open();
                    String select_by_id = "select * from course where ctno='" + tno + "'";
                    SqlCommand sqlCommand = new SqlCommand(select_by_id, con);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;
                    dataGridView1.DataSource = bindingSource;
                }
                else if (cnum == String.Empty && name == String.Empty && time == String.Empty && tno == String.Empty && test != String.Empty)
                {
                    con.Open();
                    String select_by_id = "select * from course where examine='" + test + "' ";
                    SqlCommand sqlCommand = new SqlCommand(select_by_id, con);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;
                    dataGridView1.DataSource = bindingSource;
                }
                else if (cnum == String.Empty && name == String.Empty && time != String.Empty && tno != String.Empty && test == String.Empty)
                {
                    con.Open();
                    String select_by_id = "select * from course where ctno='" + tno + "'and ctime='"+time+"'";
                    SqlCommand sqlCommand = new SqlCommand(select_by_id, con);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;
                    dataGridView1.DataSource = bindingSource;
                }
                else if (cnum == String.Empty && name == String.Empty && time != String.Empty && tno == String.Empty && test != String.Empty)
                {
                    con.Open();
                    String select_by_id = "select * from course where  ctime='" + time + "'and examine='"+test+"'";
                    SqlCommand sqlCommand = new SqlCommand(select_by_id, con);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;
                    dataGridView1.DataSource = bindingSource;
                }
                else if (cnum == String.Empty && name == String.Empty && time == String.Empty && tno != String.Empty && test != String.Empty)
                {
                    con.Open();
                    String select_by_id = "select * from course where examine='" + test + "'and ctno='"+tno+"'";
                    SqlCommand sqlCommand = new SqlCommand(select_by_id, con);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;
                    dataGridView1.DataSource = bindingSource;
                }

            }
            catch
            {
                MessageBox.Show("查询语句有误，请刷新后重试!");
            }
            finally
            {
                con.Close();
            }
            this.courseTableAdapter.Fill(this.classtimeDataSet3.course);
        }
    }
}
