
namespace IDE
{
    partial class AddNewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewForm));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.buttonEdit_HotKey = new DevExpress.XtraEditors.ButtonEdit();
            this.Btn_AddNewFormCancel = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_AddNewFormOk = new DevExpress.XtraEditors.SimpleButton();
            this.buttonEdit_FilePath = new DevExpress.XtraEditors.ButtonEdit();
            this.textEdit_ButtonName = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit_HotKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit_FilePath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_ButtonName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.buttonEdit_HotKey);
            this.layoutControl1.Controls.Add(this.Btn_AddNewFormCancel);
            this.layoutControl1.Controls.Add(this.Btn_AddNewFormOk);
            this.layoutControl1.Controls.Add(this.buttonEdit_FilePath);
            this.layoutControl1.Controls.Add(this.textEdit_ButtonName);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(272, 138);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // buttonEdit_HotKey
            // 
            this.buttonEdit_HotKey.Location = new System.Drawing.Point(93, 60);
            this.buttonEdit_HotKey.Name = "buttonEdit_HotKey";
            this.buttonEdit_HotKey.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit_HotKey.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.buttonEdit_HotKey.Size = new System.Drawing.Size(167, 20);
            this.buttonEdit_HotKey.StyleController = this.layoutControl1;
            this.buttonEdit_HotKey.TabIndex = 9;
            this.buttonEdit_HotKey.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit_HotKey_ButtonClick);
            this.buttonEdit_HotKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buttonEdit_HotKey_KeyDown);
            // 
            // Btn_AddNewFormCancel
            // 
            this.Btn_AddNewFormCancel.Location = new System.Drawing.Point(133, 104);
            this.Btn_AddNewFormCancel.Name = "Btn_AddNewFormCancel";
            this.Btn_AddNewFormCancel.Size = new System.Drawing.Size(127, 22);
            this.Btn_AddNewFormCancel.StyleController = this.layoutControl1;
            this.Btn_AddNewFormCancel.TabIndex = 8;
            this.Btn_AddNewFormCancel.Text = "Cancel";
            this.Btn_AddNewFormCancel.Click += new System.EventHandler(this.Btn_AddNewFormCancel_Click);
            // 
            // Btn_AddNewFormOk
            // 
            this.Btn_AddNewFormOk.Location = new System.Drawing.Point(12, 104);
            this.Btn_AddNewFormOk.Name = "Btn_AddNewFormOk";
            this.Btn_AddNewFormOk.Size = new System.Drawing.Size(117, 22);
            this.Btn_AddNewFormOk.StyleController = this.layoutControl1;
            this.Btn_AddNewFormOk.TabIndex = 7;
            this.Btn_AddNewFormOk.Text = "OK";
            this.Btn_AddNewFormOk.Click += new System.EventHandler(this.Btn_AddNewFormOk_Click);
            // 
            // buttonEdit_FilePath
            // 
            this.buttonEdit_FilePath.Location = new System.Drawing.Point(93, 36);
            this.buttonEdit_FilePath.Name = "buttonEdit_FilePath";
            this.buttonEdit_FilePath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit_FilePath.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.buttonEdit_FilePath.Size = new System.Drawing.Size(167, 20);
            this.buttonEdit_FilePath.StyleController = this.layoutControl1;
            this.buttonEdit_FilePath.TabIndex = 5;
            this.buttonEdit_FilePath.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit_FilePath_ButtonClick);
            // 
            // textEdit_ButtonName
            // 
            this.textEdit_ButtonName.Location = new System.Drawing.Point(93, 12);
            this.textEdit_ButtonName.Name = "textEdit_ButtonName";
            this.textEdit_ButtonName.Size = new System.Drawing.Size(167, 20);
            this.textEdit_ButtonName.StyleController = this.layoutControl1;
            this.textEdit_ButtonName.TabIndex = 4;
            this.textEdit_ButtonName.TextChanged += new System.EventHandler(this.textEdit_ButtonName_TextChanged);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem3});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(272, 138);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.textEdit_ButtonName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(252, 24);
            this.layoutControlItem1.Text = "ButtonName";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(69, 14);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 72);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(252, 20);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.buttonEdit_FilePath;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(252, 24);
            this.layoutControlItem2.Text = "File Path";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(69, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.Btn_AddNewFormOk;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 92);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(121, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.Btn_AddNewFormCancel;
            this.layoutControlItem5.Location = new System.Drawing.Point(121, 92);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(131, 26);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.buttonEdit_HotKey;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(252, 24);
            this.layoutControlItem3.Text = "Hot Key";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(69, 14);
            // 
            // AddNewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 138);
            this.Controls.Add(this.layoutControl1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("AddNewForm.IconOptions.Image")));
            this.Name = "AddNewForm";
            this.Text = "AddNewForm";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit_HotKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit_FilePath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_ButtonName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton Btn_AddNewFormCancel;
        private DevExpress.XtraEditors.SimpleButton Btn_AddNewFormOk;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit_FilePath;
        private DevExpress.XtraEditors.TextEdit textEdit_ButtonName;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit_HotKey;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}