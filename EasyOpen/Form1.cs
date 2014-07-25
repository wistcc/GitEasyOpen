using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace EasyOpen
{
    public partial class Form1 : Form
    {
        private string _selectedPath;
        private const string FileName = "SavedFolders.txt";

        public Form1()
        {
            InitializeComponent();

            var file = File.Open(FileName, FileMode.OpenOrCreate);
            file.Close();

            FillSavedFoldersCb();
            savedFoldersCb.DropDown += AdjustWidthComboBox_DropDown;
        }

        private void listBtn_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            var result = fbd.ShowDialog();

            if (result != DialogResult.OK) return;
            _selectedPath = fbd.SelectedPath;

            FillPanelWithBtns(_selectedPath);
            CheckOrUncheck();
        }

        static void buttons_Click(object obj, EventArgs e)
        {
            OpenFromDirectory(((Button)obj).Name);
        }

        private void saveChk_CheckedChanged(object sender, EventArgs e)
        {
            OpenOrCreateFile();

            if (saveChk.Checked)
            {
                var lineOfContents = File.ReadAllLines(FileName).ToList();

                if (!lineOfContents.Contains(_selectedPath))
                {
                    lineOfContents.Add(_selectedPath);
                    File.WriteAllLines(FileName, lineOfContents.ToArray());
                }
            }
            else
            {
                var lineOfContents = File.ReadAllLines(FileName);

                lineOfContents = lineOfContents.Where(l => l != _selectedPath).ToArray();
                File.WriteAllLines(FileName, lineOfContents.ToArray());
            }

            FillSavedFoldersCb();
            CheckOrUncheck();
        }

        private static void OpenFromDirectory(string directory)
        {
            var p = new Process
            {
                StartInfo =
                {
                    FileName = "cmd.exe",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    WorkingDirectory = directory,
                    CreateNoWindow = true
                }
            };
            p.Start();

            p.StandardInput.WriteLine("start \"\" \"%SYSTEMDRIVE%/Program Files (x86)/Git/bin/sh.exe\" --login -i");
        }

        private void FillPanelWithBtns(string directory)
        {
            btnsPanel.Controls.Clear();
            try
            {
                var directories = Directory.GetDirectories(directory);

                if (directories.Any())
                {
                    foreach (var newBtn in directories.Select(file => new Button
                    {
                        Text = Path.GetFileName(file),
                        Name = Path.GetFullPath(file),
                        Width = 230
                    }))
                    {
                        newBtn.Click += buttons_Click;
                        if (btnsPanel.Controls.Count > 0)
                        {
                            newBtn.Top = btnsPanel.Controls[btnsPanel.Controls.Count - 1].Bottom + 15;
                        }
                        btnsPanel.Controls.Add(newBtn);
                    }

                    infoLbl.Text = @"Now open a folder from here and have a happy code :D";
                    infoLbl.Visible = true;
                }
                else
                {
                    infoLbl.Text = @"There's no directory to list, select another one!";
                    infoLbl.Visible = true;
                }
            }
            catch (Exception)
            {
                infoLbl.Text = @"This folder doesn't exist!";
                infoLbl.Visible = true;
            }
        }

        private void CheckOrUncheck()
        {
            if (string.IsNullOrEmpty(_selectedPath)) return;
            OpenOrCreateFile();
            var lineOfContents = File.ReadAllLines(FileName).ToList();

            saveChk.Checked = lineOfContents.Contains(_selectedPath);
            if (saveChk.Checked)
            {
                savedFoldersCb.SelectedItem = _selectedPath;
            }
        }

        private static void OpenOrCreateFile()
        {
            var file = File.Open(FileName, FileMode.OpenOrCreate);
            file.Close();
        }

        private void FillSavedFoldersCb()
        {
            savedFoldersCb.Items.Clear();
            var lineOfContents = File.ReadAllLines(FileName);
            foreach (var line in lineOfContents.Where(line => !string.IsNullOrEmpty(line)))
            {
                savedFoldersCb.Items.Add(line);
            }
        }

        private void savedFoldersCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedPath = savedFoldersCb.SelectedItem.ToString();

            FillPanelWithBtns(_selectedPath);
            CheckOrUncheck();
        }

        private static void AdjustWidthComboBox_DropDown(object sender, EventArgs e)
        {
            var senderComboBox = (ComboBox)sender;
            var width = senderComboBox.DropDownWidth;
            var g = senderComboBox.CreateGraphics();
            var font = senderComboBox.Font;
            var vertScrollBarWidth =
                (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems)
                ? SystemInformation.VerticalScrollBarWidth : 0;

            width = (from string s in ((ComboBox)sender).Items select (int)g.MeasureString(s, font).Width + vertScrollBarWidth).Concat(new[] { width }).Max();
            senderComboBox.DropDownWidth = width;
        }
    }
}