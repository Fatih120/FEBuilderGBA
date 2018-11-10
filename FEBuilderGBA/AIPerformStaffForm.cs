﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace FEBuilderGBA
{
    public partial class AIPerformStaffForm : Form
    {
        public AIPerformStaffForm()
        {
            InitializeComponent();
            this.AddressList.OwnerDraw(ListBoxEx.DrawItemAndText, DrawMode.OwnerDrawFixed);

            this.InputFormRef = Init(this);
            this.InputFormRef.MakeGeneralAddressListContextMenu(true);
        }

        public InputFormRef InputFormRef;
        static InputFormRef Init(Form self)
        {
            return new InputFormRef(self
                , ""
                , Program.ROM.RomInfo.ai_preform_staff_pointer()
                , 8
                , (int i, uint addr) =>
                {
                    return Program.ROM.u16(addr) != 0x0;
                }
                , (int i, uint addr) =>
                {
                    uint item_id = Program.ROM.u16(addr);
                    return U.ToHexString(item_id) + " " + ItemForm.GetItemName(item_id);
                }
                );
        }

        private void AIPerformStaff_Load(object sender, EventArgs e)
        {

        }
        //全データの取得
        public static void MakeAllDataLength(List<Address> list)
        {
            InputFormRef InputFormRef = Init(null);
            FEBuilderGBA.Address.AddAddress(list, InputFormRef, "AIPerformStaff", new uint[] { 4 });

            List<U.AddrResult> arlist = InputFormRef.MakeList();
            FEBuilderGBA.Address.AddFunctions(list, arlist, 4, "AIPerformStaff_ASM_");
        }
    }
}