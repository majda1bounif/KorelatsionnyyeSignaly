using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear(); //графиккорреляционнойфункции
            chart2.Series[0].Points.Clear(); //графикспектральнойплотности
            int A = int.Parse(textBox1.Text); //параметрА
            int P = int.Parse(textBox2.Text); //порядок P
            int[] array = new int[P];
            double[] ARRAY = new double[P];
            Random r = new Random(); //задание случайного сигнала
            int t = 0; //время t
            int i;
            int j;
            for (i = 0; i < P; i++)
            {
                array[i] = r.Next(A); //построение случайного сигнала
                chart1.Series[0].Points.AddXY(i, array[i]); //Обновление графика корреляционной функции
                t = t + array[i];
            }
            t = t / P;
            textBox3.Text = t.ToString(); //нахождение времени t конечное
            for (i = 0; i < 10; i++) //нахождение спектральной плотности
            {
                var d = 0;
                for (j = 0; j < P; j++)
                {
                    if ((j + i) < (P - 1))
                    {
                        var z = (array[j] - t) * (array[j + i] - t);
                        d = d + z;
                    }
                }
                ARRAY[i] = d / P;
                chart2.Series[0].Points.AddXY(i, ARRAY[i]); //Обновлениеграфикаспектральнойплотности
                if (i == 0)
                {
                    textBox4.Text = ARRAY[i].ToString();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

