namespace Insite.Customer.Data.DB_DATA_RF_BST1_VST
{
    
    

    public class UDT_Arbeitszeit_A_Zeit
    {
        [ArrayBounds(1,8,0)]
        public Char[] KZBEZ { get; set; }

        [ArrayBounds(1,4,0)]
        public Char[] Zeit { get; set; }
    }

    

    public class UDT_repa_REP_TEXTE
    {
        [ArrayBounds(1,80,0)]
        public Char[] DEBT { get; set; }

        [ArrayBounds(1,80,0)]
        public Char[] SYMP { get; set; }

        [ArrayBounds(1,80,0)]
        public Char[] TXT1 { get; set; }

        [ArrayBounds(1,80,0)]
        public Char[] PRTX { get; set; }
    }

    

    public class UDT_repa_Fehler_MF
    {
        [ArrayBounds(1,2,0)]
        public Char[] code { get; set; }
    }

    

    public class UDT_repa_Fehler
    {
        [ArrayBounds(1,10,0)]
        public Char[] FBNR { get; set; }

        [ArrayBounds(1,80,0)]
        public UDT_repa_Fehler_MF[] MF { get; set; }
    }

    

    public class UDT_bauteil_intern_BAUTEIL
    {
        [ArrayBounds(1,4,0)]
        public Char[] KBEZ { get; set; }

        [ArrayBounds(1,14,0)]
        public Char[] BTCO { get; set; }
    }

    

    public class UDT_AwT_AwT_SnrSlot
    {
        [ArrayBounds(1,10,0)]
        public Char[] SNR { get; set; }
    }

    

    public class UDT_AwT_AwT
    {
        [ArrayBounds(1,4,0)]
        public Char[] KBEZ { get; set; }

        [ArrayBounds(1,7,0)]
        public UDT_AwT_AwT_SnrSlot[] SnrSlot { get; set; }
    }

    

    public class UDT_Ma_prog_MA_PROG
    {
        [ArrayBounds(1,6,0)]
        public Char[] STAT { get; set; }

        [ArrayBounds(1,2,0)]
        public Char[] PROG { get; set; }
    }

    

    public class UDT_Sachnr_Sachnummer
    {
        [ArrayBounds(1,4,0)]
        public Char[] KBEZ { get; set; }

        [ArrayBounds(1,10,0)]
        public Char[] SNR { get; set; }

        [ArrayBounds(1,2,0)]
        public Char[] BTCO { get; set; }
    }

    

    public class UDT_Motor_dat_MOMO
    {
        [ArrayBounds(1,4,0)]
        public Char[] KBEZ { get; set; }

        [ArrayBounds(1,4,0)]
        public Char[] DAT { get; set; }
    }


    
    public class UDT_Arbeitszeit
    {

        [ArrayBounds(1,50,0)]
        public UDT_Arbeitszeit_A_Zeit[] A_Zeit { get; set; }

    }

    
    public class UDT_repa
    {
        public UDT_repa_REP_TEXTE REP_TEXTE { get; set; }

        [ArrayBounds(1,5,0)]
        public UDT_repa_Fehler[] Fehler { get; set; }

    }

    
    public class UDT_Standby_text
    {

        [ArrayBounds(1,80,0)]
        public Char[] TXT1 { get; set; }

        [ArrayBounds(1,80,0)]
        public Char[] TXT2 { get; set; }

        [ArrayBounds(1,80,0)]
        public Char[] TXT3 { get; set; }

        [ArrayBounds(1,80,0)]
        public Char[] TXT4 { get; set; }

        [ArrayBounds(1,80,0)]
        public Char[] TXT5 { get; set; }

    }

    
    public class UDT_bauteil_intern
    {

        [ArrayBounds(1,29,0)]
        public UDT_bauteil_intern_BAUTEIL[] BAUTEIL { get; set; }

    }

    
    public class UDT_AwT
    {

        [ArrayBounds(1,22,0)]
        public UDT_AwT_AwT[] AwT { get; set; }
        
        [StringLength(70)]
        public string Reserve { get; set; }

    }

    
    public class UDT_Ma_prog
    {

        [ArrayBounds(1,75,0)]
        public UDT_Ma_prog_MA_PROG[] MA_PROG { get; set; }

    }

    
    public class UDT_Sachnr
    {

        [ArrayBounds(1,131,0)]
        public UDT_Sachnr_Sachnummer[] Sachnummer { get; set; }

        [ArrayBounds(2096,2099,0)]
        public Char[] Res_2096_2099 { get; set; }

    }

    
    public class UDT_Motor_dat
    {

        [ArrayBounds(1,4,0)]
        public Char[] MONR_BEZ { get; set; }

        [ArrayBounds(1,14,0)]
        public Char[] MONR { get; set; }

        [ArrayBounds(1,4,0)]
        public Char[] Prod_BEZ { get; set; }

        [ArrayBounds(1,14,0)]
        public Char[] PROD { get; set; }

        [ArrayBounds(1,4,0)]
        public Char[] LPNR_BEZ { get; set; }

        [ArrayBounds(1,14,0)]
        public Char[] LPNR { get; set; }

