namespace MapTestApp
{
    partial class MapForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mapControl1 = new MapInfo.Windows.Controls.MapControl();
            this.mapToolBar1 = new MapInfo.Windows.Controls.MapToolBar();
            this.mapToolBarButtonLayerControl = new MapInfo.Windows.Controls.MapToolBarButton();
            this.toolBarButtonSeparator = new System.Windows.Forms.ToolBarButton();
            this.mapToolBarButtonSelect = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarButtonZoomIn = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarButtonZoomOut = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarButtonPan = new MapInfo.Windows.Controls.MapToolBarButton();
            this.toolBarButtonSeparator2 = new System.Windows.Forms.ToolBarButton();
            this.mapToolBarButtonSelectRect = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarButtonSelectRadius = new MapInfo.Windows.Controls.MapToolBarButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ctType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btPie = new System.Windows.Forms.Button();
            this.btClear = new System.Windows.Forms.Button();
            this.btSearch = new System.Windows.Forms.Button();
            this.tbXianName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapControl1
            // 
            this.mapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapControl1.IgnoreLostFocusEvent = false;
            this.mapControl1.Location = new System.Drawing.Point(0, 0);
            this.mapControl1.Name = "mapControl1";
            this.mapControl1.Size = new System.Drawing.Size(771, 179);
            this.mapControl1.TabIndex = 0;
            this.mapControl1.Text = "mapControl1";
            this.mapControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.mapControl1_MouseDoubleClick);
            this.mapControl1.Tools.LeftButtonTool = null;
            this.mapControl1.Tools.MiddleButtonTool = null;
            this.mapControl1.Tools.RightButtonTool = null;
            // 
            // mapToolBar1
            // 
            this.mapToolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.mapToolBarButtonLayerControl,
            this.toolBarButtonSeparator,
            this.mapToolBarButtonSelect,
            this.mapToolBarButtonZoomIn,
            this.mapToolBarButtonZoomOut,
            this.mapToolBarButtonPan,
            this.toolBarButtonSeparator2,
            this.mapToolBarButtonSelectRect,
            this.mapToolBarButtonSelectRadius});
            this.mapToolBar1.DropDownArrows = true;
            this.mapToolBar1.Location = new System.Drawing.Point(0, 0);
            this.mapToolBar1.MapControl = this.mapControl1;
            this.mapToolBar1.Name = "mapToolBar1";
            this.mapToolBar1.ShowToolTips = true;
            this.mapToolBar1.Size = new System.Drawing.Size(799, 28);
            this.mapToolBar1.TabIndex = 1;
            // 
            // mapToolBarButtonLayerControl
            // 
            this.mapToolBarButtonLayerControl.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.LayerControl;
            this.mapToolBarButtonLayerControl.Name = "mapToolBarButtonLayerControl";
            this.mapToolBarButtonLayerControl.ToolTipText = "图层控制";
            this.mapToolBarButtonLayerControl.Visible = false;
            // 
            // toolBarButtonSeparator
            // 
            this.toolBarButtonSeparator.Name = "toolBarButtonSeparator";
            this.toolBarButtonSeparator.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // mapToolBarButtonSelect
            // 
            this.mapToolBarButtonSelect.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.Select;
            this.mapToolBarButtonSelect.Name = "mapToolBarButtonSelect";
            this.mapToolBarButtonSelect.ToolTipText = "选择";
            // 
            // mapToolBarButtonZoomIn
            // 
            this.mapToolBarButtonZoomIn.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.ZoomIn;
            this.mapToolBarButtonZoomIn.Name = "mapToolBarButtonZoomIn";
            this.mapToolBarButtonZoomIn.ToolTipText = "放大";
            // 
            // mapToolBarButtonZoomOut
            // 
            this.mapToolBarButtonZoomOut.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.ZoomOut;
            this.mapToolBarButtonZoomOut.Name = "mapToolBarButtonZoomOut";
            this.mapToolBarButtonZoomOut.ToolTipText = "缩小";
            // 
            // mapToolBarButtonPan
            // 
            this.mapToolBarButtonPan.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.Pan;
            this.mapToolBarButtonPan.Name = "mapToolBarButtonPan";
            this.mapToolBarButtonPan.ToolTipText = "平移";
            // 
            // toolBarButtonSeparator2
            // 
            this.toolBarButtonSeparator2.Name = "toolBarButtonSeparator2";
            this.toolBarButtonSeparator2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // mapToolBarButtonSelectRect
            // 
            this.mapToolBarButtonSelectRect.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.SelectRectangle;
            this.mapToolBarButtonSelectRect.Name = "mapToolBarButtonSelectRect";
            this.mapToolBarButtonSelectRect.ToolTipText = "矩形选择";
            this.mapToolBarButtonSelectRect.Visible = false;
            // 
            // mapToolBarButtonSelectRadius
            // 
            this.mapToolBarButtonSelectRadius.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.SelectRadius;
            this.mapToolBarButtonSelectRadius.Name = "mapToolBarButtonSelectRadius";
            this.mapToolBarButtonSelectRadius.ToolTipText = "半径选择";
            this.mapToolBarButtonSelectRadius.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 224);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(799, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.ToolTipText = "地图缩放";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.mapControl1);
            this.panel1.Location = new System.Drawing.Point(12, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 183);
            this.panel1.TabIndex = 3;
            // 
            // ctType
            // 
            this.ctType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctType.FormattingEnabled = true;
            this.ctType.Location = new System.Drawing.Point(153, 5);
            this.ctType.Name = "ctType";
            this.ctType.Size = new System.Drawing.Size(95, 20);
            this.ctType.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "类型";
            // 
            // btPie
            // 
            this.btPie.Location = new System.Drawing.Point(255, 4);
            this.btPie.Name = "btPie";
            this.btPie.Size = new System.Drawing.Size(75, 23);
            this.btPie.TabIndex = 6;
            this.btPie.Text = "饼图";
            this.btPie.UseVisualStyleBackColor = true;
            this.btPie.Click += new System.EventHandler(this.btPie_Click);
            // 
            // btClear
            // 
            this.btClear.Location = new System.Drawing.Point(336, 4);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(75, 23);
            this.btClear.TabIndex = 7;
            this.btClear.Text = "清除";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(558, 4);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(75, 23);
            this.btSearch.TabIndex = 8;
            this.btSearch.Text = "查找";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // tbXianName
            // 
            this.tbXianName.Location = new System.Drawing.Point(454, 5);
            this.tbXianName.Name = "tbXianName";
            this.tbXianName.Size = new System.Drawing.Size(100, 21);
            this.tbXianName.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(421, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "县名";
            // 
            // MapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 246);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbXianName);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.btPie);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctType);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mapToolBar1);
            this.Controls.Add(this.panel1);
            this.Name = "MapForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "贵州省各县人口数据";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MapForm1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MapInfo.Windows.Controls.MapControl mapControl1;
        private MapInfo.Windows.Controls.MapToolBar mapToolBar1;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarButtonLayerControl;
        private System.Windows.Forms.ToolBarButton toolBarButtonSeparator;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarButtonSelect;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarButtonZoomIn;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarButtonZoomOut;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarButtonPan;
        private System.Windows.Forms.ToolBarButton toolBarButtonSeparator2;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarButtonSelectRect;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarButtonSelectRadius;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox ctType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btPie;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.TextBox tbXianName;
        private System.Windows.Forms.Label label2;
    }
}

