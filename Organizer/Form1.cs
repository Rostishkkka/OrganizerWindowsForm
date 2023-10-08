using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Organizer
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        SqlConnection sqlConnection = new SqlConnection(@"Data Source = DESKTOP-QFRCAHK; Initial Catalog = Orginizer; Integrated Security=True");
        int count, countType;
        string[,] listAct = null;
        Button[] delete = null;
        Button[] typeBut = null;
        TextBox [,] date = null;
        bool red = false, black = false;

        public static void DpiFix()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            }
        }

        public Form1()
        {
            InitializeComponent(); 
        }

        private void AddBut_Click(object sender, EventArgs e)
        {
            SqlCommand AddElement = new SqlCommand("INSERT INTO Spisok (activity, date, complexity, type, status, cycle) " +
                "VALUES (@activity, @date, @complexity, @type, @status, @cycle)", sqlConnection);
            AddElement.Parameters.Add("@activity", SqlDbType.NVarChar, elementBox.Text.Length).Value = elementBox.Text;
            AddElement.Parameters.Add("@date", SqlDbType.Int).Value = daysBox.Text;
            //string byteImage = Convert.ToBase64String(File.ReadAllBytes(imageData));
            AddElement.Parameters.Add("@complexity", SqlDbType.Int).Value = hardBox.Text;
            AddElement.Parameters.Add("@type", SqlDbType.NVarChar, typeBox.Text.Length).Value = typeBox.Text;
            AddElement.Parameters.Add("@status", SqlDbType.Int).Value = 1;
            if(type.Text == "Обычный") AddElement.Parameters.Add("@cycle", SqlDbType.Int).Value = 1;
            else if (type.Text == "Ожидание") AddElement.Parameters.Add("@cycle", SqlDbType.Int).Value = 0;
            else if (type.Text == "Параллельно") AddElement.Parameters.Add("@cycle", SqlDbType.Int).Value = 2;
            else if (type.Text == "Ежедневно") AddElement.Parameters.Add("@cycle", SqlDbType.Int).Value = 3;
            sqlConnection.Open();
            AddElement.ExecuteNonQuery();
            sqlConnection.Close();
        }

        private void calculatingActivity()
        {
            SqlCommand countAct = new SqlCommand("SELECT COUNT(*) FROM Spisok WHERE status = 1", sqlConnection);
            sqlConnection.Open();
            count = (int)countAct.ExecuteScalar();
            sqlConnection.Close();
            SqlCommand countTypes = new SqlCommand("SELECT COUNT(*) FROM Spisok WHERE status = 1 AND (cycle = 0 OR cycle > 1)", sqlConnection);
            sqlConnection.Open();
            countType = (int)countTypes.ExecuteScalar();
            sqlConnection.Close();
            listAct = new string[6, count];
            delete = new Button[count];
            date = new TextBox[4, count];
            typeBut = new Button[countType];
        }

        private void getAct()
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT activity, date, complexity, type, cycle FROM Spisok WHERE status = 1 ORDER BY cycle DESC", sqlConnection);

            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                for (int i = 0; reader.Read(); i++) // построчно считываем данные
                {
                    listAct[0, i] = Convert.ToString(i);
                    object activity = reader.GetValue(0);
                    listAct[1, i] = Convert.ToString(activity);
                    object date = reader.GetValue(1);
                    listAct[2, i] = Convert.ToString(date);
                    object complexity = reader.GetValue(2);
                    listAct[3, i] = complexity.ToString();
                    object type = reader.GetValue(3);
                    listAct[4, i] = type.ToString();
                    object cycle = reader.GetValue(4);
                    listAct[5, i] = cycle.ToString();
                }
            }
            sqlConnection.Close();
        }

        private void addBox(int n2, int n1, string text)
        {
            int[] coord = new int[] { 270, 590, 640, 710 };
            int[] size = new int[] { 310, 40, 60, 100 };
            date[n1, n2] = new TextBox();
            date[n1, n2].Size = new Size(size[n1], 22);
            date[n1, n2].Location = new Point(coord[n1], 52 + 40 * n2);
            date[n1, n2].Text = text;
            date[n1, n2].Enabled = false;
            this.Controls.Add(date[n1, n2]);
        }

        private void addBox(string n, int n1, int n2)
        {
            typeBut[n2] = new Button();
            typeBut[n2].Location = new Point(240, 52 + 40 * n1);
            typeBut[n2].Size = new Size(22, 22);
            if(n == "0")
            {
                typeBut[n2].BackColor = Color.Black;
                typeBut[n2].Click += new EventHandler(this.MoveClick1);
                typeBut[n2].Text = Convert.ToString(n1);
            }
            else if(n == "2") 
            {
                typeBut[n2].BackColor = Color.Red;
            }
            else if (n == "3")
            {
                typeBut[n2].BackColor = Color.Blue;
            }
            this.Controls.Add(typeBut[n2]);
        }

        private void addComp()
        {
            for(int i = 0, i1 = 0; i < count; i++)
            {
                for(int j = 1; j < 5; j++) {
                    addBox(i, j - 1, listAct[j, i]);
                }

               if(listAct[5, i] != "1")
                {
                    addBox(listAct[5, i], i, i1);
                    i1++;
                }
                delete[i] = new Button();
                delete[i].Location = new Point(820, 52 + 40 * i);
                delete[i].Size = new Size(50, 22);
                delete[i].Text = Convert.ToString(i);
                delete[i].Click += new EventHandler(this.MoveClick);
                this.Controls.Add(delete[i]);
            }
        }

        public void MoveClick1(Object sender, EventArgs e)
        {
                Button but = (Button)sender;
                SqlCommand DeleteServise = new SqlCommand("UPDATE Spisok SET cycle = 1 WHERE activity = @activity AND type = @type", sqlConnection);
                DeleteServise.Parameters.Add("@activity", SqlDbType.NVarChar, listAct[1, Convert.ToInt32(but.Text)].Length).Value = listAct[1, Convert.ToInt32(but.Text)];
                DeleteServise.Parameters.Add("@type", SqlDbType.NVarChar, listAct[4, Convert.ToInt32(but.Text)].Length).Value = listAct[4, Convert.ToInt32(but.Text)];
                sqlConnection.Open();
                DeleteServise.ExecuteNonQuery();
                sqlConnection.Close();
        }

        public void MoveClick(Object sender, EventArgs e)
        {
            if (red == false && black == false)
            {
                Button but = (Button)sender;
                SqlCommand DeleteServise = new SqlCommand("UPDATE Spisok SET status = 0 WHERE activity = @activity AND type = @type", sqlConnection);
                DeleteServise.Parameters.Add("@activity", SqlDbType.NVarChar, listAct[1, Convert.ToInt32(but.Text)].Length).Value = listAct[1, Convert.ToInt32(but.Text)];
                DeleteServise.Parameters.Add("@type", SqlDbType.NVarChar, listAct[4, Convert.ToInt32(but.Text)].Length).Value = listAct[4, Convert.ToInt32(but.Text)];
                sqlConnection.Open();
                DeleteServise.ExecuteNonQuery();
                sqlConnection.Close();
            }
            else if(red == true)
            {
                red = false;
                Button but = (Button)sender;
                SqlCommand DeleteServise = new SqlCommand("UPDATE Spisok SET date = @date WHERE activity = @activity AND type = @type AND status = 1", sqlConnection);
                DeleteServise.Parameters.Add("@activity", SqlDbType.NVarChar, listAct[1, Convert.ToInt32(but.Text)].Length).Value = listAct[1, Convert.ToInt32(but.Text)];
                DeleteServise.Parameters.Add("@type", SqlDbType.NVarChar, listAct[4, Convert.ToInt32(but.Text)].Length).Value = listAct[4, Convert.ToInt32(but.Text)];
                DeleteServise.Parameters.Add("@date", SqlDbType.Int).Value = date[1, Convert.ToInt32(but.Text)].Text;
                sqlConnection.Open();
                DeleteServise.ExecuteNonQuery();
                sqlConnection.Close();
                Booling(red);
            }
            else if (black == true)
            {
                Button but = (Button)sender;
                SqlCommand DeleteServise = new SqlCommand("UPDATE Spisok SET cycle = 0 WHERE activity = @activity AND type = @type AND status = 1", sqlConnection);
                DeleteServise.Parameters.Add("@activity", SqlDbType.NVarChar, listAct[1, Convert.ToInt32(but.Text)].Length).Value = listAct[1, Convert.ToInt32(but.Text)];
                DeleteServise.Parameters.Add("@type", SqlDbType.NVarChar, listAct[4, Convert.ToInt32(but.Text)].Length).Value = listAct[4, Convert.ToInt32(but.Text)];
                DeleteServise.Parameters.Add("@date", SqlDbType.Int).Value = date[1, Convert.ToInt32(but.Text)].Text;
                sqlConnection.Open();
                DeleteServise.ExecuteNonQuery();
                sqlConnection.Close();
                black = false;
            }
        }

        private void deleteAdd()
        {
            for (int i = 0; i < count; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    this.Controls.Remove(date[j - 1, i]);
                }
                this.Controls.Remove(delete[i]);
            }
            for (int i = 0; i < countType; i++)
            {
                this.Controls.Remove(typeBut[i]);
            }
            date = null;
            delete = null;  
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DpiFix();
            sleep();
            getListAct();
        }

        private void sleep()
        {
            calculatingActivity();
            getAct();
            addComp();
        }

        void getListAct()
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT name FROM ActivityNew WHERE status = 1", sqlConnection);

            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                for (int i = 0; reader.Read(); i++)
                {
                    typeBox.Items.Add(reader.GetValue(0));
                }
            }
            sqlConnection.Close();
        }

        private void updateBut_Click(object sender, EventArgs e)
        {
            deleteAdd();
            sleep();
        }

        private void newBut_Click(object sender, EventArgs e)
        {
            SqlCommand minusDay = new SqlCommand("UPDATE Spisok SET date = date - 1 WHERE cycle != 0", sqlConnection);
            sqlConnection.Open();
            minusDay.ExecuteNonQuery();
            sqlConnection.Close();
        }

        private void statudBut_Click(object sender, EventArgs e)
        {
            SqlCommand minusDay = new SqlCommand("UPDATE Spisok SET status = 0 WHERE date < 1", sqlConnection);
            sqlConnection.Open();
            minusDay.ExecuteNonQuery();
            sqlConnection.Close();
        }

        private void sortDayBut_Click(object sender, EventArgs e)
        {
            deleteAdd();
            calculatingActivity();
            SqlCommand sqlCommand = new SqlCommand("SELECT activity, date, complexity, type, cycle FROM Spisok WHERE status = 1 ORDER BY cycle DESC, date", sqlConnection);

            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                for (int i = 0; reader.Read(); i++) // построчно считываем данные
                {
                    listAct[0, i] = Convert.ToString(i);
                    object activity = reader.GetValue(0);
                    listAct[1, i] = Convert.ToString(activity);
                    object date = reader.GetValue(1);
                    listAct[2, i] = Convert.ToString(date);
                    object complexity = reader.GetValue(2);
                    listAct[3, i] = complexity.ToString();
                    object type = reader.GetValue(3);
                    listAct[4, i] = type.ToString();
                    object cycle = reader.GetValue(4);
                    listAct[5, i] = cycle.ToString();
                }
            }
            sqlConnection.Close();
            addComp();
        }

        private void sortAllBut_Click(object sender, EventArgs e)
        {
            deleteAdd();
            calculatingActivity();
            SqlCommand sqlCommand = new SqlCommand("SELECT activity, date, complexity, type, cycle FROM Spisok WHERE status = 1 ORDER BY cycle DESC, date, complexity DESC", sqlConnection);

            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                for (int i = 0; reader.Read(); i++) // построчно считываем данные
                {
                    listAct[0, i] = Convert.ToString(i);
                    object activity = reader.GetValue(0);
                    listAct[1, i] = Convert.ToString(activity);
                    object date = reader.GetValue(1);
                    listAct[2, i] = Convert.ToString(date);
                    object complexity = reader.GetValue(2);
                    listAct[3, i] = complexity.ToString();
                    object type = reader.GetValue(3);
                    listAct[4, i] = type.ToString();
                    object cycle = reader.GetValue(4);
                    listAct[5, i] = cycle.ToString();
                }
            }
            sqlConnection.Close();
            addComp();
        }

        private void sortHardSort_Click(object sender, EventArgs e)
        {
            deleteAdd();
            calculatingActivity();
            SqlCommand sqlCommand = new SqlCommand("SELECT activity, date, complexity, type, cycle FROM Spisok WHERE status = 1 ORDER BY cycle DESC, complexity DESC", sqlConnection);

            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                for (int i = 0; reader.Read(); i++) // построчно считываем данные
                {
                    listAct[0, i] = Convert.ToString(i);
                    object activity = reader.GetValue(0);
                    listAct[1, i] = Convert.ToString(activity);
                    object date = reader.GetValue(1);
                    listAct[2, i] = Convert.ToString(date);
                    object complexity = reader.GetValue(2);
                    listAct[3, i] = complexity.ToString();
                    object type = reader.GetValue(3);
                    listAct[4, i] = type.ToString();
                    object cycle = reader.GetValue(4);
                    listAct[5, i] = cycle.ToString();
                }
            }
            sqlConnection.Close();
            addComp();
        }

        private void add_Click(object sender, EventArgs e)
        {
            typeBox.Items.Add(elementBox.Text);
            SqlCommand AddElement = new SqlCommand("INSERT INTO ActivityNew (name, status) " +
               "VALUES (@name, 1)", sqlConnection);
            AddElement.Parameters.Add("@name", SqlDbType.NVarChar, elementBox.Text.Length).Value = elementBox.Text;
            sqlConnection.Open();
            AddElement.ExecuteNonQuery();
            sqlConnection.Close();
        }

        private void del_Click(object sender, EventArgs e)
        {
            SqlCommand DeleteServise = new SqlCommand("UPDATE ActivityNew SET status = 0 WHERE name = @name", sqlConnection);
            DeleteServise.Parameters.Add("@name", SqlDbType.NVarChar, typeBox.Text.Length).Value = typeBox.Text;
            sqlConnection.Open();
            DeleteServise.ExecuteNonQuery();
            sqlConnection.Close();

            typeBox.Items.Remove(typeBox.Text);
        }

        private void Booling(bool wop)
        {
            for (int i = 0; i < count; i++)
            {
                date[1, i].Enabled = wop;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            black = true;
        }

        private void redDayBut_Click(object sender, EventArgs e)
        {
            red = true;
            Booling(red);
        }
    }
}

//Activity