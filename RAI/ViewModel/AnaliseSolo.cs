using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System;

namespace RAI.ViewModel
{
    public class AnaliseSolo
    {
        public int id { get; set; }

        public int parceiro_id { get; set; }
        public string parceiro { get; set; }

        public int fazenda_id { get; set; }
        public string fazenda { get; set; }

        public int local_id { get; set; }
        public string local { get; set; }

        public int? quadra_id { get; set; }
        public string quadra { get; set; }

        public DateTime data { get; set; }
        public string profundidade { get; set; }
        public string observacao { get; set; }

        public decimal? ph { get; set; }
        public decimal? mo { get; set; }
        public decimal? p { get; set; }
        public decimal? k { get; set; }
        public decimal? ca { get; set; }
        public decimal? mg { get; set; }
        public decimal? na { get; set; }
        public decimal? h_al { get; set; }
        public decimal? al { get; set; }
        public decimal? s { get; set; }
        public decimal? b { get; set; }
        public decimal? cu { get; set; }
        public decimal? fe { get; set; }
        public decimal? mn { get; set; }
        public decimal? zn { get; set; }
        public decimal? argila { get; set; }
        public decimal? silte { get; set; }
        public decimal? areia { get; set; }

        public decimal? k_cmolc
        {
            get
            {
                if (k_unidade == "mmolc/dm3")
                    return k / 10;
                else if (k_unidade == "mg/dm3")
                    return k / 391;

                return k;
            }
        }

        public decimal? ca_cmolc
        {
            get
            {
                if (ca_unidade == "mmolc/dm3")
                    return ca / 10;

                return ca;
            }
        }

        public decimal? mg_cmolc
        {
            get
            {
                if (mg_unidade == "mmolc/dm3")
                    return mg / 10;

                return mg;
            }
        }

        public decimal? h_al_cmolc
        {
            get
            {
                if (h_al_unidade == "mmolc/dm3")
                    return h_al / 10;

                return h_al;
            }
        }

        public string ph_extrator { get; set; }
        public string p_extrator { get; set; }
        public string k_extrator { get; set; }
        public string cu_extrator { get; set; }
        public string fe_extrator { get; set; }
        public string mn_extrator { get; set; }
        public string zn_extrator { get; set; }

        public string mo_unidade { get; set; }
        public string k_unidade { get; set; }
        public string ca_unidade { get; set; }
        public string mg_unidade { get; set; }
        public string na_unidade { get; set; }
        public string h_al_unidade { get; set; }
        public string al_unidade { get; set; }
        public string cu_unidade { get; set; }
        public string fe_unidade { get; set; }
        public string mn_unidade { get; set; }
        public string zn_unidade { get; set; }
        public string argila_unidade { get; set; }
        public string silte_unidade { get; set; }
        public string areia_unidade { get; set; }

        public decimal? prnt { get; set; }
        public string profundidade_incorporacao { get; set; }
        public decimal? area { get; set; }

        public decimal sb { get => k_cmolc.GetValueOrDefault() + ca_cmolc.GetValueOrDefault() + mg_cmolc.GetValueOrDefault(); }
        public decimal ctc { get => h_al.GetValueOrDefault() + sb; }
        public decimal t { get => sb + al.GetValueOrDefault(); }
        public decimal v { get => ctc > 0 ? (100 * sb) / ctc : 0; }
        public decimal m { get => t > 0 ? (100 * al.GetValueOrDefault()) / t : 0; }
        public decimal ca_ctc { get => ctc > 0 ? ca_cmolc.GetValueOrDefault() / ctc * 100 : 0; }
        public decimal mg_ctc { get => ctc > 0 ? mg_cmolc.GetValueOrDefault() / ctc * 100 : 0; }
        public decimal k_ctc { get => ctc > 0 ? k_cmolc.GetValueOrDefault() / ctc * 100 : 0; }
        public decimal h_al_ctc { get => ctc > 0 ? h_al_cmolc.GetValueOrDefault() / ctc * 100 : 0; }

        public decimal vd
        {
            get
            {
                if (ctc < 5) return 85;
                else if (ctc > 5 && ctc < 7) return 80;
                else if (ctc > 7 && ctc < 9) return 75;
                else if (ctc > 9) return 70;

                return 0;
            }
        }

