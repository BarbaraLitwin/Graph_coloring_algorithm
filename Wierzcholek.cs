

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Master_project
{
    public class Wierzcholek
    {
        private Point _gdzie;
        private Point _srodek;
        private string _etykieta;
        private double _sred;
        private bool kolorowanie;
        private bool multikolorowanie;
        private int t_kolory;
        private SolidColorBrush kolor;
        string _nazwa;
        private List<Kr> _krawedzie;
        private List<int> _multikolory;
        private int _stopien;
       // _multikolory = new List<int>();

        public Wierzcholek(Point gdzie, string etykieta, double sred)
        {
            this._gdzie = gdzie;
            this._etykieta = etykieta;
            this._sred = sred;

            kolorowanie = false;
            multikolorowanie = false;
            t_kolory = 0;

            _krawedzie = new List<Kr>();
            _multikolory = new List<int>();
        }

        public Wierzcholek(Point gdzie, Point srodek, string etykieta, double srednica)
            : this(gdzie, etykieta, srednica)
        {
            this._srodek = srodek;
        }

        public Point Gdzie
        {
            get { return _gdzie; }
            set { this._gdzie = value; }
        }

        public Point Srodek
        {
            get { return _srodek; }
            set { this._srodek = value; }
        }

        public double Srednica
        {
            get { return _sred; }
        }
        public int T_kolory
        {
            get { return t_kolory; }
            set { this.t_kolory = value; }
        }
        public string Etykieta
        {
            get { return _etykieta; }
        }

        public List<Kr> Krawedzie
        {
            get { return this._krawedzie; }
            set { this._krawedzie = value; }
        }
        public List<int> Multikolory
        {
            
            get { return this._multikolory; }
            set { this._multikolory = value; }
        }
        public bool Kolorowanie
        {
            get { return kolorowanie; }
            set { this.kolorowanie = value; }
        }
        public bool Multikolorowanie
        {
            get { return multikolorowanie; }
            set { this.multikolorowanie = value; }
        }
        public string Nazwa
        {
            get { return _nazwa; }
            set { this._nazwa = value; }
        }
        public SolidColorBrush Kolor
        {
            get { return kolor; }
            set { this.kolor = value; }
        }
        public int Stopien
        {
            get { return _stopien; }
            set { this._stopien = value; }
        }
        public bool Czy_jest_punkt(Point p)
        {
            double xSq = Math.Pow(p.X - _srodek.X, 2);
            double ySq = Math.Pow(p.Y - _srodek.Y, 2);
            double dist = Math.Sqrt(xSq + ySq);

            return (dist <= (_sred / 2));
        }
        public void Reset()
        {
            kolorowanie = false;
        }
    }
}
