using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using SerumClassLibrary.BusinessLogic;
using SerumClassLibrary.Models;

namespace SerumApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        System.Globalization.CultureInfo info = System.Globalization.CultureInfo.GetCultureInfo("en-US");
        private float _f0OldPrice;
        private float _f1OldPrice;
        private float _f2OldPrice;
        private float _f3OldPrice;
        private float _f4OldPrice;

        public float F0OldPrice { get { return _f0OldPrice; } set { _f0OldPrice = value; } }
        public float F1OldPrice { get { return _f1OldPrice; } set { _f1OldPrice = value; } }
        public float F2OldPrice { get { return _f2OldPrice; } set { _f2OldPrice = value; } }
        public float F3OldPrice { get { return _f3OldPrice; } set { _f3OldPrice = value; } }
        public float F4OldPrice { get { return _f4OldPrice; } set { _f4OldPrice = value; } }

        // private static string _appComponent = "/SerumApp;component/assets/svg/";
        private static string _svgPathIcon;
        public string SvgPathIcon { get { return _svgPathIcon; } set { _svgPathIcon = value; } }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetTrades();
            DispatcherTimer dispTimer = new DispatcherTimer();
            dispTimer.Tick += new EventHandler(dispTimer_Tick);
            dispTimer.Interval = new TimeSpan(0, 0, 10);
            dispTimer.Start();
        }
        private void dispTimer_Tick(object sender, EventArgs e)
        {
            GetTrades();
        }

        private async void GetTrades()
        {
            // var watch = System.Diagnostics.Stopwatch.StartNew();
            List<TradesPairModel.Rootobject> listTpm = new List<TradesPairModel.Rootobject>();
            TradesPairProcessor t = new TradesPairProcessor();
            await t.GetListOfTradesPairsParallelAsync();
            // watch.Stop();
            // var elapsedMs = watch.ElapsedMilliseconds;
            // MessageBox.Show("Time in ms: " + elapsedMs.ToString());
            listTpm = t.listTradesPair;
            //listTpm = t.GetListOfTradesPairs();
           
            TradesPairModel.Rootobject tradePM = new TradesPairModel.Rootobject();

            // so much code bellow, will implement forearch loop later if posible...

            // 0
            tradePM = listTpm[0];
            lbName0.Content = tradePM.pair;
            SvgPathIcon = "SerumApp;component/assets/svg/" + tradePM.pair.ToString() + ".svg";
            svgImg0.Source = SvgPathIcon;
            //float f0price = tradePM.trade[0].price;
            F0OldPrice = float.Parse(txPrice0.Text);
            txPrice0.Text = tradePM.trade[0].price.ToString();
            SetColorsUpDownPrice(lbBack0, _f0OldPrice, tradePM.trade[0].price);
            F0OldPrice = tradePM.trade[0].price;
            lbSize0.Content = tradePM.trade[0].size;
            lbFee0.Content = tradePM.trade[0].feeCost;
            lbSide0.Content = tradePM.trade[0].side;
            lbTime0.Content = DateTimeOffset.FromUnixTimeMilliseconds(tradePM.trade[0].time).LocalDateTime;

            // 1
            tradePM = listTpm[1];
            lbName1.Content = tradePM.pair;
            SvgPathIcon = "SerumApp;component/assets/svg/" + tradePM.pair.ToString() + ".svg";
            svgImg1.Source = SvgPathIcon;
            //float f0price = tradePM.trade[0].price;
            F1OldPrice = float.Parse(txPrice1.Text);
            txPrice1.Text = tradePM.trade[0].price.ToString();
            SetColorsUpDownPrice(lbBack1, _f1OldPrice, tradePM.trade[0].price);
            F1OldPrice = tradePM.trade[0].price;
            lbSize1.Content = tradePM.trade[0].size;
            lbFee1.Content = tradePM.trade[0].feeCost;
            lbSide1.Content = tradePM.trade[0].side;
            lbTime1.Content = DateTimeOffset.FromUnixTimeMilliseconds(tradePM.trade[0].time).LocalDateTime;

            // 2
            tradePM = listTpm[2];
            lbName2.Content = tradePM.pair;
            SvgPathIcon = "SerumApp;component/assets/svg/" + tradePM.pair.ToString() + ".svg";
            svgImg2.Source = SvgPathIcon;
            //float f0price = tradePM.trade[0].price;
            F2OldPrice = float.Parse(txPrice2.Text);
            txPrice2.Text = tradePM.trade[0].price.ToString();
            SetColorsUpDownPrice(lbBack2, _f2OldPrice, tradePM.trade[0].price);
            F2OldPrice = tradePM.trade[0].price;
            lbSize2.Content = tradePM.trade[0].size;
            lbFee2.Content = tradePM.trade[0].feeCost;
            lbSide2.Content = tradePM.trade[0].side;
            lbTime2.Content = DateTimeOffset.FromUnixTimeMilliseconds(tradePM.trade[0].time).LocalDateTime;
            // 3
            tradePM = listTpm[3];
            lbName3.Content = tradePM.pair;
            SvgPathIcon = "SerumApp;component/assets/svg/" + tradePM.pair.ToString() + ".svg";
            svgImg3.Source = SvgPathIcon;
            //float f0price = tradePM.trade[0].price;
            F3OldPrice = float.Parse(txPrice3.Text);
            txPrice3.Text = tradePM.trade[0].price.ToString();
            SetColorsUpDownPrice(lbBack3, _f3OldPrice, tradePM.trade[0].price);
            F3OldPrice = tradePM.trade[0].price;
            lbSize3.Content = tradePM.trade[0].size;
            lbFee3.Content = tradePM.trade[0].feeCost;
            lbSide3.Content = tradePM.trade[0].side;
            lbTime3.Content = DateTimeOffset.FromUnixTimeMilliseconds(tradePM.trade[0].time).LocalDateTime;
            // 4
            tradePM = listTpm[4];
            lbName4.Content = tradePM.pair;
            SvgPathIcon = "SerumApp;component/assets/svg/" + tradePM.pair.ToString() + ".svg";
            svgImg4.Source = SvgPathIcon;
            //float f0price = tradePM.trade[0].price;
            F4OldPrice = float.Parse(txPrice4.Text);
            txPrice4.Text = tradePM.trade[0].price.ToString();
            SetColorsUpDownPrice(lbBack4, _f4OldPrice, tradePM.trade[0].price);
            F4OldPrice = tradePM.trade[0].price;
            lbSize4.Content = tradePM.trade[0].size;
            lbFee4.Content = tradePM.trade[0].feeCost;
            lbSide4.Content = tradePM.trade[0].side;
            lbTime4.Content = DateTimeOffset.FromUnixTimeMilliseconds(tradePM.trade[0].time).LocalDateTime;

            listTpm = null;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void SetColorsUpDownPrice(Label lbBackColor, float oldPrice, float newPrice)
        {
            Color cUP = Color.FromArgb(255, 33, 216, 50);
            Color CDown = Color.FromArgb(255, 220, 35, 35);
            float fOld = oldPrice;
            float fNew = newPrice;
            if (fNew > fOld)
                lbBackColor.Background = new SolidColorBrush(cUP);
            if (fNew < fOld)
                lbBackColor.Background = new SolidColorBrush(CDown);
            if (fNew == fOld)
                lbBackColor.Background = new SolidColorBrush(Colors.White);
        }
    }
}

// Kudos to xGromovniKx for giving me his source code to build from :D