        public Style style_ph
        {
            get
            {
                var style = new Style();

                if (ph_extrator == "H2O")
                {
                    if (ph.GetValueOrDefault() < 5.5M)
                        style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.IndianRed));
                    else if (ph.GetValueOrDefault() >= 5.5M && ph.GetValueOrDefault() < 6)
                        style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.DarkSeaGreen));
                    else if (ph.GetValueOrDefault() >= 6 && ph.GetValueOrDefault() < 6.5M)
                        style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.DarkOliveGreen));
                    else 
                        style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.RoyalBlue));
                }
                else
                {
                    if (ph.GetValueOrDefault() < 5)
                        style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.IndianRed));
                    else if (ph.GetValueOrDefault() >= 5 && ph.GetValueOrDefault() < 5.5M)
                        style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.DarkSeaGreen));
                    else if (ph.GetValueOrDefault() >= 5.5M && ph.GetValueOrDefault() < 6)
                        style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.DarkOliveGreen));
                    else
                        style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.RoyalBlue));
                }

                return style;
            }
        }

        public Style style_p
        {
            get
            {
                var style = new Style();
               
                if (p.GetValueOrDefault() < 15)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.IndianRed));
                else if (p.GetValueOrDefault() >= 15 && p.GetValueOrDefault() < 24)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.DarkSeaGreen));
                else if (p.GetValueOrDefault() >= 24 && p.GetValueOrDefault() < 30)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.DarkOliveGreen));
                else
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.RoyalBlue));

                return style;
            }
        }

        public Style style_k
        {
            get
            {
                var style = new Style();

                if (k_cmolc.GetValueOrDefault() < 0.15M)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.IndianRed));
                else if (k_cmolc.GetValueOrDefault() >= 0.15M && k_cmolc.GetValueOrDefault() < 0.24M)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.DarkSeaGreen));
                else if (k_cmolc.GetValueOrDefault() >= 0.24M && k_cmolc.GetValueOrDefault() < 0.3M)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.DarkOliveGreen));
                else
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.RoyalBlue));

                return style;
            }
        }

        public Style style_ca
        {
            get
            {
                var style = new Style();

                if (ca_ctc < 30)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.IndianRed));
                else if (ca_ctc >= 30 && ca_ctc < 40)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.DarkSeaGreen));
                else if (ca_ctc >= 40 && ca_ctc < 60)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.DarkOliveGreen));
                else
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.RoyalBlue));

                return style;
            }
        }

        public Style style_mg
        {
            get
            {
                var style = new Style();

                if (mg_ctc < 12)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.IndianRed));
                else if (mg_ctc >= 12 && mg_ctc < 15)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.DarkSeaGreen));
                else if (mg_ctc >= 15 && mg_ctc < 20)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.DarkOliveGreen));
                else
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.RoyalBlue));

                return style;
            }
        }

        public Style style_s
        {
            get
            {
                var style = new Style();

                if (s < 10)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.IndianRed));
                else if (s.GetValueOrDefault() >= 10 && s.GetValueOrDefault() < 16)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.DarkSeaGreen));
                else if (s.GetValueOrDefault() >= 16 && s.GetValueOrDefault() < 20)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.DarkOliveGreen));
                else
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.RoyalBlue));

                return style;
            }
        }

        public Style style_ctc
        {
            get
            {
                var style = new Style();

                if (ctc < 6)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.IndianRed));
                else if (ctc >= 6 && ctc < 8)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.DarkSeaGreen));
                else if (ctc >= 8 && ctc < 10)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.DarkOliveGreen));
                else
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.RoyalBlue));

                return style;
            }
        }

        public Style style_v
        {
            get
            {
                var style = new Style();

                if (v < 50)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.IndianRed));
                else if (v >= 50 && v < 70)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.DarkSeaGreen));
                else if (v >= 70 && v < 80)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.DarkOliveGreen));
                else
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.RoyalBlue));

                return style;
            }
        }

        public Style style_mo
        {
            get
            {
                var style = new Style();

                if (mo.GetValueOrDefault() < 2)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.IndianRed));
                else if (mo.GetValueOrDefault() >= 2 && mo.GetValueOrDefault() < 3)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.DarkSeaGreen));
                else if (mo.GetValueOrDefault() >= 3 && mo.GetValueOrDefault() < 4)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.DarkOliveGreen));
                else
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.RoyalBlue));

                return style;
            }
        }

        public Style style_zn
        {
            get
            {
                var style = new Style();

                if (zn.GetValueOrDefault() < 3)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.IndianRed));
                else if (zn.GetValueOrDefault() >= 3 && zn.GetValueOrDefault() < 5)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.DarkSeaGreen));
                else if (zn.GetValueOrDefault() >= 5 && zn.GetValueOrDefault() < 10)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.DarkOliveGreen));
                else
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.RoyalBlue));

                return style;
            }
        }

        public Style style_fe
        {
            get
            {
                var style = new Style();

                if (fe.GetValueOrDefault() < 10)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.IndianRed));
                else if (fe.GetValueOrDefault() >= 10 && fe.GetValueOrDefault() < 15)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.DarkSeaGreen));
                else if (fe.GetValueOrDefault() >= 15 && fe.GetValueOrDefault() < 40)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.DarkOliveGreen));
                else
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.RoyalBlue));

                return style;
            }
        }

        public Style style_mn
        {
            get
            {
                var style = new Style();

                if (mn.GetValueOrDefault() < 5)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.IndianRed));
                else if (mn.GetValueOrDefault() >= 5 && mn.GetValueOrDefault() < 10)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.DarkSeaGreen));
                else if (mn.GetValueOrDefault() >= 10 && mn.GetValueOrDefault() < 20)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.DarkOliveGreen));
                else
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.RoyalBlue));

                return style;
            }
        }

        public Style style_cu
        {
            get
            {
                var style = new Style();

                if (cu.GetValueOrDefault() < 2)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.IndianRed));
                else if (cu.GetValueOrDefault() >= 2 && cu.GetValueOrDefault() < 3)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.DarkSeaGreen));
                else if (cu.GetValueOrDefault() >= 3 && cu.GetValueOrDefault() < 5)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.DarkOliveGreen));
                else
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.RoyalBlue));

                return style;
            }
        }

        public Style style_b
        {
            get
            {
                var style = new Style();

                if (cu.GetValueOrDefault() < 0.6M)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.IndianRed));
                else if (cu.GetValueOrDefault() >= 0.6M && cu.GetValueOrDefault() < 0.8M)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.DarkSeaGreen));
                else if (cu.GetValueOrDefault() >= 0.8M && cu.GetValueOrDefault() < 1)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.DarkOliveGreen));
                else
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.RoyalBlue));

                return style;
            }
        }

        public Style style_al
        {
            get
            {
                var style = new Style();
                style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.IndianRed));
                return style;
            }
        }

        public Style style_h_al
        {
            get
            {
                var style = new Style();

                if (h_al_ctc < 15)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.IndianRed));
                else if (h_al_ctc >= 15 && h_al_ctc < 20)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.DarkSeaGreen));
                else if (h_al_ctc >= 20 && h_al_ctc < 30)
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.DarkOliveGreen));
                else
                    style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.IndianRed));

                return style;
            }
        }
    }
}