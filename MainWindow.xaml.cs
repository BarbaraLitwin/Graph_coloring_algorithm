using Master_project;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using System.Xml;

//namespace Master_project
//{
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
//public partial class MainWindow : Window
//{
//    public MainWindow()
//    {
//        InitializeComponent();
//    }
//}
//}
namespace Master_project
{
    public partial class MainWindow : Window
    {

        int a, b, c;
        int lw;
        int w, k, po;
        Point[] p = new Point[21];
        char[] my_char = new char[100];
        bool[,] tp = new bool[21, 21];
        int[,] wag = new int[21, 21];
        int[,] pary_w;
        String wartosc1;
        String[] tablica = new String[50];
        int s;

        TextBlock textBlock = new TextBlock();
        private const double _sred = 25;
        private const int _Rozm = 12;

        private int _licznik;
        private int _licznikF;
        private int _licznikK;
        private int licz;
        private bool found;
        private bool usuwanie;
        private bool menu;
        private int ii;
        private int stopien;
        private int[] Stopnie_;
        private int[,] Stopnie1;
        private int[] multikolory;
        private int i1;
        private int i2;
        private int i3;
        private int i4;
        private int i5;
        //private List<Kolory> kol;
        //private Kolory kolo;


        private List<Wierzcholek> _wierzcholki;
        private List<Kr> _krawedzie;
        private List<Wierzcholek> _lista;
        private List<Wierzcholek>[] _multi_k;
        private List<Wierzcholek> _zbiory;
        private List<int>[] lista_w;
        private List<int> lista_k;
        private Wierzcholek aktualny2, aktualny3;
        private Wierzcholek obecny, nastepny;

        private List<Kr> _listas;
        private SolidColorBrush zwykly;
        //private SolidColorBrush kolor;
        private Wierzcholek wybrany;

