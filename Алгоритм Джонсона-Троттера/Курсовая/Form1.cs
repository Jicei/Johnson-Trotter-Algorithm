using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Подсчет количества комбинаций
        int Fractal(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return n * Fractal(n - 1);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            double[]array;
            int[]move;
            int n, i, j, countl, countr,  indexl = 0, indexr = 0, indem = 0, l, bufi;
            double left = 0, right = 0, buf, bufb, moved = 0;
            string elem;
            n=(int)numericUpDown1.Value;
            array = new double[n];
            move=new int[n];
            listBox1.Items.Clear();
            for (i = 0; i < n; i++ )
            {
                elem = Microsoft.VisualBasic.Interaction.InputBox("Введите " + (i + 1) + " элемент последовательности.Элементы не должны повторяться.");
                if (elem.Length > 0)
                {
                    while (true)
                    {
                        try
                        {
                            array[i] = Convert.ToDouble(elem);
                            break;
                        }
                        catch
                        {
                            MessageBox.Show("Не правильно введены данные.");
                            elem = Microsoft.VisualBasic.Interaction.InputBox("Введите " + (i + 1) + " элемент последовательности.Элементы не должны повторяться.");
                            if (elem.Length <= 0)
                            {
                                return;
                            }
                        }
                    }
                }
                else 
                return;
                move[i] = 0;
                listBox1.Items.Add(Convert.ToString(i + 1) + ": " + Convert.ToString(array[i]));
            }
            //Проверка на повторяемость
            for (i = 0; i < n; i++)
            {
                for (j = 1; j < n; j++)
                {
                    if (array[i] == array[j]&&i!=j)
                    {
                        MessageBox.Show("Элементы множества не должны повторятся.Введите элементы заново");
                        return;
                    }
                }
            }
                //Предварительная сортировка
                for (i = 0; i < n - 1; i++)
                {
                    for (j = i + 1; j < n; j++)
                    {
                        if (array[i] > array[j])
                        {
                            bufb = array[i];
                            array[i] = array[j];
                            array[j] = bufb;
                        }
                    }
                }
            dataGridView1.ColumnCount = n+1;
            dataGridView1.RowCount =Fractal(n)+1;
            dataGridView1.Rows[0].Cells[0].Value = "№";
            for(i=0;i<Fractal(n);i++)
            {
                countl = 0;
                countr = 0;
                //Поиск движущихся элементов
                for (j = 0; j < n; j++)
                {
                    //Движение влево
                    if (j != 0 && array[j] > array[j - 1] && move[j] == 0)
                    {
                        //Нахождение макс левого движущегося элемента
                        if (countl == 0)
                        {
                            left = array[j];
                            countl=1;
                            indexl = j;
                        }
                        else
                        if (array[j] > left)
                        {
                            left = array[j];
                            indexl = j;
                        }
                    }
                    else
                    //Движение вправо
                    if (j + 1 != n && array[j] > array[j + 1] && move[j] == 1)
                    {
                        //Нахождение макс правого движущегося элемента
                         if (countr == 0)
                         {
                             right = array[j];
                             countr=1;
                             indexr = j;
                         }
                         else
                         if (array[j] > right)
                         {
                             right = array[j];
                             indexr = j;
                         }
                    }
                }
                //Нахождение макс движущегося элеммента(сравнение левого и правого движущегося элемента)
                if (left > right)
                {
                    moved = left;
                    indem = indexl;
                }
                else
                if (right > left)
                {
                    moved = right;
                    indem = indexr;
                }
                //Замена направление движения
                for (l = 0; l < n; l++)
                {
                    if (array[l] > array[indem])
                    {
                        if (move[l] == 0)
                        {
                            move[l] = 1;
                        }
                        else
                        if (move[l] == 1)
                        {
                            move[l] = 0;
                        }
                    }
                }
                //Перемещение движущегося элемента
                if (move[indem] == 0)
                {
                    buf = array[indem - 1];
                    bufi = move[indem - 1];
                    array[indem - 1] = array[indem];
                    array[indem] = buf;
                    move[indem - 1] = move[indem];
                    move[indem] = bufi;
                }
                else
                    if (move[indem] == 1)
                    {
                        buf = array[indem + 1];
                        bufi = move[indem + 1];
                        array[indem + 1] = array[indem];
                        array[indem] = buf;
                        move[indem + 1] = move[indem];
                        move[indem] = bufi;
                    }
                //Разметка
                dataGridView1.Rows[i+1].Cells[0].Value = i+1;
                dataGridView1.Rows[i + 1].Cells[0].Style.BackColor = System.Drawing.Color.LightGray;
                //Вывод комбинаций
                for (l = 0; l < n; l++)
                {
                    dataGridView1.Rows[0].Cells[l + 1].Value = Convert.ToString(l+1)+" elem";
                    dataGridView1.Rows[0].Cells[l + 1].Style.BackColor = System.Drawing.Color.LightGray;
                    dataGridView1.Rows[i+1].Cells[l+1].Value = array[l];
                }
        }
      }

        private void button2_Click(object sender, EventArgs e)
        {
            frmTeor thirt_form = new frmTeor();
            thirt_form.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            thirt_form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}