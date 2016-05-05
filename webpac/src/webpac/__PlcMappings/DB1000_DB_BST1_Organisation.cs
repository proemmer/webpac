
using System;
using Papper.Attributes;


namespace Insite.Customer.Data.DB_BST1_Organisation
{
    

    
    public class UDT_Organisation_BST
    {
        public bool PST_available { get; set; }
        public bool PST_RFID_available { get; set; }
        public bool ST_Index_available { get; set; }
        public bool ST_RFID_available { get; set; }
        public bool ST_Release_Btn_available { get; set; }
        public bool ST_Release_saving { get; set; }
        public bool AutoRepaIsIndirectRepa { get; set; }
        public bool JIS_Send_available { get; set; }
        public bool JIS_Receive_available { get; set; }
        public bool Oiling_available { get; set; }
        public bool Pick2Symbol_Active { get; set; }
        public bool Autom_in_Repair { get; set; }
        public bool Devices_available { get; set; }
        public bool Fenata_Inp_required { get; set; }
        public bool DestSelection_per_source { get; set; }
        public bool OutLet_Coordinating { get; set; }
        public bool FixScan_Feature_1 { get; set; }
        public bool FixScan_Feature_2 { get; set; }
        public bool FixScan_Feature_3 { get; set; }
        public bool FixScan_Feature_4 { get; set; }
        public bool FixScan_Feature_5 { get; set; }
        public bool FixScan_Feature_6 { get; set; }

        [ArrayBounds(1,8,0)]
        public bool[] Rack { get; set; }

        [ArrayBounds(1,4,0)]
        public bool[] Boxes { get; set; }

        [ArrayBounds(0,12,0)]
        public bool[] HandScanner { get; set; }

        [ArrayBounds(1,12,0)]
        public bool[] Features { get; set; }
        public bool Reserve { get; set; }
        public bool Std_Camera_available { get; set; }
        public bool Data_get_from_BST_before { get; set; }
        public bool KLT_Request_triggered { get; set; }
        public bool Phone_Request_avail { get; set; }
        public bool SpecialEngine_evaluation { get; set; }
        public bool Eval_PST_too_long_busy { get; set; }
        public bool Eval_BST_in_Process { get; set; }
        public bool PST_opens_with_ST { get; set; }
        public bool Devices_on_PST_available { get; set; }
        public bool PST_right_from_ST { get; set; }
        public bool Release_f_EmptyWPC_req { get; set; }
        public bool Release2_available { get; set; }
        public bool Release2_joining { get; set; }
        public bool NOK_from_Station_repair { get; set; }
        public bool Chaku_Chaku_Fct { get; set; }
        public bool All_WPC_stop { get; set; }
        public bool CT_Button_available { get; set; }
        public bool HT_CT_Button_available { get; set; }
        public bool Engine_OutLock_available { get; set; }
        public bool Engine_new_Request_avail { get; set; }
        public bool DestPreSelect_available { get; set; }
        public bool Dest_Storage_available { get; set; }
        public bool reserve_DestPreSelect { get; set; }
        public bool WorkCont_Row1_ext_Data { get; set; }
        public bool WorkCont_Row2_ext_Data { get; set; }
        public bool WorkCont_Row3_ext_Data { get; set; }
        public bool WorkCont_PST_Data_disp { get; set; }
        public Int16 autom_Repa_NOK_Cnt { get; set; }
        public Int16 autom_Repa_Stop_reset { get; set; }

        [ArrayBounds(1,14,0)]
        public Char[] ReserveChar { get; set; }

        [ArrayBounds(1,8,0)]
        public Int16[] ECO_Rack { get; set; }

        [ArrayBounds(1,4,0)]
        public Int16[] ECO_Boxes { get; set; }
        public Int16 ECO_Devices { get; set; }
        public Int16 ECO_Ext_KLT { get; set; }
        public Int16 ECO_Devices_PST { get; set; }

        [ArrayBounds(1,6,0)]
        public Int16[] Scanner_IQ { get; set; }

    }

    [Mapping("DB_BST1_Organisation", "DB1000", 0)]
    public class DB_BST1_Organisation
    {
        public UDT_Organisation_BST Org { get; set; }

    }

}

