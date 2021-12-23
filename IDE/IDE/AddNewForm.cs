using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace IDE
{
    public partial class AddNewForm : DevExpress.XtraEditors.XtraForm
    {
        public string ButtonName = string.Empty;
        public string FilePath = string.Empty;
        public string HotKey = string.Empty;
        public Keys Key;
        public HotKey.KeyModifiers Modifier;
        public AddNewForm()
        {
            InitializeComponent();
        }

        private void textEdit_ButtonName_TextChanged(object sender, EventArgs e)
        {
            ButtonName = textEdit_ButtonName.Text;
        }

        private void buttonEdit_FilePath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            TMDIDE.fileDialog.Title = "Select Project file";
            TMDIDE.fileDialog.Filter = "可执行文件|*.*";
            if (TMDIDE.fileDialog.ShowDialog() == DialogResult.OK)
            {
                buttonEdit_FilePath.Text = TMDIDE.fileDialog.FileName;
                FilePath = TMDIDE.fileDialog.FileName;
            }
        }

        private void buttonEdit_HotKey_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            
        }

        private void buttonEdit_HotKey_KeyDown(object sender, KeyEventArgs e)
        {
            buttonEdit_HotKey.Text = Enum.GetName(typeof(Keys), ModifierKeys) + "+" + Enum.GetName(typeof(Keys), e.KeyValue);
            foreach (int item in Enum.GetValues(typeof(HotKey.KeyModifiers)))
            {
                if (Enum.GetName(typeof(Keys), ModifierKeys) == Enum.GetName(typeof(HotKey.KeyModifiers), item))
                {
                    Modifier = (HotKey.KeyModifiers)item;
                }
            }
            Key = (Keys)e.KeyValue;
            HotKey = buttonEdit_HotKey.Text;
        }

        private void Btn_AddNewFormOk_Click(object sender, EventArgs e)
        {
            if (ButtonName == string.Empty || FilePath == string.Empty || HotKey == string.Empty)
            {
                DialogResult = DialogResult.Cancel;
                return;
            }
            if (!File.Exists(TMDIDE.ConfigFile))
            {
                XtraMessageBox.Show("配置文件不存在:" + TMDIDE.ConfigFile, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                return;
            }
            List<string> ConfigList = File.ReadLines(TMDIDE.ConfigFile).ToList();
            string HotKeyStr = "C|" + ButtonName + "|" + buttonEdit_HotKey.Text + "|" + FilePath;
            for (int i = 0; i < ConfigList.Count; ++i)
            {
                int index = 1;
                if (ConfigList[i] == "[HotKeyStart]")
                {
                    while (ConfigList[i + index] != "[HotKeyEnd]")
                    {
                        if (ConfigList[i + index].Contains(ButtonName))
                        {
                            ConfigList.RemoveAt(i + index);
                        }
                        ++index;
                    }
                }
                if (ConfigList[i] == "[HotKeyEnd]")
                {
                    ConfigList.Insert(i, HotKeyStr);
                    break;
                }
            }
            StreamWriter sw = new StreamWriter(TMDIDE.ConfigFile);
            foreach (string item in ConfigList)
            {
                sw.WriteLine(item);
            }
            sw.Close();
            DialogResult = DialogResult.OK;
        }

        private void Btn_AddNewFormCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}