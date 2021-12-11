using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using System.Diagnostics;
using Microsoft.Win32;
using System.Drawing;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace IDE
{
    public partial class TMDIDE : DevExpress.XtraEditors.XtraForm
    {
        #region Form
        OpenFileDialog fileDialog;
        FolderBrowserDialog folderDialog;
        string WorkDir;
        KeyCodeHook KHook;

        public TMDIDE()
        {
            InitializeComponent();
            Init();           
        }
        private void Init()
        {
            fileDialog = new OpenFileDialog();
            folderDialog = new FolderBrowserDialog();
            WorkDir = AppDomain.CurrentDomain.BaseDirectory;

            notifyIcon.Visible = false;

            InitCookAndPak();
            InitSOAnalyze();
            InitSoftwareSet();
            InitAbout();
            InitContextMenu();
            KeyCodeListen();
        }
        private void ShowForm()
        {
            this.Show();
            notifyIcon.Visible = false;
        }
        private void HideForm()
        {
            this.Hide();
            notifyIcon.Visible = true;
        }  
        private void TMDIDE_FormClosed(object sender, FormClosedEventArgs e)
        {
            WriteCookAndPakConfigFile();
            WriteSOAnalyzeConfigFile();
        }

        private void KeyCodeListen()
        {
            KHook = new KeyCodeHook();
            KHook.KeyDownEvent += new KeyEventHandler(KeyPressd);
            KHook.Start();
        }

        private void KeyPressd(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == Convert.ToInt32(Keys.Q) && Convert.ToInt32(ModifierKeys) == Convert.ToInt32(Keys.Alt))
            {
                XtraMessageBox.Show("未检测到键盘按下", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitContextMenu()
        {
            string ConfigFile = WorkDir + "Config\\Config.ini";
            if (!File.Exists(ConfigFile))
            {
                File.Create(ConfigFile);
            }
            System.Threading.Thread.Sleep(200);
            StreamWriter sw = new StreamWriter(ConfigFile);
            XtraMessageBox.Show(contextMenuStrip.Items.Count.ToString(), "Count", MessageBoxButtons.OK, MessageBoxIcon.Error);
            for (int i = 0; i < contextMenuStrip.Items.Count; ++i)
            {
                string keyStr = contextMenuStrip.Items[i].Text + ":" + "Alt+" + Enum.GetName(typeof(Keys), 49+i);
                sw.WriteLine(keyStr);
            }
            sw.Close();
            //List<string> ConfigList = File.ReadAllLines(CookPakConfigPath).ToList<string>();

            //for (int i = 0; i < contextMenuStrip.Items.Count; ++i)
            //{
            //    contextMenuStrip.Items[i];
            //}
        }

        #endregion
        #region Cook&Pak
        string UEEditorCmd = "\\Engine\\Binaries\\Win64\\UE4Editor-Cmd.exe";
        string UnrealPak = "\\Engine\\Binaries\\Win64\\UnrealPak.exe";
        string CookPakBatTempletPath;
        string CookPakConfigPath;
        string ColName;
        string CookPakBatPath;
        DataTable PakDt;
        private void InitCookAndPak()
        {
            gv_CookPak.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gv_CookPak.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            PakDt = new DataTable();
            ColName = "PakPath";
            PakDt.Columns.Add(ColName);
            
            CookPakBatTempletPath = WorkDir + "BAT\\CookPakTemplate.bat";
            CookPakConfigPath = WorkDir + "Config\\CookPakConfig.ini";
            ReadCookAndPakConfigFile();
            gv_CookPak.OptionsBehavior.Editable = false;
        }
        private bool WriteCookAndPakConfigFile()
        {
            if (!File.Exists(CookPakConfigPath))
            {
                XtraMessageBox.Show("未检测到" + CookPakConfigPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            StreamWriter sw = new StreamWriter(CookPakConfigPath);
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
            return true;
        }
        private bool ReadCookAndPakConfigFile()
        {
            if (!File.Exists(CookPakConfigPath))
            {
                XtraMessageBox.Show("未检测到" + CookPakConfigPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            string[] ConfigContents = File.ReadAllLines(CookPakConfigPath);
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
                    gc_CookPak.DataSource = PakDt;
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
            return true;
        }
        private bool SpawnCookAndPakBatFile()
        {
            CookPakBatPath = WorkDir + "BAT\\CookPak.bat";
            if (!File.Exists(CookPakBatPath))
            {
                File.Create(CookPakBatPath);
            }
            StreamWriter sw = new StreamWriter(CookPakBatPath);
            sw.Write("");
            if (!File.Exists(CookPakBatTempletPath))
            {
                XtraMessageBox.Show("未检测到" + CookPakBatTempletPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            List<string> BatList = File.ReadAllLines(CookPakBatTempletPath).ToList();
            List<string> PakDir = new List<string>();
            for (int i = 0; i < BatList.Count - 1; ++i)
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
                        for (int j = 0; j < StrArr.Length; ++j)
                        {
                            if (StrArr[j] == "Cooked")
                            {
                                platform = StrArr[j + 1];
                                break;
                            }
                        }

                        PakDir.Add(StrArr[StrArr.Length - 1] + "_" + platform + "_%time%");
                        string cmd = "set pakcmd" + indextmp + "=%UnrealPak% %outputdir%" + "\\Paks_%time%\\"
                            + PakDir.Last() + ".pak -Create=" + "%pakdir" + indextmp + "% -compress";
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
                buttonEdit_CookLogOutput.Text = folderDialog.SelectedPath + "\\UECookLog";
            }
        }
        private void Btn_AddPath_Click(object sender, EventArgs e)
        {
            folderDialog.Description = "Select Pak folder";
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                string[] UprojectStrArr = buttonEdit_Uproject.Text.Split('\\');
                string SubStr = string.Empty;
                for (int i = 0; i < UprojectStrArr.Length - 1; ++i)
                {
                    SubStr += UprojectStrArr[i] + "\\";
                }
                if (!folderDialog.SelectedPath.Contains(SubStr))
                {
                    XtraMessageBox.Show("Cook文件夹与项目文件夹不匹配", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DataRow row = PakDt.NewRow();
                row["PakPath"] = folderDialog.SelectedPath;
                PakDt.Rows.Add(row);
                gc_CookPak.DataSource = PakDt;
            }
        }
        private void Btn_RemovePath_Click(object sender, EventArgs e)
        {
            DataRow row = gv_CookPak.GetFocusedDataRow();
            if (PakDt.Rows.Count > 0)
            {
                PakDt.Rows.Remove(row);
            }
        }
        private void Btn_Run_Click(object sender, EventArgs e)
        {
            if (!SpawnCookAndPakBatFile())
            {
                return;
            }
            if (!checkEdit_Cook.Checked && !checkEdit_Pak.Checked)
            {
                XtraMessageBox.Show("请勾选需要执行的命令Cook或Pak", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;             
            }
            WriteCookAndPakConfigFile();
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
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            WriteCookAndPakConfigFile();
            HideForm(); 
        }

        private void Btn_PakList_Click(object sender, EventArgs e)
        {
            fileDialog.Title = "Select .pak file";
            fileDialog.Filter = "Pak文件|*.pak";
            string FilePath = string.Empty;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                FilePath = fileDialog.FileName;
            }
            string PakListBat = WorkDir + "BAT\\PakList.bat";
            if (!File.Exists(PakListBat))
            {
                File.Create(PakListBat);
            }
            StreamWriter sw = new StreamWriter(PakListBat);
            string PakListCmd = "set PakListCmd=" + buttonEdit_UnrealPaK.Text + " " + FilePath + " -list";
            sw.WriteLine(PakListCmd);
            sw.WriteLine("%PakListCmd%");
            sw.WriteLine("pause");
            sw.Close();
            System.Threading.Thread.Sleep(200);
            Process.Start(PakListBat);
        }
        #endregion
        #region SO Anlyze
        string SOAnalyzeConfig;
        string SOAnalyzeBatPath;
        string SOAnalyzeBatTemplate;
        private void InitSOAnalyze()
        {
            SOAnalyzeConfig = WorkDir + "Config\\SOAnalyzeConfig.ini";
            SOAnalyzeBatTemplate = WorkDir + "BAT\\SOAnalyzeTemplate.bat";
            ReadSOAnalyzeConfigFile();
        }
        private bool WriteSOAnalyzeConfigFile()
        {
            if (!File.Exists(SOAnalyzeConfig))
            {
                XtraMessageBox.Show("未检测到" + SOAnalyzeConfig, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            StreamWriter sw = new StreamWriter(SOAnalyzeConfig);
            sw.WriteLine("[ADBSOAnalyzeTool]");
            sw.WriteLine(buttonEdit_AnalyzeToolPath.Text);
            sw.WriteLine("[SOFilePath]");
            sw.WriteLine(buttonEdit_SOFilePath.Text);
            sw.Close();
            return true;
        }
        private bool ReadSOAnalyzeConfigFile()
        {
            if (!File.Exists(SOAnalyzeConfig))
            {
                XtraMessageBox.Show("未检测到" + SOAnalyzeConfig, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            string[] ConfigContents = File.ReadAllLines(SOAnalyzeConfig);
            for (int i = 0; i < ConfigContents.Length; ++i)
            {
                if (ConfigContents[i] == "[ADBSOAnalyzeTool]")
                {
                    buttonEdit_AnalyzeToolPath.Text = ConfigContents[i + 1];
                }
                else if (ConfigContents[i] == "[SOFilePath]")
                {
                    buttonEdit_SOFilePath.Text = ConfigContents[i + 1];
                }
            }
            return true;
        }
        private void buttonEdit1_Properties_Click(object sender, EventArgs e)
        {
            fileDialog.Title = "Select ADB SO analyze tool file";
            fileDialog.Filter = "exe文件|*.exe";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                buttonEdit_AnalyzeToolPath.Text = fileDialog.FileName;
            }
        }
        private void buttonEdit_SOFilePath_Click(object sender, EventArgs e)
        {
            fileDialog.Title = "Select .so file";
            fileDialog.Filter = "so文件|*.so";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                buttonEdit_SOFilePath.Text = fileDialog.FileName;
            }
        }
        private void Btn_SOAnalyze_Click(object sender, EventArgs e)
        {
            WriteSOAnalyzeConfigFile();
            if (!SpawnSOAnalyzeBatFile())
            {
                return;
            }
            Process proc = null;
            try
            {
                proc = new Process();
                proc.StartInfo.FileName = SOAnalyzeBatPath;
                proc.StartInfo.Arguments = string.Format("10");
                proc.StartInfo.CreateNoWindow = false;
                proc.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occurred :{0},{1}", ex.Message, ex.StackTrace.ToString());
            }
        }
        private void Btn_SOCancel_Click(object sender, EventArgs e)
        {
            WriteSOAnalyzeConfigFile();
            HideForm();
        }
        private bool SpawnSOAnalyzeBatFile()
        {  
            SOAnalyzeBatPath = WorkDir + "\\BAT\\SOAnalyze.bat";
            if (!File.Exists(SOAnalyzeBatPath))
            {
                File.Create(SOAnalyzeBatPath);
            }
            StreamWriter sw = new StreamWriter(SOAnalyzeBatPath);
            sw.Write("");
            if (!File.Exists(SOAnalyzeBatTemplate))
            {
                XtraMessageBox.Show("未检测到" + SOAnalyzeBatTemplate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            List<string> BatList = File.ReadAllLines(SOAnalyzeBatTemplate).ToList();
            for (int i = 0; i < BatList.Count; ++i)
            {
                if (BatList[i] == "rem adbsoanalyzetool")
                {
                    BatList[i + 1] = "set soanalyzetool=" + buttonEdit_AnalyzeToolPath.Text;
                }
                else if (BatList[i] == "rem sofile")
                {
                    BatList[i + 1] = "set sofile=" + buttonEdit_SOFilePath.Text;
                }
                else if (BatList[i] == "rem stackcontent")
                {
                    string StackContent = memoEdit_StackIndexs.Text;
                    if (StackContent.Contains('\n'))
                    {
                        StackContent = StackContent.Replace('\n', ' ');
                    }
                    if (StackContent.Contains('\r'))
                    {
                        StackContent = StackContent.Replace('\r', ' ');
                    }
                    BatList[i + 1] = "set stackcontent=" + StackContent;
                }
                else if (BatList[i] == "rem docmd")
                {
                    BatList[i + 1] = "%soanalyzetool% -e %sofile% %stackcontent%";
                }     
            }

            foreach (string row in BatList)
            {
                sw.WriteLine(row);    
            }
            sw.Close();
            return true;
        }
        #endregion
        #region NotifyIcon
        private void notifyIcon_Click(object sender, EventArgs e)
        {
            contextMenuStrip.Show(MousePosition.X, MousePosition.Y);
        }

        private void contextMenuStrip_MouseLeave(object sender, EventArgs e)
        {
            contextMenuStrip.Close();
        }

        private void contextMenuStrip_MouseEnter(object sender, EventArgs e)
        {
            contextMenuStrip.Show(MousePosition.X, MousePosition.Y);
        }

        private void uECookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkEdit_Pak.Checked = false;
            checkEdit_Cook.Checked = true;
            Btn_Run_Click(sender, e);
        }

        private void uEPakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkEdit_Pak.Checked = true;
            checkEdit_Cook.Checked = false;
            Btn_Run_Click(sender, e);
        }

        private void uECookPakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkEdit_Pak.Checked = true;
            checkEdit_Cook.Checked = true;
            Btn_Run_Click(sender, e);
        }

        private void showFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region Software Set
        string WebBrowserConfig;
        string WebBrowser = string.Empty;
        Dictionary<string, string> LinkDic = new Dictionary<string, string>();
        private void InitSoftwareSet()
        {
            gv_SoftwareSet.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gv_SoftwareSet.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gv_SoftwareSet.OptionsSelection.MultiSelect = true;
            gv_SoftwareSet.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;

            WebBrowserConfig = WorkDir + "Config\\SoftwareSetConfig.ini";
            if (ReadSoftwareConfig(ref WebBrowser, ref LinkDic))
            {
                DataTable table = new DataTable();
                DataColumn col = new DataColumn();
                col.ColumnName = "Software";
                table.Columns.Add(col);

                int i = 1;
                foreach (string key in LinkDic.Keys)
                {
                    DataRow row = table.NewRow();
                    row["Software"] = key;
                    table.Rows.Add(row);
                    ++i;
                }
                gc_SoftwareSet.DataSource = table;
            }    
        }
        private void Btn_Download_Click(object sender, EventArgs e)
        {          
            if (WebBrowser == string.Empty)
            {
                return;
            }
            if (LinkDic.Count <= 0)
            {
                XtraMessageBox.Show("没有需要下载的软件", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            for (int i = 0; i < gv_SoftwareSet.RowCount; ++i)
            {
                if (gv_SoftwareSet.IsRowSelected(i))
                {
                    string Key = gv_SoftwareSet.GetDataRow(i)["Software"].ToString();
                    Process.Start(WebBrowser, LinkDic[Key]);
                }             
            }
        }
        private bool ReadSoftwareConfig(ref string WebBrowser,ref Dictionary<string,string> LinkDic)
        {
            string RegistryKeyLeft = string.Empty;
            string RegistryKeyRight = string.Empty;
            string RegistryKey = string.Empty;
            RegistryKey Key = null;
            if (!File.Exists(WebBrowserConfig))
            {
                XtraMessageBox.Show("未检测到" + WebBrowserConfig, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            string[] ConfigContents = File.ReadAllLines(WebBrowserConfig);
            List<string> BroswerTyps = new List<string>();
            for (int i = 0; i < ConfigContents.Length; ++i)
            {
                if (ConfigContents[i] == "[TypesStart]")
                {
                    int indextmp = 1;
                    while (ConfigContents[i + indextmp] != "[TypesEnd]")
                    {
                        BroswerTyps.Add(ConfigContents[i + indextmp]);
                        ++indextmp;
                    }
                }
                else if (ConfigContents[i] == "[RegistryKeyLeft]")
                {
                    RegistryKeyLeft = ConfigContents[i + 1];
                }
                else if (ConfigContents[i] == "[RegistryKeyRight]")
                {
                    RegistryKeyRight = ConfigContents[i + 1];
                }
                else if (ConfigContents[i] == "[SoftwareSetLinkStart]")
                {
                    int indextmp = 1;
                    while (ConfigContents[i + indextmp] != "[SoftwareSetLinkEnd]")
                    {
                        if (ConfigContents[i + indextmp].Contains(' '))
                        {
                            string[] Splits = ConfigContents[i + indextmp].Split(' ');
                            LinkDic.Add(Splits[0], Splits[1]);
                        }
                        ++indextmp;
                    }
                }
            } 
            foreach (string type in BroswerTyps)
            {
                RegistryKey = RegistryKeyLeft + type + RegistryKeyRight;
                Key = Registry.LocalMachine.OpenSubKey(RegistryKey, false);
                if (Key != null)
                {
                    break;
                }
            }
            if (Key == null)
            {
                XtraMessageBox.Show("没有找到默认浏览器", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            WebBrowser = Key.GetValue("").ToString();
            Key.Close();
            return true;
        }
        private void Btn_SoftwareSetCancel_Click(object sender, EventArgs e)
        {
            HideForm();
        }
        #endregion
        #region About
        string TMDEXE = string.Empty;
        private void InitAbout()
        {
            string AboutConfig = WorkDir + "Config//AboutConfig.ini";
            if (File.Exists(AboutConfig))
            {
                List<string> ConfigContents = File.ReadAllLines(AboutConfig).ToList();
                for (int i = 0; i < ConfigContents.Count; ++i)
                {
                    if (ConfigContents[i] == "[GithubLink]")
                    {
                        linkLabel_About.Text = ConfigContents[i + 1];
                    }
                    else if (ConfigContents[i] == "[TMD]")
                    {
                        TMDEXE = ConfigContents[i + 1];
                    }
                    else if (ConfigContents[i] == "[AboutImage]")
                    {
                        pictureBox_About.Image = Image.FromFile(WorkDir + ConfigContents[i + 1]);
                    }
                    else if (ConfigContents[i] == "[IconImage]")
                    { 
                        IconOptions.Image = Image.FromFile(WorkDir + ConfigContents[i + 1]);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("未检测到" + AboutConfig, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(WebBrowser, linkLabel_About.Text);
        }
        private void label_TMD_Click(object sender, EventArgs e)
        {
            if (File.Exists(TMDEXE))
            {
                Process.Start(TMDEXE);
            }
        }
        #endregion
    }
}
