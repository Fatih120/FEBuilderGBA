﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace FEBuilderGBA
{
    public partial class EventUnitFE7Form : Form
    {
        public EventUnitFE7Form()
        {
            InitializeComponent();

            this.InputFormRef = Init(this);

            this.MAP_LISTBOX.OwnerDraw(ListBoxEx.DrawTextOnly, DrawMode.OwnerDrawFixed);
            this.AddressList.OwnerDraw(EventUnitForm.AddressList_Draw, DrawMode.OwnerDrawVariable);
            this.EVENT_LISTBOX.OwnerDraw(EventUnitForm.EVENT_LISTBOX_Draw, DrawMode.OwnerDrawVariable);

            //マップIDリストを作る.
            U.ConvertListBox(MapSettingForm.MakeMapIDList(), ref this.MAP_LISTBOX);

            //AIで狙うキャラアドレスをちゃんと埋める.
            L_12_COMBO.BeginUpdate();
            L_12_COMBO.Items.Clear();
            for (int i = 0; i < EventUnitForm.AI1.Count; i++)
            {
                L_12_COMBO.Items.Add(EventUnitForm.AI1[i].Name);
            }
            L_12_COMBO.EndUpdate();
            L_12_COMBO.SelectedIndex = 0;

            L_13_COMBO.BeginUpdate();
            L_13_COMBO.Items.Clear();
            for (int i = 0; i < EventUnitForm.AI2.Count; i++)
            {
                L_13_COMBO.Items.Add(EventUnitForm.AI2[i].Name);
            }
            L_13_COMBO.EndUpdate();
            L_13_COMBO.SelectedIndex = 0;

            //右クリックメニューを出す.
            this.InputFormRef.MakeGeneralAddressListContextMenu(true);

            this.InputFormRef.PreAddressListExpandsEvent += EventUnitForm.OnPreClassExtendsWarningHandler;
            this.InputFormRef.AddressListExpandsEvent += AddressListExpandsEvent;

            this.MapPictureBox.MapMouseDownEvent += MapMouseDownEvent;

//            //ユニットID重複チェック
//            //ダメ、重複が許されるケースがあった
//            this.B0.ValueChanged += EventUnitForm_CheckDuplicatePlayerUnits;
        }

        public InputFormRef InputFormRef;
        static InputFormRef Init(EventUnitFE7Form self)
        {
            return new InputFormRef(self
                , ""
                , 0
                , Program.ROM.RomInfo.eventunit_data_size()
                , (int i, uint addr) =>
                {//読込最大値検索
                    //00まで検索
                    return Program.ROM.u8(addr) != 0;
                }
                , (int i, uint addr) =>
                {
                    uint unit_id = Program.ROM.u8(addr);
                    if (unit_id == 0)
                    {
                        return null;
                    }
                    uint class_id = Program.ROM.u8(addr+1);
                    uint unitgrow = Program.ROM.u16(addr + 3);
                    if (class_id == 0)
                    {//クラスIDが0だったらユーザIDで補完する
                        class_id = UnitForm.GetClassID(unit_id);
                    }

                    String unit_name = UnitForm.GetUnitName(unit_id);
                    String class_name = ClassForm.GetClassName(class_id);
                    uint level = U.ParseUnitGrowLV(unitgrow);

                    return unit_name + "(" + class_name + ")" + "  " + "Lv:"+level.ToString();
                }
                );
        }

        private void MAP_LISTBOX_SelectedIndexChanged(object sender, EventArgs e)
        {
            uint mapid = (uint)MAP_LISTBOX.SelectedIndex;
            if (mapid == U.NOT_FOUND)
            {
                return;
            }
            uint addr = MapSettingForm.GetEventAddrWhereMapID(mapid);
            if (!U.isSafetyOffset(addr))
            {
                return;
            }

            List<U.AddrResult> list = EventCondForm.MakeUnitPointer(mapid);
            //未記帳の拡張した領域があれば追加する.
            EventUnitForm.AppendNoWriteNewData(list, mapid);

            U.ConvertListBox(list, ref this.EVENT_LISTBOX);
            if (this.EVENT_LISTBOX.Items.Count > 0)
            {
                this.EVENT_LISTBOX.SelectedIndex = 0;
            }
            else
            {
                MapPictureBox.LoadMap(mapid);
            }
        }


        private void EVENT_LISTBOX_SelectedIndexChanged(object sender, EventArgs e)
        {
            U.AddrResult ar = InputFormRef.SelectToAddrResult(this.EVENT_LISTBOX);
            if (!U.isSafetyOffset(ar.addr))
            {
                this.MapPictureBox.ClearAllPoint();
                return;
            }
            //タグにマップ番号が入っている.
            MapPictureBox.LoadMap(ar.tag);

            this.MapPictureBox.ClearAllPoint();
            this.InputFormRef.ReInit(ar.addr);
        }


        public void JumpToMap(uint mapid)
        {
            MAP_LISTBOX.SelectedIndex = (int)mapid;
        }
        public void JumpTo(uint addr, int unitIndex = 0)
        {
            addr = U.toOffset(addr);

            //アドレスからマップとイベントの逆変換
            int mapindex, eventindex;
            if (ConvertAddrToMapAndEvent(0, (uint)MAP_LISTBOX.Items.Count, addr, out mapindex, out eventindex))
            {
                if (mapindex < this.MAP_LISTBOX.Items.Count)
                {
                    this.MAP_LISTBOX.SelectedIndex = mapindex;
                    if (eventindex < this.EVENT_LISTBOX.Items.Count)
                    {
                        this.EVENT_LISTBOX.SelectedIndex = eventindex;

                        if (unitIndex < this.AddressList.Items.Count)
                        {
                            this.AddressList.SelectedIndex = unitIndex;
                        }
                        return;
                    }
                }
            }

            this.MapPictureBox.ClearAllPoint();
            this.InputFormRef.ReInit(addr);
        }

        bool ConvertAddrToMapAndEvent(uint starti,uint endi,uint addr, out int out_mapindex, out int out_eventindex)
        {
            for (uint i = starti; i < endi; i++)
            {
                List<U.AddrResult> eventlist = EventCondForm.MakeUnitPointer(i);
                for (int n = 0; n < eventlist.Count; n++)
                {
                    if (eventlist[n].addr == addr)
                    {//FOUND!
                        out_mapindex = (int)i;
                        out_eventindex = n;
                        return true;
                    }
                }
            }
            out_mapindex = -1;
            out_eventindex = -1;
            return false;
        }

        private void JUMP_BATTLETALK_Click(object sender, EventArgs e)
        {
            EventBattleTalkFE7Form f = (EventBattleTalkFE7Form)InputFormRef.JumpForm<EventBattleTalkFE7Form>(U.NOT_FOUND);
            f.JumpTo((uint)B0.Value);
        }

        private void JUMP_BATTLEBGM_Click(object sender, EventArgs e)
        {
            SoundBossBGMForm f = (SoundBossBGMForm)InputFormRef.JumpForm<SoundBossBGMForm>(U.NOT_FOUND);
            f.JumpTo((uint)B0.Value);
        }

        private void JUMP_HAIKU_Click(object sender, EventArgs e)
        {
            EventHaikuFE7Form f = (EventHaikuFE7Form)InputFormRef.JumpForm<EventHaikuFE7Form>(U.NOT_FOUND);
            f.JumpTo((uint)B0.Value, (uint)MAP_LISTBOX.SelectedIndex);
        }

        public GrowSimulator BuildSim()
        {
            GrowSimulator sim = new GrowSimulator();
            UnitForm.GetSim(ref sim
                , (uint)B0.Value //ユニット
            );
            ClassForm.GetSim(ref sim
                , (uint)B1.Value //クラス
            );

            return sim;
        }
        
        private void AddressList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawAllUnits();
            PosSyncCheck();

            SetNotifyMode();
            CheckCoord();
        }

        void CheckCoord()
        {
            if (!this.MapPictureBox.IsMapLoad())
            {//まだマップを読みこんでいない.
                return;
            }

            int mapwidth = this.MapPictureBox.GetMapBitmapWidth() / 16;
            int mapheight = this.MapPictureBox.GetMapBitmapHeight() / 16;

            if (B4.Value > mapwidth || B5.Value > mapheight)
            {
                this.EVENTUNIT_BEFORE_COORD.ErrorMessage = R._("ユニットの座標({0},{1})は、マップのサイズ({2},{3})より大きい座標です。"
                    , B4.Value, B5.Value, mapwidth, mapheight);
            }
            else
            {
                this.EVENTUNIT_BEFORE_COORD.ErrorMessage = "";
            }

            if (B6.Value > mapwidth || B7.Value > mapheight)
            {
                this.EVENTUNIT_AFTER_COORD.ErrorMessage = R._("ユニットの座標({0},{1})は、マップのサイズ({2},{3})より大きい座標です。"
                    , B6.Value, B7.Value, mapwidth, mapheight);
            }
            else
            {
                this.EVENTUNIT_AFTER_COORD.ErrorMessage = "";
            }
        }
        void SetNotifyMode()
        {
            if (this.MapPictureBox.GetNotifyMode())
            {//既に通知モードなので何もしない.
                return;
            }

            //一度フォーカスを当てて、位置選択状態にする
            Control prevFocusedControl = this.ActiveControl;
            B4.Focus();
            if (prevFocusedControl == null)
            {
                AddressList.Focus();
            }
            else
            {
                prevFocusedControl.Focus();
            }
        }

        void PosSyncCheck()
        {
            if (B4.Value == B6.Value && B5.Value == B7.Value)
            {//配置前と配置後が同一の場合、同時変更オプションを提示
                PosSyncUpdateComboBox.SelectedIndex = 0;
            }
            else
            {
                PosSyncUpdateComboBox.SelectedIndex = 1;
            }
        }

        ToolTipEx X_Tooltip;
        private void EventUnitFE7Form_Load(object sender, EventArgs e)
        {
            X_Tooltip = InputFormRef.GetToolTip<EventUnitFE7Form>();
            this.EVENTUNIT_BEFORE_COORD.SetToolTipEx(this.X_Tooltip);
            this.EVENTUNIT_AFTER_COORD.SetToolTipEx(this.X_Tooltip);
            MapPictureBox.SetDefualtIcon(ImageSystemIconForm.Blank16());
        }
        public static List<U.AddrResult> MakeList(uint addr)
        {
            InputFormRef InputFormRef = Init(null);
            InputFormRef.ReInit(addr);
            return InputFormRef.MakeList();
        }

        public void DrawAllUnits()
        {
            MapPictureBox.ClearStaticItem();
            List<U.AddrResult> list = InputFormRef.MakeList();
            for (int i = 0; i < list.Count; i++)
            {
                if (AddressList.SelectedIndex == i)
                {//選択しているものは別ルーチンで詳細に描画する.
                    DrawSelectedUnit();
                }
                else
                {//選択していないものは、移動後座標だけ描画する.
                    MapPictureBox.StaticItem sitem = DrawAfterPosUnit(list[i].addr);
                    MapPictureBox.SetStaticItem("o" + i.ToString(), sitem.x, sitem.y, sitem.bitmap, sitem.draw_x_add, sitem.draw_y_add);
                }
            }
            MapPictureBox.Invalidate();
        }
        public static Bitmap DrawItemIconOnly(uint addr, int itemcount)
        {
            uint p = addr + 8 + (uint)itemcount;
            if (!U.isSafetyZArray(p))
            {
                return ImageUtil.BlankDummy();
            }
            uint item_id = Program.ROM.u8(p);
            return ItemForm.DrawIcon(item_id);
        }
        public static List<MapPictureBox.StaticItem> DrawUnit(uint addr)
        {
            uint unit_id = Program.ROM.u8(addr + 0);
            uint class_id = Program.ROM.u8(addr + 1);
            uint unitgrow = Program.ROM.u8(addr + 3);
            int before_x = (int)Program.ROM.u8(addr + 4);
            int before_y = (int)Program.ROM.u8(addr + 5);
            int after_x = (int)Program.ROM.u8(addr + 6);
            int after_y = (int)Program.ROM.u8(addr + 7);

            if (class_id == 0)
            {//クラスIDが0だったらユーザIDで補完する
                class_id = UnitForm.GetClassID(unit_id);
            }
            
            return
                DrawUnit(class_id, unitgrow, before_x, before_y, after_x, after_y);
        }


        public void DrawSelectedUnit()
        {
            uint unit_id = (uint)B0.Value;
            uint class_id = (uint)B1.Value;
            if (class_id == 0)
            {//クラスIDが0だったらユーザIDで補完する
                class_id = UnitForm.GetClassID(unit_id);
            }

            List<MapPictureBox.StaticItem> list =
                EventUnitFE7Form.DrawUnit(
                  class_id
                , (uint)B3.Value
                , (int)B4.Value
                , (int)B5.Value
                , (int)B6.Value
                , (int)B7.Value
                );
            for (int n = list.Count - 1; n >= 0; n--)
            {
                MapPictureBox.SetStaticItem("c" + n.ToString(), list[n].x, list[n].y, list[n].bitmap, list[n].draw_x_add, list[n].draw_y_add);
            }

        }

        public static List<MapPictureBox.StaticItem> DrawUnit(uint class_id, uint unitgrow, int before_x, int before_y, int after_x, int after_y)
        {
            MapPictureBox.StaticItem st;
            List<MapPictureBox.StaticItem> list = new List<MapPictureBox.StaticItem>();
            int palette_type = (int)U.ParseUnitGrowAssign(unitgrow);

            Bitmap icon = ClassForm.DrawWaitIcon(class_id, palette_type);

            //たまに背丈がでかくて16x16を超えてしまうやつがいるので補正する
            int draw_x_add = 16 - icon.Width;
            int draw_y_add = 16 - icon.Height;

            uint assign = U.ParseUnitGrowAssign(unitgrow);

            st = new MapPictureBox.StaticItem();
            st.bitmap = icon;
            st.x = before_x;
            st.y = before_y;
            st.draw_x_add = draw_x_add;
            st.draw_y_add = draw_y_add;
            list.Add(st);

            if (before_x == after_x && before_y == after_y)
            {
                return list;
            }

            st = new MapPictureBox.StaticItem();
            st.bitmap = icon;
            st.x = after_x;
            st.y = after_y;
            st.draw_x_add = draw_x_add;
            st.draw_y_add = draw_y_add;
            list.Add(st);

            EventUnitForm.AppendDrawAllow(ref list, before_x, before_y, after_x, after_y);

            return list;
        }


        //移動後の終端位置にいるキャラの描画
        public static MapPictureBox.StaticItem DrawAfterPosUnit(uint addr)
        {
            uint unit_id = Program.ROM.u8(addr);
            uint class_id = Program.ROM.u8(addr + 1);
            uint unitgrow = Program.ROM.u8(addr + 3);
            int before_x = (int)Program.ROM.u8(addr + 4);
            int before_y = (int)Program.ROM.u8(addr + 5);
            int after_x = (int)Program.ROM.u8(addr + 6);
            int after_y = (int)Program.ROM.u8(addr + 7);
            if (class_id == 0)
            {//クラスIDが0だったらユーザIDで補完する
                class_id = UnitForm.GetClassID(unit_id);
            }

            return
                DrawAfterPosUnit(class_id, unitgrow, before_x, before_y, after_x, after_y);
        }

        public static MapPictureBox.StaticItem DrawAfterPosUnit(uint class_id, uint unitgrow, int before_x, int before_y, int after_x,int after_y)
        {
            MapPictureBox.StaticItem st;
            int palette_type = (int)U.ParseUnitGrowAssign(unitgrow);

            Bitmap icon = ClassForm.DrawWaitIcon(class_id, palette_type);

            //たまに背丈がでかくて16x16を超えてしまうやつがいるので補正する
            int draw_x_add = 16 - icon.Width;
            int draw_y_add = 16 - icon.Height;

            uint assign = U.ParseUnitGrowAssign(unitgrow);

            st = new MapPictureBox.StaticItem();
            st.bitmap = icon;
            st.x = before_x;
            st.y = before_y;
            st.draw_x_add = draw_x_add;
            st.draw_y_add = draw_y_add;

            if (before_x == after_x && before_y == after_y)
            {
                return st;
            }

            st = new MapPictureBox.StaticItem();
            st.bitmap = icon;
            st.x = after_x;
            st.y = after_y;
            st.draw_x_add = draw_x_add;
            st.draw_y_add = draw_y_add;
            return st;
        }



        //リストが拡張されたとき
        void AddressListExpandsEvent(object sender, EventArgs arg)
        {
            U.ReSelectList(this.MAP_LISTBOX, this.EVENT_LISTBOX);
        }

        private void MapMouseDownEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {//右クリックされたとき
                int clickx = MapPictureBox.CursolToTile(e.X);
                int clicky = MapPictureBox.CursolToTile(e.Y);

                for (int index = 0; true; index++)
                {
                    //表示領域の都合上、選択されたユニットでなければ、最終移動位置しか描画していないため、探索するときはそれを踏まえる.
                    bool isSelectedUnit = (this.AddressList.SelectedIndex == index);

                    uint addr = InputFormRef.SelectToAddr(this.AddressList, index);
                    if (!U.isSafetyOffset(addr))
                    {
                        break;
                    }
                    int before_x = (int)Program.ROM.u8(addr + 4);
                    int before_y = (int)Program.ROM.u8(addr + 5);
                    int after_x = (int)Program.ROM.u8(addr + 6);
                    int after_y = (int)Program.ROM.u8(addr + 7);

                    if (isSelectedUnit)
                    {//選択している場合は、配置前座標を探索.
                        if (before_x == clickx && before_y == clicky)
                        {
                            this.AddressList.SelectedIndex = index; //選択されたユニットへ移動
                            this.B4.Focus(); //移動場所にフォーカスを当てることで notifyモードに切り替える.
                            break;
                        }
                    }
                    //配置後探索
                    if (after_x == clickx && after_y == clicky)
                    {
                        this.AddressList.SelectedIndex = index; //選択されたユニットへ移動

                        //ただし配置後と配置前か同一の場合、配置前を選択する.
                        if (before_x == after_x && before_y == after_y)
                        {
                            this.B4.Focus(); //配置前
                        }
                        else
                        {
                            this.B6.Focus(); //移動場所にフォーカスを当てることで notifyモードに切り替える.
                        }
                        
                        break;
                    }
                }
            }
        }

        private void B4_ValueChanged(object sender, EventArgs e)
        {
            if (PosSyncUpdateComboBox.SelectedIndex == 0)
            {//配置後も自動変更 X
                U.ForceUpdate(B6, B4.Value);
            }
            else
            {
                AddressList_SelectedIndexChanged(null, null);
            }
        }

        private void B5_ValueChanged(object sender, EventArgs e)
        {
            if (PosSyncUpdateComboBox.SelectedIndex == 0)
            {//配置後も自動変更 Y
                B7.Value = B5.Value;
            }
            else
            {
                AddressList_SelectedIndexChanged(null, null);
            }
        }

        //新規に確保した領域
        private void NewButton_Click(object sender, EventArgs e)
        {
            EventUnitForm.CreateNewData(EVENT_LISTBOX, MAP_LISTBOX.SelectedIndex);
        }
        public void MakeAddressListExpandsCallback(EventHandler eventHandler)
        {
            this.InputFormRef.MakeAddressListExpandsCallback(eventHandler);
        }

        public static string CheckUnitsEvenetArg(uint units_address)
        {
            if (!U.isSafetyPointer(units_address))
            {
                return R._("ユニットを読みこむポインタの指定が正しくありません。: {0}", U.To0xHexString(units_address));
            }

            units_address = U.toOffset(units_address);
            if (!U.isSafetyOffset(units_address))
            {
                return R._("ユニットを読みこむポインタの指定が正しくありません。: {0}", U.To0xHexString(units_address));
            }

            int count = 0;
            uint addr = units_address;
            while (Program.ROM.u8(addr) != 0x0)
            {
                if (!U.isSafetyOffset(addr+4))
                {
                    break;
                }

//                string errorMessage;
//                errorMessage = EventUnitForm.CheckUnitsUnitType(addr);
//                if (errorMessage.Length > 0)
//                {
//                    return R._("ユニットを読込 {0} 、 {1}番目のユニットのデータに問題があります。:{2}", U.To0xHexString(units_address) , count , errorMessage);
//                }

                addr += Program.ROM.RomInfo.eventunit_data_size();
                if (!U.isSafetyOffset(addr))
                {
                    break;
                }
                count ++;
            }

            return "";
        }

        private void AddressList_KeyDown(object sender, KeyEventArgs e)
        {
        }
        //プレイヤーユニットの重複を警告する.
        private void EventUnitForm_CheckDuplicatePlayerUnits(object sender, EventArgs e)
        {
            uint mapid = (uint)MAP_LISTBOX.SelectedIndex;
            U.AddrResult selectEventAR = InputFormRef.SelectToAddrResult(this.EVENT_LISTBOX);
            U.AddrResult selectUnitAR = InputFormRef.SelectToAddrResult(this.AddressList);

            uint unitID = (uint)B0.Value;
            uint unitGrow = (uint)B3.Value;
            uint posHash = ((uint)B4.Value) << 8 | ((uint)B5.Value);
            L_0_UNIT.ErrorMessage = EventUnitForm.ErrorCheckDuplicatePlayerUnits(unitID
                , unitGrow
                , posHash
                , selectEventAR.addr
                , selectUnitAR.addr
                , mapid);
        }

    }
}
