using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace Master_project
{
    public class Kr 
    {
        private double _dl;
        private Wierzcholek _1Wi;
        private Wierzcholek _2Wi;
        string _nazwa;
      //  private const int Rozm = 10;
        private bool kolorowanie;
        private int t_kolory;
        private SolidColorBrush kolor;
        private int _etykieta;
        private int nr_kolor;

        public Kr(Wierzcholek pierwszy_wierzcholek, Wierzcholek drugi_wierzcholek)
        {
            this._1Wi= pierwszy_wierzcholek;
            this._2Wi = drugi_wierzcholek;
        }

        public Kr(Wierzcholek pierwszy_wierzcholek, Wierzcholek drugi_wierzcholek, double dlugosc)
            : this(pierwszy_wierzcholek, drugi_wierzcholek)
        {
            this._dl = dlugosc;
        }

        public Wierzcholek Pierwszy_Wierzcholek
        {
            get { return this._1Wi; }
            set { this._1Wi = value; }
        }

        public Wierzcholek Drugi_Wierzcholek
        {
            get { return this._2Wi; }
            set { this._2Wi = value; }
        }
        public string Nazwa
        {
            get { return _nazwa; }
            set { this._nazwa = value; }
        }
        public double Dlugosc
        {
            get { return this._dl; }
            set { this._dl = value; }
        }
        public int Etykieta
        {
            get { return this._etykieta; }
            set { this._etykieta = value; }
        }
        public void Reset()
        {
            kolorowanie = false;
        }

        public bool Kolorowanie
        {
            get { return kolorowanie; }
            set { this.kolorowanie = value; }
        }
        public SolidColorBrush Kolor
        {
            get { return kolor; }
            set { this.kolor = value; }
        }
        public int Nr_kolor
        {
            get { return nr_kolor; }
            set { this.nr_kolor = value; }
        }
    }
}
