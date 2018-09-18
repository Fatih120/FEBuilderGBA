﻿namespace FEBuilderGBA
{
    partial class MapTileAnimation1Form
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
            this.ReloadListButton = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.SamplePaletteComboBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ImportButton = new System.Windows.Forms.Button();
            this.ExportButton = new System.Windows.Forms.Button();
            this.P4 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.W2 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.W0 = new System.Windows.Forms.NumericUpDown();
            this.J_0 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.WriteButton = new System.Windows.Forms.Button();
            this.Address = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.AddressListExpandsButton = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.ReadCount = new System.Windows.Forms.NumericUpDown();
            this.panel3 = new System.Windows.Forms.Panel();
            this.FilterComboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ReadStartAddress = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ExportAllButton = new System.Windows.Forms.Button();
            this.ImportAllButton = new System.Windows.Forms.Button();
            this.MapPictureBox = new FEBuilderGBA.MapPictureBox();
            this.X_SAMPLE_BIG_PIC = new FEBuilderGBA.InterpolatedPictureBox();
            this.BlockSize = new FEBuilderGBA.TextBoxEx();
            this.SelectAddress = new FEBuilderGBA.TextBoxEx();
            this.AddressList = new FEBuilderGBA.ListBoxEx();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.P4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.W2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.W0)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Address)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReadCount)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReadStartAddress)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.X_SAMPLE_BIG_PIC)).BeginInit();
            this.SuspendLayout();
            // 
            // ReloadListButton
            // 
            this.ReloadListButton.Location = new System.Drawing.Point(909, -2);
            this.ReloadListButton.Name = "ReloadListButton";
            this.ReloadListButton.Size = new System.Drawing.Size(112, 30);
            this.ReloadListButton.TabIndex = 25;
            this.ReloadListButton.Text = "再取得";
            this.ReloadListButton.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.SamplePaletteComboBox);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.ImportButton);
            this.panel4.Controls.Add(this.ExportButton);
            this.panel4.Controls.Add(this.X_SAMPLE_BIG_PIC);
            this.panel4.Controls.Add(this.P4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.W2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.W0);
            this.panel4.Controls.Add(this.J_0);
            this.panel4.Location = new System.Drawing.Point(295, 75);
            this.panel4.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(916, 717);
            this.panel4.TabIndex = 149;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 18);
            this.label4.TabIndex = 91;
            this.label4.Text = "パレット";
            // 
            // SamplePaletteComboBox
            // 
            this.SamplePaletteComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SamplePaletteComboBox.FormattingEnabled = true;
            this.SamplePaletteComboBox.Items.AddRange(new object[] {
            "パレット0",
            "パレット1",
            "パレット2",
            "パレット3",
            "パレット4"});
            this.SamplePaletteComboBox.Location = new System.Drawing.Point(90, 266);
            this.SamplePaletteComboBox.Name = "SamplePaletteComboBox";
            this.SamplePaletteComboBox.Size = new System.Drawing.Size(233, 26);
            this.SamplePaletteComboBox.TabIndex = 90;
            this.SamplePaletteComboBox.SelectedIndexChanged += new System.EventHandler(this.SamplePaletteComboBox_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.MapPictureBox);
            this.panel1.Location = new System.Drawing.Point(5, 308);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(909, 408);
            this.panel1.TabIndex = 89;
            // 
            // ImportButton
            // 
            this.ImportButton.Location = new System.Drawing.Point(530, 267);
            this.ImportButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(182, 30);
            this.ImportButton.TabIndex = 88;
            this.ImportButton.Text = "画像読込";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // ExportButton
            // 
            this.ExportButton.Location = new System.Drawing.Point(727, 267);
            this.ExportButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(180, 30);
            this.ExportButton.TabIndex = 87;
            this.ExportButton.Text = "画像取出";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // P4
            // 
            this.P4.Hexadecimal = true;
            this.P4.Location = new System.Drawing.Point(414, 62);
            this.P4.Maximum = new decimal(new int[] {
            -559939585,
            902409669,
            54,
            0});
            this.P4.Name = "P4";
            this.P4.Size = new System.Drawing.Size(178, 25);
            this.P4.TabIndex = 85;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(-1, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(409, 30);
            this.label3.TabIndex = 84;
            this.label3.Text = "書き換えるマップチップ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // W2
            // 
            this.W2.Location = new System.Drawing.Point(414, 34);
            this.W2.Maximum = new decimal(new int[] {
            -559939585,
            902409669,
            54,
            0});
            this.W2.Name = "W2";
            this.W2.Size = new System.Drawing.Size(96, 25);
            this.W2.TabIndex = 82;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(-1, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(409, 30);
            this.label1.TabIndex = 81;
            this.label1.Text = "データ個数";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // W0
            // 
            this.W0.Location = new System.Drawing.Point(414, 4);
            this.W0.Maximum = new decimal(new int[] {
            -559939585,
            902409669,
            54,
            0});
            this.W0.Name = "W0";
            this.W0.Size = new System.Drawing.Size(96, 25);
            this.W0.TabIndex = 80;
            // 
            // J_0
            // 
            this.J_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.J_0.Location = new System.Drawing.Point(-1, 0);
            this.J_0.Name = "J_0";
            this.J_0.Size = new System.Drawing.Size(409, 30);
            this.J_0.TabIndex = 78;
            this.J_0.Text = "アニメーション間隔";
            this.J_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(-1, -2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(141, 30);
            this.label8.TabIndex = 23;
            this.label8.Text = "先頭アドレス";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.BlockSize);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Controls.Add(this.SelectAddress);
            this.panel5.Controls.Add(this.label22);
            this.panel5.Controls.Add(this.WriteButton);
            this.panel5.Controls.Add(this.Address);
            this.panel5.Controls.Add(this.label16);
            this.panel5.Location = new System.Drawing.Point(295, 45);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(917, 30);
            this.panel5.TabIndex = 147;
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Location = new System.Drawing.Point(240, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 30);
            this.label11.TabIndex = 64;
            this.label11.Text = "Size:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label22.Location = new System.Drawing.Point(414, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(122, 30);
            this.label22.TabIndex = 61;
            this.label22.Text = "選択アドレス:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WriteButton
            // 
            this.WriteButton.Location = new System.Drawing.Point(749, -1);
            this.WriteButton.Name = "WriteButton";
            this.WriteButton.Size = new System.Drawing.Size(167, 30);
            this.WriteButton.TabIndex = 60;
            this.WriteButton.Text = "書き込み";
            this.WriteButton.UseVisualStyleBackColor = true;
            // 
            // Address
            // 
            this.Address.Hexadecimal = true;
            this.Address.Location = new System.Drawing.Point(90, 4);
            this.Address.Maximum = new decimal(new int[] {
            -559939585,
            902409669,
            54,
            0});
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(130, 25);
            this.Address.TabIndex = 55;
            // 
            // label16
            // 
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Location = new System.Drawing.Point(-1, -2);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(85, 30);
            this.label16.TabIndex = 1;
            this.label16.Text = "アドレス";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.AddressListExpandsButton);
            this.panel6.Controls.Add(this.label30);
            this.panel6.Controls.Add(this.AddressList);
            this.panel6.Location = new System.Drawing.Point(12, 45);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(277, 782);
            this.panel6.TabIndex = 150;
            // 
            // AddressListExpandsButton
            // 
            this.AddressListExpandsButton.Location = new System.Drawing.Point(-2, 751);
            this.AddressListExpandsButton.Name = "AddressListExpandsButton";
            this.AddressListExpandsButton.Size = new System.Drawing.Size(274, 30);
            this.AddressListExpandsButton.TabIndex = 115;
            this.AddressListExpandsButton.Text = "リストの拡張";
            this.AddressListExpandsButton.UseVisualStyleBackColor = true;
            // 
            // label30
            // 
            this.label30.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label30.Location = new System.Drawing.Point(0, -1);
            this.label30.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(276, 26);
            this.label30.TabIndex = 106;
            this.label30.Text = "名前";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ReadCount
            // 
            this.ReadCount.Location = new System.Drawing.Point(372, 4);
            this.ReadCount.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.ReadCount.Name = "ReadCount";
            this.ReadCount.Size = new System.Drawing.Size(78, 25);
            this.ReadCount.TabIndex = 28;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.FilterComboBox);
            this.panel3.Controls.Add(this.ReloadListButton);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.ReadCount);
            this.panel3.Controls.Add(this.ReadStartAddress);
            this.panel3.Location = new System.Drawing.Point(12, 12);
            this.panel3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1200, 30);
            this.panel3.TabIndex = 148;
            // 
            // FilterComboBox
            // 
            this.FilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FilterComboBox.FormattingEnabled = true;
            this.FilterComboBox.Location = new System.Drawing.Point(456, 2);
            this.FilterComboBox.Name = "FilterComboBox";
            this.FilterComboBox.Size = new System.Drawing.Size(447, 26);
            this.FilterComboBox.TabIndex = 30;
            this.FilterComboBox.SelectedIndexChanged += new System.EventHandler(this.FilterComboBox_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(282, 1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 30);
            this.label9.TabIndex = 24;
            this.label9.Text = "読込数";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ReadStartAddress
            // 
            this.ReadStartAddress.Hexadecimal = true;
            this.ReadStartAddress.Location = new System.Drawing.Point(146, 3);
            this.ReadStartAddress.Maximum = new decimal(new int[] {
            -559939585,
            902409669,
            54,
            0});
            this.ReadStartAddress.Name = "ReadStartAddress";
            this.ReadStartAddress.Size = new System.Drawing.Size(130, 25);
            this.ReadStartAddress.TabIndex = 27;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ExportAllButton);
            this.panel2.Controls.Add(this.ImportAllButton);
            this.panel2.Location = new System.Drawing.Point(295, 796);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(915, 30);
            this.panel2.TabIndex = 151;
            // 
            // ExportAllButton
            // 
            this.ExportAllButton.Location = new System.Drawing.Point(641, 0);
            this.ExportAllButton.Name = "ExportAllButton";
            this.ExportAllButton.Size = new System.Drawing.Size(274, 30);
            this.ExportAllButton.TabIndex = 117;
            this.ExportAllButton.Text = "一括エクスポート";
            this.ExportAllButton.UseVisualStyleBackColor = true;
            this.ExportAllButton.Click += new System.EventHandler(this.ExportAllButton_Click);
            // 
            // ImportAllButton
            // 
            this.ImportAllButton.Location = new System.Drawing.Point(329, 0);
            this.ImportAllButton.Name = "ImportAllButton";
            this.ImportAllButton.Size = new System.Drawing.Size(274, 30);
            this.ImportAllButton.TabIndex = 116;
            this.ImportAllButton.Text = "一括インポート";
            this.ImportAllButton.UseVisualStyleBackColor = true;
            this.ImportAllButton.Click += new System.EventHandler(this.ImportAllButton_Click);
            // 
            // MapPictureBox
            // 
            this.MapPictureBox.AutoScroll = true;
            this.MapPictureBox.Location = new System.Drawing.Point(2, 2);
            this.MapPictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.MapPictureBox.Name = "MapPictureBox";
            this.MapPictureBox.Size = new System.Drawing.Size(905, 403);
            this.MapPictureBox.TabIndex = 152;
            // 
            // X_SAMPLE_BIG_PIC
            // 
            this.X_SAMPLE_BIG_PIC.Interpolation = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
            this.X_SAMPLE_BIG_PIC.Location = new System.Drawing.Point(5, 93);
            this.X_SAMPLE_BIG_PIC.Margin = new System.Windows.Forms.Padding(5);
            this.X_SAMPLE_BIG_PIC.Name = "X_SAMPLE_BIG_PIC";
            this.X_SAMPLE_BIG_PIC.Size = new System.Drawing.Size(904, 167);
            this.X_SAMPLE_BIG_PIC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.X_SAMPLE_BIG_PIC.TabIndex = 86;
            this.X_SAMPLE_BIG_PIC.TabStop = false;
            // 
            // BlockSize
            // 
            this.BlockSize.ErrorMessage = "";
            this.BlockSize.Location = new System.Drawing.Point(326, 1);
            this.BlockSize.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BlockSize.Name = "BlockSize";
            this.BlockSize.Placeholder = "";
            this.BlockSize.ReadOnly = true;
            this.BlockSize.Size = new System.Drawing.Size(82, 25);
            this.BlockSize.TabIndex = 63;
            // 
            // SelectAddress
            // 
            this.SelectAddress.ErrorMessage = "";
            this.SelectAddress.Location = new System.Drawing.Point(540, 1);
            this.SelectAddress.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.SelectAddress.Name = "SelectAddress";
            this.SelectAddress.Placeholder = "";
            this.SelectAddress.ReadOnly = true;
            this.SelectAddress.Size = new System.Drawing.Size(137, 25);
            this.SelectAddress.TabIndex = 62;
            // 
            // AddressList
            // 
            this.AddressList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AddressList.FormattingEnabled = true;
            this.AddressList.ItemHeight = 18;
            this.AddressList.Location = new System.Drawing.Point(-1, 25);
            this.AddressList.Margin = new System.Windows.Forms.Padding(4);
            this.AddressList.Name = "AddressList";
            this.AddressList.Size = new System.Drawing.Size(277, 724);
            this.AddressList.TabIndex = 0;
            this.AddressList.SelectedIndexChanged += new System.EventHandler(this.AddressList_SelectedIndexChanged);
            // 
            // MapTileAnimation1Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1222, 828);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel3);
            this.Name = "MapTileAnimation1Form";
            this.Text = "マップタイルアニメーション1";
            this.Load += new System.EventHandler(this.MapTileAnimation1Form_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.P4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.W2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.W0)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Address)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ReadCount)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ReadStartAddress)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.X_SAMPLE_BIG_PIC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ReloadListButton;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label J_0;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label30;
        private ListBoxEx AddressList;
        private System.Windows.Forms.NumericUpDown ReadCount;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown ReadStartAddress;
        private System.Windows.Forms.NumericUpDown W0;
        private System.Windows.Forms.NumericUpDown Address;
        private FEBuilderGBA.TextBoxEx BlockSize;
        private System.Windows.Forms.Label label11;
        private FEBuilderGBA.TextBoxEx SelectAddress;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button WriteButton;
        private System.Windows.Forms.ComboBox FilterComboBox;
        private System.Windows.Forms.Button AddressListExpandsButton;
        private System.Windows.Forms.NumericUpDown W2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown P4;
        private InterpolatedPictureBox X_SAMPLE_BIG_PIC;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.Panel panel1;
        private MapPictureBox MapPictureBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox SamplePaletteComboBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button ExportAllButton;
        private System.Windows.Forms.Button ImportAllButton;
    }
}