        public MainWindow()
        {
            InitializeComponent();
            myGrid.SetValue(Canvas.ZIndexProperty, 0);

            //kol = new List<Kolory>();
            _wierzcholki = new List<Wierzcholek>();
            _krawedzie = new List<Kr>();
            _listas = new List<Kr>();
            _lista = new List<Wierzcholek>();
            _multi_k = new List<Wierzcholek>[1000];
            //_multikolory = new List<int>();
            _zbiory = new List<Wierzcholek>();
            lista_w = new List<int>[1000];
            lista_k = new List<int>();
            _licznik = 1;
            _licznikF = 1;
            _licznikK = 1;
            licz = -1;
            found = false;
            usuwanie = false;
            menu = false;

            ii = 0;
            stopien = 0;
            Stopnie_ = new int[50];
            Stopnie1 = new int[50, 2];
            pary_w = new int[500, 2];
            i1 = 0;
            i2 = 0;
            i3 = 0;
            i5 = 0;
            wartosc1 = "";
            zwykly = new SolidColorBrush(Colors.Blue);
        }
        private void myGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }
        public void myGrid_MouseMove(object sender, MouseEventArgs e)
        {
            Point pt = e.GetPosition(myGrid);
            ////  UIElement element = (UIElement)sender;
            statusLabel.Content = "wybrany X:" + pt.X.ToString() + "wybrany Y:" + pt.Y.ToString();
            //  if (e.LeftButton == MouseButtonState.Pressed)
            {
                //    if (Czy_Wi(pt.X, pt.Y))
                //    {
                //        wybrany = Pobierz_wi(pt.X, pt.Y);
                //        string nazwa = wybrany.Nazwa;

                //        double pX = pt.X;
                //        double pY = pt.Y;
                //        UIElement[] tmp = new UIElement[myGrid.Children.Count];
                //        myGrid.Children.CopyTo(tmp, 0);
                //        foreach (UIElement uielement in tmp)
                //        {
                //            // statusLabel.Content = "wybrany:" + wybrany.Nazwa.ToString();
                //            Ellipse elipsa = uielement as Ellipse;
                //            if (elipsa != null && elipsa.Name == wybrany.Nazwa)
                //            {
                //                elipsa.SetValue(Canvas.LeftProperty, pt.X);
                //                elipsa.SetValue(Canvas.TopProperty, pt.Y);
                //                wybrany.Srodek = pt;
                //                wybrany.Gdzie = pt;
                //                statusLabel.Content = "wybrany X:" + wybrany.Srodek.X.ToString() + "wybrany Y:" + wybrany.Srodek.Y.ToString();
                //                // elipsa.SetValue(Canvas.LeftProperty, wybrany.Location.X-pt.X);
                //                //  elipsa.SetValue(Canvas.TopProperty, wybrany.Location.Y-pt.Y);
                //                // elipsa.SetValue(Canvas.ZIndexProperty, 2);

                //            }
                //            TextBlock tekst = uielement as TextBlock;
                //            if (tekst != null && tekst.Text == wybrany.Etykieta)
                //            {
                //                tekst.SetValue(Canvas.LeftProperty, pt.X+9);
                //                tekst.SetValue(Canvas.TopProperty, pt.Y+3);

                //                //  tekst.SetValue(Canvas.LeftProperty, pt.X - (_Rozm / 4 * wybrany.Etykieta.Length));
                //                //  tekst.SetValue(Canvas.TopProperty, pt.Y - _Rozm / 2);
                //                // tekst.SetValue(Canvas.ZIndexProperty, 3);
                //            }
                //        }
                //    }
                //}
            }
        }
        //po kliknięciu prawym przyciskiem pojawia się opcja Usuń,po klinięciu lewym pojawia sie wierzcholek lub krawedz
        private void myGrid_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                //Point punkt = e.GetPosition(myGrid);
                if (menu)
                {
                    menu11.Visibility = Visibility.Collapsed;
                    // menu = false;
                }
                if (!menu)
                {
                    Point punkt = e.GetPosition(myGrid);
                    //statusLabel.Content = "X:" + punkt.X.ToString();
                    //czy kliknięto na wierzchołek
                    if (Czy_Wi(punkt.X, punkt.Y) && (punkt.X < 600))
                    {
                        Dwa_wierzcholki(punkt.X, punkt.Y);
                        if (obecny != null && nastepny != null)
                        {
                            Kr krawedz = Utworz_kr(obecny, nastepny);
                            _krawedzie.Add(krawedz);

                            obecny.Krawedzie.Add(krawedz);
                            nastepny.Krawedzie.Add(krawedz);

                            Rysuj_Kr(krawedz);
                            obecny = null;
                            nastepny = null;
                            panel.Visibility = Visibility.Visible;
                        }
                    }
                    //w przeciwnym przypadku
                    else
                    {
                        if (!Odleglosc_wierzcholkow(punkt) && (punkt.X < 600))
                        {
                            Wierzcholek n = Utworz_wi(punkt);
                            _wierzcholki.Add(n);
                            Rysuj_W(n);
                            _licznik++;
                            obecny = null;
                            nastepny = null;
                        }
                    }
                }

            }
            menu = false;
            if (e.RightButton == MouseButtonState.Pressed)
            {
                menu = true;
                Point x = e.GetPosition(menu11);
                Point pt = e.GetPosition(myGrid);
                //  menu9.SetValue(Menu.);
                //Canvas.SetLeft(menu11, Canvas.GetLeft(menu11) + (pt.X));

                // menu11.SetValue(Canvas.TopProperty, pt.Y-180);
                // menu11.SetValue(Canvas.LeftProperty,pt.X-240);
                menu10.SetValue(Canvas.TopProperty, pt.Y - 190);
                menu10.SetValue(Canvas.LeftProperty, pt.X - 240);
                if (Czy_Wi(pt.X, pt.Y))
                {
                    menu11.SetValue(Canvas.TopProperty, pt.Y - 180);
                    menu11.SetValue(Canvas.LeftProperty, pt.X - 240);
                    wybrany = Pobierz_wi(pt.X, pt.Y);
                    if (wybrany != null)
                    {
                        wybrany = Pobierz_wi(pt.X, pt.Y);
                        menu11.Visibility = Visibility.Visible;
                        //statusLabel.Content = wybrany.Etykieta.ToString();
                        //  statusLabel.Content="wybrany";
                    }
                }
            }
            //statusLabel.Content = "punkt" + x.X.ToString();

        }
        //usuwanie wierzcholka z listy wraz z krawedziami
        private void usun()
        {
            //tutaj mozna iterowac od zera
            for (int i = 0; i < _wierzcholki.Count; i++)
            {
                if (wybrany.Etykieta == _wierzcholki[i].Etykieta)
                    _wierzcholki.Remove(_wierzcholki[i]);
            }
            //lista iteruje sie nie od zera,a od glowy
            for (int j = _krawedzie.Count - 1; j >= 0; j--)
            {
                if (_krawedzie[j].Pierwszy_Wierzcholek.Etykieta.ToString() == wybrany.Etykieta.ToString() || _krawedzie[j].Drugi_Wierzcholek.Etykieta.ToString() == wybrany.Etykieta.ToString())
                {
                    _krawedzie.RemoveAt(j);
                }
            }

        }
        //odtwarzanie grafu z nowej listy
        private void Usun_w(object sender, RoutedEventArgs args)
        {
            menu11.Visibility = Visibility.Collapsed;
            usuwanie = true;
            usun();
            Clear();
            foreach (Kr e in _krawedzie)
                Rysuj_Kr(e);
            foreach (Wierzcholek n in _wierzcholki)
                Rysuj_W(n);
            usuwanie = false;
            menu = false;
        }

        //czy zostal wybrany jakikolwiek wierzcholek
        private bool Czy_Wi(double x, double y)
        {
            bool _czy = false;
            for (int i = 0; i < _wierzcholki.Count; i++)
            {
                if (_wierzcholki[i].Czy_jest_punkt(new Point(x, y)))
                {
                    _czy = true;
                    break;
                }
            }
            return _czy;
        }
        //Który dokładnie wierzchołek zostal wybrany
        private Wierzcholek Pobierz_wi(double x, double y)
        {
            Wierzcholek rez = null;
            for (int i = 0; i < _wierzcholki.Count; i++)
            {
                if (_wierzcholki[i].Czy_jest_punkt(new Point(x, y)))
                {
                    rez = _wierzcholki[i];
                    break;
                }
            }
            return rez;
        }
        //wybór dwóch różnych wierzchołków,żeby stworzyć krawędź
        private void Dwa_wierzcholki(double x, double y)
        {
            Wierzcholek pierwszy = Pobierz_wi(x, y);
            if (pierwszy != null)
            {
                if (obecny == null)
                {
                    obecny = pierwszy;
                    statusLabel.Content = "Wybrałeś wierzchołek " + pierwszy.Etykieta.ToString() + ". Wybierz kolejny.";
                }
                else
                {
                    if (pierwszy != obecny)
                    {
                        nastepny = pierwszy;
                        statusLabel.Content = "Kliknij,żeby utworzyć graf.";
                    }
                }
            }
        }
        private int Liczba_w(Wierzcholek p)
        {
            for (int i = 0; i < _wierzcholki.Count; i++)
            {
                if (p.Etykieta == _wierzcholki[i].Etykieta)
                {
                    foreach (Kr krawedz in _wierzcholki[i].Krawedzie)
                    {
                        stopien++;
                    }
                }
            }
            return stopien;
        }
        private int[] Stopnie()
        {
            for (int i = 0; i < _wierzcholki.Count; i++)
            {
                Stopnie_[i] = Liczba_w(_wierzcholki[i]);
                stopien = 0;
                _wierzcholki[i].Stopien = Stopnie_[i];
            }
            return Stopnie_;
        }
        private int[,] Pary_wierzcholkow()
        {
            for (int i = 0; i < _krawedzie.Count; i++)
            {
                pary_w[i3, 0] = Convert.ToInt32(_krawedzie[i].Pierwszy_Wierzcholek.Etykieta);
                pary_w[i3, 1] = Convert.ToInt32(_krawedzie[i].Drugi_Wierzcholek.Etykieta);
                i3++;
                pary_w[i3, 0] = Convert.ToInt32(_krawedzie[i].Drugi_Wierzcholek.Etykieta);
                pary_w[i3, 1] = Convert.ToInt32(_krawedzie[i].Pierwszy_Wierzcholek.Etykieta);
                i3++;
                //    wartosc1 += "Tab(" + pary_w[i, 0].ToString()+","+pary_w[i, 1].ToString()+ ")\r\n";
                //    tekst.Content += wartosc1;
            }
            for (int j = 0; j < pary_w.Length / 2; j++)
            {
                // wartosc1 += "Tab(" + pary_w[j, 0].ToString() + "," + pary_w[j, 1].ToString() + ")"+pary_w.LongLength.ToString()+"\r\n";

                // tekst.Content = wartosc1;
            }
            return pary_w;
        }
        private int[,] Tablica()
        {
            //for (int i = 0; i < 50; i++)
            //{
            //    if(Stopnie_[i]!=0)
            //    {
            //    if(_wierzcholki[i1].Stopien==Stopnie_[i])
            //    {
            //        Stopnie1[i1,0] = _wierzcholki[i1].Stopien;
            //        Stopnie1[i1, 1] = Convert.ToInt32(_wierzcholki[i1].Etykieta);
            //       // _wierzcholki[i
            //       // i1++;
            //       // break;
            //    }
            //    }
            //}
            ///////

            //  i1 = 0;
            //  i2 = 0;
            //   Stopnie();
            //for (int i = 0; i < Stopnie_.Length; i++)
            //{
            //   // if (Stopnie_[i] != 0 && _wierzcholki[i].Stopien!=-1)
            //   // {
            //        while (_wierzcholki[i1].Stopien != Stopnie_[i] && _wierzcholki[i1].Stopien !=-1)
            //        { 
            //            i1++; 
            //        }
            //        Stopnie1[i2, 0] = _wierzcholki[i1].Stopien;
            //        Stopnie1[i2, 1] = Convert.ToInt32(_wierzcholki[i1].Etykieta);
            //        _wierzcholki[i1].Stopien = -1;
            //        i2++;
            //        i1 = 0;
            //       // break;
            //  // }
            // //   i1 = 0;
            //}
            ////     int[] Stopnie_ = Stopnie();
            Stopnie();
            Array.Sort(Stopnie_);
            Array.Reverse(Stopnie_);
            statusLabel.Content = "St_max:" + Stopnie_[0].ToString();
            // statusLabel.Content = "St2:" + _wierzcholki[1].Stopien.ToString(); 
            //  i1 = 0;
            for (int i = 0; i < _wierzcholki.Count; i++)
            {
                while (_wierzcholki[i1].Stopien != Stopnie_[i] || _wierzcholki[i1].Stopien == -1)
                {
                    i1++;
                }
                Stopnie1[i2, 0] = _wierzcholki[i1].Stopien;
                Stopnie1[i2, 1] = Convert.ToInt32(_wierzcholki[i1].Etykieta);
                _wierzcholki[i1].Stopien = -1;
                i2++;
                i1 = 0;

            }
            //   statusLabel.Content = "St2:" + _wierzcholki[1].Stopien.ToString(); 
            //  statusLabel.Content = "St_max:" + Stopnie_[0].ToString(); 
            statusLabel.Content = "Nr:" + Stopnie1[1, 1].ToString() + " St:" + Stopnie1[1, 0].ToString();
            return Stopnie1;
        }
        private void button12_Click(object sender, RoutedEventArgs e)
        {
            //int[] Stopnie_ = Stopnie();
            //Array.Sort(Stopnie_);
            //Array.Reverse(Stopnie_);
            Tablica();
            //   statusLabel.Content = "St_max:" + Stopnie_[0];
            //   statusLabel.Content = "Nr:" + Stopnie1[1, 1].ToString() + " St:" + Stopnie1[1, 0].ToString();
            List<SolidColorBrush> kolory2 = T();
            _lista.Clear();
            licz++;
            if (Czy())
            {
                for (int i = 0; i < _wierzcholki.Count; i++)
                {
                    while ((_wierzcholki[Stopnie1[i, 1] - 1].Kolorowanie) && i < _wierzcholki.Count - 1)
                    {
                        i++;
                    }
                    aktualny2 = _wierzcholki[Stopnie1[i, 1] - 1];
                    //        // statusLabel.Content = "wierzcholek:" + _wierzcholki[0].Etykieta.ToString();
                    //        // aktualny2 = Podaj1();
                    found = false;
                    if (_lista.Count == 0)
                    {
                        _lista.Add(aktualny2);
                        aktualny2.Kolorowanie = true;
                        aktualny2.Kolor = kolory2[licz];
                        Rysuj_W(aktualny2);
                        //           // aktualny2 = _wierzcholki[Stopnie1[i+1, 1] - 1];
                        //           // statusLabel.Content = "aktualny:" + aktualny2.Etykieta.ToString();
                        aktualny2 = Podaj1();
                        //            //statusLabel.Content = "wierzcholek:" + _wierzcholki[0].Etykieta.ToString();
                    }
                    //        // statusLabel.Content = "wierzcholek:" + _wierzcholki[0].Etykieta.ToString();
                    if (aktualny2 != null && !(aktualny2.Kolorowanie))
                    {
                        for (int j = 0; j < _lista.Count; j++)
                        {
                            aktualny3 = _lista[j];
                            //   // if (aktualny2 != null && aktualny3 != null)
                            //    // {
                            if (czy(aktualny2, aktualny3))
                            {
                                found = true;
                            }
                            //    //}
                        }

                        //            // statusLabel.Content = aktualny2.Etykieta.ToString();
                        //            // statusLabel.Content = found.ToString();
                        if (!(found))
                        {
                            _lista.Add(aktualny2);
                            aktualny2.Kolorowanie = true;
                            aktualny2.Kolor = kolory2[licz];
                            Rysuj_W(aktualny2);
                        }
                        //            //// aktualny2 = Podaj();
                        //            //// statusLabel.Content = aktualny2.Etykieta.ToString();
                    }
                    else
                    {
                    }
                }
            }
            else
            {
                statusLabel.Content = "Pokolorowany";
                panel.Visibility = Visibility.Collapsed;
                statusLabel.Content = "Liczba chromatyczna wynosi:" + licz.ToString();

            }

        }
        private void button14_Click(object sender, RoutedEventArgs e)
        {
            //  lista_w[1].Add(4);
            //  lista_w[1].Reverse();
            for (int a = 0; a < 1000; a++)
            {
                lista_w[a] = new List<int>();
            }
            wartosc = "";
            tekst.Content = wartosc;
            for (int i = 0; i < _wierzcholki.Count; i++)
            {
                _wierzcholki[i].Kolorowanie = false;
                Rysuj_W(_wierzcholki[i]);
            }
            _lista.Clear();
            licz = -1;
            //pary_w= Pary_wierzcholkow();
            //  //1 i 3
            //for (int i = 0; i < pary_w.Length / 2; i++)
            //{
            //    if (pary_w[i, 0] == 1)
            //    {
            //        if (pary_w[i, 1] != 4)
            //        {
            //            //lista_w[i4] = new List<int>();
            //            if (lista_w[i4][0] == 0)
            //           { 
            //                lista_w[i4].Add(pary_w[i, 0]);
            //        }
            //            lista_w[i4].Add(pary_w[i, 1]);
            //            i4++;
            //        }
            //        else { 
            //            //int f=lista_w[0][0]; 
            //        }
            //    }
            //}
            //tekst.Content = "Nr:" + lista_w[0][0] + "," + lista_w[0][1]; 
        }
        //Czy odległość między wierzchołkami nie jest zbyt mała.
        private bool Odleglosc_wierzcholkow(Point p)
        {
            bool rez = false;
            double distance;
            for (int i = 0; i < _wierzcholki.Count; i++)
            {
                distance = Pobierz_odl(p, _wierzcholki[i].Srodek);
                if (distance < _sred)
                {
                    rez = true;
                    break;
                }
            }
            return rez;
        }
        private double Pobierz_odl(Point p1, Point p2)
        {
            double xSq = Math.Pow(p1.X - p2.X, 2);
            double ySq = Math.Pow(p1.Y - p2.Y, 2);
            double dist = Math.Sqrt(xSq + ySq);

            return dist;
        }
        private Wierzcholek Utworz_wi(Point p)
        {
            double Wi_SrX = p.X - _sred / 2;
            double Wi_SrY = p.Y - _sred / 2;
            Wierzcholek nowyWi = new Wierzcholek(new Point(Wi_SrX, Wi_SrY), p, _licznik.ToString(), _sred);
            return nowyWi;
        }
        private void Rysuj_W(Wierzcholek wi)
        {
            //Rysuj wierzcholek
            Ellipse elipsa = new Ellipse();
            elipsa.Stroke = Brushes.Black;

            if (!wi.Kolorowanie)
                elipsa.Fill = zwykly;
            if (wi.Kolorowanie)
                elipsa.Fill = wi.Kolor;
            elipsa.Width = _sred;
            elipsa.Height = _sred;

            elipsa.SetValue(Canvas.LeftProperty, wi.Gdzie.X);
            elipsa.SetValue(Canvas.TopProperty, wi.Gdzie.Y);
            elipsa.SetValue(Canvas.ZIndexProperty, 2);
            //dodawanie 
            elipsa.Name = "Elipsa" + _licznikF.ToString();
            wi.Nazwa = elipsa.Name;
            myGrid.Children.Add(elipsa);


            //dodaj numer
            TextBlock tb = new TextBlock();
            tb.Text = wi.Etykieta;
            tb.Foreground = Brushes.White;
            tb.FontSize = _Rozm;
            tb.TextAlignment = TextAlignment.Center;
            tb.SetValue(Canvas.LeftProperty, wi.Srodek.X - (_Rozm / 4 * wi.Etykieta.Length));
            tb.SetValue(Canvas.TopProperty, wi.Srodek.Y - _Rozm / 2 - 2);
            tb.SetValue(Canvas.ZIndexProperty, 3);

            //dodaj 
            myGrid.Children.Add(tb);
            //double licznik = 0;
            // licznik++;
            //statusLabel.Content = licznik;
            _licznikF++;
        }
        private Kr Utworz_kr(Wierzcholek wi1, Wierzcholek wi2)
        {
            return new Kr(wi1, wi2);
        }

        private void Rysuj_Kr(Kr krawedz)
        {
            //rysuj krawedz
            Line linia = new Line();
            linia.StrokeThickness = 1;

            linia.X1 = krawedz.Pierwszy_Wierzcholek.Srodek.X;
            linia.X2 = krawedz.Drugi_Wierzcholek.Srodek.X;

            linia.Y1 = krawedz.Pierwszy_Wierzcholek.Srodek.Y;
            linia.Y2 = krawedz.Drugi_Wierzcholek.Srodek.Y;

            if (!krawedz.Kolorowanie)
            {
                linia.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
                krawedz.Nr_kolor = -1;
            }
            //if (edge.Kolorowanie)
            //    linia.Stroke = kolor;
            //if (!wi.Kolorowanie)
            // elipsa.Fill = zwykly;
            if (krawedz.Kolorowanie)
                linia.Stroke = krawedz.Kolor;
            //elipsa.Fill = wi.Kolor;
            // linia.SetValue(Canvas.ZIndexProperty, 1);
            linia.Name = "Linia" + _licznikF.ToString();
            krawedz.Nazwa = linia.Name;
            krawedz.Etykieta = _licznikK;
            myGrid.Children.Add(linia);
            _licznikK++;
            Stopnie();
            //int[] Stopnie_ = Stopnie();
            //Array.Sort(Stopnie_);
            //Array.Reverse(Stopnie_);
            //Tablica();


        }
        //Czy wierzchołki p i e mają ze sobą połączenie w grafie
        private bool czy(Wierzcholek p, Wierzcholek e)
        {
            for (int i = 0; i < _wierzcholki.Count; i++)
            {
                if (_wierzcholki[i] != null)
                {
                    if (p.Etykieta == _wierzcholki[i].Etykieta)
                    {
                        foreach (Kr krawedz in _wierzcholki[i].Krawedzie)
                        {
                            //for (int j = 0; j < _krawedzie.Count; j++)
                            //{
                            if (krawedz.Pierwszy_Wierzcholek.Etykieta == p.Etykieta && krawedz.Drugi_Wierzcholek.Etykieta == e.Etykieta)
                            {
                                return true;
                            }
                            if (krawedz.Drugi_Wierzcholek.Etykieta == p.Etykieta && krawedz.Pierwszy_Wierzcholek.Etykieta == e.Etykieta)
                            {
                                return true;
                            }
                        }
                    }
                    // else
                }
                // else { return true; }  // return false;
            }
            return false;
        }
        private List<int> S_krawedzi(Kr e)
        {
            for (int i = 0; i < e.Etykieta - 1; i++)
            {
                if (_krawedzie[i].Pierwszy_Wierzcholek != e.Pierwszy_Wierzcholek && _krawedzie[i].Pierwszy_Wierzcholek != e.Drugi_Wierzcholek && _krawedzie[i].Drugi_Wierzcholek != e.Pierwszy_Wierzcholek && _krawedzie[i].Drugi_Wierzcholek != e.Drugi_Wierzcholek)
                {
                    //_listas.Add(_krawedzie[i]);
                    //wartosc += ("P:" + _krawedzie[i].Pierwszy_Wierzcholek.Etykieta + ",D:" + _krawedzie[i].Drugi_Wierzcholek.Etykieta);
                    //tekst.Content = wartosc;
                    //lista_k.Add(_krawedzie[i].Nr_kolor);
                    //wartosc += _krawedzie[i].Nr_kolor;
                    //// tekst.Content = wartosc;
                }
                else
                {
                    _listas.Add(_krawedzie[i]);
                    wartosc += ("P:" + _krawedzie[i].Pierwszy_Wierzcholek.Etykieta + ",D:" + _krawedzie[i].Drugi_Wierzcholek.Etykieta);
                    tekst.Content = wartosc;
                    lista_k.Add(_krawedzie[i].Nr_kolor);
                    wartosc += _krawedzie[i].Nr_kolor;
                    // tekst.Content = wartosc;
                }
            }
            //  tekst.Content = ("K:" + e.Etykieta);
            return lista_k;
        }
        private int Nr_k(Kr e)
        {
            List<int> lista = new List<int>();
            lista = S_krawedzi(e);
            for (i5 = 0; i5 < 20; i5++)
            {
                if (!lista.Contains(i5))
                {
                    break;
                }
            }
            lista_k.Clear();
            lista.Clear();
            statusLabel.Content = ("Nr:" + i5);
            return i5;
        }
        bool Czy_multikolorowanie()
        {
            for (int i = 0; i < _wierzcholki.Count; i++)
            {
                if (_wierzcholki[i].Multikolorowanie == false)
                { return true; }
            }
            return false;
        }
        bool Czy_niezalezne(List<Wierzcholek> w1, Wierzcholek n)
        {
            // for (int i = 0; i < _wierzcholki.Count; i++)
            //  {
            //   w.Add(_wierzcholki[0]);
            //   _wierzcholki[0].Multikolorowanie = true;
            for (int j = 0; j < _zbiory.Count; j++)
            {
                if (!(czy(n, _zbiory[j])))
                {
                    //   wartosc += ("nr:NZ:" +_zbiory[j].Etykieta.ToString() + ",\r");
                    //  tekst.Content = wartosc;
                    // return true;
                }
                else
                { return false; }
            }
            //}
            return true;
        }
        private List<Wierzcholek> zbiory_niez(List<Wierzcholek> w)
        {
            for (int i = 0; i < _wierzcholki.Count; i++)
            {
                if (w.Count == 0 && _wierzcholki[i].Multikolorowanie == false)
                {
                    w.Add(_wierzcholki[i]);
                    _wierzcholki[i].Multikolorowanie = true;
                    //   wartosc += ("nr:__" + _wierzcholki[i].Etykieta.ToString() + ",\r");
                    //  tekst.Content = wartosc;
                }
                if (w.Count > 0 && _wierzcholki[i].Multikolorowanie == false)
                {
                    if (Czy_niezalezne(w, _wierzcholki[i]) && _wierzcholki[i].Multikolorowanie == false)
                    {
                        w.Add(_wierzcholki[i]);
                        _wierzcholki[i].Multikolorowanie = true;
                        //    wartosc += ("nr:" + _wierzcholki[i].Etykieta.ToString() + ",\r");
                        //   tekst.Content = wartosc;
                    }
                }
                //   wartosc += ("nr:" + _wierzcholki[i].Etykieta.ToString() + ",\r");
                //  tekst.Content = wartosc;
            }
            return w;
        }
        //Czytnik z podanego pliku XML do tablicy(wierzchołki i krawędzie są też zapisane w postaci listy...)
        private double[] Czytnik(string nazwa)
        {
            string red = "";
            double[] graf1 = new double[1000];
            double graf3 = -1;
            double[,] graf = new double[20, 20];
            XmlDocument dokument = new XmlDocument();
            if (nazwa != "")
            {
                dokument.Load(nazwa);
                XmlElement xmlElement = dokument.DocumentElement;
                int jj = 0;
                // int ii = 0;
                for (int i = 0; i < xmlElement.ChildNodes.Count; i++)
                {
                    red += '0';
                    graf1[jj] = 0;
                    jj++;
                    ii++;
                    XmlNode xmlWierzcholek = xmlElement.ChildNodes[i];
                    for (int j = 0; j < xmlWierzcholek.ChildNodes.Count; j++)
                    {
                        //   ii++;
                        //   string Nazwa = xmlWierzcholek.ChildNodes[j].Name;
                        string Wartosc = xmlWierzcholek.ChildNodes[j].ChildNodes[0].Value;
                        graf3 = Convert.ToDouble(Wartosc);
                        // red += Wartosc;
                        graf1[jj] = graf3;
                        jj++;
                    }
                }
            }
            else { MessageBox.Show("Nie podano nazwy pliku."); panel.Visibility = Visibility.Collapsed; }
            return graf1;
        }

        public void odcinek(int a, int b)
        {
            Line mL = new Line();
            mL.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
            mL.StrokeThickness = 1;
            mL.X1 = p[a].X;
            mL.Y1 = p[a].Y;
            mL.X2 = p[b].X;
            mL.Y2 = p[b].Y;
            myGrid.Children.Add(mL);
        }
        public void wierzcholki(int W)
        {
            double x, y;
            double alfa = 0;
            string punkt_na_grafie;
            for (int i = 1; i <= W; i++)
            {
                Ellipse myE = new Ellipse();
                SolidColorBrush wypelnienie = new SolidColorBrush();
                myE.Stroke = Brushes.Black;
                wypelnienie.Color = Colors.Blue;
                myE.StrokeThickness = 1;
                myE.Fill = wypelnienie;
                myE.Width = 25;
                myE.Height = 25;

                //foreach (Wierzcholek n in _wierzcholki)
                //    Rysuj_W(n);

                x = Math.Sin(alfa * (Math.PI / 180)) * 150;
                y = Math.Cos(alfa * (Math.PI / 180)) * 150;

                p[i] = new Point(280 - x, 165 - y);
                Canvas.SetTop(myE, 152 - y);
                Canvas.SetLeft(myE, 268 - x);

                punkt_na_grafie = Convert.ToString(i);
                Text(277 - x, 135 - y, punkt_na_grafie, Colors.Black);

                alfa += 360 / W;
                myGrid.Children.Add(myE);
            }
        }

        public void Text(double x, double y, string tekst, Color kolor)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = tekst;
            Canvas.SetLeft(textBlock, x);
            Canvas.SetTop(textBlock, y);
            myGrid.Children.Add(textBlock);
        }

        public void clear()
        {
            for (int a = 0; a < lw + 1; a++)
                for (int b = 0; b < lw + 1; b++)
                    tp[a, b] = false;

            for (int a = 0; a <= lw; a++)
                for (int b = 0; b <= lw; b++)
                    t[a, b] = 0;
            //for (int i = 0; i <= 30; i++)
            //    komiw[i] = "";
            //for (int a = 0; a < 20; a++)
            //    for (int b = 0; b < 20; b++)
            //        wag[a, b] = 0;

          
            tekst.Content = "";
            //Rectangle rect = new Rectangle();
            //myGrid.Children.Remove(rect);   //hehe
            //rect.Fill = Brushes.White;
            //Canvas.SetTop(rect, -100);
            //rect.Height = 450;
            //rect.Width = 500;
            //myGrid.Children.Add(rect);
            //textBox1.Text = "";

        }
        public void button2_Click(object sender, RoutedEventArgs e)
        {
            double alpha = 0, x1, y1;
            Point[] p1 = new Point[21];
            string tekst;
            // int i1;
            panel.Visibility = Visibility.Visible;
            Clear();
            clear();
            int stopien;
            Random x = new Random();
            Random st = new Random();

            lw = x.Next(3, 12);         //liczba wierzchołków w trybie losowym;

            for (int w = 1; w <= lw; w++)
            {
                x1 = Math.Sin(alpha * (Math.PI / 180)) * 150;
                y1 = Math.Cos(alpha * (Math.PI / 180)) * 150;

                p1[w] = new Point(280 - x1, 165 - y1);

                tekst = Convert.ToString(w);

                Wierzcholek s = Utworz_wi(p1[w]);
                _wierzcholki.Add(s);
                Rysuj_W(s);
                _licznik++;
                alpha += 360 / lw;
            };
            Wierzcholek aktualny;
            Wierzcholek kolejny;
            for (int a = 0; a < lw; a++)
            {

                stopien = st.Next(2, lw - 1);
                for (int z = 1; z < stopien; z++)
                {
                    if ((a + z) < lw)
                    {
                        kolejny = _wierzcholki[a + z];
                        t[a + z, 1] = a + z;
                        t[1, a + z] = 1;
                    }
                    else
                    {
                        t[a + 1, 1] = a + 1;
                        t[1, a + 1] = 1;
                        kolejny = _wierzcholki[0];          //zamyka losowy cykl                 
                    }
                    aktualny = _wierzcholki[a];
                    Kr krawedz = Utworz_kr(aktualny, kolejny);
                    aktualny.Krawedzie.Add(krawedz);
                    _krawedzie.Add(krawedz);
                    kolejny.Krawedzie.Add(krawedz);
                    //_kolejny.Krawedzie.Add(krawedz);
                    Rysuj_Kr(krawedz);
                    t[a, a + z] = a;
                    t[a + z, a] = a + z;
                }
            }
        }


        public void button4_Click(object sender, RoutedEventArgs e)
        {
            panel.Visibility = Visibility.Collapsed;
            clear();
            Clear();
        }

        public void button3_Click(object sender, RoutedEventArgs e)
        {
            panel.Visibility = Visibility.Collapsed;
            clear();
            Clear();
            int n = 0, o = 2, m = 4;
            wierzcholki(w);
            //lw = w;
            //for (int i = 1; i <= k; i++)
            //{//konwersja:  string na char na int :)...
            //    a = Convert.ToInt32(my_char[n]) - 48;
            //    b = Convert.ToInt32(my_char[m]) - 48;
            //    c = Convert.ToInt32(my_char[o]) - 48;

            //    odcinek(a, b);
            //    n += 6; o += 6; m += 6;
            //    wag[a, b] = c;
            //    wag[b, a] = c;

            //    t[a, b] = a;
            //    t[b, a] = b;

            //    waga(a, b, c);
            //}
        }
        public void waga(int a, int b, int c)
        {
            //string waga_krawedz = "";
            //double xn, yn;
            //waga_krawedz = Convert.ToString(c);

            //xn = (p[a].X + p[b].X) * 0.5;
            //yn = (p[a].Y + p[b].Y) * 0.5 - 20;

            //Text(xn, yn, waga_krawedz, Colors.Black);
        }

        private void xml_ile_w(object sender, TextChangedEventArgs e)
        {
      
        }

        private void xml_ile_k(object sender, TextChangedEventArgs e)
        {
    
        }

        private void poczatek_koniec(object sender, TextChangedEventArgs e)
        {
       
        }
        public void textBox4_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (textBox4.Text == "") po = 1;
            //else
            //    po = Convert.ToInt32(textBox4.Text);
            //if ((po > lw) || (po == 0)) { po = 1; textBox4.Text = "1"; }
        }

        public void textBox12_TextChanged(object sender, TextChangedEventArgs e)
        {
            string ll = Convert.ToString(l);
            //textBox12.AppendText(ll);
            //textBox12.Text = ll;
        }
     

        public int[,] t = new int[22, 22];
        List<int> q = new List<int>();
        public bool[] odwiedzony = new bool[21];
        public string wartosc;

        public int l = 0;
        public string liczby;
        //string[] komiw = new string[100];
        public void start()
        {
            q.Clear();
          
            tekst.Content = "";
            //textBox1.Visibility = Visibility.Visible;
            //tekst.Visibility = Visibility.Collapsed;
            //textBox1.AppendText("");
            for (int i = 1; i <= 19; i++) odwiedzony[i] = false;
            l = 0;
         
        }
      

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            int l1 = 0, l2 = 0;
            int suma = 0;
            char[] my_kom = new char[40];
            char[] cha = new char[40];
            for (int i = 1; i <= l; i++)
            {

                suma = 0;

                //String my_ch = komiw[i];
                //for (int y = 0; y < my_ch.Length; y++)
                //{
                //    cha[y] = my_ch[y];
                //}
                l1 = 0; l2 = 0;
                for (int z = 0; z < 3 * w - 3; z += 3)
                {
                    l1 = Convert.ToInt32(cha[z]) - 48;
                    l2 = Convert.ToInt32(cha[z + 3]) - 48;
                    if (l2 == 0) l2 = po;
                    suma += wag[l1, l2];
                    // textBox7.AppendText(" - (" + wag[l1,l2] + ")" );
                    // textBox7.AppendText(" - (" + l1 + ")" + " - (" + l2 + ")");
                }

                suma += wag[po, l2];
                //textBox7.AppendText(" - (" + suma + ")" + "\r\n");
                //textBox7.AppendText("\r\n");
            }
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            panel.Visibility = Visibility.Visible;
            Clear();
            double alpha = 0, x1, y1;
            Point[] p1 = new Point[21];

            Random x = new Random();
            Random st = new Random();
            do
            {
                lw = x.Next(15, 21);         //liczba wierzchołków w trybie losowym;
            }
            while ((lw == 19) || (lw == 16));
            for (int w = 1; w <= lw; w++)
            {
                x1 = Math.Sin(alpha * (Math.PI / 180)) * 150;
                y1 = Math.Cos(alpha * (Math.PI / 180)) * 150;

                p1[w] = new Point(280 - x1, 165 - y1);
                Wierzcholek s = Utworz_wi(p1[w]);
                _wierzcholki.Add(s);
                Rysuj_W(s);
                _licznik++;
                alpha += 360 / lw;
            };
            Wierzcholek aktualny;
            Wierzcholek kolejny;
            for (int a = 0; a < lw; a++)
            {
                for (int z = 1; z <= lw; z++)
                {
                    if ((a + z) < lw)
                    {
                        kolejny = _wierzcholki[a + z];
                    }
                    else
                        kolejny = _wierzcholki[0];          //zamyka losowy cykl                 
                    aktualny = _wierzcholki[a];
                    Kr krawedz = Utworz_kr(aktualny, kolejny);
                    aktualny.Krawedzie.Add(krawedz);
                    _krawedzie.Add(krawedz);
                    kolejny.Krawedzie.Add(krawedz);
                    //_kolejny.Krawedzie.Add(krawedz);
                    Rysuj_Kr(krawedz);
                }
            }
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Projekt magisterski" +  "\r\n" + "Barbara Litwin", "ZTSI");
        }
        //Tworzenie pliku XML o danej nazwie wierzchołki są określone wraz z ich położeniem
        private void XML(string nazwa)
        {
            if (_wierzcholki.Count > 0)
            {
                if (nazwa != "")
                {
                    using (XmlWriter writer = XmlWriter.Create(nazwa))
                    {
                        writer.WriteStartDocument();
                        writer.WriteStartElement("wierzcholki");
                        for (int i = 0; i < _wierzcholki.Count; i++)
                        {
                            writer.WriteStartElement("wierzcholek");
                            writer.WriteStartElement("numer");
                            string numer = _wierzcholki[i].Etykieta.ToString();
                            writer.WriteString(numer);
                            writer.WriteEndElement();

                            writer.WriteStartElement("X");
                            string X = _wierzcholki[i].Gdzie.X.ToString();
                            writer.WriteString(X);
                            writer.WriteEndElement();

                            writer.WriteStartElement("Y");
                            string Y = _wierzcholki[i].Gdzie.Y.ToString();
                            writer.WriteString(Y);
                            writer.WriteEndElement();
                            foreach (Kr krawedz in _wierzcholki[i].Krawedzie)
                            {
                                if (krawedz.Pierwszy_Wierzcholek != _wierzcholki[i])
                                {
                                    writer.WriteStartElement("krawedz");
                                    string krawedz1 = krawedz.Pierwszy_Wierzcholek.Etykieta.ToString();
                                    writer.WriteString(krawedz1);
                                    writer.WriteEndElement();
                                }
                                if (krawedz.Drugi_Wierzcholek != _wierzcholki[i])
                                {
                                    writer.WriteStartElement("krawedz");
                                    string krawedz2 = krawedz.Drugi_Wierzcholek.Etykieta.ToString();
                                    writer.WriteString(krawedz2);
                                    writer.WriteEndElement();
                                }

                            }
                            writer.WriteEndElement();
                        }

                        writer.WriteEndElement();
                        writer.WriteEndDocument();

                    }
                }
                else { MessageBox.Show("Nie podano nazwy pliku."); panel.Visibility = Visibility.Collapsed; }
            }
            else { MessageBox.Show("Przed zapisaniem narysuj graf."); panel.Visibility = Visibility.Collapsed; }
        }
        private void Zapisz_graf(object sender, RoutedEventArgs args)
        {
            if (_wierzcholki.Count > 0)
            {
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = ""; // Nazwa pliku
                dlg.DefaultExt = ".xml"; // rozszerzenie pliku
                dlg.Filter = "Pliki xml (.xml)|*.xml"; // filtruj według rozszerzenia

                Nullable<bool> result = dlg.ShowDialog();
                if (result == true)
                {
                    // Zapisz dokument
                    string filename = dlg.FileName;
                }
                string nazwa = dlg.FileName;
                XML(nazwa);
            }
            else { MessageBox.Show("Przed zapisaniem narysuj graf."); }
        }
        private void Odtworz_graf(string nazwa)
        {
            clear();
            Clear();
            panel.Visibility = Visibility.Visible;
            double[] graf = new double[100];
            graf = Czytnik(nazwa);
            int i1 = 0;
            double max = 0;
            for (i1 = 1; i1 < graf.Length; i1++)
            {

                if ((graf[i1] != 0) && (graf[i1 - 1] == 0))
                {
                    if (graf[i1] > max)
                        max = graf[i1];
                }
            }
            int i2 = 0;
            Point[] p17 = new Point[21];
            for (int j = 0; j < graf.Length; j++)
            {
                if ((graf[j] != 0) && (graf[j - 1] == 0))
                {
                    double x1 = graf[j + 1];
                    double y1 = graf[j + 2];
                    p17[i2] = new Point(x1, y1);
                    i2++;
                }
            }
            for (int w = 0; w < max; w++)
            {
                Wierzcholek s = Utworz_wi(p17[w]);
                _wierzcholki.Add(s);
                Rysuj_W(s);
                _licznik++;

            };
            Wierzcholek aktualny;
            Wierzcholek kolejny;
            int ii = 0;
            while (ii < graf.Length - 10)
            {
                ii++;

                if ((graf[ii] != 0) && (graf[ii - 1] == 0))
                {
                    int wartosc = Convert.ToInt32(graf[ii] - 1);
                    aktualny = _wierzcholki[wartosc];
                    ii++;
                    ii++;
                    ii++;
                    while ((graf[ii] != 0) && (graf[ii - 1] != 0))
                    {
                        int wartosc1 = Convert.ToInt32(graf[ii] - 1);
                        kolejny = _wierzcholki[wartosc1];
                        Kr krawedz = Utworz_kr(aktualny, kolejny);
                        aktualny.Krawedzie.Add(krawedz);
                        _krawedzie.Add(krawedz);
                        kolejny.Krawedzie.Add(krawedz);
                        Rysuj_Kr(krawedz);
                        ii++;
                    }
                }
            }
        }
        private void Odczytaj_graf(object sender, RoutedEventArgs args)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = ""; // Nazwa pliku
            dlg.DefaultExt = ".xml"; //rozszerzenie pliku
            dlg.Filter = "Pliki (.xml)|*.xml"; // Filtruj według rozszerzenia

            // Otwórz dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Otwiera rezultat
            if (result == true)
            {
                // Otwórz dokument
                string filename = dlg.FileName;
            }
            string nazwa = dlg.FileName;
            Odtworz_graf(nazwa);

        }

        //Tutaj z tablicy zczytanej z pliku XML jest odtwarzany graf
        private void button8_Click(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = ""; // Default file name
            dlg.DefaultExt = ".xml"; // Default file extension
            dlg.Filter = "Pliki (.xml)|*.xml"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
            }
            string nazwa = dlg.FileName;
            Odtworz_graf(nazwa);

        }
        //paleta barw w postaci listy
        public static List<SolidColorBrush> T()
        {
            var kolory = new List<SolidColorBrush>
            {
                 new SolidColorBrush(Colors.Chocolate),
                 new SolidColorBrush(Colors.DarkViolet),
                 new SolidColorBrush(Colors.LawnGreen),
                 new SolidColorBrush(Colors.Orange),
                 new SolidColorBrush(Colors.Silver),
                 new SolidColorBrush(Colors.Cyan),
                 new SolidColorBrush(Colors.AliceBlue),
                 new SolidColorBrush(Colors.Aquamarine),
                 new SolidColorBrush(Colors.Black),
                 new SolidColorBrush(Colors.Red),
                 new SolidColorBrush(Colors.Blue),
                 new SolidColorBrush(Colors.Yellow),
                 new SolidColorBrush(Colors.Pink),
                 new SolidColorBrush(Colors.Cyan),
                 new SolidColorBrush(Colors.Magenta),
                 new SolidColorBrush(Colors.SkyBlue),
                 new SolidColorBrush(Colors.Gold),
                 new SolidColorBrush(Colors.Honeydew),
                 new SolidColorBrush(Colors.RosyBrown),
                 new SolidColorBrush(Colors.RoyalBlue),
                 new SolidColorBrush(Colors.DarkOrchid),
            };

            return kolory;
        }
        //usuwanie elementów klasy Ellipse,Line i TextBlock
        private void Clear()
        {
            wartosc = "";
            tekst.Content = wartosc;
            if (!usuwanie)
            {
                this._wierzcholki.Clear();
                this._krawedzie.Clear();
                i1 = 0;
                i2 = 0;
                stopien = 0;
                licz = -1;

            }
            if (_wierzcholki.Count == 0)
            {
                this._licznik = 1;
            }
            //else 
            //{ _licznik=_licznik; }
            // licz = 0;
            UIElement[] tmp = new UIElement[myGrid.Children.Count];
            myGrid.Children.CopyTo(tmp, 0);
            foreach (UIElement uielement in tmp)
            {
                Ellipse elipsa = uielement as Ellipse;
                Line linia = uielement as Line;
                TextBlock tekst1 = uielement as TextBlock;
                myGrid.Children.Remove(tekst1);
                if (linia != null && linia.Name != null)
                {
                    myGrid.Children.Remove(linia);
                }
                if (elipsa != null && elipsa.Name != null)
                {
                    myGrid.Children.Remove(elipsa);
                    myGrid.Children.Remove(linia);
                }
            }
        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            clear();
            Clear();
            statusLabel.Content = "Kliknij,aby narysować graf.";
        }
        //Czy istniej niepokolorowany wierzchołek
        private bool Czy()
        {
            bool jest = false;
            for (int i = 0; i < _wierzcholki.Count; i++)
            {
                if (!(_wierzcholki[i].Kolorowanie))
                    jest = true;
                // if ((_wierzcholki[i].Kolorowanie))
                //    jest = false;
            }
            return jest;
        }
        //Wskaż pierwszy niepokolorowany wierzchołek w grafie
        private Wierzcholek Podaj()
        {
            int i = 0;
            Wierzcholek p = _wierzcholki[i];
            if (Czy())
            {
                while ((_wierzcholki[i].Kolorowanie) && i < _wierzcholki.Count - 1)
                {
                    i++;
                }
            }
            else { p = null; }
            return p;
        }
        private Wierzcholek Podaj1()
        {
            int i = 0;
            Wierzcholek p = _wierzcholki[Stopnie1[i, 1] - 1];
            if (Czy())
            {
                // for (int j = 0; j < _wierzcholki.Count; j++)
                // {
                while ((_wierzcholki[Stopnie1[i, 1] - 1].Kolorowanie) && i < _wierzcholki.Count - 1 && Stopnie1[i, 1] != 0)
                {
                    //   statusLabel.Content = "petla";
                    i++;
                }
                //}
            }
            else { p = null; }
            return p;
        }
        //Algorytm kolorowania grafu
        private void button11_Click(object sender, RoutedEventArgs e)
        {
            List<SolidColorBrush> kolory2 = T();
            _lista.Clear();
            licz++;
            //  Kr krawedz = _krawedzie[0];
            //  krawedz.Kolorowanie = true;
            //  krawedz.Kolor = kolory2[0];
            //  krawedz.Nr_kolor = 0;
            //  //lista_k.Add(0);
            //  Rysuj_Kr(krawedz);
            // // S_krawedzi(_krawedzie[0]);
            ////  Nr_k(_krawedzie[1]);
            //  for (int a = 1; a < _krawedzie.Count; a++)
            //  {
            //      int nr = Nr_k(_krawedzie[a]);
            //      _krawedzie[a].Kolorowanie = true;
            //      _krawedzie[a].Kolor = kolory2[nr];
            //      _krawedzie[a].Nr_kolor = nr;
            //      Rysuj_Kr(_krawedzie[a]);
            //  }
            if (Czy())
            {
                for (int i = 0; i < _wierzcholki.Count; i++)
                {
                    while ((_wierzcholki[i].Kolorowanie) && i < _wierzcholki.Count - 1)
                    {
                        i++;
                    }
                    aktualny2 = _wierzcholki[i];
                    // statusLabel.Content = "wierzcholek:" + _wierzcholki[0].Etykieta.ToString();
                    // aktualny2 = Podaj();
                    found = false;
                    if (_lista.Count == 0)
                    {
                        _lista.Add(aktualny2);
                        aktualny2.Kolorowanie = true;
                        aktualny2.Kolor = kolory2[licz];
                        Rysuj_W(aktualny2);
                        aktualny2 = Podaj();
                        //statusLabel.Content = "wierzcholek:" + _wierzcholki[0].Etykieta.ToString();
                    }
                    // statusLabel.Content = "wierzcholek:" + _wierzcholki[0].Etykieta.ToString();
                    if (aktualny2 != null && !(aktualny2.Kolorowanie))
                    {
                        for (int j = 0; j < _lista.Count; j++)
                        {
                            aktualny3 = _lista[j];
                            // if (aktualny2 != null && aktualny3 != null)
                            // {
                            if (czy(aktualny2, aktualny3))
                            {
                                found = true;
                            }
                            //}
                        }

                        // statusLabel.Content = aktualny2.Etykieta.ToString();
                        // statusLabel.Content = found.ToString();
                        if (!(found))
                        {
                            _lista.Add(aktualny2);
                            aktualny2.Kolorowanie = true;
                            aktualny2.Kolor = kolory2[licz];
                            Rysuj_W(aktualny2);
                        }
                        // aktualny2 = Podaj();
                        // statusLabel.Content = aktualny2.Etykieta.ToString();
                    }
                    else
                    {
                    }
                }
            }
            else
            {
                statusLabel.Content = "Pokolorowany";
                //  panel.Visibility = Visibility.Collapsed;
                statusLabel.Content = "Liczba chromatyczna wynosi:" + licz.ToString();

            }

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }


        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Algorytm kolorowania grafu, zmienia barwy wierzchołków w grafie, gdzie każda krawędź łączy wierzchołki o różnym kolorze. Liczbą chromatyczna nazywamy liczbę różnych barw użytych podczas wykonywania algorytmu.", "Help");
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void button15_Click(object sender, RoutedEventArgs e)
        {
            List<SolidColorBrush> kolory2 = T();
            _lista.Clear();
            licz++;
            Kr krawedz = _krawedzie[0];
            krawedz.Kolorowanie = true;
            krawedz.Kolor = kolory2[0];
            krawedz.Nr_kolor = 0;
            //lista_k.Add(0);
            Rysuj_Kr(krawedz);
            // S_krawedzi(_krawedzie[0]);
            //  Nr_k(_krawedzie[1]);
            for (int a = 1; a < _krawedzie.Count; a++)
            {
                int nr = Nr_k(_krawedzie[a]);
                _krawedzie[a].Kolorowanie = true;
                _krawedzie[a].Kolor = kolory2[nr];
                _krawedzie[a].Nr_kolor = nr;
                Rysuj_Kr(_krawedzie[a]);
            }
        }

        private void button16_Click(object sender, RoutedEventArgs e)
        {
            //List<Wierzcholek> zbior = zbiory_niez(_zbiory);
            //if(czy(_wierzcholki[2],_wierzcholki[3]))
            int n = 1;
            if (textBox6.Text == "")
            {
                n = 1;
            }
            else
            {
                n = Convert.ToInt32(textBox6.Text);
            }
            multikolory = new int[n];
            for (int j = 0; j < multikolory.Length; j++)
            {
                multikolory[j] = j + 1;
            }
            while (Czy_multikolorowanie())
            {
                zbiory_niez(_zbiory);
                for (int i = 0; i < _zbiory.Count; i++)
                {
                    for (int jj = 0; jj < multikolory.Length; jj++)
                    {
                        _zbiory[i].Multikolory.Add(multikolory[jj]);
                    }
                }
                _zbiory.Clear();
                for (int jjj = 0; jjj < multikolory.Length; jjj++)
                {
                    multikolory[jjj] = multikolory[jjj] + n;
                }
            }
            for (int a = 0; a < _wierzcholki.Count; a++)
            {
                wartosc += ("Nr:" + _wierzcholki[a].Etykieta.ToString() + ",\r");
                tekst.Content = wartosc;
                for (int b = 0; b < _wierzcholki[a].Multikolory.Count; b++)
                {
                    wartosc += ("kolor:" + _wierzcholki[a].Multikolory[b].ToString() + ",\r");
                    tekst.Content = wartosc;
                }
            }
            //_zbiory.Add(_wierzcholki[0]);
            //_zbiory.Add(_wierzcholki[2]);
            //for (int i = 0; i < _zbiory.Count; i++)
            //{
            //    wartosc += ("nr:::::" + _zbiory[i].Etykieta.ToString() + ",\r");
            //    tekst.Content = wartosc;
            //}
            //if(Czy_niezalezne(_zbiory, _wierzcholki[4]))
            //{
            //wartosc += ("nr:Z" + _wierzcholki[4].Etykieta.ToString() + ",\r");
            //tekst.Content = wartosc;
            //}
            //_zbiory.Clear();
            //  zbiory_niez(_zbiory);
        }

        private void multi(object sender, TextChangedEventArgs e)
        {

        }







        //public Klasa()
        //{
        //    InitializeComponent();
        //}

        //private void button9_Click_1(object sender, RoutedEventArgs e)
        //{
        //    Myclas mc = new Myclas();
        //    mc.txtRef = this.textBox1;
        //    mc.metoda();
        //}
    }
    public class Myclas : MainWindow //bez :Klasa tez działa txtRef
    {
        //public TextBox txtRef;
        //public void metoda()
        //{
        //    txtRef.Text = "123 \r\n";
        //}  
    }
}