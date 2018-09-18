﻿using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace FEBuilderGBA
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();

            //自動アップデートチェック
            AutoUpdateCheck();

            string romfilename = Program.GetLastROMFilename();
            if (romfilename == "" || File.Exists(romfilename) == false)
            {
                OpenLastROMButton.Enabled = false;
                OpenROMButton.Focus();
            }
            else
            {
                OpenLastROMButton.Text = R._("{0} を開く(最後に開いたROMを開く)", Path.GetFileName(romfilename));
                OpenLastROMButton.Focus();
            }
#if DEBUG
            VersionLabel.Text = "-Debug Build-";
#else
            VersionLabel.Text = "Ver:" + U.getVersion();
#endif
            AllowDropFilename();
        }

        void AllowDropFilename()
        {
            U.AllowDropFilename(this
                , new string[] { ".GBA", ".7Z", ".UPS", ".BIN" }
                , (string filename) =>
                {
                    //open
                    bool r = MainFormUtil.Open(this, filename, false, "");
                    if (r)
                    {
                        this.Close();
                    }
                });
        }


        private void UpdateCheckButton_Click(object sender, EventArgs e)
        {
            if (InputFormRef.IsPleaseWaitDialog(this))
            {//2重割り込み禁止
                return;
            }

#if DEBUG
            R.ShowStopError("デバッグビルドはバージョンが取れないので、常に最新版があると回答します。");
#endif
            //少し時間がかかるので、しばらくお待ちください表示.
            using (InputFormRef.AutoPleaseWait pleaseWait = new InputFormRef.AutoPleaseWait(this))
            {
                pleaseWait.DoEvents(R._("アップデートがあるか確認しています・・・"));
                UpdateCheck.CheckUpdateUI();
            }
        }

        //自動アップデートチェック
        void AutoUpdateCheck()
        {
            UpdateCheck update = new UpdateCheck();
            update.EventHandler += UpdateThreadCallback;
            update.CheckUpdateThread();
        }
        void UpdateThreadCallback(object sender, EventArgs e)
        {
            UpdateCheck.UpdateEventArgs ee = (UpdateCheck.UpdateEventArgs)e;
            UpdateCheck.CheckUpdateUI(ee);
        }


        private void OpenROMButton_Click(object sender, EventArgs e)
        {
            string romfilename = Program.OpenROMDialog();
            bool r = MainFormUtil.Open(this, romfilename , false,"");
            if (r)
            {
                this.Close();
            }
        }

        private void OpenLastROMButton_Click(object sender, EventArgs e)
        {
            string romfilename = Program.GetLastROMFilename();
            if (romfilename != "")
            {
                bool r = MainFormUtil.Open(this, romfilename, false, "");
                if (r)
                {
                    this.Close();
                }
            }
        }

        private void ManButton_Click(object sender, EventArgs e)
        {
            MainFormUtil.GotoManual();
        }

        private void WelcomeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
