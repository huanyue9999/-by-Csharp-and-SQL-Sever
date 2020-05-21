using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace LoginDemo
{
    public partial class Sign : Form
    {
        public Sign()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string s1 = textBox1.Text.ToString().Trim();
            string s2 = textBox2.Text.ToString().Trim();
            string s3 = textBox3.Text.ToString().Trim();
            string s21 = EncryptWithMD5(s2);


            string myConnString = "Data Source=.;Initial Catalog=classtime;Persist Security Info=True;MultipleActiveResultSets=true;User ID=sa;Password=admin";
            SqlConnection sqlConnection = new SqlConnection(myConnString);  //实例化连接对象

            sqlConnection.Open();

            string sql = "select account,pass from login1 where account = '" + s1 + "' ";                                            //编写SQL命令

            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            if(sqlDataReader.HasRows)
            {
                MessageBox.Show("账户已存在！", "notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {




                if ( s2 == s3)
                {

                    sqlConnection.Close();



                    string sql1 = "insert into login1(account,   pass ,   userphoto ) " +
                                                              "values (@s1, @s21,@userphoto)";
                    //编写SQL命令
                    SqlCommand sqlCommand1 = new SqlCommand(sql1, sqlConnection);
                    //SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    SqlParameter sqlParameter = new SqlParameter("@userphoto", SqlDbType.VarBinary, mybyte.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, mybyte);
                    sqlCommand1.Parameters.Add(sqlParameter);
                    sqlParameter = new SqlParameter("@s1", textBox1.Text);
                    sqlCommand1.Parameters.Add(sqlParameter);
                    sqlParameter = new SqlParameter("@s21", EncryptWithMD5(textBox2.Text));
                    sqlCommand1.Parameters.Add(sqlParameter);

                    MessageBox.Show("注册成功！", "notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    //登录成功
                    sqlConnection.Open();
                    sqlCommand1.ExecuteNonQuery();                                                                                               //form2.Show();
                    this.Hide();
                    Form1 form1 = new Form1();
                    form1.Show();
                }

                else if ( s2 != s3)
                {
                    MessageBox.Show("两次输入密码不同,请重新输入密码！", "notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox3.Text = "";
                    textBox2.Text = "";
                }
            }

                       
            
                sqlConnection.Close();
            

        }

        private string EncryptWithMD5(string source)
        {

            byte[] sor = Encoding.UTF8.GetBytes(source);

            MD5 md5 = MD5.Create();

            byte[] result = md5.ComputeHash(sor);

            StringBuilder strbul = new StringBuilder(40);

            for (int i = 0; i < result.Length; i++)

            {

                strbul.Append(result[i].ToString("x2"));//加密结果"x2"结果为32位,"x3"结果为48位,"x4"结果为64位

            }

            return strbul.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox3_MouseLeave(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Sign_Leave(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
                //使用regex（正则表达式）进行格式设置 至少有数字、大写字母、小写字母各一个。最少3个字符、最长20个字符。
                Regex regex = new Regex(@"^[\\u4e00-\\u9fa5_a-zA-Z0-9-]{6,16}$");

                if (regex.IsMatch(textBox1.Text))//判断格式是否符合要求
                {
                    //MessageBox.Show("输入密码格式正确!");
                }
                else
                {
                    MessageBox.Show("限6-16个字符，支持中英文、数字、减号或下划线！");
                    textBox1.Focus();
                }
            }
            else
            {
                MessageBox.Show("请先输入用户名！");
            }
        }
        public Byte[] mybyte = new byte[0];
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            string picturePath = openFileDialog.FileName;//获取图片路径
            //文件的名称，每次必须更换图片的名称，这里很为不便
            //创建FileStream对象
            FileStream fs = new FileStream(picturePath, FileMode.Open, FileAccess.Read);
            //声明Byte数组
            mybyte = new byte[fs.Length];
            //读取数据
            fs.Read(mybyte, 0, mybyte.Length);
            pictureBox1.Image = Image.FromStream(fs);
            fs.Close();
        }

        private void Sign_Load(object sender, EventArgs e)
        {

        }
    }
}
