using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MapInfo.Mapping;
using MapInfo.Data;
using MapInfo.Engine;
using MapInfo.Tools;
using MapInfo.Mapping.Thematics;
using MapInfo.Styles;

namespace MapTestApp
{
    public partial class MapForm : Form
    {
        public static DataTable DataTablePerson = null; //保存人口数据表
        public Table XianTable = null;
        List<string> listBMPS = new List<string>();
        public MapForm()
        {
            InitializeComponent();
            mapControl1.Map.ViewChangedEvent += new MapInfo.Mapping.ViewChangedEventHandler(Map_ViewChangedEvent);
            Map_ViewChangedEvent(this, null);

            string CommonFilesPah = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles);
            string BMPPath = Path.Combine(CommonFilesPah, @"MapInfo\MapXtreme\6.8.0\CustSymb");

            string[] s = Directory.GetFiles(BMPPath, "*.BMP");
            foreach (string stemp in s)
            {
                listBMPS.Add(stemp.Substring(stemp.LastIndexOf("\\") + 1, stemp.Length - 1 - stemp.LastIndexOf("\\")));
            }
        }

        void Map_ViewChangedEvent(object sender, MapInfo.Mapping.ViewChangedEventArgs e)
        {
            // Display the zoom level
            Double dblZoom = System.Convert.ToDouble(String.Format("{0:E2}", mapControl1.Map.Zoom.Value));
            if (statusStrip1.Items.Count > 0)
            {
                statusStrip1.Items[0].Text = "缩放: " + dblZoom.ToString() + " " + MapInfo.Geometry.CoordSys.DistanceUnitAbbreviation(mapControl1.Map.Zoom.Unit);
            }
        }

        private void MapForm1_Load(object sender, EventArgs e)
        {
            //加载地图
            string MapPath = Path.Combine(Application.StartupPath, @"map\map.mws");
            MapWorkSpaceLoader mwsLoader = new MapWorkSpaceLoader(MapPath);
            mapControl1.Map.Load(mwsLoader);
            mapControl1.Tools.LeftButtonTool = "Select";

            DataTablePerson = OleHelper.Instance.GetDataTable("select * from peopledata");//加载人口数据表

            if (DataTablePerson == null || DataTablePerson.Rows.Count <= 0)
                return;

            for (int i = 2; i < DataTablePerson.Columns.Count; i++)
            {
                ctType.Items.Add(DataTablePerson.Columns[i].ColumnName);
            }
            try
            {
                ctType.SelectedIndex = 0;
            }
            catch
            { }

            FeatureLayer fLayer = null;
            //MapTool.SetInfoTipExpression(MyMapControl.Tools["Select"], bugLayer, "'详细信息：'+other"); // "'详细信息：'+other" //MyMapControl.Tools.MapToolProperties
            foreach (IMapLayer layer in mapControl1.Map.Layers)
            {
                if (layer is FeatureLayer && layer.Alias.Equals("县界"))
                {
                    fLayer = layer as FeatureLayer;
                    XianTable = fLayer.Table;
                }
            }
            if (fLayer != null)
            {
                //MessageBox.Show(fLayer.InfoTipExpression)
                //MapTool.SetInfoTipExpression(mapControl1.Tools.CurrentTool, fLayer, "TOOLTIP");
            }

            if (XianTable != null)
            {
                SearchInfo si = MapInfo.Data.SearchInfoFactory.SearchAll();
                si.QueryDefinition.Columns = null;
                IResultSetFeatureCollection ifs = MapInfo.Engine.Session.Current.Catalog.Search(XianTable, si);

                for (int i = 0; i < ifs.Count; i++)
                {
                    Feature f = ifs[i];
                    string Name = f["NAME"].ToString();
                    //string ToolTipString = string.Empty;
                    //foreach (DataRow dr in DataTablePerson.Rows)
                    //{
                    //    if (Name.Trim().Equals(dr[1].ToString().Trim()))
                    //    {
                    //        foreach (DataColumn column in DataTablePerson.Columns)
                    //        {
                    //            ToolTipString += column.Caption+"：" + dr[column].ToString() + "\r\n";
                    //        }
                    //        break;
                    //    }
                    //}
                    //if (string.IsNullOrEmpty(ToolTipString.Trim()))
                    //{
                    //    ToolTipString = "人口数据不存在!";
                    //}
                    f["TOOLTIP"] = GetMessage(Name);
                    f.Update();
                }

            }
        }

        private void mapControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //取得地图坐标点
            System.Drawing.PointF DisplayPoint = new PointF(e.X, e.Y);
            MapInfo.Geometry.DPoint MapPoint = new MapInfo.Geometry.DPoint();
            MapInfo.Geometry.DisplayTransform converter = this.mapControl1.Map.DisplayTransform;
            converter.FromDisplay(DisplayPoint, out MapPoint);

            //查找县

