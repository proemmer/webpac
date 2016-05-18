namespace Insite.Customer.Data.SymbolTable
{
    
    [Mapping("Flag", "FB", 0)]
    public class Flag
    {
		public bool M_Null { get; set; }// M       0.0
		public bool M_Eins { get; set; }// M       0.1
		public bool M_Neustart { get; set; }// M       0.2
		public bool M_IntFehlerCPU { get; set; }// M       0.3

        [MappingOffset(0,6)]
		public bool M_Inbetriebnahme_0 { get; set; }// M       0.6
		public bool M_Inbetriebnahme_1 { get; set; }// M       0.7
		public bool M_Takt_10hz { get; set; }// M       1.0
		public bool M_Takt_5hz { get; set; }// M       1.1
		public bool M_Takt_2hz5 { get; set; }// M       1.2
		public bool M_Takt_2hz { get; set; }// M       1.3
		public bool M_Takt_2hz25 { get; set; }// M       1.4
		public bool M_Takt_1hz { get; set; }// M       1.5
		public bool M_Takt_0hz625 { get; set; }// M       1.6
		public bool M_takt_0hz5 { get; set; }// M       1.7
		public bool M_All_DP_SL_OK { get; set; }// M       2.0
		public bool M_DP_SL_NIO { get; set; }// M       2.1
		public bool M_DP_SL_gestoert { get; set; }// M       2.2

        [MappingOffset(3,0)]
		public bool M_P_FL_ServBetr_aus { get; set; }// M       3.0

        [MappingOffset(4,0)]
		public bool M_HM_Takt_10hz { get; set; }// M       4.0
		public bool M_HM_Takt_5hz { get; set; }// M       4.1
		public bool M_HM_Takt_2hz5 { get; set; } // M       4.2
		public bool M_HM_Takt_2hz { get; set; }// M       4.3
		public bool M_HM_Takt_2hz25 { get; set; }// M       4.4
		public bool M_HM_Takt_1hz { get; set; }// M       4.5
		public bool M_HM_Takt_0hz625 { get; set; }// M       4.6
		public bool M_HM_takt_0hz5 { get; set; }// M       4.7
		public bool M_FL_Takt_10hz { get; set; }// M       5.0
		public bool M_FL_Takt_5hz { get; set; }// M       5.1
		public bool M_FL_Takt_2hz5 { get; set; }// M       5.2
		public bool M_FL_Takt_2hz { get; set; }// M       5.3
		public bool M_FL_Takt_2hz25 { get; set; }// M       5.4
		public bool M_FL_Takt_1hz { get; set; }// M       5.5
		public bool M_FL_Takt_0hz625 { get; set; }// M       5.6
		public bool M_FL_takt_0hz5 { get; set; }// M       5.7
		public bool M_USV_NIO { get; set; }// M       6.0

        [MappingOffset(10,0)]
		public bool M_P_FLAW_Zentr_Start { get; set; }// M      10.0
		public bool M_IP_FLAW_Zentr_Start { get; set; }// M      10.1
		public bool M_N_FLAW_Zentr_Start { get; set; }// M      10.2
		public bool M_IN_FLAW_Zentr_Start { get; set; }// M      10.3
		public bool M_Anlage_Zentral_Eing { get; set; }// M      10.4
		public bool M_P_FLAW_Zentr_Ein { get; set; }// M      10.5
		public bool M_IP_FLAW_Zentr_ein { get; set; }// M      10.6
		public bool M_HNTE_angef { get; set; }// M      10.7

        [MappingOffset(20,0)]
		public bool M_Freigabe_Antr_BST1 { get; set; }// M      20.0
		public bool M_Automatik_ein_BST1 { get; set; }// M      20.1
		public bool M_Hand_Betr_BST1 { get; set; }// M      20.2
		public bool M_Serv_Betr_BST1 { get; set; }// M      20.3
		public bool M_GST_fahren_BST1 { get; set; }// M      20.4
		public bool M_Einzelschrittbetr_BST1 { get; set; }// M      20.5
		public bool M_HNTE_BST1 { get; set; }// M      20.6
		public bool M_HNTE_erreicht_BST1 { get; set; }// M      20.7
		public bool M_Stoerung_quitt_BST1 { get; set; }// M      21.0
		public bool M_Anlage_ein_verz_BST1 { get; set; }// M      21.1
		public bool M_Grundstellung_BST1 { get; set; }// M      21.2

        [MappingOffset(22,0)]
		public bool M_Freigabe_Antr_BST2 { get; set; }// M      22.0
		public bool M_Automatik_ein_BST2 { get; set; }// M      22.1
		public bool M_Hand_Betr_BST2 { get; set; }// M      22.2
		public bool M_Serv_Betr_BST2 { get; set; }// M      22.3
		public bool M_GST_fahren_BST2 { get; set; }// M      22.4
		public bool M_Einzelschrittbetr_BST2 { get; set; }// M      22.5
		public bool M_HNTE_BST2 { get; set; }// M      22.6
		public bool M_HNTE_erreicht_BST2 { get; set; }// M      22.7
		public bool M_Stoerung_quitt_BST2 { get; set; }// M      23.0
		public bool M_Anlage_ein_verz_BST2 { get; set; }// M      23.1
		public bool M_Grundstellung_BST2 { get; set; }// M      23.2

        [MappingOffset(24,0)]
		public bool M_Freigabe_Antr_BST3 { get; set; }// M      24.0
		public bool M_Automatik_ein_BST3 { get; set; }// M      24.1
		public bool M_Hand_Betr_BST3 { get; set; }// M      24.2
		public bool M_Serv_Betr_BST3 { get; set; }// M      24.3
		public bool M_GST_fahren_BST3 { get; set; }// M      24.4
		public bool M_Einzelschrittbetr_BST3 { get; set; }// M      24.5
		public bool M_HNTE_BST3 { get; set; }// M      24.6
		public bool M_HNTE_erreicht_BST3 { get; set; }// M      24.7
		public bool M_Stoerung_quitt_BST3 { get; set; }// M      25.0
		public bool M_Anlage_ein_verz_BST3 { get; set; }// M      25.1
		public bool M_Grundstellung_BST3 { get; set; }// M      25.2

        [MappingOffset(26,0)]
		public bool M_Freigabe_Antr_BST4 { get; set; }// M      26.0
		public bool M_Automatik_ein_BST4 { get; set; }// M      26.1
		public bool M_Hand_Betr_BST4 { get; set; }// M      26.2
		public bool M_Serv_Betr_BST4 { get; set; }// M      26.3
		public bool M_GST_fahren_BST4 { get; set; }// M      26.4
		public bool M_Einzelschrittbetr_BST4 { get; set; }// M      26.5
		public bool M_HNTE_BST4 { get; set; }// M      26.6
		public bool M_HNTE_erreicht_BST4 { get; set; }// M      26.7
		public bool M_Stoerung_quitt_BST4 { get; set; }// M      27.0
		public bool M_Anlage_ein_verz_BST4 { get; set; }// M      27.1
		public bool M_Grundstellung_BST4 { get; set; }// M      27.2

        [MappingOffset(30,0)]
		public bool M_Sammelstoerung_BST1 { get; set; }// M      30.0
		public bool M_Auto_Start_moegl_BST1 { get; set; }// M      30.1
		public bool M_Sammelmeldung_BST1 { get; set; }// M      30.2
		public bool M_Meld_mit_AutoStop_BST1 { get; set; }// M      30.3
		public bool M_Sofort_stop_BST1 { get; set; }// M      30.4
		public bool M_Anw_einzelschritt_BST1 { get; set; }// M      30.5
		public bool M_abwahl_BST1 { get; set; }// M      30.6
		public bool M_ohne_Station_BST1 { get; set; }// M      30.7
		public bool M_Teilemangel_BST1 { get; set; }// M      31.0
		public bool M_Stör_HNTE_BST1 { get; set; }// M      31.1
		public bool M_Teile_ENDE_BST1 { get; set; }// M      31.2
		public bool M_Stoer_ohne_Stop_BST1 { get; set; }// M      31.3
		public bool M_Meld_Stoerlampe_BST1 { get; set; }// M      31.4

        [MappingOffset(32,0)]
		public bool M_Sammelstoerung_BST2 { get; set; }// M      32.0
		public bool M_Auto_Start_moegl_BST2 { get; set; }// M      32.1
		public bool M_Sammelmeldung_BST2 { get; set; }// M      32.2
		public bool M_Meld_mit_AutoStop_BST2 { get; set; }// M      32.3
		public bool M_Sofort_stop_BST2 { get; set; }// M      32.4
		public bool M_Anw_einzelschritt_BST2 { get; set; }// M      32.5
		public bool M_abwahl_BST2 { get; set; }// M      32.6
		public bool M_ohne_Station_BST2 { get; set; }// M      32.7
		public bool M_Teilemangel_BST2 { get; set; }// M      33.0
		public bool M_Stör_HNTE_BST2 { get; set; }// M      33.1
		public bool M_Teile_ENDE_BST2 { get; set; }// M      33.2
		public bool M_Stoer_ohne_Stop_BST2 { get; set; }// M      33.3
		public bool M_Meld_Stoerlampe_BST2 { get; set; }// M      33.4

        [MappingOffset(34,0)]
		public bool M_Sammelstoerung_BST3 { get; set; }// M      34.0
		public bool M_Auto_Start_moegl_BST3 { get; set; }// M      34.1
		public bool M_Sammelmeldung_BST3 { get; set; }// M      34.2
		public bool M_Meld_mit_AutoStop_BST3 { get; set; }// M      34.3
		public bool M_Sofort_stop_BST3 { get; set; }// M      34.4
		public bool M_Anw_einzelschritt_BST3 { get; set; }// M      34.5
		public bool M_abwahl_BST3 { get; set; }// M      34.6
		public bool M_ohne_Station_BST3 { get; set; }// M      34.7
		public bool M_Teilemangel_BST3 { get; set; }// M      35.0
		public bool M_Stör_HNTE_BST3 { get; set; }// M      35.1
		public bool M_Teile_ENDE_BST3 { get; set; }// M      35.2
		public bool M_Stoer_ohne_Stop_BST3 { get; set; }// M      35.3
		public bool M_Meld_Stoerlampe_BST3 { get; set; }// M      35.4

        [MappingOffset(36,0)]
		public bool M_Sammelstoerung_BST4 { get; set; }// M      36.0
		public bool M_Auto_Start_moegl_BST4 { get; set; }// M      36.1
		public bool M_Sammelmeldung_BST4 { get; set; }// M      36.2
		public bool M_Meld_mit_AutoStop_BST4 { get; set; }// M      36.3
		public bool M_Sofort_stop_BST4 { get; set; }// M      36.4
		public bool M_Anw_einzelschritt_BST4 { get; set; }// M      36.5
		public bool M_abwahl_BST4 { get; set; }// M      36.6
		public bool M_ohne_Station_BST4 { get; set; }// M      36.7
		public bool M_Teilemangel_BST4 { get; set; }// M      37.0
		public bool M_Stör_HNTE_BST4 { get; set; }// M      37.1
		public bool M_Teile_ENDE_BST4 { get; set; }// M      37.2
		public bool M_Stoer_ohne_Stop_BST4 { get; set; }// M      37.3
		public bool M_Meld_Stoerlampe_BST4 { get; set; }// M      37.4

        [MappingOffset(38,0)]
		public bool M_Sammelstoerung_BST5 { get; set; }// M      38.0
		public bool M_Auto_Start_moegl_BST5 { get; set; }// M      38.1
		public bool M_Sammelmeldung_BST5 { get; set; }// M      38.2
		public bool M_Meld_mit_AutoStop_BST5 { get; set; }// M      38.3
		public bool M_Sofort_stop_BST5 { get; set; }// M      38.4
		public bool M_Anw_einzelschritt_BST5 { get; set; }// M      38.5
		public bool M_abwahl_BST5 { get; set; }// M      38.6
		public bool M_ohne_Station_BST5 { get; set; }// M      38.7
		public bool M_Teilemangel_BST5 { get; set; }// M      39.0
		public bool M_Stör_HNTE_BST5 { get; set; }// M      39.1
		public bool M_Teile_ENDE_BST5 { get; set; }// M      39.2
		public bool M_Stoer_ohne_Stop_BST5 { get; set; }// M      39.3
		public bool M_Meld_Stoerlampe_BST5 { get; set; }// M      39.4

        [MappingOffset(40,0)]
		public bool M_Sammelstoerung_BST6 { get; set; }// M      40.0
		public bool M_Auto_Start_moegl_BST6 { get; set; }// M      40.1
		public bool M_Sammelmeldung_BST6 { get; set; }// M      40.2
		public bool M_Meld_mit_AutoStop_BST6 { get; set; }// M      40.3
		public bool M_Sofort_stop_BST6 { get; set; }// M      40.4
		public bool M_Anw_einzelschritt_BST6 { get; set; }// M      40.5
		public bool M_abwahl_BST6 { get; set; }// M      40.6
		public bool M_ohne_Station_BST6 { get; set; }// M      40.7
		public bool M_Teilemangel_BST6 { get; set; }// M      41.0
		public bool M_Stör_HNTE_BST6 { get; set; }// M      41.1
		public bool M_Teile_ENDE_BST6 { get; set; }// M      41.2
		public bool M_Stoer_ohne_Stop_BST6 { get; set; }// M      41.3
		public bool M_Meld_Stoerlampe_BST6 { get; set; }// M      41.4

        [MappingOffset(42,0)]
		public bool M_Freigabe_Antr_BST5 { get; set; }// M      42.0
		public bool M_Automatik_ein_BST5 { get; set; }// M      42.1
		public bool M_Hand_Betr_BST5 { get; set; }// M      42.2
		public bool M_Serv_Betr_BST5 { get; set; }// M      42.3
		public bool M_GST_fahren_BST5 { get; set; }// M      42.4
		public bool M_Einzelschrittbetr_BST5 { get; set; }// M      42.5
		public bool M_HNTE_BST5 { get; set; }// M      42.6
		public bool M_HNTE_erreicht_BST5 { get; set; }// M      42.7
		public bool M_Stoerung_quitt_BST5 { get; set; }// M      43.0
		public bool M_Anlage_ein_verz_BST5 { get; set; }// M      43.1
		public bool M_Grundstellung_BST5 { get; set; }// M      43.2

        [MappingOffset(44,0)]
		public bool M_Freigabe_Antr_BST6 { get; set; }// M      44.0
		public bool M_Automatik_ein_BST6 { get; set; }// M      44.1
		public bool M_Hand_Betr_BST6 { get; set; }// M      44.2
		public bool M_Serv_Betr_BST6 { get; set; }// M      44.3
		public bool M_GST_fahren_BST6 { get; set; }// M      44.4
		public bool M_Einzelschrittbetr_BST6 { get; set; }// M      44.5
		public bool M_HNTE_BST6 { get; set; }// M      44.6
		public bool M_HNTE_erreicht_BST6 { get; set; }// M      44.7
		public bool M_Stoerung_quitt_BST6 { get; set; }// M      45.0
		public bool M_Anlage_ein_verz_BST6 { get; set; }// M      45.1
		public bool M_Grundstellung_BST6 { get; set; }// M      45.2

        [MappingOffset(51,0)]
		public bool M_not_Aus_HVO_IO { get; set; }// M      51.0

        [MappingOffset(140,0)]
		public bool M_Daten_von_ACS_vorh { get; set; }// M     140.0
		public bool M_alte_Daten_von_ACS { get; set; }// M     140.1

        [MappingOffset(140,4)]
		public bool M_Datenaust__ACS_fertig { get; set; }// M     140.4

        [MappingOffset(280,0)]
		public bool M_Bildanwahl_NIO { get; set; }// M     280.0
		public bool M_bildanwahl_res { get; set; }// M     280.1
		public bool M_bildanwahl_res2 { get; set; }// M     280.2
		public bool M_bildanwahl_res3 { get; set; }// M     280.3
		public bool M_Bildanwahl_NIO_BSt5 { get; set; }// M     280.4
		public bool M_Bildanwahl_NIO_BSt6 { get; set; }// M     280.5
		public bool M_bildanwahl_res6 { get; set; }// M     280.6
		public bool M_bildanwahl_res7 { get; set; }// M     280.7

        [MappingOffset(1100,0)]
		public bool M_Dat_vorh_ST_BST1 { get; set; }// M    1100.0
		public bool M_WT_mit_Bearb_BST1 { get; set; }// M    1100.1
		public bool M_WT_ohne_Bearb_BST1 { get; set; }// M    1100.2
		public bool M_WT_and_ziel_BST1 { get; set; }// M    1100.3
		public bool M_Frg_Dat_schreib_BST1 { get; set; }// M    1100.4
		public bool M_Standby_Ziel_ST_BST1 { get; set; }// M    1100.5
		public bool M_Leer_WT_St_BST1 { get; set; }// M    1100.6
		public bool M_Stat_fuer_WT_abgw_BST1 { get; set; }// M    1100.7
		public bool M_St_by_Ziel_vorgew_BST1 { get; set; }// M    1101.0
		public bool M_Somo_BST1 { get; set; }// M    1101.1
		public bool M_StandBy_info_BST1 { get; set; }// M    1101.2
		public bool M_Irrläufer_BST1 { get; set; }// M    1101.3
		public bool M_Prio_1_BST1 { get; set; }// M    1101.4

        [MappingOffset(1101,7)]
		public bool M_Lampentest_BST1 { get; set; }// M    1101.7

        [MappingOffset(1110,0)]
		public bool M_Dat_vorh_VS_BST1 { get; set; }// M    1110.0
		public bool M_WT_mit_Bearb_VS_BST1 { get; set; }// M    1110.1
		public bool M_WT_ohne_Bearb_VS_BST1 { get; set; }// M    1110.2
		public bool M_WT_and_ziel_VS_BST1 { get; set; }// M    1110.3
		public bool M_Frg_schreib_VS_BST1 { get; set; }// M    1110.4
		public bool M_Standby_Ziel_VS_BST1 { get; set; }// M    1110.5
		public bool M_Leer_WT_VS_BST1 { get; set; }// M    1110.6
		public bool M_Prio_1_VS_BST1 { get; set; }// M    1110.7

        [MappingOffset(1115,1)]
		public bool M_bearbeitung_NIO_BST1 { get; set; }// M    1115.1

        [MappingOffset(1117,0)]
		public bool M_Vorw_SST_loesen_BST1 { get; set; }// M    1117.0

        [MappingOffset(1120,0)]
		public bool M_WT_Vorhanden_BST1 { get; set; }// M    1120.0

        [MappingOffset(1120,4)]
		public bool M_Erg_ausgewertet_BST1 { get; set; }// M    1120.4
		public bool M_frg_Typ_einst_BST1 { get; set; }// M    1120.5
		public bool M_WT_Freig_ausfahrt_BST1 { get; set; }// M    1120.6
		public bool M_WT_bearbeitet_BST1 { get; set; }// M    1120.7
		public bool M_Fertigmeld_ges_BST1 { get; set; }// M    1121.0

        [MappingOffset(1121,5)]
		public bool M_Frg_Taster_Lampe_BSt1 { get; set; }// M    1121.5
		public bool M_Frg_Taster2_gedr_BST1 { get; set; }// M    1121.6
		public bool M_Frg_Taster_gedr_BST1 { get; set; }// M    1121.7

        [MappingOffset(1140,0)]
		public bool M_Typ_4_zyl_BST1 { get; set; }// M    1140.0
		public bool M_Typ_6_zyl_BST1 { get; set; }// M    1140.1
		public bool M_Typ_res_3_BSt1 { get; set; }// M    1140.2
		public bool M_Typ_res_4_BSt1 { get; set; }// M    1140.3
		public bool M_Typ_res_5_BSt1 { get; set; }// M    1140.4
		public bool M_Typ_res_6_BSt1 { get; set; }// M    1140.5
		public bool M_Typ_res_7_BSt1 { get; set; }// M    1140.6
		public bool M_Typ_res_8_BSt1 { get; set; }// M    1140.7
		public bool M_Typ_res_9_BSt1 { get; set; }// M    1141.0
		public bool M_Typ_res_10_BSt1 { get; set; }// M    1141.1
		public bool M_Typ_res_11_BSt1 { get; set; }// M    1141.2
		public bool M_Typ_res_12_BSt1 { get; set; }// M    1141.3
		public bool M_Typ_res_13_BSt1 { get; set; }// M    1141.4
		public bool M_Typ_res_14_BSt1 { get; set; }// M    1141.5
		public bool M_Typ_res_15_BSt1 { get; set; }// M    1141.6
		public bool M_Typ_res_16_BSt1 { get; set; }// M    1141.7
		public bool M_Typ_res_17_BSt1 { get; set; }// M    1142.0
		public bool M_Typ_res_18_BSt1 { get; set; }// M    1142.1
		public bool M_Typ_res_19_BSt1 { get; set; }// M    1142.2
		public bool M_Typ_res_20_BSt1 { get; set; }// M    1142.3
		public bool M_Typ_res_21_BSt1 { get; set; }// M    1142.4
		public bool M_Typ_res_22_BSt1 { get; set; }// M    1142.5
		public bool M_Typ_res_23_BSt1 { get; set; }// M    1142.6
		public bool M_Typ_res_24_BSt1 { get; set; }// M    1142.7
		public bool M_Typ_res_25_BSt1 { get; set; }// M    1143.0
		public bool M_Typ_res_26_BSt1 { get; set; }// M    1143.1
		public bool M_Typ_res_27_BSt1 { get; set; }// M    1143.2
		public bool M_Typ_res_28_BSt1 { get; set; }// M    1143.3
		public bool M_Typ_res_29_BSt1 { get; set; }// M    1143.4
		public bool M_Typ_res_30_BSt1 { get; set; }// M    1143.5
		public bool M_Typ_res_31_BSt1 { get; set; }// M    1143.6
		public bool M_Typ_00_BSt1 { get; set; }// M    1143.7

        [MappingOffset(1150,0)]
		public bool M_Mld_Abwahl_BST1 { get; set; }// M    1150.0
		public bool M_Mld_Bearb_NIO_BST1 { get; set; }// M    1150.1
		public bool M_Mld_Schraub_NIO_BST1 { get; set; }// M    1150.2
		public bool M_Mld_res1_BST1 { get; set; }// M    1150.3
		public bool M_Mld_res2_BST1 { get; set; }// M    1150.4
		public bool M_Mld_res3_BST1 { get; set; }// M    1150.5
		public bool M_Mld_res4_BST1 { get; set; }// M    1150.6
		public bool M_Mld_letzte_ST_NIO_BSt1 { get; set; }// M    1150.7
		public bool M_Mld_res6_BST1 { get; set; }// M    1151.0
		public bool M_Mld_res7_BST1 { get; set; }// M    1151.1
		public bool M_Mld_res8_BST1 { get; set; }// M    1151.2
		public bool M_Mld_res9_BST1 { get; set; }// M    1151.3
		public bool M_Mld_res10_BST1 { get; set; }// M    1151.4
		public bool M_Mld_res11_BST1 { get; set; }// M    1151.5
		public bool M_Mld_res12_BST1 { get; set; }// M    1151.6
		public bool M_Mld_res13_BST1 { get; set; }// M    1151.7

        [MappingOffset(1160,0)]
		public bool M_Stoer_Ziel_ung_BST1 { get; set; }// M    1160.0
		public bool M_Stoer_UNIV_ung_BST1 { get; set; }// M    1160.1

        [MappingOffset(1160,3)]
		public bool M_Stoer_res4_BST1 { get; set; }// M    1160.3
		public bool M_Stoer_res5_BST1 { get; set; }// M    1160.4
		public bool M_Stoer_Stat_name_BST1 { get; set; }// M    1160.5
		public bool M_Stoer_ung__Mapro_BST1 { get; set; }// M    1160.6
		public bool M_Stoer_ung_Zielvor_BST1 { get; set; }// M    1160.7
		public bool M_Stoer_timout_JIS_rec { get; set; }// M    1161.0

        [MappingOffset(1300,0)]
		public bool M_Sammelstoer_PGS_BST1 { get; set; }// M    1300.0
		public bool M_Sammelmeld_PGS_BST1 { get; set; }// M    1300.1

        [MappingOffset(1600,0)]
		public bool M_Fertig_Regal_ges_BST1 { get; set; }// M    1600.0
		public bool M_Abwahl_Regal_BST1 { get; set; }// M    1600.1

        [MappingOffset(1610,0)]
		public bool M_Fertig_Pistol_ges_BST1 { get; set; }// M    1610.0
		public bool M_Abwahl_Pistole_BST1 { get; set; }// M    1610.1

        [MappingOffset(1612,0)]
		public bool M_Fertig_FIXScanner_BST1 { get; set; }// M    1612.0
		public bool M_Abwahl_FixScanner_BST1 { get; set; }// M    1612.1

        [MappingOffset(1613,0)]
		public bool M_Start_Fixscanner1_BST1 { get; set; }// M    1613.0

        [MappingOffset(1613,2)]
		public bool M_Start_Fixscanner2_BST1 { get; set; }// M    1613.2

        [MappingOffset(1613,4)]
		public bool M_Start_Fixscanner3_BST1 { get; set; }// M    1613.4

        [MappingOffset(1614,0)]
		public bool M_Lesefehl_FIXSCAN1_BST1 { get; set; }// M    1614.0
		public bool M_Lesefehl_FIXSCAN2_BST1 { get; set; }// M    1614.1
		public bool M_Lesefehl_FIXSCAN3_BST1 { get; set; }// M    1614.2

        [MappingOffset(1620,0)]
		public bool M_Fertig_Boxen_ges_BST1 { get; set; }// M    1620.0
		public bool M_Abwahl_Boxen_BST1 { get; set; }// M    1620.1

        [MappingOffset(1628,0)]
		public bool M_Fertig_Merkm_ges_BST1 { get; set; }// M    1628.0
		public bool M_Abwahl_Merkm_BST1 { get; set; }// M    1628.1

        [MappingOffset(1630,0)]
		public bool M_Fertig_Geraet_ges_BST1 { get; set; }// M    1630.0
		public bool M_Abwahl_Gerät_BST1 { get; set; }// M    1630.1
		public bool M_Gerät_Frg_Einlauf_BST1 { get; set; }// M    1630.2
		public bool M_Fertig_Geraet_ges_VST1 { get; set; }// M    1630.3
		public bool M_Abwahl_Gerät_VST1 { get; set; }// M    1630.4

        [MappingOffset(1640,0)]
		public bool M_Fertig_PGS_ges_BST1 { get; set; }// M    1640.0
		public bool M_Abwahl_PGS_BST1 { get; set; }// M    1640.1

        [MappingOffset(1647,0)]
		public bool M_Virt_Hap_fertig_BST1 { get; set; }// M    1647.0

        [MappingOffset(1650,0)]
		public bool M_Fertig_Fedok_BST1 { get; set; }// M    1650.0

        [MappingOffset(1652,1)]
		public bool M_TimeOut_ACS_ZP_BST1 { get; set; }// M    1652.1

        [MappingOffset(1653,0)]
		public bool M_Fertig_Chaku_BST1 { get; set; }// M    1653.0

        [MappingOffset(1999,0)]
		public bool M_Fertig_Sonderfkt_BST1 { get; set; }// M    1999.0
		public bool M_Frg_St_Sondfkt_BST1 { get; set; }// M    1999.1
		public bool M_Stoer_Sondfkt_BST1 { get; set; }// M    1999.2

        [MappingOffset(2100,0)]
		public bool M_Dat_vorh_ST_BST2 { get; set; }// M    2100.0
		public bool M_WT_mit_Bearb_BST2 { get; set; }// M    2100.1
		public bool M_WT_ohne_Bearb_BST2 { get; set; }// M    2100.2
		public bool M_WT_and_ziel_BST2 { get; set; }// M    2100.3
		public bool M_Frg_Dat_schreib_BST2 { get; set; }// M    2100.4
		public bool M_Standby_Ziel_ST_BST2 { get; set; }// M    2100.5
		public bool M_Leer_WT_St_BST2 { get; set; }// M    2100.6
		public bool M_Stat_fuer_WT_abgw_BST2 { get; set; }// M    2100.7
		public bool M_St_by_Ziel_vorgew_BST2 { get; set; }// M    2101.0
		public bool M_Somo_BST2 { get; set; }// M    2101.1
		public bool M_StandBy_info_BST2 { get; set; }// M    2101.2
		public bool M_Irrläufer_BST2 { get; set; }// M    2101.3
		public bool M_Prio_1_BST2 { get; set; }// M    2101.4

        [MappingOffset(2101,7)]
		public bool M_Lampentest_BST2 { get; set; }// M    2101.7

        [MappingOffset(2110,0)]
		public bool M_Dat_vorh_VS_BST2 { get; set; }// M    2110.0
		public bool M_WT_mit_Bearb_VS_BST2 { get; set; }// M    2110.1
		public bool M_WT_ohne_Bearb_VS_BST2 { get; set; }// M    2110.2
		public bool M_WT_and_ziel_VS_BST2 { get; set; }// M    2110.3
		public bool M_Frg_schreib_VS_BST2 { get; set; }// M    2110.4
		public bool M_Standby_Ziel_VS_BST2 { get; set; }// M    2110.5
		public bool M_Leer_WT_VS_BST2 { get; set; }// M    2110.6
		public bool M_Prio_1_VS_BST2 { get; set; }// M    2110.7

        [MappingOffset(2115,1)]
		public bool M_bearbeitung_NIO_BST2 { get; set; }// M    2115.1

        [MappingOffset(2117,0)]
		public bool M_Vorw_SST_loesen_BST2 { get; set; }// M    2117.0

        [MappingOffset(2120,0)]
		public bool M_WT_Vorhanden_BST2 { get; set; }// M    2120.0

        [MappingOffset(2120,4)]
		public bool M_Erg_ausgewertet_BST2 { get; set; }// M    2120.4
		public bool M_frg_Typ_einst_BST2 { get; set; }// M    2120.5
		public bool M_WT_Freig_ausfahrt_BST2 { get; set; }// M    2120.6
		public bool M_WT_bearbeitet_BST2 { get; set; }// M    2120.7
		public bool M_Fertigmeld_ges_BST2 { get; set; }// M    2121.0

        [MappingOffset(2121,5)]
		public bool M_Frg_Taster_Lampe_BSt2 { get; set; }// M    2121.5
		public bool M_Frg_Taster2_gedr_BST2 { get; set; }// M    2121.6
		public bool M_Frg_Taster_gedr_BST2 { get; set; }// M    2121.7

        [MappingOffset(2140,0)]
		public bool M_Typ_4_zyl_BST2 { get; set; }// M    2140.0
		public bool M_Typ_6_zyl_BST2 { get; set; }// M    2140.1
		public bool M_Typ_res_3_BST2 { get; set; }// M    2140.2
		public bool M_Typ_res_4_BST2 { get; set; }// M    2140.3
		public bool M_Typ_res_5_BST2 { get; set; }// M    2140.4
		public bool M_Typ_res_6_BST2 { get; set; }// M    2140.5
		public bool M_Typ_res_7_BST2 { get; set; }// M    2140.6
		public bool M_Typ_res_8_BST2 { get; set; }// M    2140.7
		public bool M_Typ_res_9_BST2 { get; set; }// M    2141.0
		public bool M_Typ_res_10_BST2 { get; set; }// M    2141.1
		public bool M_Typ_res_11_BST2 { get; set; }// M    2141.2
		public bool M_Typ_res_12_BST2 { get; set; }// M    2141.3
		public bool M_Typ_res_13_BST2 { get; set; }// M    2141.4
		public bool M_Typ_res_14_BST2 { get; set; }// M    2141.5
		public bool M_Typ_res_15_BST2 { get; set; }// M    2141.6
		public bool M_Typ_res_16_BST2 { get; set; }// M    2141.7
		public bool M_Typ_res_17_BST2 { get; set; }// M    2142.0
		public bool M_Typ_res_18_BST2 { get; set; }// M    2142.1
		public bool M_Typ_res_19_BST2 { get; set; }// M    2142.2
		public bool M_Typ_res_20_BST2 { get; set; }// M    2142.3
		public bool M_Typ_res_21_BST2 { get; set; }// M    2142.4
		public bool M_Typ_res_22_BST2 { get; set; }// M    2142.5
		public bool M_Typ_res_23_BST2 { get; set; }// M    2142.6
		public bool M_Typ_res_24_BST2 { get; set; }// M    2142.7
		public bool M_Typ_res_25_BST2 { get; set; }// M    2143.0
		public bool M_Typ_res_26_BST2 { get; set; }// M    2143.1
		public bool M_Typ_res_27_BST2 { get; set; }// M    2143.2
		public bool M_Typ_res_28_BST2 { get; set; }// M    2143.3
		public bool M_Typ_res_29_BST2 { get; set; }// M    2143.4
		public bool M_Typ_res_30_BST2 { get; set; }// M    2143.5
		public bool M_Typ_res_31_BST2 { get; set; }// M    2143.6
		public bool M_Typ_00_BSt2 { get; set; }// M    2143.7

        [MappingOffset(2150,0)]
		public bool M_Mld_Abwahl_BST2 { get; set; }// M    2150.0
		public bool M_Mld_Bearb_NIO_BST2 { get; set; }// M    2150.1
		public bool M_Mld_Schraub_NIO_BST2 { get; set; }// M    2150.2
		public bool M_Mld_res1_BST2 { get; set; }// M    2150.3
		public bool M_Mld_res2_BST2 { get; set; }// M    2150.4
		public bool M_Mld_res3_BST2 { get; set; }// M    2150.5
		public bool M_Mld_res4_BST2 { get; set; }// M    2150.6
		public bool M_Mld_letzte_ST_NIO_BST2 { get; set; }// M    2150.7

        [MappingOffset(2151,1)]
		public bool M_Mld_res7_BST2 { get; set; }// M    2151.1
		public bool M_Mld_res8_BST2 { get; set; }// M    2151.2
		public bool M_Mld_res9_BST2 { get; set; }// M    2151.3
		public bool M_Mld_res10_BST2 { get; set; }// M    2151.4
		public bool M_Mld_res11_BST2 { get; set; }// M    2151.5
		public bool M_Mld_res12_BST2 { get; set; }// M    2151.6
		public bool M_Mld_res13_BST2 { get; set; }// M    2151.7

        [MappingOffset(2160,0)]
		public bool M_Stoer_Ziel_ung_BST2 { get; set; }// M    2160.0
		public bool M_Stoer_UNIV_ung_BST2 { get; set; }// M    2160.1

        [MappingOffset(2160,3)]
		public bool M_Stoer_res4_BST2 { get; set; }// M    2160.3
		public bool M_Stoer_res5_BST2 { get; set; }// M    2160.4
		public bool M_Stoer_Stat_name_BST2 { get; set; }// M    2160.5
		public bool M_Stoer_ung__Mapro_BST2 { get; set; }// M    2160.6
		public bool M_Stoer_ung_Zielvor_BST2 { get; set; }// M    2160.7

        [MappingOffset(2300,0)]
		public bool M_Sammelstoer_PGS_BST2 { get; set; }// M    2300.0
		public bool M_Sammelmeld_PGS_BST2 { get; set; }// M    2300.1

        [MappingOffset(2600,0)]
		public bool M_Fertig_Regal_ges_BST2 { get; set; }// M    2600.0
		public bool M_Abwahl_Regal_BST2 { get; set; }// M    2600.1

        [MappingOffset(2610,0)]
		public bool M_Fertig_Pistol_ges_BST2 { get; set; }// M    2610.0
		public bool M_Abwahl_Pistole_BST2 { get; set; }// M    2610.1

        [MappingOffset(2612,0)]
		public bool M_Fertig_FIXScanner_BST2 { get; set; }// M    2612.0
		public bool M_Abwahl_FixScanner_BST2 { get; set; }// M    2612.1

        [MappingOffset(2613,0)]
		public bool M_Start_Fixscanner1_BST2 { get; set; }// M    2613.0

        [MappingOffset(2613,2)]
		public bool M_Start_Fixscanner2_BST2 { get; set; }// M    2613.2

        [MappingOffset(2613,4)]
		public bool M_Start_Fixscanner3_BST2 { get; set; }// M    2613.4

        [MappingOffset(2614,0)]
		public bool M_Lesefehl_FIXSCAN1_BST2 { get; set; }// M    2614.0
		public bool M_Lesefehl_FIXSCAN2_BST2 { get; set; }// M    2614.1
		public bool M_Lesefehl_FIXSCAN3_BST2 { get; set; }// M    2614.2

        [MappingOffset(2620,0)]
		public bool M_Fertig_Boxen_ges_BST2 { get; set; }// M    2620.0
		public bool M_Abwahl_Boxen_BST2 { get; set; }// M    2620.1

        [MappingOffset(2628,0)]
		public bool M_Fertig_Merkm_ges_BST2 { get; set; }// M    2628.0
		public bool M_Abwahl_Merkm_BST2 { get; set; }// M    2628.1

        [MappingOffset(2630,0)]
		public bool M_Fertig_Geraet_ges_BST2 { get; set; }// M    2630.0
		public bool M_Abwahl_Gerät_BST2 { get; set; }// M    2630.1
		public bool M_Gerät_Frg_Einlauf_BST2 { get; set; }// M    2630.2
		public bool M_Fertig_Geraet_ges_VST2 { get; set; }// M    2630.3
		public bool M_Abwahl_Gerät_VST2 { get; set; }// M    2630.4

        [MappingOffset(2640,0)]
		public bool M_Fertig_PGS_ges_BST2 { get; set; }// M    2640.0
		public bool M_Abwahl_PGS_BST2 { get; set; }// M    2640.1

        [MappingOffset(2647,0)]
		public bool M_Virt_Hap_fertig_BST2 { get; set; }// M    2647.0

        [MappingOffset(2650,0)]
		public bool M_Fertig_Fedok_BST2 { get; set; }// M    2650.0

        [MappingOffset(2653,0)]
		public bool M_Fertig_Chaku_BST2 { get; set; }// M    2653.0

        [MappingOffset(2999,0)]
		public bool M_Fertig_Sonderfkt_BST2 { get; set; }// M    2999.0
		public bool M_Frg_St_Sondfkt_BST2 { get; set; }// M    2999.1
		public bool M_Stoer_Sondfkt_BST2 { get; set; }// M    2999.2

        [MappingOffset(3100,0)]
		public bool M_Dat_vorh_ST_BST3 { get; set; }// M    3100.0
		public bool M_WT_mit_Bearb_BST3 { get; set; }// M    3100.1
		public bool M_WT_ohne_Bearb_BST3 { get; set; }// M    3100.2
		public bool M_WT_and_ziel_BST3 { get; set; }// M    3100.3
		public bool M_Frg_Dat_schreib_BST3 { get; set; }// M    3100.4
		public bool M_Standby_Ziel_ST_BST3 { get; set; }// M    3100.5
		public bool M_Leer_WT_St_BST3 { get; set; }// M    3100.6
		public bool M_Stat_fuer_WT_abgw_BST3 { get; set; }// M    3100.7
		public bool M_St_by_Ziel_vorgew_BST3 { get; set; }// M    3101.0
		public bool M_Somo_BST3 { get; set; }// M    3101.1
		public bool M_StandBy_info_BST3 { get; set; }// M    3101.2
		public bool M_Irrläufer_BST3 { get; set; }// M    3101.3
		public bool M_Prio_1_BST3 { get; set; }// M    3101.4

        [MappingOffset(3101,7)]
		public bool M_Lampentest_BST3 { get; set; }// M    3101.7

        [MappingOffset(3110,0)]
		public bool M_Dat_vorh_VS_BST3 { get; set; }// M    3110.0
		public bool M_WT_mit_Bearb_VS_BST3 { get; set; }// M    3110.1
		public bool M_WT_ohne_Bearb_VS_BST3 { get; set; }// M    3110.2
		public bool M_WT_and_ziel_VS_BST3 { get; set; }// M    3110.3
		public bool M_Frg_schreib_VS_BST3 { get; set; }// M    3110.4
		public bool M_Standby_Ziel_VS_BST3 { get; set; }// M    3110.5
		public bool M_Leer_WT_VS_BST3 { get; set; }// M    3110.6
		public bool M_Prio_1_VS_BST3 { get; set; }// M    3110.7

        [MappingOffset(3115,1)]
		public bool M_bearbeitung_NIO_BST3 { get; set; }// M    3115.1

        [MappingOffset(3117,0)]
		public bool M_Vorw_SST_loesen_BST3 { get; set; }// M    3117.0

        [MappingOffset(3120,0)]
		public bool M_WT_Vorhanden_BST3 { get; set; }// M    3120.0

        [MappingOffset(3120,4)]
		public bool M_Erg_ausgewertet_BST3 { get; set; }// M    3120.4
		public bool M_frg_Typ_einst_BST3 { get; set; }// M    3120.5
		public bool M_WT_Freig_ausfahrt_BST3 { get; set; }// M    3120.6
		public bool M_WT_bearbeitet_BST3 { get; set; }// M    3120.7
		public bool M_Fertigmeld_ges_BST3 { get; set; }// M    3121.0

        [MappingOffset(3121,5)]
		public bool M_Frg_Taster_Lampe_BSt3 { get; set; }// M    3121.5
		public bool M_Frg_Taster2_gedr_BST3 { get; set; }// M    3121.6
		public bool M_Frg_Taster_gedr_BST3 { get; set; }// M    3121.7

        [MappingOffset(3140,0)]
		public bool M_Typ_4_zyl_BST3 { get; set; }// M    3140.0
		public bool M_Typ_6_zyl_BST3 { get; set; }// M    3140.1
		public bool M_Typ_res_3_BST3 { get; set; }// M    3140.2
		public bool M_Typ_res_4_BST3 { get; set; }// M    3140.3
		public bool M_Typ_res_5_BST3 { get; set; }// M    3140.4
		public bool M_Typ_res_6_BST3 { get; set; }// M    3140.5
		public bool M_Typ_res_7_BST3 { get; set; }// M    3140.6
		public bool M_Typ_res_8_BST3 { get; set; }// M    3140.7
		public bool M_Typ_res_9_BST3 { get; set; }// M    3141.0
		public bool M_Typ_res_10_BST3 { get; set; }// M    3141.1
		public bool M_Typ_res_11_BST3 { get; set; }// M    3141.2
		public bool M_Typ_res_12_BST3 { get; set; }// M    3141.3
		public bool M_Typ_res_13_BST3 { get; set; }// M    3141.4
		public bool M_Typ_res_14_BST3 { get; set; }// M    3141.5
		public bool M_Typ_res_15_BST3 { get; set; }// M    3141.6
		public bool M_Typ_res_16_BST3 { get; set; }// M    3141.7
		public bool M_Typ_res_17_BST3 { get; set; }// M    3142.0
		public bool M_Typ_res_18_BST3 { get; set; }// M    3142.1
		public bool M_Typ_res_19_BST3 { get; set; }// M    3142.2
		public bool M_Typ_res_20_BST3 { get; set; }// M    3142.3
		public bool M_Typ_res_21_BST3 { get; set; }// M    3142.4
		public bool M_Typ_res_22_BST3 { get; set; }// M    3142.5
		public bool M_Typ_res_23_BST3 { get; set; }// M    3142.6
		public bool M_Typ_res_24_BST3 { get; set; }// M    3142.7
		public bool M_Typ_res_25_BST3 { get; set; }// M    3143.0
		public bool M_Typ_res_26_BST3 { get; set; }// M    3143.1
		public bool M_Typ_res_27_BST3 { get; set; }// M    3143.2
		public bool M_Typ_res_28_BST3 { get; set; }// M    3143.3
		public bool M_Typ_res_29_BST3 { get; set; }// M    3143.4
		public bool M_Typ_res_30_BST3 { get; set; }// M    3143.5
		public bool M_Typ_res_31_BST3 { get; set; }// M    3143.6
		public bool M_Typ_00_BSt3 { get; set; }// M    3143.7

        [MappingOffset(3150,0)]
		public bool M_Mld_Abwahl_BST3 { get; set; }// M    3150.0
		public bool M_Mld_Bearb_NIO_BST3 { get; set; }// M    3150.1
		public bool M_Mld_Schraub_NIO_BST3 { get; set; }// M    3150.2
		public bool M_Mld_res1_BST3 { get; set; }// M    3150.3
		public bool M_Mld_res2_BST3 { get; set; }// M    3150.4
		public bool M_Mld_res3_BST3 { get; set; }// M    3150.5
		public bool M_Mld_res4_BST3 { get; set; }// M    3150.6
		public bool M_Mld_letzte_ST_NIO_BST3 { get; set; }// M    3150.7

        [MappingOffset(3151,1)]
		public bool M_Mld_res7_BST3 { get; set; }// M    3151.1
		public bool M_Mld_res8_BST3 { get; set; }// M    3151.2
		public bool M_Mld_res9_BST3 { get; set; }// M    3151.3
		public bool M_Mld_res10_BST3 { get; set; }// M    3151.4
		public bool M_Mld_res11_BST3 { get; set; }// M    3151.5
		public bool M_Mld_res12_BST3 { get; set; }// M    3151.6
		public bool M_Mld_res13_BST3 { get; set; }// M    3151.7

        [MappingOffset(3160,0)]
		public bool M_Stoer_Ziel_ung_BST3 { get; set; }// M    3160.0
		public bool M_Stoer_UNIV_ung_BST3 { get; set; }// M    3160.1

        [MappingOffset(3160,3)]
		public bool M_Stoer_res4_BST3 { get; set; }// M    3160.3
		public bool M_Stoer_res5_BST3 { get; set; }// M    3160.4
		public bool M_Stoer_Stat_name_BST3 { get; set; }// M    3160.5
		public bool M_Stoer_ung__Mapro_BST3 { get; set; }// M    3160.6
		public bool M_Stoer_ung_Zielvor_BST3 { get; set; }// M    3160.7

        [MappingOffset(3300,0)]
		public bool M_Sammelstoer_PGS_BST3 { get; set; }// M    3300.0
		public bool M_Sammelmeld_PGS_BST3 { get; set; }// M    3300.1

        [MappingOffset(3600,0)]
		public bool M_Fertig_Regal_ges_BST3 { get; set; }// M    3600.0
		public bool M_Abwahl_Regal_BST3 { get; set; }// M    3600.1

        [MappingOffset(3610,0)]
		public bool M_Fertig_Pistol_ges_BST3 { get; set; }// M    3610.0
		public bool M_Abwahl_Pistole_BST3 { get; set; }// M    3610.1

        [MappingOffset(3612,0)]
		public bool M_Fertig_FIXScanner_BST3 { get; set; }// M    3612.0
		public bool M_Abwahl_FixScanner_BST3 { get; set; }// M    3612.1

        [MappingOffset(3613,0)]
		public bool M_Start_Fixscanner1_BST3 { get; set; }// M    3613.0

        [MappingOffset(3613,2)]
		public bool M_Start_Fixscanner2_BST3 { get; set; }// M    3613.2

        [MappingOffset(3613,4)]
		public bool M_Start_Fixscanner3_BST3 { get; set; }// M    3613.4

        [MappingOffset(3614,0)]
		public bool M_Lesefehl_FIXSCAN1_BST3 { get; set; }// M    3614.0
		public bool M_Lesefehl_FIXSCAN2_BST3 { get; set; }// M    3614.1
		public bool M_Lesefehl_FIXSCAN3_BST3 { get; set; }// M    3614.2

        [MappingOffset(3620,0)]
		public bool M_Fertig_Boxen_ges_BST3 { get; set; }// M    3620.0
		public bool M_Abwahl_Boxen_BST3 { get; set; }// M    3620.1

        [MappingOffset(3628,0)]
		public bool M_Fertig_Merkm_ges_BST3 { get; set; }// M    3628.0
		public bool M_Abwahl_Merkm_BST3 { get; set; }// M    3628.1

        [MappingOffset(3630,0)]
		public bool M_Fertig_Geraet_ges_BST3 { get; set; }// M    3630.0
		public bool M_Abwahl_Gerät_BST3 { get; set; }// M    3630.1
		public bool M_Gerät_Frg_Einlauf_BST3 { get; set; }// M    3630.2
		public bool M_Fertig_Geraet_ges_VST3 { get; set; }// M    3630.3
		public bool M_Abwahl_Gerät_VST3 { get; set; }// M    3630.4

        [MappingOffset(3640,0)]
		public bool M_Fertig_PGS_ges_BST3 { get; set; }// M    3640.0
		public bool M_Abwahl_PGS_BST3 { get; set; }// M    3640.1

        [MappingOffset(3647,0)]
		public bool M_Virt_Hap_fertig_BST3 { get; set; }// M    3647.0

        [MappingOffset(3650,0)]
		public bool M_Fertig_Fedok_BST3 { get; set; }// M    3650.0

        [MappingOffset(3653,0)]
		public bool M_Fertig_Chaku_BST3 { get; set; }// M    3653.0

        [MappingOffset(3999,0)]
		public bool M_Fertig_Sonderfkt_BST3 { get; set; }// M    3999.0
		public bool M_Frg_St_Sondfkt_BST3 { get; set; }// M    3999.1
		public bool M_Stoer_Sondfkt_BST3 { get; set; }// M    3999.2

        [MappingOffset(4100,0)]
		public bool M_Dat_vorh_ST_BST4 { get; set; }// M    4100.0
		public bool M_WT_mit_Bearb_BST4 { get; set; }// M    4100.1
		public bool M_WT_ohne_Bearb_BST4 { get; set; }// M    4100.2
		public bool M_WT_and_ziel_BST4 { get; set; }// M    4100.3
		public bool M_Frg_Dat_schreib_BST4 { get; set; }// M    4100.4
		public bool M_Standby_Ziel_ST_BST4 { get; set; }// M    4100.5
		public bool M_Leer_WT_St_BST4 { get; set; }// M    4100.6
		public bool M_Stat_fuer_WT_abgw_BST4 { get; set; }// M    4100.7
		public bool M_St_by_Ziel_vorgew_BST4 { get; set; }// M    4101.0
		public bool M_Somo_BST4 { get; set; }// M    4101.1
		public bool M_StandBy_info_BST4 { get; set; }// M    4101.2
		public bool M_Irrläufer_BST4 { get; set; }// M    4101.3
		public bool M_Prio_1_BST4 { get; set; }// M    4101.4

        [MappingOffset(4101,7)]
		public bool M_Lampentest_BST4 { get; set; }// M    4101.7

        [MappingOffset(4110,0)]
		public bool M_Dat_vorh_VS_BST4 { get; set; }// M    4110.0
		public bool M_WT_mit_Bearb_VS_BST4 { get; set; }// M    4110.1
		public bool M_WT_ohne_Bearb_VS_BST4 { get; set; }// M    4110.2
		public bool M_WT_and_ziel_VS_BST4 { get; set; }// M    4110.3
		public bool M_Frg_schreib_VS_BST4 { get; set; }// M    4110.4
		public bool M_Standby_Ziel_VS_BST4 { get; set; }// M    4110.5
		public bool M_Leer_WT_VS_BST4 { get; set; }// M    4110.6
		public bool M_Prio_1_VS_BST4 { get; set; }// M    4110.7

        [MappingOffset(4115,1)]
		public bool M_bearbeitung_NIO_BST4 { get; set; }// M    4115.1

        [MappingOffset(4117,0)]
		public bool M_Vorw_SST_loesen_BST4 { get; set; }// M    4117.0

        [MappingOffset(4120,0)]
		public bool M_WT_Vorhanden_BST4 { get; set; }// M    4120.0

        [MappingOffset(4120,4)]
		public bool M_Erg_ausgewertet_BST4 { get; set; }// M    4120.4
		public bool M_frg_Typ_einst_BST4 { get; set; }// M    4120.5
		public bool M_WT_Freig_ausfahrt_BST4 { get; set; }// M    4120.6
		public bool M_WT_bearbeitet_BST4 { get; set; }// M    4120.7
		public bool M_Fertigmeld_ges_BST4 { get; set; }// M    4121.0

        [MappingOffset(4121,5)]
		public bool M_Frg_Taster_Lampe_BSt4 { get; set; }// M    4121.5
		public bool M_Frg_Taster2_gedr_BST4 { get; set; }// M    4121.6
		public bool M_Frg_Taster_gedr_BST4 { get; set; }// M    4121.7

        [MappingOffset(4140,0)]
		public bool M_Typ_4_zyl_BST4 { get; set; }// M    4140.0
		public bool M_Typ_6_zyl_BST4 { get; set; }// M    4140.1
		public bool M_Typ_res_3_BST4 { get; set; }// M    4140.2
		public bool M_Typ_res_4_BST4 { get; set; }// M    4140.3
		public bool M_Typ_res_5_BST4 { get; set; }// M    4140.4
		public bool M_Typ_res_6_BST4 { get; set; }// M    4140.5
		public bool M_Typ_res_7_BST4 { get; set; }// M    4140.6
		public bool M_Typ_res_8_BST4 { get; set; }// M    4140.7
		public bool M_Typ_res_9_BST4 { get; set; }// M    4141.0
		public bool M_Typ_res_10_BST4 { get; set; }// M    4141.1
		public bool M_Typ_res_11_BST4 { get; set; }// M    4141.2
		public bool M_Typ_res_12_BST4 { get; set; }// M    4141.3
		public bool M_Typ_res_13_BST4 { get; set; }// M    4141.4
		public bool M_Typ_res_14_BST4 { get; set; }// M    4141.5
		public bool M_Typ_res_15_BST4 { get; set; }// M    4141.6
		public bool M_Typ_res_16_BST4 { get; set; }// M    4141.7
		public bool M_Typ_res_17_BST4 { get; set; }// M    4142.0
		public bool M_Typ_res_18_BST4 { get; set; }// M    4142.1
		public bool M_Typ_res_19_BST4 { get; set; }// M    4142.2
		public bool M_Typ_res_20_BST4 { get; set; }// M    4142.3
		public bool M_Typ_res_21_BST4 { get; set; }// M    4142.4
		public bool M_Typ_res_22_BST4 { get; set; }// M    4142.5
		public bool M_Typ_res_23_BST4 { get; set; }// M    4142.6
		public bool M_Typ_res_24_BST4 { get; set; }// M    4142.7
		public bool M_Typ_res_25_BST4 { get; set; }// M    4143.0
		public bool M_Typ_res_26_BST4 { get; set; }// M    4143.1
		public bool M_Typ_res_27_BST4 { get; set; }// M    4143.2
		public bool M_Typ_res_28_BST4 { get; set; }// M    4143.3
		public bool M_Typ_res_29_BST4 { get; set; }// M    4143.4
		public bool M_Typ_res_30_BST4 { get; set; }// M    4143.5
		public bool M_Typ_res_31_BST4 { get; set; }// M    4143.6
		public bool M_Typ_00_BSt4 { get; set; }// M    4143.7

        [MappingOffset(4150,0)]
		public bool M_Mld_Abwahl_BST4 { get; set; }// M    4150.0
		public bool M_Mld_Bearb_NIO_BST4 { get; set; }// M    4150.1
		public bool M_Mld_Schraub_NIO_BST4 { get; set; }// M    4150.2
		public bool M_Mld_res1_BST4 { get; set; }// M    4150.3
		public bool M_Mld_res2_BST4 { get; set; }// M    4150.4
		public bool M_Mld_res3_BST4 { get; set; }// M    4150.5
		public bool M_Mld_res4_BST4 { get; set; }// M    4150.6
		public bool M_Mld_letzte_ST_NIO_BST4 { get; set; }// M    4150.7

        [MappingOffset(4151,1)]
		public bool M_Mld_res7_BST4 { get; set; }// M    4151.1
		public bool M_Mld_res8_BST4 { get; set; }// M    4151.2
		public bool M_Mld_res9_BST4 { get; set; }// M    4151.3
		public bool M_Mld_res10_BST4 { get; set; }// M    4151.4
		public bool M_Mld_res11_BST4 { get; set; }// M    4151.5
		public bool M_Mld_res12_BST4 { get; set; }// M    4151.6
		public bool M_Mld_res13_BST4 { get; set; }// M    4151.7

        [MappingOffset(4160,0)]
		public bool M_Stoer_Ziel_ung_BST4 { get; set; }// M    4160.0
		public bool M_Stoer_UNIV_ung_BST4 { get; set; }// M    4160.1

        [MappingOffset(4160,3)]
		public bool M_Stoer_res4_BST4 { get; set; }// M    4160.3
		public bool M_Stoer_res5_BST4 { get; set; }// M    4160.4
		public bool M_Stoer_Stat_name_BST4 { get; set; }// M    4160.5
		public bool M_Stoer_ung__Mapro_BST4 { get; set; }// M    4160.6
		public bool M_Stoer_ung_Zielvor_BST4 { get; set; }// M    4160.7

        [MappingOffset(4300,0)]
		public bool M_Sammelstoer_PGS_BST4 { get; set; }// M    4300.0
		public bool M_Sammelmeld_PGS_BST4 { get; set; }// M    4300.1

        [MappingOffset(4600,0)]
		public bool M_Fertig_Regal_ges_BST4 { get; set; }// M    4600.0
		public bool M_Abwahl_Regal_BST4 { get; set; }// M    4600.1

        [MappingOffset(4610,0)]
		public bool M_Fertig_Pistol_ges_BST4 { get; set; }// M    4610.0
		public bool M_Abwahl_Pistole_BST4 { get; set; }// M    4610.1

        [MappingOffset(4612,0)]
		public bool M_Fertig_FIXScanner_BST4 { get; set; }// M    4612.0
		public bool M_Abwahl_FixScanner_BST4 { get; set; }// M    4612.1

        [MappingOffset(4613,0)]
		public bool M_Start_Fixscanner1_BST4 { get; set; }// M    4613.0

        [MappingOffset(4613,2)]
		public bool M_Start_Fixscanner2_BST4 { get; set; }// M    4613.2

        [MappingOffset(4613,4)]
		public bool M_Start_Fixscanner3_BST4 { get; set; }// M    4613.4

        [MappingOffset(4614,0)]
		public bool M_Lesefehl_FIXSCAN1_BST4 { get; set; }// M    4614.0
		public bool M_Lesefehl_FIXSCAN2_BST4 { get; set; }// M    4614.1
		public bool M_Lesefehl_FIXSCAN3_BST4 { get; set; }// M    4614.2

        [MappingOffset(4620,0)]
		public bool M_Fertig_Boxen_ges_BST4 { get; set; }// M    4620.0
		public bool M_Abwahl_Boxen_BST4 { get; set; }// M    4620.1

        [MappingOffset(4628,0)]
		public bool M_Fertig_Merkm_ges_BST4 { get; set; }// M    4628.0
		public bool M_Abwahl_Merkm_BST4 { get; set; }// M    4628.1

        [MappingOffset(4630,0)]
		public bool M_Fertig_Geraet_ges_BST4 { get; set; }// M    4630.0
		public bool M_Abwahl_Gerät_BST4 { get; set; }// M    4630.1
		public bool M_Gerät_Frg_Einlauf_BST4 { get; set; }// M    4630.2
		public bool M_Fertig_Geraet_ges_VST4 { get; set; }// M    4630.3
		public bool M_Abwahl_Gerät_VST4 { get; set; }// M    4630.4

        [MappingOffset(4640,0)]
		public bool M_Fertig_PGS_ges_BST4 { get; set; }// M    4640.0
		public bool M_Abwahl_PGS_BST4 { get; set; }// M    4640.1

        [MappingOffset(4647,0)]
		public bool M_Virt_Hap_fertig_BST4 { get; set; }// M    4647.0

        [MappingOffset(4650,0)]
		public bool M_Fertig_Fedok_BST4 { get; set; }// M    4650.0

        [MappingOffset(4653,0)]
		public bool M_Fertig_Chaku_BST4 { get; set; }// M    4653.0

        [MappingOffset(4999,0)]
		public bool M_Fertig_Sonderfkt_BST4 { get; set; }// M    4999.0
		public bool M_Frg_St_Sondfkt_BST4 { get; set; }// M    4999.1
		public bool M_Stoer_Sondfkt_BST4 { get; set; }// M    4999.2

        [MappingOffset(5100,0)]
		public bool M_Dat_vorh_ST_BST5 { get; set; }// M    5100.0
		public bool M_WT_mit_Bearb_BST5 { get; set; }// M    5100.1
		public bool M_WT_ohne_Bearb_BST5 { get; set; }// M    5100.2
		public bool M_WT_and_ziel_BST5 { get; set; }// M    5100.3
		public bool M_Frg_Dat_schreib_BST5 { get; set; }// M    5100.4
		public bool M_Standby_Ziel_ST_BST5 { get; set; }// M    5100.5
		public bool M_Leer_WT_St_BST5 { get; set; }// M    5100.6
		public bool M_Stat_fuer_WT_abgw_BST5 { get; set; }// M    5100.7
		public bool M_St_by_Ziel_vorgew_BST5 { get; set; }// M    5101.0
		public bool M_Somo_BST5 { get; set; }// M    5101.1
		public bool M_StandBy_info_BST5 { get; set; }// M    5101.2
		public bool M_Irrläufer_BST5 { get; set; }// M    5101.3
		public bool M_Prio_1_BST5 { get; set; }// M    5101.4

        [MappingOffset(5101,7)]
		public bool M_Lampentest_BST5 { get; set; }// M    5101.7

        [MappingOffset(5110,0)]
		public bool M_Dat_vorh_VS_BST5 { get; set; }// M    5110.0
		public bool M_WT_mit_Bearb_VS_BST5 { get; set; }// M    5110.1
		public bool M_WT_ohne_Bearb_VS_BST5 { get; set; }// M    5110.2
		public bool M_WT_and_ziel_VS_BST5 { get; set; }// M    5110.3
		public bool M_Frg_schreib_VS_BST5 { get; set; }// M    5110.4
		public bool M_Standby_Ziel_VS_BST5 { get; set; }// M    5110.5
		public bool M_Leer_WT_VS_BST5 { get; set; }// M    5110.6
		public bool M_Prio_1_VS_BST5 { get; set; }// M    5110.7

        [MappingOffset(5115,1)]
		public bool M_bearbeitung_NIO_BST5 { get; set; }// M    5115.1

        [MappingOffset(5117,0)]
		public bool M_Vorw_SST_loesen_BST5 { get; set; }// M    5117.0

        [MappingOffset(5120,0)]
		public bool M_WT_Vorhanden_BST5 { get; set; }// M    5120.0

        [MappingOffset(5120,4)]
		public bool M_Erg_ausgewertet_BST5 { get; set; }// M    5120.4
		public bool M_frg_Typ_einst_BST5 { get; set; }// M    5120.5
		public bool M_WT_Freig_ausfahrt_BST5 { get; set; }// M    5120.6
		public bool M_WT_bearbeitet_BST5 { get; set; }// M    5120.7
		public bool M_Fertigmeld_ges_BST5 { get; set; }// M    5121.0

        [MappingOffset(5121,5)]
		public bool M_Frg_Taster_Lampe_BSt5 { get; set; }// M    5121.5
		public bool M_Frg_Taster2_gedr_BST5 { get; set; }// M    5121.6
		public bool M_Frg_Taster_gedr_BST5 { get; set; }// M    5121.7

        [MappingOffset(5140,0)]
		public bool M_Typ_4_zyl_BST5 { get; set; }// M    5140.0
		public bool M_Typ_6_zyl_BST5 { get; set; }// M    5140.1
		public bool M_Typ_res_3_BST5 { get; set; }// M    5140.2
		public bool M_Typ_res_4_BST5 { get; set; }// M    5140.3
		public bool M_Typ_res_5_BST5 { get; set; }// M    5140.4
		public bool M_Typ_res_6_BST5 { get; set; }// M    5140.5
		public bool M_Typ_res_7_BST5 { get; set; }// M    5140.6
		public bool M_Typ_res_8_BST5 { get; set; }// M    5140.7
		public bool M_Typ_res_9_BST5 { get; set; }// M    5141.0
		public bool M_Typ_res_10_BST5 { get; set; }// M    5141.1
		public bool M_Typ_res_11_BST5 { get; set; }// M    5141.2
		public bool M_Typ_res_12_BST5 { get; set; }// M    5141.3
		public bool M_Typ_res_13_BST5 { get; set; }// M    5141.4
		public bool M_Typ_res_14_BST5 { get; set; }// M    5141.5
		public bool M_Typ_res_15_BST5 { get; set; }// M    5141.6
		public bool M_Typ_res_16_BST5 { get; set; }// M    5141.7
		public bool M_Typ_res_17_BST5 { get; set; }// M    5142.0
		public bool M_Typ_res_18_BST5 { get; set; }// M    5142.1
		public bool M_Typ_res_19_BST5 { get; set; }// M    5142.2
		public bool M_Typ_res_20_BST5 { get; set; }// M    5142.3
		public bool M_Typ_res_21_BST5 { get; set; }// M    5142.4
		public bool M_Typ_res_22_BST5 { get; set; }// M    5142.5
		public bool M_Typ_res_23_BST5 { get; set; }// M    5142.6
		public bool M_Typ_res_24_BST5 { get; set; }// M    5142.7
		public bool M_Typ_res_25_BST5 { get; set; }// M    5143.0
		public bool M_Typ_res_26_BST5 { get; set; }// M    5143.1
		public bool M_Typ_res_27_BST5 { get; set; }// M    5143.2
		public bool M_Typ_res_28_BST5 { get; set; }// M    5143.3
		public bool M_Typ_res_29_BST5 { get; set; }// M    5143.4
		public bool M_Typ_res_30_BST5 { get; set; }// M    5143.5
		public bool M_Typ_res_31_BST5 { get; set; }// M    5143.6
		public bool M_Typ_00_BST5 { get; set; }// M    5143.7

        [MappingOffset(5150,0)]
		public bool M_Mld_Abwahl_BST5 { get; set; }// M    5150.0
		public bool M_Mld_Bearb_NIO_BST5 { get; set; }// M    5150.1
		public bool M_Mld_Schraub_NIO_BST5 { get; set; }// M    5150.2
		public bool M_Mld_res1_BST5 { get; set; }// M    5150.3
		public bool M_Mld_res2_BST5 { get; set; }// M    5150.4
		public bool M_Mld_res3_BST5 { get; set; }// M    5150.5
		public bool M_Mld_res4_BST5 { get; set; }// M    5150.6
		public bool M_Mld_letzte_ST_NIO_BST5 { get; set; }// M    5150.7

        [MappingOffset(5151,1)]
		public bool M_Mld_res7_BST5 { get; set; }// M    5151.1
		public bool M_Mld_res8_BST5 { get; set; }// M    5151.2
		public bool M_Mld_res9_BST5 { get; set; }// M    5151.3
		public bool M_Mld_res10_BST5 { get; set; }// M    5151.4
		public bool M_Mld_res11_BST5 { get; set; }// M    5151.5
		public bool M_Mld_res12_BST5 { get; set; }// M    5151.6
		public bool M_Mld_res13_BST5 { get; set; }// M    5151.7

        [MappingOffset(5160,0)]
		public bool M_Stoer_Ziel_ung_BST5 { get; set; }// M    5160.0
		public bool M_Stoer_UNIV_ung_BST5 { get; set; }// M    5160.1

        [MappingOffset(5160,3)]
		public bool M_Stoer_res4_BST5 { get; set; }// M    5160.3
		public bool M_Stoer_res5_BST5 { get; set; }// M    5160.4
		public bool M_Stoer_Stat_name_BST5 { get; set; }// M    5160.5
		public bool M_Stoer_ung__Mapro_BST5 { get; set; }// M    5160.6
		public bool M_Stoer_ung_Zielvor_BST5 { get; set; }// M    5160.7

        [MappingOffset(5300,0)]
		public bool M_Sammelstoer_PGS_BST5 { get; set; }// M    5300.0
		public bool M_Sammelmeld_PGS_BST5 { get; set; }// M    5300.1

        [MappingOffset(5600,0)]
		public bool M_Fertig_Regal_ges_BST5 { get; set; }// M    5600.0
		public bool M_Abwahl_Regal_BST5 { get; set; }// M    5600.1

        [MappingOffset(5610,0)]
		public bool M_Fertig_Pistol_ges_BST5 { get; set; }// M    5610.0
		public bool M_Abwahl_Pistole_BST5 { get; set; }// M    5610.1

        [MappingOffset(5612,0)]
		public bool M_Fertig_FIXScanner_BST5 { get; set; }// M    5612.0
		public bool M_Abwahl_FixScanner_BST5 { get; set; }// M    5612.1

        [MappingOffset(5613,0)]
		public bool M_Start_Fixscanner1_BST5 { get; set; }// M    5613.0

        [MappingOffset(5613,2)]
		public bool M_Start_Fixscanner2_BST5 { get; set; }// M    5613.2

        [MappingOffset(5613,4)]
		public bool M_Start_Fixscanner3_BST5 { get; set; }// M    5613.4

        [MappingOffset(5614,0)]
		public bool M_Lesefehl_FIXSCAN1_BST5 { get; set; }// M    5614.0
		public bool M_Lesefehl_FIXSCAN2_BST5 { get; set; }// M    5614.1
		public bool M_Lesefehl_FIXSCAN3_BST5 { get; set; }// M    5614.2

        [MappingOffset(5620,0)]
		public bool M_Fertig_Boxen_ges_BST5 { get; set; }// M    5620.0
		public bool M_Abwahl_Boxen_BST5 { get; set; }// M    5620.1

        [MappingOffset(5628,0)]
		public bool M_Fertig_Merkm_ges_BST5 { get; set; }// M    5628.0
		public bool M_Abwahl_Merkm_BST5 { get; set; }// M    5628.1

        [MappingOffset(5630,0)]
		public bool M_Fertig_Geraet_ges_BST5 { get; set; }// M    5630.0
		public bool M_Abwahl_Gerät_BST5 { get; set; }// M    5630.1
		public bool M_Gerät_Frg_Einlauf_BST5 { get; set; }// M    5630.2
		public bool M_Fertig_Geraet_ges_VST5 { get; set; }// M    5630.3
		public bool M_Abwahl_Gerät_VST5 { get; set; }// M    5630.4

        [MappingOffset(5640,0)]
		public bool M_Fertig_PGS_ges_BST5 { get; set; }// M    5640.0
		public bool M_Abwahl_PGS_BST5 { get; set; }// M    5640.1

        [MappingOffset(5647,0)]
		public bool M_Virt_Hap_fertig_BST5 { get; set; }// M    5647.0

        [MappingOffset(5650,0)]
		public bool M_Fertig_Fedok_BST5 { get; set; }// M    5650.0

        [MappingOffset(5653,0)]
		public bool M_Fertig_Chaku_BST5 { get; set; }// M    5653.0

        [MappingOffset(5999,0)]
		public bool M_Fertig_Sonderfkt_BST5 { get; set; }// M    5999.0
		public bool M_Frg_St_Sondfkt_BST5 { get; set; }// M    5999.1
		public bool M_Stoer_Sondfkt_BST5 { get; set; }// M    5999.2

        [MappingOffset(6100,0)]
		public bool M_Dat_vorh_ST_BST6 { get; set; }// M    6100.0
		public bool M_WT_mit_Bearb_BST6 { get; set; }// M    6100.1
		public bool M_WT_ohne_Bearb_BST6 { get; set; }// M    6100.2
		public bool M_WT_and_ziel_BST6 { get; set; }// M    6100.3
		public bool M_Frg_Dat_schreib_BST6 { get; set; }// M    6100.4
		public bool M_Standby_Ziel_ST_BST6 { get; set; }// M    6100.5
		public bool M_Leer_WT_St_BST6 { get; set; }// M    6100.6
		public bool M_Stat_fuer_WT_abgw_BST6 { get; set; }// M    6100.7
		public bool M_St_by_Ziel_vorgew_BST6 { get; set; }// M    6101.0
		public bool M_Somo_BST6 { get; set; }// M    6101.1
		public bool M_StandBy_info_BST6 { get; set; }// M    6101.2
		public bool M_Irrläufer_BST6 { get; set; }// M    6101.3
		public bool M_Prio_1_BST6 { get; set; }// M    6101.4

        [MappingOffset(6101,7)]
		public bool M_Lampentest_BST6 { get; set; }// M    6101.7

        [MappingOffset(6110,0)]
		public bool M_Dat_vorh_VS_BST6 { get; set; }// M    6110.0
		public bool M_WT_mit_Bearb_VS_BST6 { get; set; }// M    6110.1
		public bool M_WT_ohne_Bearb_VS_BST6 { get; set; }// M    6110.2
		public bool M_WT_and_ziel_VS_BST6 { get; set; }// M    6110.3
		public bool M_Frg_schreib_VS_BST6 { get; set; }// M    6110.4
		public bool M_Standby_Ziel_VS_BST6 { get; set; }// M    6110.5
		public bool M_Leer_WT_VS_BST6 { get; set; }// M    6110.6
		public bool M_Prio_1_VS_BST6 { get; set; }// M    6110.7

        [MappingOffset(6115,1)]
		public bool M_bearbeitung_NIO_BST6 { get; set; }// M    6115.1

        [MappingOffset(6117,0)]
		public bool M_Vorw_SST_loesen_BST6 { get; set; }// M    6117.0

        [MappingOffset(6120,0)]
		public bool M_WT_Vorhanden_BST6 { get; set; }// M    6120.0

        [MappingOffset(6120,4)]
		public bool M_Erg_ausgewertet_BST6 { get; set; }// M    6120.4
		public bool M_frg_Typ_einst_BST6 { get; set; }// M    6120.5
		public bool M_WT_Freig_ausfahrt_BST6 { get; set; }// M    6120.6
		public bool M_WT_bearbeitet_BST6 { get; set; }// M    6120.7
		public bool M_Fertigmeld_ges_BST6 { get; set; }// M    6121.0

        [MappingOffset(6121,5)]
		public bool M_Frg_Taster_Lampe_BSt6 { get; set; }// M    6121.5
		public bool M_Frg_Taster2_gedr_BST6 { get; set; }// M    6121.6
		public bool M_Frg_Taster_gedr_BST6 { get; set; }// M    6121.7

        [MappingOffset(6140,0)]
		public bool M_Typ_4_zyl_BST6 { get; set; }// M    6140.0
		public bool M_Typ_6_zyl_BST6 { get; set; }// M    6140.1
		public bool M_Typ_res_3_BST6 { get; set; }// M    6140.2
		public bool M_Typ_res_4_BST6 { get; set; }// M    6140.3
		public bool M_Typ_res_5_BST6 { get; set; }// M    6140.4
		public bool M_Typ_res_6_BST6 { get; set; }// M    6140.5
		public bool M_Typ_res_7_BST6 { get; set; }// M    6140.6
		public bool M_Typ_res_8_BST6 { get; set; }// M    6140.7
		public bool M_Typ_res_9_BST6 { get; set; }// M    6141.0
		public bool M_Typ_res_10_BST6 { get; set; }// M    6141.1
		public bool M_Typ_res_11_BST6 { get; set; }// M    6141.2
		public bool M_Typ_res_12_BST6 { get; set; }// M    6141.3
		public bool M_Typ_res_13_BST6 { get; set; }// M    6141.4
		public bool M_Typ_res_14_BST6 { get; set; }// M    6141.5
		public bool M_Typ_res_15_BST6 { get; set; }// M    6141.6
		public bool M_Typ_res_16_BST6 { get; set; }// M    6141.7
		public bool M_Typ_res_17_BST6 { get; set; }// M    6142.0
		public bool M_Typ_res_18_BST6 { get; set; }// M    6142.1
		public bool M_Typ_res_19_BST6 { get; set; }// M    6142.2
		public bool M_Typ_res_20_BST6 { get; set; }// M    6142.3
		public bool M_Typ_res_21_BST6 { get; set; }// M    6142.4
		public bool M_Typ_res_22_BST6 { get; set; }// M    6142.5
		public bool M_Typ_res_23_BST6 { get; set; }// M    6142.6
		public bool M_Typ_res_24_BST6 { get; set; }// M    6142.7
		public bool M_Typ_res_25_BST6 { get; set; }// M    6143.0
		public bool M_Typ_res_26_BST6 { get; set; }// M    6143.1
		public bool M_Typ_res_27_BST6 { get; set; }// M    6143.2
		public bool M_Typ_res_28_BST6 { get; set; }// M    6143.3
		public bool M_Typ_res_29_BST6 { get; set; }// M    6143.4
		public bool M_Typ_res_30_BST6 { get; set; }// M    6143.5
		public bool M_Typ_res_31_BST6 { get; set; }// M    6143.6
		public bool M_Typ_00_BST6 { get; set; }// M    6143.7

        [MappingOffset(6150,0)]
		public bool M_Mld_Abwahl_BST6 { get; set; }// M    6150.0
		public bool M_Mld_Bearb_NIO_BST6 { get; set; }// M    6150.1
		public bool M_Mld_Schraub_NIO_BST6 { get; set; }// M    6150.2
		public bool M_Mld_res1_BST6 { get; set; }// M    6150.3
		public bool M_Mld_res2_BST6 { get; set; }// M    6150.4
		public bool M_Mld_res3_BST6 { get; set; }// M    6150.5
		public bool M_Mld_res4_BST6 { get; set; }// M    6150.6
		public bool M_Mld_letzte_ST_NIO_BST6 { get; set; }// M    6150.7

        [MappingOffset(6151,1)]
		public bool M_Mld_res7_BST6 { get; set; }// M    6151.1
		public bool M_Mld_res8_BST6 { get; set; }// M    6151.2
		public bool M_Mld_res9_BST6 { get; set; }// M    6151.3
		public bool M_Mld_res10_BST6 { get; set; }// M    6151.4
		public bool M_Mld_res11_BST6 { get; set; }// M    6151.5
		public bool M_Mld_res12_BST6 { get; set; }// M    6151.6
		public bool M_Mld_res13_BST6 { get; set; }// M    6151.7

        [MappingOffset(6160,0)]
		public bool M_Stoer_Ziel_ung_BST6 { get; set; }// M    6160.0
		public bool M_Stoer_UNIV_ung_BST6 { get; set; }// M    6160.1

        [MappingOffset(6160,3)]
		public bool M_Stoer_res4_BST6 { get; set; }// M    6160.3
		public bool M_Stoer_res5_BST6 { get; set; }// M    6160.4
		public bool M_Stoer_Stat_name_BST6 { get; set; }// M    6160.5
		public bool M_Stoer_ung__Mapro_BST6 { get; set; }// M    6160.6
		public bool M_Stoer_ung_Zielvor_BST6 { get; set; }// M    6160.7

        [MappingOffset(6300,0)]
		public bool M_Sammelstoer_PGS_BST6 { get; set; }// M    6300.0
		public bool M_Sammelmeld_PGS_BST6 { get; set; }// M    6300.1

        [MappingOffset(6600,0)]
		public bool M_Fertig_Regal_ges_BST6 { get; set; }// M    6600.0
		public bool M_Abwahl_Regal_BST6 { get; set; }// M    6600.1

        [MappingOffset(6610,0)]
		public bool M_Fertig_Pistol_ges_BST6 { get; set; }// M    6610.0
		public bool M_Abwahl_Pistole_BST6 { get; set; }// M    6610.1

        [MappingOffset(6612,0)]
		public bool M_Fertig_FIXScanner_BST6 { get; set; }// M    6612.0
		public bool M_Abwahl_FixScanner_BST6 { get; set; }// M    6612.1

        [MappingOffset(6613,0)]
		public bool M_Start_Fixscanner1_BST6 { get; set; }// M    6613.0

        [MappingOffset(6613,2)]
		public bool M_Start_Fixscanner2_BST6 { get; set; }// M    6613.2

        [MappingOffset(6613,4)]
		public bool M_Start_Fixscanner3_BST6 { get; set; }// M    6613.4

        [MappingOffset(6614,0)]
		public bool M_Lesefehl_FIXSCAN1_BST6 { get; set; }// M    6614.0
		public bool M_Lesefehl_FIXSCAN2_BST6 { get; set; }// M    6614.1
		public bool M_Lesefehl_FIXSCAN3_BST6 { get; set; }// M    6614.2

        [MappingOffset(6620,0)]
		public bool M_Fertig_Boxen_ges_BST6 { get; set; }// M    6620.0
		public bool M_Abwahl_Boxen_BST6 { get; set; }// M    6620.1

        [MappingOffset(6628,0)]
		public bool M_Fertig_Merkm_ges_BST6 { get; set; }// M    6628.0
		public bool M_Abwahl_Merkm_BST6 { get; set; }// M    6628.1

        [MappingOffset(6630,0)]
		public bool M_Fertig_Geraet_ges_BST6 { get; set; }// M    6630.0
		public bool M_Abwahl_Gerät_BST6 { get; set; }// M    6630.1
		public bool M_Gerät_Frg_Einlauf_BST6 { get; set; }// M    6630.2
		public bool M_Fertig_Geraet_ges_VST6 { get; set; }// M    6630.3
		public bool M_Abwahl_Gerät_VST6 { get; set; }// M    6630.4

        [MappingOffset(6640,0)]
		public bool M_Fertig_PGS_ges_BST6 { get; set; }// M    6640.0
		public bool M_Abwahl_PGS_BST6 { get; set; }// M    6640.1

        [MappingOffset(6647,0)]
		public bool M_Virt_Hap_fertig_BST6 { get; set; }// M    6647.0

        [MappingOffset(6650,0)]
		public bool M_Fertig_Fedok_BST6 { get; set; }// M    6650.0

        [MappingOffset(6653,0)]
		public bool M_Fertig_Chaku_BST6 { get; set; }// M    6653.0

        [MappingOffset(6999,0)]
		public bool M_Fertig_Sonderfkt_BST6 { get; set; }// M    6999.0
		public bool M_Frg_St_Sondfkt_BST6 { get; set; }// M    6999.1
		public bool M_Stoer_Sondfkt_BST6 { get; set; }// M    6999.2
    }

    [Mapping("Timer", "TM", 0)]
    public class Timer
    {
        [MappingOffset(5,-1)]

		[PlcType("S5Time")]public TimeSpan t_HNTE_Zentr_Ein { get; set; }// T       5

		[PlcType("S5Time")]public TimeSpan t_auto_start_Zentr_Ein { get; set; }// T       6

		[PlcType("S5Time")]public TimeSpan T_SE_Anlage_Ein_NIO { get; set; }// T       7

		[PlcType("S5Time")]public TimeSpan T_SE_Anlage_Ein_IO { get; set; }// T       8

		[PlcType("S5Time")]public TimeSpan T_SE_Verz_profinet { get; set; }// T       9

        [MappingOffset(25,-1)]

		[PlcType("S5Time")]public TimeSpan T_SE_USV_NIO { get; set; }// T      25

		[PlcType("S5Time")]public TimeSpan T_SE_Shut_Down { get; set; }// T      26

        [MappingOffset(30,-1)]

		[PlcType("S5Time")]public TimeSpan T_SE_Anlage_Ein { get; set; }// T      30

		[PlcType("S5Time")]public TimeSpan T_SA_Anlage_Ein { get; set; }// T      31

		[PlcType("S5Time")]public TimeSpan T_SE_Zentr_ein { get; set; }// T      32

		[PlcType("S5Time")]public TimeSpan T_SE_HNTE_BST1 { get; set; }// T      33

		[PlcType("S5Time")]public TimeSpan T_SE_HNTE_mit_WT_BST1 { get; set; }// T      34

		[PlcType("S5Time")]public TimeSpan T_SE_ANLAGE_IO { get; set; }// T      35

        [MappingOffset(37,-1)]

		[PlcType("S5Time")]public TimeSpan T_VI_Stoer_quitt { get; set; }// T      37

        [MappingOffset(43,-1)]

		[PlcType("S5Time")]public TimeSpan T_SE_HNTE_BST2 { get; set; }// T      43

		[PlcType("S5Time")]public TimeSpan T_SE_HNTE_mit_WT_BST2 { get; set; }// T      44

		[PlcType("S5Time")]public TimeSpan T_VI_Not_aus_quitt { get; set; }// T      45

        [MappingOffset(53,-1)]

		[PlcType("S5Time")]public TimeSpan T_SE_HNTE_BST3 { get; set; }// T      53

		[PlcType("S5Time")]public TimeSpan T_SE_HNTE_mit_WT_BST3 { get; set; }// T      54

        [MappingOffset(63,-1)]

		[PlcType("S5Time")]public TimeSpan T_SE_HNTE_BST4 { get; set; }// T      63

		[PlcType("S5Time")]public TimeSpan T_SE_HNTE_mit_WT_BST4 { get; set; }// T      64

        [MappingOffset(73,-1)]

		[PlcType("S5Time")]public TimeSpan T_SE_HNTE_BST5 { get; set; }// T      73

		[PlcType("S5Time")]public TimeSpan T_SE_HNTE_mit_WT_BST5 { get; set; }// T      74

        [MappingOffset(83,-1)]

		[PlcType("S5Time")]public TimeSpan T_SE_HNTE_BST6 { get; set; }// T      83

		[PlcType("S5Time")]public TimeSpan T_SE_HNTE_mit_WT_BST6 { get; set; }// T      84

        [MappingOffset(130,-1)]

		[PlcType("S5Time")]public TimeSpan T_Time_out_ACS_head_pc { get; set; }// T     130

		[PlcType("S5Time")]public TimeSpan T_Time_out_ACS_ZP_BST1 { get; set; }// T     131

		[PlcType("S5Time")]public TimeSpan T_Time_out_ACS_ZP_BST2 { get; set; }// T     132

		[PlcType("S5Time")]public TimeSpan T_Time_out_ACS_ZP_BST3 { get; set; }// T     133

		[PlcType("S5Time")]public TimeSpan T_Time_out_ACS_ZP_BST4 { get; set; }// T     134

        [MappingOffset(136,-1)]

		[PlcType("S5Time")]public TimeSpan T_Time_out_ACS_ZP_BST5 { get; set; }// T     136

		[PlcType("S5Time")]public TimeSpan T_Time_out_ACS_ZP_BST6 { get; set; }// T     137

		[PlcType("S5Time")]public TimeSpan T_Time_out_ACS_SPSAPC { get; set; }// T     138

        [MappingOffset(141,-1)]

		[PlcType("S5Time")]public TimeSpan T_Lampentest_BST1 { get; set; }// T     141

		[PlcType("S5Time")]public TimeSpan T_Lampentest_BST2 { get; set; }// T     142

		[PlcType("S5Time")]public TimeSpan T_Lampentest_BST3 { get; set; }// T     143

		[PlcType("S5Time")]public TimeSpan T_Lampentest_BST4 { get; set; }// T     144

		[PlcType("S5Time")]public TimeSpan T_Lampentest_BST5 { get; set; }// T     145

		[PlcType("S5Time")]public TimeSpan T_Lampentest_BST6 { get; set; }// T     146
    }

    [Mapping("Input", "IB", 0)]
    public class Input
    {
        [MappingOffset(2,0)]
		public bool E_Taste_Bew_plus { get; set; }// I       2.0
		public bool E_Taste_Bew_minus { get; set; }// I       2.1
		public bool E2_2 { get; set; }// I       2.2
		public bool E_Hand_Auto { get; set; }// I       2.3

        [MappingOffset(3,0)]
		public bool E3_0 { get; set; }// I       3.0
		public bool E3_1 { get; set; }// I       3.1
		public bool E3_2 { get; set; }// I       3.2
		public bool E_Hand_ohne { get; set; }// I       3.3
		public bool E_Auto_start { get; set; }// I       3.4
		public bool E_Halt_n_taktende { get; set; }// I       3.5
		public bool E_Gst_fahren { get; set; }// I       3.6
		public bool E_Stör_quitt { get; set; }// I       3.7
		public bool E_Zentr_anlage_ein { get; set; }// I       4.0
		public bool E_Zentr_Anlage_start { get; set; }// I       4.1
		public bool E_Zentr_USV_IO { get; set; }// I       4.2
		public bool E_Temp_HVO_IO { get; set; }// I       4.3
		public bool E_Sich_HVO_IO { get; set; }// I       4.4
		public bool E4_5 { get; set; }// I       4.5
		public bool E4_6 { get; set; }// I       4.6
		public bool E4_7 { get; set; }// I       4.7

        [MappingOffset(60,0)]
		public bool E_VS_ZU_BST1 { get; set; }// I      60.0
		public bool E_PAL_VS_BST1 { get; set; }// I      60.1
		public bool E_VS_Schliess_BST1 { get; set; }// I      60.2
		public bool E_PAL_IN_POS_VS_BST1 { get; set; }// I      60.3
		public bool E_Frg_Koord_FS_BST1 { get; set; }// I      60.4
		public bool E_ST_ZU_BST1 { get; set; }// I      60.5
		public bool E_PAL_ST_BST1 { get; set; }// I      60.6
		public bool E_ST_Schliess_BST1 { get; set; }// I      60.7
		public bool E_PAL_IN_POS_BST1 { get; set; }// I      61.0
		public bool E_PAL_AL1_BST1 { get; set; }// I      61.1
		public bool E_PAL_AL2_BST1 { get; set; }// I      61.2
		public bool E_PAL_AL3_BST1 { get; set; }// I      61.3
		public bool E_Sich_UV10 { get; set; }// I      61.4
		public bool E_Frg2_IO_BST1 { get; set; }// I      61.5
		public bool E_Pneumatik_druck_IO { get; set; }// I      61.6
		public bool E_Frg_IO_BST1 { get; set; }// I      61.7

        [MappingOffset(79,0)]
		public bool E_Geraet_1_BST1 { get; set; }// I      79.0
		public bool E_Geraet_2_BST1 { get; set; }// I      79.1
		public bool E_Geraet_3_BST1 { get; set; }// I      79.2
		public bool E_Geraet_4_BST1 { get; set; }// I      79.3
		public bool E_Geraet_5_BST1 { get; set; }// I      79.4
		public bool E_Geraet_6_BST1 { get; set; }// I      79.5
		public bool E_Geraet_7_BST1 { get; set; }// I      79.6
		public bool E_Geraet_8_BST1 { get; set; }// I      79.7
		public bool E_VS_ZU_BST2 { get; set; }// I      80.0
		public bool E_PAL_VS_BST2 { get; set; }// I      80.1
		public bool E_VS_Schliess_BST2 { get; set; }// I      80.2
		public bool E_PAL_IN_POS_VS_BST2 { get; set; }// I      80.3
		public bool E_Frg_Koord_FS_BST2 { get; set; }// I      80.4
		public bool E_ST_ZU_BST2 { get; set; }// I      80.5
		public bool E_PAL_ST_BST2 { get; set; }// I      80.6
		public bool E_ST_Schliess_BST2 { get; set; }// I      80.7
		public bool E_PAL_IN_POS_BST2 { get; set; }// I      81.0
		public bool E_PAL_AL1_BST2 { get; set; }// I      81.1
		public bool E_PAL_AL2_BST2 { get; set; }// I      81.2
		public bool E_PAL_AL3_BST2 { get; set; }// I      81.3
		public bool E_Sich_UV20 { get; set; }// I      81.4
		public bool E_Frg2_IO_BST2 { get; set; }// I      81.5
		public bool E81_6 { get; set; }// I      81.6
		public bool E_Frg_IO_BST2 { get; set; }// I      81.7

        [MappingOffset(99,0)]
		public bool E_Geraet_1_BST2 { get; set; }// I      99.0
		public bool E_Geraet_2_BST2 { get; set; }// I      99.1
		public bool E_Geraet_3_BST2 { get; set; }// I      99.2
		public bool E_Geraet_4_BST2 { get; set; }// I      99.3
		public bool E_Geraet_5_BST2 { get; set; }// I      99.4
		public bool E_Geraet_6_BST2 { get; set; }// I      99.5
		public bool E_Geraet_7_BST2 { get; set; }// I      99.6
		public bool E_Geraet_8_BST2 { get; set; }// I      99.7
		public bool E_VS_ZU_BST3 { get; set; }// I     100.0
		public bool E_PAL_VS_BST3 { get; set; }// I     100.1
		public bool E_VS_Schliess_BST3 { get; set; }// I     100.2
		public bool E_PAL_IN_POS_VS_BST3 { get; set; }// I     100.3
		public bool E_Frg_Koord_FS_BST3 { get; set; }// I     100.4
		public bool E_ST_ZU_BST3 { get; set; }// I     100.5
		public bool E_PAL_ST_BST3 { get; set; }// I     100.6
		public bool E_ST_Schliess_BST3 { get; set; }// I     100.7
		public bool E_PAL_IN_POS_BST3 { get; set; }// I     101.0
		public bool E_PAL_AL1_BST3 { get; set; }// I     101.1
		public bool E_PAL_AL2_BST3 { get; set; }// I     101.2
		public bool E_PAL_AL3_BST3 { get; set; }// I     101.3
		public bool E_Sich_UV30 { get; set; }// I     101.4
		public bool E_Frg2_IO_BST3 { get; set; }// I     101.5
		public bool E_____101_6 { get; set; }// I     101.6
		public bool E_Frg_IO_BST3 { get; set; }// I     101.7

        [MappingOffset(119,0)]
		public bool E_Geraet_1_BST3 { get; set; }// I     119.0
		public bool E_Geraet_2_BST3 { get; set; }// I     119.1
		public bool E_Geraet_3_BST3 { get; set; }// I     119.2
		public bool E_Geraet_4_BST3 { get; set; }// I     119.3
		public bool E_Geraet_5_BST3 { get; set; }// I     119.4
		public bool E_Geraet_6_BST3 { get; set; }// I     119.5
		public bool E_Geraet_7_BST3 { get; set; }// I     119.6
		public bool E_Geraet_8_BST3 { get; set; }// I     119.7
		public bool E_VS_ZU_BST4 { get; set; }// I     120.0
		public bool E_PAL_VS_BST4 { get; set; }// I     120.1
		public bool E_VS_Schliess_BST4 { get; set; }// I     120.2
		public bool E_PAL_IN_POS_VS_BST4 { get; set; }// I     120.3
		public bool E_Frg_Koord_FS_BST4 { get; set; }// I     120.4
		public bool E_ST_ZU_BST4 { get; set; }// I     120.5
		public bool E_PAL_ST_BST4 { get; set; }// I     120.6
		public bool E_ST_Schliess_BST4 { get; set; }// I     120.7
		public bool E_PAL_IN_POS_BST4 { get; set; }// I     121.0
		public bool E_PAL_AL1_BST4 { get; set; }// I     121.1
		public bool E_PAL_AL2_BST4 { get; set; }// I     121.2
		public bool E_PAL_AL3_BST4 { get; set; }// I     121.3
		public bool E_Sich_UV40 { get; set; }// I     121.4
		public bool E_Frg2_IO_BST4 { get; set; }// I     121.5
		public bool E121_6 { get; set; }// I     121.6
		public bool E_Frg_IO_BST4 { get; set; }// I     121.7

        [MappingOffset(139,0)]
		public bool E_Geraet_1_BST4 { get; set; }// I     139.0
		public bool E_Geraet_2_BST4 { get; set; }// I     139.1
		public bool E_Geraet_3_BST4 { get; set; }// I     139.2
		public bool E_Geraet_4_BST4 { get; set; }// I     139.3
		public bool E_Geraet_5_BST4 { get; set; }// I     139.4
		public bool E_Geraet_6_BST4 { get; set; }// I     139.5
		public bool E_Geraet_7_BST4 { get; set; }// I     139.6
		public bool E_Geraet_8_BST4 { get; set; }// I     139.7
		public bool E_VS_ZU_BST5 { get; set; }// I     140.0
		public bool E_PAL_VS_BST5 { get; set; }// I     140.1
		public bool E_VS_Schliess_BST5 { get; set; }// I     140.2
		public bool E_PAL_IN_POS_VS_BST5 { get; set; }// I     140.3
		public bool E_Frg_Koord_FS_BST5 { get; set; }// I     140.4
		public bool E_ST_ZU_BST5 { get; set; }// I     140.5
		public bool E_PAL_ST_BST5 { get; set; }// I     140.6
		public bool E_ST_Schliess_BST5 { get; set; }// I     140.7
		public bool E_PAL_IN_POS_BST5 { get; set; }// I     141.0
		public bool E_PAL_AL1_BST5 { get; set; }// I     141.1
		public bool E_PAL_AL2_BST5 { get; set; }// I     141.2
		public bool E_PAL_AL3_BST5 { get; set; }// I     141.3
		public bool E_Sich_UV50 { get; set; }// I     141.4
		public bool E_Frg2_IO_BST5 { get; set; }// I     141.5
		public bool E141_6 { get; set; }// I     141.6
		public bool E_Frg_IO_BST5 { get; set; }// I     141.7

        [MappingOffset(159,0)]
		public bool E_Geraet_1_BST5 { get; set; }// I     159.0
		public bool E_Geraet_2_BST5 { get; set; }// I     159.1
		public bool E_Geraet_3_BST5 { get; set; }// I     159.2
		public bool E_Geraet_4_BST5 { get; set; }// I     159.3
		public bool E_Geraet_5_BST5 { get; set; }// I     159.4
		public bool E_Geraet_6_BST5 { get; set; }// I     159.5
		public bool E_Geraet_7_BST5 { get; set; }// I     159.6
		public bool E_Geraet_8_BST5 { get; set; }// I     159.7
		public bool E_VS_ZU_BST6 { get; set; }// I     160.0
		public bool E_PAL_VS_BST6 { get; set; }// I     160.1
		public bool E_VS_Schliess_BST6 { get; set; }// I     160.2
		public bool E_PAL_IN_POS_VS_BST6 { get; set; }// I     160.3
		public bool E_Frg_Koord_FS_BST6 { get; set; }// I     160.4
		public bool E_ST_ZU_BST6 { get; set; }// I     160.5
		public bool E_PAL_ST_BST6 { get; set; }// I     160.6
		public bool E_ST_Schliess_BST6 { get; set; }// I     160.7
		public bool E_PAL_IN_POS_BST6 { get; set; }// I     161.0
		public bool E_PAL_AL1_BST6 { get; set; }// I     161.1
		public bool E_PAL_AL2_BST6 { get; set; }// I     161.2
		public bool E_PAL_AL3_BST6 { get; set; }// I     161.3
		public bool E_Sich_UV60 { get; set; }// I     161.4
		public bool E_Frg2_IO_BST6 { get; set; }// I     161.5
		public bool E161_6 { get; set; }// I     161.6
		public bool E_Frg_IO_BST6 { get; set; }// I     161.7

        [MappingOffset(179,0)]
		public bool E_Geraet_1_BST6 { get; set; }// I     179.0
		public bool E_Geraet_2_BST6 { get; set; }// I     179.1
		public bool E_Geraet_3_BST6 { get; set; }// I     179.2
		public bool E_Geraet_4_BST6 { get; set; }// I     179.3
		public bool E_Geraet_5_BST6 { get; set; }// I     179.4
		public bool E_Geraet_6_BST6 { get; set; }// I     179.5
		public bool E_Geraet_7_BST6 { get; set; }// I     179.6
		public bool E_Geraet_8_BST6 { get; set; }// I     179.7
    }

    [Mapping("Output", "QB", 0)]
    public class Output
    {
        [MappingOffset(3,0)]
		public bool A3_0 { get; set; }// Q       3.0
		public bool A_Not_Halt { get; set; }// Q       3.1
		public bool A3_2 { get; set; }// Q       3.2
		public bool A3_3 { get; set; }// Q       3.3
		public bool A_Auto_start { get; set; }// Q       3.4
		public bool A_Halt_nach_taktende { get; set; }// Q       3.5
		public bool A_Grundstellung { get; set; }// Q       3.6
		public bool A_Stoerung { get; set; }// Q       3.7

        [MappingOffset(12,0)]
		public bool A_Betriebsart { get; set; }// Q      12.0
		public bool A_Abwahl { get; set; }// Q      12.1
		public bool A12_2 { get; set; }// Q      12.2
		public bool A12_3 { get; set; }// Q      12.3

        [MappingOffset(60,0)]
		public bool A_VST_oeffnen_BST1 { get; set; }// Q      60.0
		public bool A_ST_oeffnen_BST1 { get; set; }// Q      60.1
		public bool A_Anf_Koord_FS_BST1 { get; set; }// Q      60.2
		public bool A_Frg_IO_BST1 { get; set; }// Q      60.3
		public bool A_Mot_bearb_BST1 { get; set; }// Q      60.4
		public bool A_Frg_2IO_BST1 { get; set; }// Q      60.5
		public bool A60_6 { get; set; }// Q      60.6
		public bool A_Pneumatik_ein { get; set; }// Q      60.7

        [MappingOffset(79,0)]
		public bool A_Geraet_1_BST1 { get; set; }// Q      79.0
		public bool A_Geraet_2_BST1 { get; set; }// Q      79.1
		public bool A_Geraet_3_BST1 { get; set; }// Q      79.2
		public bool A_Geraet_4_BST1 { get; set; }// Q      79.3
		public bool A_Geraet_5_BST1 { get; set; }// Q      79.4
		public bool A_Geraet_6_BST1 { get; set; }// Q      79.5
		public bool A_Geraet_7_BST1 { get; set; }// Q      79.6
		public bool A_Geraet_8_BST1 { get; set; }// Q      79.7
		public bool A_VST_oeffnen_BST2 { get; set; }// Q      80.0
		public bool A_ST_oeffnen_BST2 { get; set; }// Q      80.1
		public bool A_Anf_Koord_FS_BST2 { get; set; }// Q      80.2
		public bool A_Frg_IO_BST2 { get; set; }// Q      80.3
		public bool A_Mot_bearb_BST2 { get; set; }// Q      80.4
		public bool A_Frg_2IO_BST2 { get; set; }// Q      80.5
		public bool A80_6 { get; set; }// Q      80.6
		public bool A80_7 { get; set; }// Q      80.7

        [MappingOffset(99,0)]
		public bool A_Geraet_1_BST2 { get; set; }// Q      99.0
		public bool A_Geraet_2_BST2 { get; set; }// Q      99.1
		public bool A_Geraet_3_BST2 { get; set; }// Q      99.2
		public bool A_Geraet_4_BST2 { get; set; }// Q      99.3
		public bool A_Geraet_5_BST2 { get; set; }// Q      99.4
		public bool A_Geraet_6_BST2 { get; set; }// Q      99.5
		public bool A_Geraet_7_BST2 { get; set; }// Q      99.6
		public bool A_Geraet_8_BST2 { get; set; }// Q      99.7
		public bool A_VST_oeffnen_BST3 { get; set; }// Q     100.0
		public bool A_ST_oeffnen_BST3 { get; set; }// Q     100.1
		public bool A_Anf_Koord_FS_BST3 { get; set; }// Q     100.2
		public bool A_Frg_IO_BST3 { get; set; }// Q     100.3
		public bool A_Mot_bearb_BST3 { get; set; }// Q     100.4
		public bool A_Frg_2IO_BST3 { get; set; }// Q     100.5
		public bool A100_6 { get; set; }// Q     100.6
		public bool A100_7 { get; set; }// Q     100.7

        [MappingOffset(119,0)]
		public bool A_Geraet_1_BST3 { get; set; }// Q     119.0
		public bool A_Geraet_2_BST3 { get; set; }// Q     119.1
		public bool A_Geraet_3_BST3 { get; set; }// Q     119.2
		public bool A_Geraet_4_BST3 { get; set; }// Q     119.3
		public bool A_Geraet_5_BST3 { get; set; }// Q     119.4
		public bool A_Geraet_6_BST3 { get; set; }// Q     119.5
		public bool A_Geraet_7_BST3 { get; set; }// Q     119.6
		public bool A_Geraet_8_BST3 { get; set; }// Q     119.7
		public bool A_VST_oeffnen_BST4 { get; set; }// Q     120.0
		public bool A_ST_oeffnen_BST4 { get; set; }// Q     120.1
		public bool A_Anf_Koord_FS_BST4 { get; set; }// Q     120.2
		public bool A_Frg_IO_BST4 { get; set; }// Q     120.3
		public bool A_Mot_bearb_BST4 { get; set; }// Q     120.4
		public bool A_Frg_2IO_BST4 { get; set; }// Q     120.5
		public bool A120_6 { get; set; }// Q     120.6
		public bool A120_7 { get; set; }// Q     120.7

        [MappingOffset(139,0)]
		public bool A_Geraet_1_BST4 { get; set; }// Q     139.0
		public bool A_Geraet_2_BST4 { get; set; }// Q     139.1
		public bool A_Geraet_3_BST4 { get; set; }// Q     139.2
		public bool A_Geraet_4_BST4 { get; set; }// Q     139.3
		public bool A_Geraet_5_BST4 { get; set; }// Q     139.4
		public bool A_Geraet_6_BST4 { get; set; }// Q     139.5
		public bool A_Geraet_7_BST4 { get; set; }// Q     139.6
		public bool A_Geraet_8_BST4 { get; set; }// Q     139.7
		public bool A_VST_oeffnen_BST5 { get; set; }// Q     140.0
		public bool A_ST_oeffnen_BST5 { get; set; }// Q     140.1
		public bool A_Anf_Koord_FS_BST5 { get; set; }// Q     140.2
		public bool A_Frg_IO_BST5 { get; set; }// Q     140.3
		public bool A_Mot_bearb_BST5 { get; set; }// Q     140.4
		public bool A_Frg_2IO_BST5 { get; set; }// Q     140.5
		public bool A140_6 { get; set; }// Q     140.6
		public bool A140_7 { get; set; }// Q     140.7

        [MappingOffset(159,0)]
		public bool A_Geraet_1_BST5 { get; set; }// Q     159.0
		public bool A_Geraet_2_BST5 { get; set; }// Q     159.1
		public bool A_Geraet_3_BST5 { get; set; }// Q     159.2
		public bool A_Geraet_4_BST5 { get; set; }// Q     159.3
		public bool A_Geraet_5_BST5 { get; set; }// Q     159.4
		public bool A_Geraet_6_BST5 { get; set; }// Q     159.5
		public bool A_Geraet_7_BST5 { get; set; }// Q     159.6
		public bool A_Geraet_8_BST5 { get; set; }// Q     159.7
		public bool A_VST_oeffnen_BST6 { get; set; }// Q     160.0
		public bool A_ST_oeffnen_BST6 { get; set; }// Q     160.1
		public bool A_Anf_Koord_FS_BST6 { get; set; }// Q     160.2
		public bool A_Frg_IO_BST6 { get; set; }// Q     160.3
		public bool A_Mot_bearb_BST6 { get; set; }// Q     160.4
		public bool A_Frg_2IO_BST6 { get; set; }// Q     160.5
		public bool A160_6 { get; set; }// Q     160.6
		public bool A160_7 { get; set; }// Q     160.7

        [MappingOffset(179,0)]
		public bool A_Geraet_1_BST6 { get; set; }// Q     179.0
		public bool A_Geraet_2_BST6 { get; set; }// Q     179.1
		public bool A_Geraet_3_BST6 { get; set; }// Q     179.2
		public bool A_Geraet_4_BST6 { get; set; }// Q     179.3
		public bool A_Geraet_5_BST6 { get; set; }// Q     179.4
		public bool A_Geraet_6_BST6 { get; set; }// Q     179.5
		public bool A_Geraet_7_BST6 { get; set; }// Q     179.6
		public bool A_Geraet_8_BST6 { get; set; }// Q     179.7
    }

}
