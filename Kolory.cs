using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Master_project
{
    public class Kolory
    {
        private Wierzcholek _w;
        private Kr _k;
        private int t_kolory;

        public Kolory(Wierzcholek w, Kr k)
        {
            this._w = w;
            this._k = k;
        }
        public Wierzcholek wierzcholek
        {
            get { return this._w; }
            set { this._w = value; }
        }
        public int T_kolory
        {
            get { return t_kolory; }
            set { this.t_kolory = value; }
        }
        public Kr krawedz
        {
            get { return this._k; }
            set { this._k = value; }
        }
        public void Dodaj(Kolory kol1)
        {
            {
                // kol.Add(kol1);
                //_nodes.Add(kol1.Node);
            }
        }

    }
}
