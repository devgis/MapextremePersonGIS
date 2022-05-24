using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace MapTestApp
{
    public partial class ShowInfo : Form
    {
        private string message;
        private DataRow drPata;
        public ShowInfo(String Message,DataRow drData)
        {
            InitializeComponent();
            this.message = Message;
            this.drPata = drData;
        }

        private void ShowInfo_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = message;
            LoadChart();
        }

        private void LoadChart()
        {
            GraphPane myPane;
            myPane = zedGraphControl1.GraphPane;
            myPane.Title.Text = "柱图";
            myPane.Title.FontSpec.Size = 10;
            myPane.YAxis.Title.Text = "数量";
            myPane.YAxis.Title.FontSpec.Size = 8;
            myPane.YAxis.Scale.FontSpec.Size = 5;

            myPane.Legend.Border.Color = Color.White; //去掉图例边框
            myPane.Legend.FontSpec.Size = 8; //图例字体大小

            if(drPata!=null)
            {
                int Count=MapForm.DataTablePerson.Columns.Count-2;
                double[] Values=new double[Count];
                string[] Labels=new string[Count];

                for (int i = 2; i < Count - 1;i++ )
                {
                    Labels[i - 2] = MapForm.DataTablePerson.Columns[i].Caption;
                    Values[i - 2] = Convert.ToDouble(drPata[i]);
                }
                myPane.AddPieSlices(Values, Labels);
            }
        }

        private void zedGraphControl1_Click(object sender, EventArgs e)
        {
            ChartsForm frmChartsForm = new ChartsForm(drPata);
            frmChartsForm.ShowDialog();
        }
    }
}