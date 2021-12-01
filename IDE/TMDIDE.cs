using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using System.Diagnostics;

namespace IDE
{
    public partial class TMDIDE : DevExpress.XtraEditors.XtraForm
    {
        public TMDIDE()
        {
            InitializeComponent();
            InitCookAndPak();
        }
        #region Cook&Pak
        string UEEditorCmd = "\\Engine\\Binaries\\Win64\\UE4Editor-Cmd.exe";
        string UnrealPak = "\\Engine\\Binaries\\Win64\\UnrealPak.exe";
        string CookPakBatTempletFilePath;
        string ConfigFilePath;
        string WorkDir;
        string ColName;
        string CookPakBatPath;
        List<string> BatList;

        FolderBrowserDialog folderDialog;
        DataTable PakDt;
        private void InitCookAndPak()
        {
            folderDialog = new FolderBrowserDialog();
            PakDt = new DataTable();
            ColName = "PakPath";
            PakDt.Columns.Add(ColName);
            WorkDir = AppDomain.CurrentDomain.BaseDirectory;
            string DeleteString = "/IDE/bin/Debug";
            WorkDir = WorkDir.Substring(0, WorkDir.Length - DeleteString.Length);
            CookPakBatTempletFilePath = WorkDir + "BAT\\CookPak.bat";
            ConfigFilePath = WorkDir + "Config\\Config.ini";
            
            if (File.Exists(ConfigFilePath))
            {
                ReadConfigFile();
            }

            gv.OptionsBehavior.Editable = false;
        }

        private void WriteConfigFile()
        {
            StreamWriter sw = new StreamWriter(ConfigFilePath);
            sw.WriteLine("[UnrealEngine]");
            sw.WriteLine(buttonEdit_UEFolder.Text);
            sw.WriteLine("[Uproject]");
            sw.WriteLine(buttonEdit_Uproject.Text);
            sw.WriteLine("[UnrealPak]");
            sw.WriteLine(buttonEdit_UnrealPaK.Text);
            sw.WriteLine("[UE4Editor-Cmd]");
            sw.WriteLine(buttonEdit_EditorCmd.Text);
            sw.WriteLine("[Outputdir]");
            sw.WriteLine(buttonEdit_PakOutput.Text);
            sw.WriteLine("[Project]");
            sw.WriteLine(buttonEdit_Project.Text);
            sw.WriteLine("[CookLogOutput]");
            sw.WriteLine(buttonEdit_CookLogOutput.Text);
            sw.WriteLine("[PakDirStart]");
            foreach (DataRow row in PakDt.Rows)
            {
                sw.WriteLine(row[ColName]);
            }
            sw.WriteLine("[PakDirEnd]");
            sw.WriteLine("[PlatformsStart]");
            CheckedListBoxItemCollection items = checkedComboBoxEdit_CookType.Properties.Items;
            for (int i = 0; i < items.Count; ++i)
            {
                string CheckSate = items[i].Value as string;
                CheckSate += ":" + items[i].CheckState;
                sw.WriteLine(CheckSate);
            }
            sw.WriteLine("[PlatformsEnd]");
            sw.WriteLine("[DoCook]");
            sw.WriteLine(checkEdit_Cook.Checked);
            sw.WriteLine("[DoPak]");
            sw.WriteLine(checkEdit_Pak.Checked);
            sw.WriteLine("[DoIterate]");
            sw.WriteLine(checkEdit_Iterate.Checked);
            sw.WriteLine(" ");
            sw.Close();
        }
        private void ReadConfigFile()
        {
            string[] ConfigContents = File.ReadAllLines(ConfigFilePath);
            for (int i = 0; i < ConfigContents.Length - 1; ++i)
            {
                if (ConfigContents[i] == "[Outputdir]")
                {
                    buttonEdit_PakOutput.Text = ConfigContents[i + 1];
                }
                else if (ConfigContents[i] == "[UE4Editor-Cmd]")
                {
                    buttonEdit_EditorCmd.Text = ConfigContents[i + 1];
                }
                else if (ConfigContents[i] == "[UnrealPak]")
                {
                    buttonEdit_UnrealPaK.Text = ConfigContents[i + 1];
                }
                else if (ConfigContents[i] == "[Uproject]")
                {
                    buttonEdit_Uproject.Text = ConfigContents[i + 1];
                }
                else if (ConfigContents[i] == "[Project]")
                {
                    buttonEdit_Project.Text = ConfigContents[i + 1];
                }
                else if (ConfigContents[i] == "[UnrealEngine]")
                {
                    buttonEdit_UEFolder.Text = ConfigContents[i + 1];
                }
                else if (ConfigContents[i] == "[CookLogOutput]")
                {
                    buttonEdit_CookLogOutput.Text = ConfigContents[i + 1];
                }
                else if (ConfigContents[i] == "[PakDirStart]")
                {
                    int indextmp = i + 1;
                    string EndFlag = ConfigContents[indextmp];
                    while (EndFlag != "[PakDirEnd]")
                    {

                        DataRow row = PakDt.NewRow();
                        row[ColName] = ConfigContents[indextmp];
                        PakDt.Rows.Add(row);
                        ++indextmp;
                        EndFlag = ConfigContents[indextmp];
                    }
                    gc.DataSource = PakDt;
                }
                else if (ConfigContents[i] == "[PlatformsStart]")
                {
                    int indextmp = i + 1;
                    string EndFlag = ConfigContents[indextmp];

                    CheckedListBoxItemCollection items = checkedComboBoxEdit_CookType.Properties.Items;
                    while (EndFlag != "[PlatformsEnd]")
                    {
                        string cmd = ConfigContents[indextmp];
                        if (!ConfigContents[indextmp].Contains(':'))
                        {
                            continue;
                        }
                        string[] CheckStrArr = ConfigContents[indextmp].Split(':');
                        if (CheckStrArr.Length == 2)
                        {
                            if (CheckStrArr[1] == "Checked")
                            {
                                items[CheckStrArr[0]].CheckState = CheckState.Checked;
                            }
                            else
                            {
                                items[CheckStrArr[0]].CheckState = CheckState.Unchecked;
                            }
                        }
                        ++indextmp;
                        EndFlag = ConfigContents[indextmp];
                    }
                }
                else if (ConfigContents[i] == "[DoCook]")
                {
                    if (ConfigContents[i + 1] == "True")
                    {
                        checkEdit_Cook.Checked = true;
                    }
                    else
                    {
                        checkEdit_Cook.Checked = false;
                    }
                }
                else if (ConfigContents[i] == "[DoPak]")
                {
                    if (ConfigContents[i + 1] == "True")
                    {
                        checkEdit_Pak.Checked = true;
                    }
                    else
                    {
                        checkEdit_Pak.Checked = false;
                    }
                }
                else if (ConfigContents[i] == "[DoIterate]")
                {
                    if (ConfigContents[i + 1] == "True")
                    {
                        checkEdit_Iterate.Checked = true;
                    }
                    else
                    {
                        checkEdit_Iterate.Checked = false;
                    }
                }
            }
        }

