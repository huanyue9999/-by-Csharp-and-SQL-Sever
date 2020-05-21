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
    public partial class TeacherInfo : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=classtime;Persist Security Info=True;User ID=sa;Password=admin");

        public TeacherInfo()
        {
            InitializeComponent();
        }

        private void TeacherInfo_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“classtimeDataSet5.teacher”中。您可以根据需要移动或删除它。
            this.teacherTableAdapter1.Fill(this.classtimeDataSet5.teacher);
            // TODO: 这行代码将数据加载到表“classtimeDataSet2.teacher”中。您可以根据需要移动或删除它。
            this.teacherTableAdapter.Fill(this.classtimeDataSet2.teacher);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string num = textBox1.Text.Trim(); ;
            string name = textBox2.Text.Trim();
            string title = textBox3.Text.Trim();
            string major = textBox4.Text.Trim();
            string sex = textBox5.Text.Trim();

            con.Open();
            
            try
            {
                if(num!=String.Empty)
                {
                    String select_by_id = "insert into teacher(tno,tname,title,tmajor,tsex) values ('" + num + "'" +
                        ",'" + name + "','" + title + "','" + major + "','"+sex+"')";
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
            this.teacherTableAdapter.Fill(this.classtimeDataSet2.teacher);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMain formMain = new FormMain();
            formMain.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string num = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();//选择的当前行第一列的值，也就是ID


                string delete_by_id = "delete from teacher where tno='" + num + "'";//sql删除语句
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
            this.teacherTableAdapter.Fill(this.classtimeDataSet2.teacher);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string num = textBox1.Text.Trim(); ;
            string name = textBox2.Text.Trim();
            string title = textBox3.Text.Trim();
            string major = textBox4.Text.Trim();
            string sex = textBox5.Text.Trim();
            try
            {
                if(num!=String.Empty)
                {
                    string num1 = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();//选择的当前行第一列的值，也就是ID

                    con.Open();
                    string insertStr = "UPDATE teacher SET tno = '" + num + "',tname='" + name + "'" +
                        ",title='" + title + "',tmajor='" + major + "',tsex='"+sex+"' WHERE tno='" + num1 + "'";
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
            this.teacherTableAdapter.Fill(this.classtimeDataSet2.teacher);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string num1 = textBox1.Text.Trim(); ;
            string sex = textBox5.Text.Trim();
            string name = textBox2.Text.Trim();
            string title = textBox3.Text.Trim();
            string major = textBox4.Text.Trim();
            try
            {
                if(num1!=String.Empty)
                {
                    con.Open();
                    String select_by_id = "select * from teacher where tno='" + num1 + "'";
                    SqlCommand sqlCommand = new SqlCommand(select_by_id, con);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;
                    dataGridView2.DataSource = bindingSource;
                }
                else if(num1 == String.Empty && name != String.Empty)
                {
                    con.Open();
                    String select_by_id = "select * from teacher where tname like'%" + name + "%'";
                    SqlCommand sqlCommand = new SqlCommand(select_by_id, con);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;
                    dataGridView2.DataSource = bindingSource;
                }
                else if(num1 == String.Empty && name == String.Empty &&sex!=String.Empty&&major!=String.Empty)
                {
                    con.Open();
                    String select_by_id = "select * from teacher where tsex='" + sex + "' and tmajor='"+major+"'";
                    SqlCommand sqlCommand = new SqlCommand(select_by_id, con);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;
                    dataGridView2.DataSource = bindingSource;
                }
                else if (num1 == String.Empty && name == String.Empty && sex != String.Empty && title != String.Empty)
                {
                    con.Open();
                    String select_by_id = "select * from teacher where tsex='" + sex + "' and title='" + title + "'";
                    SqlCommand sqlCommand = new SqlCommand(select_by_id, con);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;
                    dataGridView2.DataSource = bindingSource;
                }
                else if (num1 == String.Empty && name == String.Empty && title != String.Empty && major != String.Empty)
                {
                    con.Open();
                    String select_by_id = "select * from teacher where title='" + title + "' and tmajor='" + major + "'";
                    SqlCommand sqlCommand = new SqlCommand(select_by_id, con);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;
                    dataGridView2.DataSource = bindingSource;
                }
                else if (num1 == String.Empty && name == String.Empty && title == String.Empty && major == String.Empty&&sex!=String.Empty)
                {
                    con.Open();
                    String select_by_id = "select * from teacher where tsex='" + sex + "'";
                    SqlCommand sqlCommand = new SqlCommand(select_by_id, con);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;
                    dataGridView2.DataSource = bindingSource;
                }
                else if (num1 == String.Empty && name == String.Empty && title == String.Empty && major != String.Empty && sex == String.Empty)
                {
                    con.Open();
                    String select_by_id = "select * from teacher where  tmajor='" + major + "'";
                    SqlCommand sqlCommand = new SqlCommand(select_by_id, con);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;
                    dataGridView2.DataSource = bindingSource;
                }
                else if (num1 == String.Empty && name == String.Empty && title != String.Empty && major == String.Empty && sex == String.Empty)
                {
                    con.Open();
                    String select_by_id = "select * from teacher where title='" + title + "'";
                    SqlCommand sqlCommand = new SqlCommand(select_by_id, con);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;
                    dataGridView2.DataSource = bindingSource;
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
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                String select_by_id = "select * from teacher";
                SqlCommand sqlCommand = new SqlCommand(select_by_id, con);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = sqlDataReader;
                dataGridView2.DataSource = bindingSource;
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

        private void button7_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox3.Text = "";
            textBox2.Text = "";
            textBox1.Text = "";
            textBox5.Text = "";
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            string sex = textBox5.Text.Trim();
            if(sex!="男"&&sex!="女")
            {
                MessageBox.Show("请输入男或女!");
            }

        }
    }
}
