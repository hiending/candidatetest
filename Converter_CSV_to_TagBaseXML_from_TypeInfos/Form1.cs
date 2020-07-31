using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;


namespace Converter_CSV_to_TagBaseXML_from_TypeInfos
{
    /// <summary>
    /// Программа для конвертирования объектов в базу тегов XML в соответствии с TypeInfos
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //инициализация логики
            LogicsProgram = new Logics(this);

            //У таблицы убираем последнюю пустую строку
            dataGridView_SelectInput.AllowUserToAddRows = false;

            //деактивируем кнопку до тех пор пока не будут обработаны входные файлы
            button_Convert.Enabled = false;

        }

        //объявим 
        private Logics LogicsProgram;


        //поместим входные данные в таблицу
        private void input_InDataGridView()
        {
            dataGridView_SelectInput.Rows.Clear();

            if (LogicsProgram.arrInput.Count > 0)
            {
                for (int i = 0; i < LogicsProgram.arrInput.Count; i++)
                {
                    dataGridView_SelectInput.Rows.Add(i + 1, LogicsProgram.arrInput[i].Tag, LogicsProgram.arrInput[i].Type, LogicsProgram.arrInput[i].Address);
                    
                    //Защита от ввода текущую строку с данными
                    for (int j = 0; j < dataGridView_SelectInput.Columns.Count; j++)
                    {
                        dataGridView_SelectInput[j, i].ReadOnly = true;
                    }
                }
            }
        }

        //открываем файл TypeInfos
        private void button_OpenFileTypeInfos_Click(object sender, EventArgs e)
        {
            LogicsProgram.FlagRead_TypeInfos = LogicsProgram.readFile_TypeInfos();

            if (LogicsProgram.FlagRead_TypeInfos)
            {
                button_OpenFileTypeInfos.BackColor = clrLightGreen;
            }
            else
            {
                button_OpenFileTypeInfos.BackColor = Color.Red;
                button_Convert.Enabled = false;

                errorMessage();
            }
        }

        //открываем файл Input
        private void button_OpenFileInput_Click(object sender, EventArgs e)
        {
            LogicsProgram.FlagRead_Input = LogicsProgram.readFile_InputCSV();

            if (LogicsProgram.FlagRead_Input)
            {
                button_OpenFileInput.BackColor = clrLightGreen;
                input_InDataGridView();
            }
            else
            {
                button_OpenFileInput.BackColor = Color.Red;
                button_Convert.Enabled = false;

                errorMessage();
            }

        }

        //сообщение об ошибке чтения файла
        private void errorMessage()
        {
            MessageBox.Show("Не удалось загрузить файл." + "\r" + "\n" +
                " Убедитесь, что файл не использует другая программа." + "\r" + "\n" +
                " Убедитесь, что формат файла веный.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //При наведении мыши на таблицу, элемент принимает фокус
        private void dataGridView_SelectInput_MouseEnter(object sender, EventArgs e)
        {
            dataGridView_SelectInput.Focus();
        }

        //создадим цвет подсветки выделенного элемента
        private Color clrLightGreen = Color.FromArgb(77, 255, 72);
        //Метод для выделения объекта конвертации
        private void dataGridView_SelectInput_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (dataGridView_SelectInput[1, e.RowIndex].Style.BackColor == Color.Empty)
                {
                    for (int i = 0; i< dataGridView_SelectInput.Columns.Count; i++)
                    {
                        dataGridView_SelectInput[i, e.RowIndex].Style.BackColor = clrLightGreen;
                    }
                }
                else if (dataGridView_SelectInput[1, e.RowIndex].Style.BackColor == clrLightGreen)
                {
                    for (int i = 0; i < dataGridView_SelectInput.Columns.Count; i++)
                    {
                        dataGridView_SelectInput[i, e.RowIndex].Style.BackColor = Color.Empty;
                    }
                }
            }
        }

        //Выделим все строки
        private void button_SelectAll_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < dataGridView_SelectInput.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView_SelectInput.Rows.Count; j++)
                {
                    dataGridView_SelectInput[i, j].Style.BackColor = clrLightGreen;
                }
                
            }
        }

        //Снимем выделение всех строк
        private void button_CancelAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView_SelectInput.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView_SelectInput.Rows.Count; j++)
                {
                    dataGridView_SelectInput[i, j].Style.BackColor = Color.Empty;
                }
            }
        }

        private void button_Convert_Click(object sender, EventArgs e)
        {
            //Сделаем выборку по выделенным из таблицы данным
            LogicsProgram.takeSelectedData(dataGridView_SelectInput, clrLightGreen);
            //Сделаем соединение с TypeInfos
            LogicsProgram.getAssociation();
            //Сохраним файлы XML
            LogicsProgram.saveOutputData();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Очистим таблицу если входной файл считан неверно
            if (!LogicsProgram.FlagRead_Input)
            {
                dataGridView_SelectInput.Rows.Clear();
            }

            //диактивируем кнопку конвертации до тех пор пока файлы не будут считанны корректно
            if (LogicsProgram.FlagRead_Input && LogicsProgram.FlagRead_TypeInfos)
            {
                button_Convert.Enabled = true;
            }
            else
            {
                button_Convert.Enabled = false;
            }
        }
    }
}