        private bool SpawnBatFile()
        {
#if DEBUG
            CookPakBatPath = "D:\\Goulandis\\TMD\\IDE\\BAT\\bat.bat";
#endif
            StreamWriter sw = new StreamWriter(CookPakBatPath);
            sw.Write("");
            string[] BatContents = File.ReadAllLines(CookPakBatTempletFilePath);
            BatList = BatContents.ToList();
            List<string> PakDir = new List<string>();
            for (int i = 0; i < BatList.Count-1; ++i)
            {
                if (BatList[i] == "rem outputdir")
                {
                    BatList[i + 1] = "set outputdir=" + buttonEdit_PakOutput.Text;
                }
                else if (BatList[i] == "rem UE4Editor")
                {
                    BatList[i + 1] = "set UE4Editor-Cmd=" + buttonEdit_EditorCmd.Text;
                }
                else if (BatList[i] == "rem UnrealPak")
                {
                    BatList[i + 1] = "set UnrealPak=" + buttonEdit_UnrealPaK.Text;
                }
                else if (BatList[i] == "rem uproject")
                {
                    BatList[i + 1] = "set uproject=" + buttonEdit_Uproject.Text;
                }
                else if (BatList[i] == "rem cooklogoutput")
                {
                    BatList[i + 1] = "set cooklogoutput=" + buttonEdit_CookLogOutput.Text;
                }
                else if (BatList[i] == "rem pakdir")
                {
                    for (int indextmp = 0; indextmp < PakDt.Rows.Count; ++indextmp)
                    {
                        string cmd = "set pakdir" + indextmp + "=" + PakDt.Rows[indextmp][ColName];
                        BatList.Insert(i + 1 + indextmp, cmd);
                    }
                }
                else if (BatList[i] == "rem cookcmd")
                {
                    string TargetPlatform = string.Empty;
                    CheckedListBoxItemCollection items = checkedComboBoxEdit_CookType.Properties.Items;
                    if (items.Count > 0)
                    {
                        for (int indextmp = 0; indextmp < items.Count; ++indextmp)
                        {
                            if (items[indextmp].CheckState == CheckState.Checked)
                            {
                                string Platform = items[indextmp].Value as string;
                                TargetPlatform += Platform + "+";
                            }
                        }
                        if (TargetPlatform != string.Empty)
                        {
                            TargetPlatform = TargetPlatform.Remove(TargetPlatform.Length - 1, 1);
                            string cmd = "set cook=%UE4Editor-Cmd% %uproject% -run=Cook -TargetPlatform="
                                + TargetPlatform + " -fileopenlog -unversioned -abslog=%cooklogoutput%"
                                + "\\Cook.log -stdout - CrashForUAT - unattended - NoLogTimes - UTF8Output";
                            if (checkEdit_Iterate.Checked)
                            {
                                cmd += " -iterate";
                            }
                            BatList[i + 1] = cmd;
                        }
                        else
                        {
                            XtraMessageBox.Show("没有选择Cook平台", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
                else if (BatList[i] == "rem pakcmd")
                {
                    for (int indextmp = 0; indextmp < PakDt.Rows.Count; ++indextmp)
                    {
                        string PakDirStr = PakDt.Rows[indextmp][ColName] as string;
                        string[] StrArr = PakDirStr.Split('\\');
                        string platform = string.Empty;
                        for (int j=0;j<StrArr.Length;++j)
                        {
                            if (StrArr[j] == "Cooked")
                            {
                                platform = StrArr[j + 1];
                                break;
                            }
                        }

                        PakDir.Add(StrArr[StrArr.Length - 1]+ "_" + platform + "_%time%");
                        string cmd = "set pakcmd" + indextmp + "=%UnrealPak% %outputdir%"+ "\\Paks_%time%\\" 
                            + PakDir.Last() + " -Create=" + "%pakdir" + indextmp + "% -compress";
                        BatList.Insert(i + 1 + indextmp, cmd);
                    }
                }
                else if (BatList[i] == "rem docook")
                {
                    if (checkEdit_Cook.Checked)
                    {
                        BatList.Insert(i + 1, "%cook%");
                    }   
                }
                else if (BatList[i] == "rem pakdirexsit")
                {
                    for (int indextmp = 0; indextmp < PakDt.Rows.Count; ++indextmp)
                    {
                        string cmd = "if not exist %pakdir" + indextmp + "% (echo %pakdir" + indextmp + "% done not exist; pause)";
                        BatList.Insert(i + 1 + indextmp, cmd);
                    }
                }
                else if (BatList[i] == "rem dopak")
                {
                    if (checkEdit_Pak.Checked)
                    {
                        string cmd = string.Empty;
                        for (int indextmp = 0; indextmp < PakDt.Rows.Count; ++indextmp)
                        {
                            cmd += "%pakcmd" + indextmp + "%&&";
                        }
                        if (cmd != string.Empty)
                        {
                            cmd = cmd.Remove(cmd.Length - 2, 2);
                            BatList.Insert(i + 1, cmd);
                        }
                        else
                        {
                            XtraMessageBox.Show("生成Pak命令是出错", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        BatList[i + 2] = "start explorer \"%outputdir%\\Paks_%time%\"";
                        //for (int indextmp = 0; indextmp < PakDir.Count; ++indextmp)
                        //{
                        //    BatList[i + 2 + indextmp] = "start explorer \"" + PakDir[indextmp] + "\"";
                        //}
                    }   
                }
            }       
            foreach (string row in BatList)
            {  
                sw.WriteLine(row);
            }
            sw.Close(); 
            return true;
        }

        private void buttonEdit1_Click(object sender, EventArgs e)
        {
            folderDialog.Description = "Select Unreal Engine folder";
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                buttonEdit_UEFolder.Text = folderDialog.SelectedPath;
                FindUETool();
            }
        }

        private void FindUETool()
        {
            string UEEditorCmdTmp = buttonEdit_UEFolder.Text + UEEditorCmd;
            string UnrealPakTmp = buttonEdit_UEFolder.Text + UnrealPak;

            if (File.Exists(UEEditorCmdTmp))
            {
                buttonEdit_EditorCmd.Text = UEEditorCmdTmp;
            }
            else
            {
                buttonEdit_EditorCmd.Text = "未自动找到Editor-Cmd.exe,可以试着手动选择";
            }
            if (File.Exists(UnrealPakTmp))
            {
                buttonEdit_UnrealPaK.Text = UnrealPakTmp;
            }
            else
            {
                buttonEdit_EditorCmd.Text = "未自动找到UnrealPak.exe,可以试着手动选择";
            }
        }

        private void buttonEdit_EditorCmd_Click(object sender, EventArgs e)
        {
            folderDialog.Description = "Select UE Editor-Cmd.exe file";
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                buttonEdit_EditorCmd.Text = folderDialog.SelectedPath;
            }
        }

        private void buttonEdit_UnrealPaK_Click(object sender, EventArgs e)
        {
            folderDialog.Description = "Select UE UnrealPaK.exe file";
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                buttonEdit_UnrealPaK.Text = folderDialog.SelectedPath;
            }
        }

        private void buttonEdit_Project_Click(object sender, EventArgs e)
        {
            folderDialog.Description = "Select Project file";
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                buttonEdit_Project.Text = folderDialog.SelectedPath;
            }

            if (Directory.Exists(buttonEdit_Project.Text))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(buttonEdit_Project.Text);
                FileInfo[] fileInfoArr = directoryInfo.GetFiles();
                string extName = ".uproject";
                List<FileInfo> uprojectInfoList = new List<FileInfo>();
                foreach (FileInfo file in fileInfoArr)
                {
                    if (extName.ToLower().IndexOf(file.Extension.ToLower()) >= 0)
                    {
                        uprojectInfoList.Add(file);
                    }
                }

                if (uprojectInfoList.Count == 1)
                {
                    buttonEdit_Uproject.Text = uprojectInfoList[0].FullName;
                }
                else
                {
                    XtraMessageBox.Show(".uproject文件数量异常", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void buttonEdit_PakOutput_Click(object sender, EventArgs e)
        {
            folderDialog.Description = "Select Pak output folder";
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                buttonEdit_PakOutput.Text = folderDialog.SelectedPath;
            }
        }

        private void buttonEdit_CookLogOutput_Click(object sender, EventArgs e)
        {
            folderDialog.Description = "Select Pak output folder";
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                buttonEdit_CookLogOutput.Text = folderDialog.SelectedPath;
            }
        }

        private void Btn_AddPath_Click(object sender, EventArgs e)
        {
            folderDialog.Description = "Select Pak folder";
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                string[] UprojectStrArr = buttonEdit_Uproject.Text.Split('\\');
                string SubStr = string.Empty;
                for (int i = 0; i < UprojectStrArr.Length-1; ++i)
                {
                    SubStr += UprojectStrArr[i]+"\\";
                }
                if (!folderDialog.SelectedPath.Contains(SubStr))
                {
                    XtraMessageBox.Show("Cook文件夹与项目文件夹不匹配", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DataRow row = PakDt.NewRow();
                row["PakPath"] = folderDialog.SelectedPath;
                PakDt.Rows.Add(row);
                gc.DataSource = PakDt;
            }
        }

        private void Btn_RemovePath_Click(object sender, EventArgs e)
        {
            DataRow row = gv.GetFocusedDataRow();
            if (PakDt.Rows.Count > 0)
            {
                PakDt.Rows.Remove(row);
            }
        }

        private void Btn_Run_Click(object sender, EventArgs e)
        {
            if (SpawnBatFile())
            {
                if (checkEdit_Cook.Checked || checkEdit_Pak.Checked)
                {
                    WriteConfigFile();
                    Process proc = null;
                    try
                    {
                        proc = new Process();
                        proc.StartInfo.FileName = CookPakBatPath;
                        proc.StartInfo.Arguments = string.Format("10");
                        proc.StartInfo.CreateNoWindow = false;
                        proc.Start();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception Occurred :{0},{1}", ex.Message, ex.StackTrace.ToString());
                    }
                }
                else
                {
                    XtraMessageBox.Show("请勾选需要执行的命令Cook或Pak", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            WriteConfigFile();
            this.Close();
        }
        #endregion
        #region SO Anlyze
        private void InitSOAnlyze()
        { 
        
        }
        private void buttonEdit_SOAnlayzeToolPath_Click(object sender, EventArgs e)
        { 
            
        }
        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TMDIDE
            // 
            this.ClientSize = new System.Drawing.Size(298, 268);
            this.Name = "TMDIDE";
            this.Load += new System.EventHandler(this.TMDIDE_Load);
            this.ResumeLayout(false);

        }

        private void TMDIDE_Load(object sender, EventArgs e)
        {

        }
    }
}
