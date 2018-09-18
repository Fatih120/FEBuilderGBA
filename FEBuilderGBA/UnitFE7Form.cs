﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace FEBuilderGBA
{
    public partial class UnitFE7Form : Form
    {
        

        public UnitFE7Form()
        {
            InitializeComponent();

            this.AddressList.OwnerDraw(ListBoxEx.DrawUnitAndText, DrawMode.OwnerDrawFixed);
            this.InputFormRef = Init(this);
            this.InputFormRef.MakeGeneralAddressListContextMenu(true);

            //成長率
            B28.ValueChanged += X_SIM_ValueChanged;
            B29.ValueChanged += X_SIM_ValueChanged;
            B30.ValueChanged += X_SIM_ValueChanged;
            B31.ValueChanged += X_SIM_ValueChanged;
            B32.ValueChanged += X_SIM_ValueChanged;
            B33.ValueChanged += X_SIM_ValueChanged;
            B34.ValueChanged += X_SIM_ValueChanged;

            //初期値
            B11.ValueChanged += X_SIM_ValueChanged;
            b12.ValueChanged += X_SIM_ValueChanged;
            b13.ValueChanged += X_SIM_ValueChanged;
            b14.ValueChanged += X_SIM_ValueChanged;
            b15.ValueChanged += X_SIM_ValueChanged;
            b16.ValueChanged += X_SIM_ValueChanged;
            b17.ValueChanged += X_SIM_ValueChanged;

            X_SIM.ValueChanged += X_SIM_ValueChanged;
        }

        public InputFormRef InputFormRef;
        static InputFormRef Init(Form self)
        {
            return new InputFormRef(self
                , ""
                , Program.ROM.RomInfo.unit_pointer()
                , Program.ROM.RomInfo.unit_datasize()
                , (int i, uint addr) =>
                {//個数が固定できまっている
                    return i < Program.ROM.RomInfo.unit_maxcount(); 
                }
                , (int i, uint addr) =>
                {
                    uint id = Program.ROM.u16(addr);
                    return U.ToHexString(i + 1) + " " + TextForm.Direct(id);
                }
                );
        }

        private void UnitFormFE7_Load(object sender, EventArgs e)
        {
            List<Control> controls = InputFormRef.GetAllControls(this);
            ToolTipEx tooltip = InputFormRef.GetToolTip<UnitFE7Form>();
            InputFormRef.LoadCheckboxesResource(U.ConfigDataFilename("unitclass_checkbox_"), controls, tooltip, "", "L_40_BIT_", "L_41_BIT_", "L_42_BIT_", "L_43_BIT_");

        }


        public static uint GetUnitBaseMagicExtends(uint addr)
        {
            return Program.ROM.u8(addr + 50);
        }
        public static uint GetUnitGrowMagicExtends(uint addr)
        {
            return Program.ROM.u8(addr + 51);
        }

        public static void GetSim(ref GrowSimulator sim,uint uid)
        {
            if (uid == 0)
            {
                return ;
            }
            uid--;
            InputFormRef InputFormRef = Init(null);
            uint addr = InputFormRef.IDToAddr(uid);
            if (!U.isSafetyOffset(addr))
            {
                return;
            }

            sim.SetUnitBase((int)Program.ROM.u8(addr+11) //LV
                , (int)Program.ROM.u8(addr + 12) //hp
                , (int)Program.ROM.u8(addr + 13) //str
                , (int)Program.ROM.u8(addr + 14) //skill
                , (int)Program.ROM.u8(addr + 15) //spd
                , (int)Program.ROM.u8(addr + 16) //def
                , (int)Program.ROM.u8(addr + 17) //res
                , (int)Program.ROM.u8(addr + 18) //luck
                , (int)GetUnitBaseMagicExtends(addr) //magic ext
                );
            sim.SetUnitGrow(
                  (int)Program.ROM.u8(addr + 28) //hp
                , (int)Program.ROM.u8(addr + 29) //str
                , (int)Program.ROM.u8(addr + 30) //skill
                , (int)Program.ROM.u8(addr + 31) //spd
                , (int)Program.ROM.u8(addr + 32) //def
                , (int)Program.ROM.u8(addr + 33) //res
                , (int)Program.ROM.u8(addr + 34) //luck
                , (int)GetUnitGrowMagicExtends(addr) //magic ext
                );
        }
        public GrowSimulator BuildSim()
        {
            GrowSimulator sim = new GrowSimulator();
            sim.SetUnitBase((int)B11.Value //LV
                , (int)b12.Value //hp
                , (int)b13.Value //str
                , (int)b14.Value //skill
                , (int)b15.Value //spd
                , (int)b16.Value //def
                , (int)b17.Value //res
                , (int)b18.Value //luck
                , (int)MagicExtUnitBase.Value //magic ext
                );
            sim.SetUnitGrow(
                  (int)B28.Value //hp
                , (int)B29.Value //str
                , (int)B30.Value //skill
                , (int)B31.Value //spd
                , (int)B32.Value //def
                , (int)B33.Value //res
                , (int)B34.Value //luck
                , (int)MagicExtUnitGrow.Value //magic ext
                );
            ClassForm.GetSim(ref sim
                , (uint)B5.Value //支援クラス
            );

            return sim;
        }

        private void X_SIM_ValueChanged(object sender, EventArgs e)
        {
            if (this.InputFormRef != null && this.InputFormRef.IsUpdateLock)
            {
                return;
            }

            GrowSimulator sim = BuildSim();
            sim.Grow((int)X_SIM.Value,true);

            X_SIM.Value = sim.sim_lv;
            X_SIM_HP.Value = sim.sim_hp;
            X_SIM_STR.Value = sim.sim_str;
            X_SIM_SKILL.Value = sim.sim_skill;
            X_SIM_SPD.Value = sim.sim_spd;
            X_SIM_DEF.Value = sim.sim_def;
            X_SIM_RES.Value = sim.sim_res;
            X_SIM_LUCK.Value = sim.sim_luck;

            X_SIM_SUM_RATE.Value = sim.sim_sum_grow_rate;
        }

        private void AddressList_SelectedIndexChanged(object sender, EventArgs e)
        {
            X_SIM.Value = GrowSimulator.CalcMaxLevel((uint)B5.Value);
            X_SIM_ValueChanged(null, null);
//            MeleeAndMagicFix();
        }
        public void MeleeAndMagicFix()
        {
            if (this.InputFormRef != null && this.InputFormRef.IsUpdateLock)
            {
                return;
            }
            if (InputFormRef.SearchMeleeAndMagicFixPatch())
            {
                return;
            }
            bool useMelee = (B20.Value > 0 || B21.Value > 0 || B22.Value > 0 || B23.Value > 0);
            bool useMagic = (B24.Value > 0 || B25.Value > 0 || B26.Value > 0 || B27.Value > 0);
            if (useMelee && useMagic)
            {
                HowDoYouLikePatchForm.CheckAndShowPopupDialog(HowDoYouLikePatchForm.TYPE.MeleeAndMagicFix_By_Unit);
            }
        }

        public static uint GetPaletteLowClass(uint uid)
        {
            if (uid == 0)
            {
                return 0;
            }
            uid--;
            InputFormRef InputFormRef = Init(null);
            uint addr = InputFormRef.IDToAddr(uid);
            if (!U.isSafetyOffset(addr))
            {
                return 0;
            }
            return Program.ROM.u8(addr+35);
        }
        public static uint GetPaletteHighClass(uint uid)
        {
            if (uid == 0)
            {
                return 0;
            }
            uid--;
            InputFormRef InputFormRef = Init(null);
            uint addr = InputFormRef.IDToAddr(uid);
            if (!U.isSafetyOffset(addr))
            {
                return 0;
            }
            return Program.ROM.u8(addr + 36);
        }

        public static string GetNameWhereCustomBattleAnime(uint custom_battle_id)
        {
            if (custom_battle_id == 0)
            {
                return "";
            }

            InputFormRef InputFormRef = Init(null);

            uint addr = InputFormRef.BaseAddress;
            for (int i = 0; i < InputFormRef.DataCount; i++)
            {
                if (custom_battle_id == Program.ROM.u8(addr + 37))
                {//下級職
                    uint id = Program.ROM.u16(addr);
                    return TextForm.Direct(id) + " " + R._("下級職");
                }
                if (custom_battle_id == Program.ROM.u8(addr + 38))
                {//上級職
                    uint id = Program.ROM.u16(addr);
                    return TextForm.Direct(id) + " " + R._("上級職");
                }
                
                addr += InputFormRef.BlockSize;
            }
            return "";
        }
        //全データの取得
        public static void MakeAllDataLength(List<Address> list)
        {
            InputFormRef InputFormRef = Init(null);
            FEBuilderGBA.Address.AddAddress(list, InputFormRef, "Unit", new uint[] { 44 });
        }

        public static uint GetHighClassFE7(uint uid)
        {
            if (uid == 0)
            {
                return 0;
            }
            uid--;

            //FE7までは分岐がないので、クラスのCCクラスを参照する.
            uint shien_classs_id = UnitForm.GetClassID(uid);
            if (shien_classs_id <= 0)
            {
                return 0;
            }

            uint change_class = ClassForm.GetChangeClassID(shien_classs_id);
            if (change_class <= 0)
            {
                return 0;
            }

            if (ClassForm.isHighClass(change_class))
            {//上位クラスなので、もう CCではない
                return change_class;
            }
            return 0;
        }
        //ロードユニットフラグの確認

    }
}
