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
    public partial class ChartsForm : Form
    {
        private DataRow drPata;
        public ChartsForm(DataRow DrPata)
        {
            InitializeComponent();
            this.drPata = DrPata;
        }

        private void ChartsForm_Load(object sender, EventArgs e)
        {
            LoadChart();
        }

        private void LoadChart()
        {
            if (drPata == null || drPata.ItemArray.Length <= 0)
                return;


            LoadManWomenData(); //男女户籍人口柱图
            LoadPersonData();//户籍人口饼图

            LoadPersonDataCurve();//总人口曲线
            LoadRateCurve(); //增长率
            LoadTotalFamilyCurve();//总户数曲线
            LoadCityPersonDataCurve();//非农人口人口曲线
            LoadManCountCurve();//男性人口曲线
            LoadWomanCountCurve();//女性人口曲线
        }

        //男女户籍人口柱图
        private void LoadManWomenData()
        {
            try
            {
                PieItem CHI1 = zedGraphControl1.GraphPane.CurveList[0] as PieItem;
                IPointListEdit CH1List = CHI1.Points as IPointListEdit;
                CH1List.Clear();
            }
            catch
            { }
            GraphPane myPane;
            myPane = zedGraphControl1.GraphPane;
            myPane.Title.Text = "饼图";
            myPane.Title.FontSpec.Size = 20;
            myPane.YAxis.Title.Text = "数量";
            myPane.YAxis.Title.FontSpec.Size = 18;
            myPane.YAxis.Scale.FontSpec.Size = 15;

            myPane.Legend.Border.Color = Color.White; //去掉图例边框
            myPane.Legend.FontSpec.Size = 18; //图例字体大小

            double[] Values = new double[10];
            string[] Labels = new string[10];
            //男女人口
            for (int i = 0; i < 10; i++)
            {
                Labels[i] = MapForm.DataTablePerson.Columns[i + 21].Caption;
                Values[i] = Convert.ToDouble(drPata[i + 21]);
            }
            myPane.AddPieSlices(Values, Labels);

            
        }

        //户籍人口饼图
        private void LoadPersonData()
        {

            try
            {
                PieItem CHI1 = zedGraphControl2.GraphPane.CurveList[0] as PieItem;
                IPointListEdit CH1List = CHI1.Points as IPointListEdit;
                CH1List.Clear();
            }
            catch
            { }
            GraphPane myPane;
            myPane = zedGraphControl2.GraphPane;
            myPane.Title.Text = "户籍人口饼图";
            myPane.Title.FontSpec.Size = 20;
            myPane.YAxis.Title.Text = "数量";
            myPane.YAxis.Title.FontSpec.Size = 18;
            myPane.YAxis.Scale.FontSpec.Size = 15;

            myPane.Legend.Border.Color = Color.White; //去掉图例边框
            myPane.Legend.FontSpec.Size = 18; //图例字体大小

            double[] Values = new double[10];
            string[] Labels = new string[10];
            //男女人口
            for (int i = 0; i < 5; i++)
            {
                Labels[i] = MapForm.DataTablePerson.Columns[i + 2].Caption;
                Values[i] = Convert.ToDouble(drPata[i + 2]);
            }
            myPane.AddPieSlices(Values, Labels);
        }

        //总人口曲线
        private void LoadPersonDataCurve()
        {
            GraphPane myPane;
            myPane = zedGraphControl4.GraphPane;
            myPane.Title.Text = "曲线";
            myPane.Title.FontSpec.Size = 20;
            myPane.YAxis.Title.Text = "数量";
            myPane.YAxis.Title.FontSpec.Size = 18;
            myPane.YAxis.Scale.FontSpec.Size = 15;

            myPane.Legend.Border.Color = Color.White; //去掉图例边框
            myPane.Legend.FontSpec.Size = 18; //图例字体大小

            PointPairList list = new PointPairList();
            for (int i = 0; i < 5; i++)
            {
                double x = new XDate(i+2008, 0, 0);//new XDate( 1995, i+1, 1 );
                double y = Convert.ToDouble(drPata[i + 2]);
                PointPair p = new PointPair();
                p.X = x;
                p.Y = y;
                list.Add(p);
            }
            try
            {
                LineItem CHI1 = zedGraphControl4.GraphPane.CurveList[0] as LineItem;
                IPointListEdit CH1List = CHI1.Points as IPointListEdit;
                CH1List.Clear();
            }
            catch
            { }
            // Generate a blue curve with circle symbols, and "My Curve 2" in the legend
            LineItem myCurve2 = myPane.AddCurve("总人口", list, Color.Blue,
                                    SymbolType.Circle);

            zedGraphControl4.AxisChange();
        }

        //增长率
        private void LoadRateCurve()
        {
            GraphPane myPane;
            myPane = zedGraphControl5.GraphPane;
            myPane.Title.Text = "曲线";
            myPane.Title.FontSpec.Size = 20;
            myPane.YAxis.Title.Text = "数量";
            myPane.YAxis.Title.FontSpec.Size = 18;
            myPane.YAxis.Scale.FontSpec.Size = 15;

            myPane.Legend.Border.Color = Color.White; //去掉图例边框
            myPane.Legend.FontSpec.Size = 18; //图例字体大小

            PointPairList list = new PointPairList();
            for (int i = 0; i < 5; i++)
            {
                double x = new XDate(i + 2008, 0, 0);//new XDate( 1995, i+1, 1 );
                double y = Convert.ToDouble(drPata[i + 7]);
                PointPair p = new PointPair();
                p.X = x;
                p.Y = y;
                list.Add(p);
            }
            try
            {
                LineItem CHI1 = zedGraphControl5.GraphPane.CurveList[0] as LineItem;
                IPointListEdit CH1List = CHI1.Points as IPointListEdit;
                CH1List.Clear();
            }
            catch
            { }
            // Generate a blue curve with circle symbols, and "My Curve 2" in the legend
            LineItem myCurve2 = myPane.AddCurve("增长率", list, Color.Blue,
                                    SymbolType.Circle);

            zedGraphControl5.AxisChange();
        }

        //总户数曲线
        private void LoadTotalFamilyCurve()
        {
            GraphPane myPane;
            myPane = zedGraphControl6.GraphPane;
            myPane.Title.Text = "曲线";
            myPane.Title.FontSpec.Size = 20;
            myPane.YAxis.Title.Text = "数量";
            myPane.YAxis.Title.FontSpec.Size = 18;
            myPane.YAxis.Scale.FontSpec.Size = 15;

            myPane.Legend.Border.Color = Color.White; //去掉图例边框
            myPane.Legend.FontSpec.Size = 18; //图例字体大小

            PointPairList list = new PointPairList();
            for (int i = 0; i < 5; i++)
            {
                double x = new XDate(i + 2008, 0, 0);//new XDate( 1995, i+1, 1 );
                double y = Convert.ToDouble(drPata[i + 12]);
                PointPair p = new PointPair();
                p.X = x;
                p.Y = y;
                list.Add(p);
            }
            try
            {
                LineItem CHI1 = zedGraphControl6.GraphPane.CurveList[0] as LineItem;
                IPointListEdit CH1List = CHI1.Points as IPointListEdit;
                CH1List.Clear();
            }
            catch
            { }
            // Generate a blue curve with circle symbols, and "My Curve 2" in the legend
            LineItem myCurve2 = myPane.AddCurve("总户数曲线", list, Color.Blue,
                                    SymbolType.Circle);

            zedGraphControl6.AxisChange();
        }

        //非农人口人口曲线
        private void LoadCityPersonDataCurve()
        {
            GraphPane myPane;
            myPane = zedGraphControl7.GraphPane;
            myPane.Title.Text = "曲线";
            myPane.Title.FontSpec.Size = 20;
            myPane.YAxis.Title.Text = "数量";
            myPane.YAxis.Title.FontSpec.Size = 18;
            myPane.YAxis.Scale.FontSpec.Size = 15;

            myPane.Legend.Border.Color = Color.White; //去掉图例边框
            myPane.Legend.FontSpec.Size = 18; //图例字体大小

            PointPairList list = new PointPairList();
            for (int i = 0; i < 5; i++)
            {
                double x = new XDate(i + 2008, 0, 0);//new XDate( 1995, i+1, 1 );
                double y = Convert.ToDouble(drPata[i + 17]);
                PointPair p = new PointPair();
                p.X = x;
                p.Y = y;
                list.Add(p);
            }
            try
            {
                LineItem CHI1 = zedGraphControl7.GraphPane.CurveList[0] as LineItem;
                IPointListEdit CH1List = CHI1.Points as IPointListEdit;
                CH1List.Clear();
            }
            catch
            { }
            // Generate a blue curve with circle symbols, and "My Curve 2" in the legend
            LineItem myCurve2 = myPane.AddCurve("非农人口", list, Color.Blue,
                                    SymbolType.Circle);

            zedGraphControl7.AxisChange();
        }

        //男性人口曲线
        private void LoadManCountCurve()
        {
            GraphPane myPane;
            myPane = zedGraphControl8.GraphPane;
            myPane.Title.Text = "曲线";
            myPane.Title.FontSpec.Size = 20;
            myPane.YAxis.Title.Text = "数量";
            myPane.YAxis.Title.FontSpec.Size = 18;
            myPane.YAxis.Scale.FontSpec.Size = 15;

            myPane.Legend.Border.Color = Color.White; //去掉图例边框
            myPane.Legend.FontSpec.Size = 18; //图例字体大小

            PointPairList list = new PointPairList();
            for (int i = 0; i < 5; i++)
            {
                double x = new XDate(i + 2008, 0, 0);//new XDate( 1995, i+1, 1 );
                double y = Convert.ToDouble(drPata[2*i + 17]);
                PointPair p = new PointPair();
                p.X = x;
                p.Y = y;
                list.Add(p);
            }
            try
            {
                LineItem CHI1 = zedGraphControl8.GraphPane.CurveList[0] as LineItem;
                IPointListEdit CH1List = CHI1.Points as IPointListEdit;
                CH1List.Clear();
            }
            catch
            { }
            // Generate a blue curve with circle symbols, and "My Curve 2" in the legend
            LineItem myCurve2 = myPane.AddCurve("男性人口", list, Color.Blue,
                                    SymbolType.Circle);

            zedGraphControl8.AxisChange();
        }

        //女性人口曲线
        private void LoadWomanCountCurve()
        {
            GraphPane myPane;
            myPane = zedGraphControl9.GraphPane;
            myPane.Title.Text = "曲线";
            myPane.Title.FontSpec.Size = 20;
            myPane.YAxis.Title.Text = "数量";
            myPane.YAxis.Title.FontSpec.Size = 18;
            myPane.YAxis.Scale.FontSpec.Size = 15;

            myPane.Legend.Border.Color = Color.White; //去掉图例边框
            myPane.Legend.FontSpec.Size = 18; //图例字体大小

            PointPairList list = new PointPairList();
            for (int i = 0; i < 5; i++)
            {
                double x = new XDate(i + 2008, 0, 0);//new XDate( 1995, i+1, 1 );
                double y = Convert.ToDouble(drPata[2*i+1 + 17]);
                PointPair p = new PointPair();
                p.X = x;
                p.Y = y;
                list.Add(p);
            }
            try
            {
                LineItem CHI1 = zedGraphControl9.GraphPane.CurveList[0] as LineItem;
                IPointListEdit CH1List = CHI1.Points as IPointListEdit;
                CH1List.Clear();
            }
            catch
            { }
            // Generate a blue curve with circle symbols, and "My Curve 2" in the legend
            LineItem myCurve2 = myPane.AddCurve("女性人口", list, Color.Blue,
                                    SymbolType.Circle);

            zedGraphControl9.AxisChange();
        }
    }
}