        [ArrayBounds(1,4,0)]
        public Char[] MOAR_BEZ { get; set; }

        [ArrayBounds(1,14,0)]
        public Char[] MOAR { get; set; }

        [ArrayBounds(1,4,0)]
        public Char[] APOI_BEZ { get; set; }

        [ArrayBounds(1,14,0)]
        public Char[] APOI { get; set; }

        [ArrayBounds(1,4,0)]
        public Char[] SEQI_BEZ { get; set; }

        [ArrayBounds(1,14,0)]
        public Char[] SEQI { get; set; }

        [ArrayBounds(1,4,0)]
        public Char[] SMAT_BEZ { get; set; }

        [ArrayBounds(1,14,0)]
        public Char[] SMAT { get; set; }

        [ArrayBounds(1,4,0)]
        public Char[] TYP_Bez { get; set; }

        [ArrayBounds(1,14,0)]
        public Char[] TYP { get; set; }

        [ArrayBounds(1,4,0)]
        public Char[] ABE_Bez { get; set; }

        [ArrayBounds(1,14,0)]
        public Char[] ABEK { get; set; }

        [ArrayBounds(1,4,0)]
        public Char[] SNMO_Bez { get; set; }

        [ArrayBounds(1,14,0)]
        public Char[] SNMO { get; set; }

        [ArrayBounds(1,4,0)]
        public Char[] ABLO_BEZ { get; set; }

        [ArrayBounds(1,14,0)]
        public Char[] ABLO { get; set; }

        [ArrayBounds(1,4,0)]
        public Char[] BEMO_BEZ { get; set; }

        [ArrayBounds(1,14,0)]
        public Char[] BEMO { get; set; }

        [ArrayBounds(216,399,0)]
        public Char[] RES_216bis399 { get; set; }

        [ArrayBounds(1,37,0)]
        public UDT_Motor_dat_MOMO[] MOMO { get; set; }

        [ArrayBounds(1,4,0)]
        public Char[] Reserve { get; set; }

    }

    
    public class UDT_FK_dat
    {

        [ArrayBounds(1,4,0)]
        public Char[] PALETTEN_NUMMER { get; set; }
        public Char PALETTEN_STATUS { get; set; }
        public Char PALETTEN_REP { get; set; }

        [ArrayBounds(1,2,0)]
        public Char[] UMLAUF_ZAEHL { get; set; }

        [ArrayBounds(1,8,0)]
        public Char[] HERK_DIREKT { get; set; }

        [ArrayBounds(1,8,0)]
        public Char[] ZIEL_DIREKT { get; set; }

        [ArrayBounds(1,8,0)]
        public Char[] HERK_REP_INFO { get; set; }

        [ArrayBounds(1,8,0)]
        public Char[] ZIEL_IND_BEARB { get; set; }

        [ArrayBounds(1,8,0)]
        public Char[] ZIEL_IND_REP { get; set; }

        [ArrayBounds(1,8,0)]
        public Char[] HERK_STBY_INFO { get; set; }

        [ArrayBounds(1,8,0)]
        public Char[] ZIEL_STBY_INFO { get; set; }

        [ArrayBounds(1,8,0)]
        public Char[] FERNZIEL { get; set; }

        [ArrayBounds(1,8,0)]
        public Char[] FERNZIEL_res1 { get; set; }

        [ArrayBounds(1,8,0)]
        public Char[] FERNZIEL_res2 { get; set; }
        public Char MOTOR_NIO { get; set; }
        public Char LECKTEST_IO { get; set; }
        public Char OELBEFUELLSTATUS { get; set; }
        public Char MECH_KALTTEST_IO { get; set; }

        [ArrayBounds(1,4,0)]
        public Char[] PRUEFLZ_LECKTEST { get; set; }

        [ArrayBounds(1,4,0)]
        public Char[] PRUEFLZ_MECH_KALTTEST { get; set; }

        [ArrayBounds(1,4,0)]
        public Char[] IO_PRUEFLZ_LECKTEST { get; set; }

        [ArrayBounds(1,4,0)]
        public Char[] IO_PRUEFLZ_MECH_KALTTEST { get; set; }
        public Char NW_Abruf { get; set; }
        public Char Res109 { get; set; }

        [ArrayBounds(110,177,0)]
        public Char[] RES_110BIS177 { get; set; }

    }

    
    public class UDT_RF_Dat
    {
        public UDT_FK_dat Fahrkurs { get; set; }
        public UDT_bauteil_intern BT_intern { get; set; }
        public UDT_Motor_dat Motordaten { get; set; }
        public UDT_Sachnr Sachnr { get; set; }
        public UDT_Ma_prog Masch_prog { get; set; }
        public UDT_AwT AuswTab { get; set; }
        public UDT_Arbeitszeit Arbeitszeit { get; set; }
        public UDT_Standby_text Text_standby { get; set; }
        public UDT_repa Repa { get; set; }

    }

    [Mapping("DB_DATA_RF_BST1_VST", "DB1112", 0)]
    public class DB_DATA_RF_BST1_VST
    {
        public UDT_RF_Dat daten { get; set; }

    }

}