            SearchInfo si = MapInfo.Data.SearchInfoFactory.SearchIntersectsGeometry(new MapInfo.Geometry.Point(mapControl1.Map.GetDisplayCoordSys(),MapPoint),IntersectType.Geometry);
            si.QueryDefinition.Columns = null;
            IResultSetFeatureCollection ifs = MapInfo.Engine.Session.Current.Catalog.Search(XianTable, si);

            if (ifs == null || ifs.Count <= 0)
                return;
            else
            {
                string Name = ifs[0]["NAME"].ToString();
                string Message = GetMessage(Name);
                ShowInfo frmShowInfo = new ShowInfo(Message, drSerachResult);
                frmShowInfo.ShowDialog();
            }

        }
        DataRow drSerachResult = null;
        /// <summary>
        /// 查找所属县的人口数据
        /// </summary>
        /// <param name="XianName">县名</param>
        /// <returns></returns>
        private string GetMessage(string Name)
        {
            string ToolTipString = string.Empty;
            foreach (DataRow dr in DataTablePerson.Rows)
            {
                if (Name.Trim().Equals(dr[1].ToString().Trim()))
                {
                    drSerachResult = dr;
                    foreach (DataColumn column in DataTablePerson.Columns)
                    {
                        ToolTipString += column.Caption + "：" + dr[column].ToString() + "\r\n";
                    }
                    break;
                }
            }
            if (string.IsNullOrEmpty(ToolTipString.Trim()))
            {
                ToolTipString = "人口数据不存在!";
            }
            return ToolTipString;
        }
        MapInfo.Mapping.Thematics.GraduatedSymbolTheme theme = null;
        private void btPie_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ctType.Text.Trim()))
            {
                MessageBox.Show("请选择类型");
            }
            else
            {
                //初始化数据
                SearchInfo si = MapInfo.Data.SearchInfoFactory.SearchAll();
                si.QueryDefinition.Columns = null;
                IResultSetFeatureCollection ifs = MapInfo.Engine.Session.Current.Catalog.Search(XianTable, si);

                for (int i = 0; i < ifs.Count; i++)
                {
                    Feature f = ifs[i];
                    string name = f["NAME"].ToString();
                    float value=0;

                    foreach (DataRow dr in DataTablePerson.Rows)
                    {
                        if (name.Trim().Equals(dr[1].ToString().Trim()))
                        {
                            value = Convert.ToSingle(dr[ctType.Text]);
                            break;
                        }
                    }

                    f["VALUE"] = value;
                    f.Update();
                }


                //初始化饼图
                DeletePieThemeLayer();//清除
                theme = new GraduatedSymbolTheme(
                        XianTable,
                        "VALUE");
                ObjectThemeLayer themeLayer = new ObjectThemeLayer(
                    "人口数据", null, theme);
                
                mapControl1.Map.Layers.Add(themeLayer);
                //BaseLineStyle linStyel = new MapInfo.Styles.();
                //(linStyel as SimpleLineStyle).Color= Color.Green;
                //theme.BorderLineStyle = linStyel;

                BitmapPointStyle bmpStyl = new BitmapPointStyle(listBMPS[ctType.SelectedIndex], BitmapStyles.None, Color.Red, 100);//"AMBU1-32.bmp"
                theme.PositiveSymbol = bmpStyl; 
                
                theme.DataValueAtSize *= 2;
                theme.GraduateSizeBy = GraduateSizeBy.Constant;
                themeLayer.RebuildTheme();

            }
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            DeletePieThemeLayer();//清除
        }

        private void DeletePieThemeLayer()
        {
            // Remove previous themes:
            MapLayerEnumerator e = mapControl1.Map.Layers.GetMapLayerEnumerator(MapLayerFilterFactory.FilterByType(typeof(ObjectThemeLayer)));
            while (e.MoveNext())
            {
                mapControl1.Map.Layers.Remove(e.Current);
                e = mapControl1.Map.Layers.GetMapLayerEnumerator(MapLayerFilterFactory.FilterByType(typeof(ObjectThemeLayer)));
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbXianName.Text.Trim()))
            {
                MessageBox.Show("请输入县名！");
                tbXianName.Focus();
            }
            else
            {
                String Where = "NAME='" + tbXianName.Text + "'";
                SearchInfo si = MapInfo.Data.SearchInfoFactory.SearchWhere(Where);
                si.QueryDefinition.Columns = null;
                IResultSetFeatureCollection ifs = MapInfo.Engine.Session.Current.Catalog.Search(XianTable, si);
                if (ifs == null || ifs.Count <= 0)
                {
                    MessageBox.Show("没有符合查询条件的结果！");
                }
                else
                {
                    Feature f = ifs[0];
                    string name = f["NAME"].ToString();
                    String Info = GetMessage(name);
                    mapControl1.Map.Bounds = f.Geometry.Bounds;
                    Session.Current.Selections.DefaultSelection.Clear();
                    Session.Current.Selections.DefaultSelection.Add(ifs);
                    ShowInfo frmShowInfo = new ShowInfo(Info, drSerachResult);
                    frmShowInfo.ShowDialog();


                }
            }
        }
    }
}
