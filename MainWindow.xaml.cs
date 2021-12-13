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

namespace gra_statki
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Button[,] visibleBbuttons = new Button[10, 10];
        public bool[,] hiddenButtons = new bool[10, 10];
        public MainWindow()
        {
            InitializeComponent();
            PrezepiszButtonsDoTablicy(visibleBbuttons);
            ClearStatki();
        }

        private void btnLosoj_Click(object sender, RoutedEventArgs e)
        {
            WpiszStatekDoGridu(5);
            WpiszStatekDoGridu(4);
            WpiszStatekDoGridu(3);
            WpiszStatekDoGridu(3);
            WpiszStatekDoGridu(2);
            WpiszStatekDoGridu(2);
            WpiszStatekDoGridu(1);
            WpiszStatekDoGridu(1);
            WpiszStatekDoGridu(1);
        }

        public void WpiszStatekDoGridu(int dlugoscStatku)
        {
            var random = new Random();
            int rowRandom = random.Next(0, 10);
            int columnRandom = random.Next(0, 10);
            int kierunekStatku = random.Next(0, 2); ;

            bool moznaWpisac = false;
            bool wpisanoStatek = false;
            while (!wpisanoStatek)
            {
                rowRandom = random.Next(0, 10);
                columnRandom = random.Next(0, 10);
                kierunekStatku = random.Next(0, 2);

                try
                {
                    if(kierunekStatku == 0)
                    {
                        moznaWpisac = true;
                        for(int i=0; i<dlugoscStatku; i++)
                        {
                            for(int j=-1; j<=1; j++)
                            {
                                for(int k=-1; k<=1; k++)
                                {
                                    if (columnRandom + i + j >= 0 && columnRandom + i + j <= 9 &&
                                        rowRandom + k >= 0 && rowRandom + k <= 9)
                                    {
                                        if(hiddenButtons[columnRandom+i+j, rowRandom+k] == true)
                                        {
                                            moznaWpisac = false;
                                        }
                                    }
                                }
                            }
                        }

                        if(moznaWpisac == true)
                        {
                            for (int i = 0; i < dlugoscStatku; i++)
                            {
                                hiddenButtons[columnRandom + i, rowRandom] = true;
                            }
                            wpisanoStatek = true;
                        }  
                    }
                    else
                    {
                        moznaWpisac = true;
                        for (int i = 0; i < dlugoscStatku; i++)
                        {
                            for (int j = -1; j <= 1; j++)
                            {
                                for (int k = -1; k <= 1; k++)
                                {
                                    if (columnRandom + j >= 0 && columnRandom + j <= 9 &&
                                        rowRandom + i + k >= 0 && rowRandom + i + k <= 9)
                                    {
                                        if (hiddenButtons[columnRandom + j, rowRandom + i + k] == true)
                                        {
                                            moznaWpisac = false;
                                        }
                                    }
                                }
                            }
                        }

                        if (moznaWpisac == true)
                        {
                            for (int i = 0; i < dlugoscStatku; i++)
                            {
                                hiddenButtons[columnRandom, rowRandom + i] = true;
                            }
                            wpisanoStatek = true;
                        }
                    }
                    
                }
                catch
                {
                    wpisanoStatek = false;
                }
            }
        }
        public void ClearStatki()
        {
            for(int i=0; i<10; i++)
            {
                for(int j=0; j<10; j++)
                {
                    visibleBbuttons[i, j].Background = Brushes.LightSeaGreen;
                    visibleBbuttons[i, j].Content = string.Empty;
                    hiddenButtons[i, j] = false;
                }
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearStatki();
        }

        public bool SetPole(int column, int row)
        {
            if (visibleBbuttons[column, row].Background != Brushes.Blue)
            {
                visibleBbuttons[column, row].Background = Brushes.Blue;
                return true;
            }
            else return false;

        }
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            var clickButton = sender as Button;
            clickButton.Content = "X";

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (visibleBbuttons[i, j] == clickButton)
                    {
                        if(hiddenButtons[i,j] == true)
                        {
                            visibleBbuttons[i, j].Content = "X";
                            visibleBbuttons[i, j].Background = Brushes.Blue;
                        }
                        else
                        {
                            visibleBbuttons[i, j].Content = "o";
                        }
                    }
                }
            }
        }

        public void PrezepiszButtonsDoTablicy(Button[,] buttons)
        {
            buttons[0,0] = btn0x0;
            buttons[1,0] = btn1x0;
            buttons[2,0] = btn2x0;
            buttons[3,0] = btn3x0;
            buttons[4,0] = btn4x0;
            buttons[5,0] = btn5x0;
            buttons[6,0] = btn6x0;
            buttons[7,0] = btn7x0;
            buttons[8,0] = btn8x0;
            buttons[9,0] = btn9x0;

            buttons[0, 1] = btn0x1;
            buttons[1, 1] = btn1x1;
            buttons[2, 1] = btn2x1;
            buttons[3, 1] = btn3x1;
            buttons[4, 1] = btn4x1;
            buttons[5, 1] = btn5x1;
            buttons[6, 1] = btn6x1;
            buttons[7, 1] = btn7x1;
            buttons[8, 1] = btn8x1;
            buttons[9, 1] = btn9x1;

            buttons[0, 2] = btn0x2;
            buttons[1, 2] = btn1x2;
            buttons[2, 2] = btn2x2;
            buttons[3, 2] = btn3x2;
            buttons[4, 2] = btn4x2;
            buttons[5, 2] = btn5x2;
            buttons[6, 2] = btn6x2;
            buttons[7, 2] = btn7x2;
            buttons[8, 2] = btn8x2;
            buttons[9, 2] = btn9x2;

            buttons[0, 3] = btn0x3;
            buttons[1, 3] = btn1x3;
            buttons[2, 3] = btn2x3;
            buttons[3, 3] = btn3x3;
            buttons[4, 3] = btn4x3;
            buttons[5, 3] = btn5x3;
            buttons[6, 3] = btn6x3;
            buttons[7, 3] = btn7x3;
            buttons[8, 3] = btn8x3;
            buttons[9, 3] = btn9x3;

            buttons[0, 4] = btn0x4;
            buttons[1, 4] = btn1x4;
            buttons[2, 4] = btn2x4;
            buttons[3, 4] = btn3x4;
            buttons[4, 4] = btn4x4;
            buttons[5, 4] = btn5x4;
            buttons[6, 4] = btn6x4;
            buttons[7, 4] = btn7x4;
            buttons[8, 4] = btn8x4;
            buttons[9, 4] = btn9x4;

            buttons[0, 5] = btn0x5;
            buttons[1, 5] = btn1x5;
            buttons[2, 5] = btn2x5;
            buttons[3, 5] = btn3x5;
            buttons[4, 5] = btn4x5;
            buttons[5, 5] = btn5x5;
            buttons[6, 5] = btn6x5;
            buttons[7, 5] = btn7x5;
            buttons[8, 5] = btn8x5;
            buttons[9, 5] = btn9x5;

            buttons[0, 6] = btn0x6;
            buttons[1, 6] = btn1x6;
            buttons[2, 6] = btn2x6;
            buttons[3, 6] = btn3x6;
            buttons[4, 6] = btn4x6;
            buttons[5, 6] = btn5x6;
            buttons[6, 6] = btn6x6;
            buttons[7, 6] = btn7x6;
            buttons[8, 6] = btn8x6;
            buttons[9, 6] = btn9x6;

            buttons[0, 7] = btn0x7;
            buttons[1, 7] = btn1x7;
            buttons[2, 7] = btn2x7;
            buttons[3, 7] = btn3x7;
            buttons[4, 7] = btn4x7;
            buttons[5, 7] = btn5x7;
            buttons[6, 7] = btn6x7;
            buttons[7, 7] = btn7x7;
            buttons[8, 7] = btn8x7;
            buttons[9, 7] = btn9x7;

            buttons[0, 8] = btn0x8;
            buttons[1, 8] = btn1x8;
            buttons[2, 8] = btn2x8;
            buttons[3, 8] = btn3x8;
            buttons[4, 8] = btn4x8;
            buttons[5, 8] = btn5x8;
            buttons[6, 8] = btn6x8;
            buttons[7, 8] = btn7x8;
            buttons[8, 8] = btn8x8;
            buttons[9, 8] = btn9x8;

            buttons[0, 9] = btn0x9;
            buttons[1, 9] = btn1x9;
            buttons[2, 9] = btn2x9;
            buttons[3, 9] = btn3x9;
            buttons[4, 9] = btn4x9;
            buttons[5, 9] = btn5x9;
            buttons[6, 9] = btn6x9;
            buttons[7, 9] = btn7x9;
            buttons[8, 9] = btn8x9;
            buttons[9, 9] = btn9x9;
        }

    }
}
