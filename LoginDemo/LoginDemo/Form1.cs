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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginDemo
{
    public partial class Form1 : Form
    {
        public string code;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sign sign = new Sign();
            sign.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login_code = textBox1.Text.Trim();
            string username = textBoxUserName.Text.Trim();  //取出账号

            string password = textBoxPassWord.Text.Trim();  //取出密码

            password = EncryptWithMD5(password);

            //string connstr = ConfigurationManager.ConnectionStrings["connectionString"].ToString(); //读取连接字符串

            string myConnString = "Data Source=.;Initial Catalog=classtime;Persist Security Info=True;MultipleActiveResultSets=true;User ID=sa;Password=admin";



            SqlConnection sqlConnection = new SqlConnection(myConnString);  //实例化连接对象

            sqlConnection.Open();



            string sql = "select account,pass from login1 where account = '" + username + "' ";                                            //编写SQL命令

            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();



            if (sqlDataReader.HasRows)

            {

                string sql1 = "select account,pass from login1 where account = '" + username + "' and pass='"+password+"'";                                            //编写SQL命令

                SqlCommand sqlCommand1 = new SqlCommand(sql1, sqlConnection);

                SqlDataReader sqlDataReader1 = sqlCommand1.ExecuteReader();
                if (sqlDataReader1.HasRows)
                {
                    if(login_code==code)
                    {
                        MessageBox.Show("登陆成功！", "notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);             //登录成功

                        this.Hide();
                        FormMain formMain = new FormMain();
                        formMain.Show();
                    }
                    else
                    {
                        MessageBox.Show("验证码错误！", "notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("密码错误！", "notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }

            else

            {

                MessageBox.Show("账户不存在！", "notice", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        private void textBoxUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random ran = new Random();
            int number;
            char code1;
            //取五个数 
            for (int i = 0; i < 5; i++)
            {
                number = ran.Next();
                if (number % 2 == 0)
                    code1 = (char)('0' + (char)(number % 10));
                else
                    code1 = (char)('A' + (char)(number % 26)); //转化为字符 

                this.code += code1.ToString();
            }

            label5.Text = code;
        }

        private void textBoxUserName_Leave(object sender, EventArgs e)
        {
            string s1 = textBoxUserName.Text;
            try
            {
                string connString = "Data Source =.; Initial Catalog = classtime; Persist Security Info = True; MultipleActiveResultSets = true; User ID = sa; Password = admin";//数据库连接字符串
                SqlConnection connection = new SqlConnection(connString);//创建connection对象

                //打开数据库连接
                connection.Open();
                //创建SQL语句
                string sql = "select userphoto from login1 where account = '" + s1 + "'";
                //创建SqlCommand对象
                SqlCommand command = new SqlCommand(sql, connection);
                //创建DataAdapter对象
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                //创建DataSet对象
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "login1");
                int c = dataSet.Tables["login1"].Rows.Count;
                if (c > 0)
                {
                    Byte[] mybyte = new byte[0];
                    mybyte = (Byte[])(dataSet.Tables["login1"].Rows[c - 1]["userphoto"]);
                    MemoryStream ms = new MemoryStream(mybyte);
                    pictureBox1.Image = Image.FromStream(ms);
                }
                else
                    pictureBox1.Image = null;
              
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();

            FormMain x = new FormMain();
            x.Show();
        }
    }
}
