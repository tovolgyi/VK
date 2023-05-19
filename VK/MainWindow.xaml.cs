using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
namespace VK
{
    public partial class MainWindow : Window
    {
        public ICommand icom;
        public MainWindow()
        {

            #region A hátterek beállítása, a click eventek létrehozása
            InitializeComponent();
             DTablazat.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Background = Brushes.LightGreen;
                button.Click += Disz_Click;
                diBem.Text += button.Content;
            });

            KTablazat.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Background = Brushes.PaleVioletRed;
                button.Click += Kon_Click;
                konBem.Text += button.Content;
            });

            void Kon_Click(object sender, RoutedEventArgs e)
            {
                Button button = (Button)sender;

                if (button.Background == Brushes.PaleVioletRed)
                {
                    button.Background = Brushes.LightGreen;
                    if (button.Background == Brushes.LightGreen)
                    {
                        konBem.Text = konBem.Text.Replace(button.Content.ToString(), "");
                    }
                }
                else if (button.Background == Brushes.LightGreen)
                {
                    button.Background = Brushes.PaleVioletRed;
                    if (button.Background == Brushes.PaleVioletRed)
                    {
                        konBem.Text += button.Content.ToString();
                    }
                }

                DTablazat.Children.Cast<Button>().ToList().ForEach(button2 =>
                {
                    int row1 = Grid.GetRow(button);
                    int row2 = Grid.GetRow(button2);

                    int column1 = Grid.GetColumn(button);
                    int column2 = Grid.GetColumn(button2);

                    if (row1 == row2 && column1 == column2 && button.Background == Brushes.PaleVioletRed)
                    {
                        button2.Background = Brushes.LightGreen;
                    }

                    else if (row1 == row2 && column1 == column2 && button.Background == Brushes.LightGreen)
                    {
                        button2.Background = Brushes.PaleVioletRed;
                    }
                });
            }

            void Disz_Click(object sender, RoutedEventArgs e)
            {
                Button button = (Button)sender;

                if (button.Background == Brushes.LightGreen)
                {
                    button.Background = Brushes.PaleVioletRed;
                    if (button.Background == Brushes.PaleVioletRed)
                    {
                        diBem.Text = diBem.Text.Replace(button.Content.ToString(), "");
                    }
                }
                else if (button.Background == Brushes.PaleVioletRed)
                {
                    button.Background = Brushes.LightGreen;
                    if (button.Background == Brushes.LightGreen)
                    {
                        diBem.Text += button.Content.ToString();
                    }
                }

                KTablazat.Children.Cast<Button>().ToList().ForEach(button2 =>
                {
                    int row1 = Grid.GetRow(button);
                    int row2 = Grid.GetRow(button2);

                    int column1 = Grid.GetColumn(button);
                    int column2 = Grid.GetColumn(button2);

                    if (row1 == row2 && column1 == column2 && button.Background == Brushes.PaleVioletRed)
                    {
                        button2.Background = Brushes.LightGreen;
                    }

                    else if (row1 == row2 && column1 == column2 && button.Background == Brushes.LightGreen)
                    {
                        button2.Background = Brushes.PaleVioletRed;
                    }
                });

            }
            #endregion
            icom = new Command(Execute, canExecute);
        }

        public void Execute(object param)
        {
            DTablazat.Children.Cast<Button>().ToList().ForEach(button =>
            {
                int row1 = Grid.GetRow(button);
                int column1 = Grid.GetColumn(button);
                if (button.Background == Brushes.LightGreen)
                {
                    KTablazat.Children.Cast<Button>().ToList().ForEach(button2 =>
                    {
                        int row2 = Grid.GetRow(button2);
                        int column2 = Grid.GetColumn(button2);

                        if (row1 == row2 && column1 == column2 && button.Background == Brushes.LightGreen)
                        {
                            button2.Background = Brushes.PaleVioletRed;
                        }
                        else
                        {
                            button2.Background = Brushes.LightGreen;
                        }
                    });
                }
            });
        }

        public bool canExecute(object param)
        {
            return true;
        }
    }
            #region A command implementálása. Innen veszi át az összes többi
        public class Command : ICommand
        {

            Action<object> execute;
            Func<object, bool> canexecute;

            public Command(Action<object> execute, Func<object, bool> canexecute)
            {
                this.execute = execute;
                this.canexecute = canexecute;
            }

            public event EventHandler? CanExecuteChanged;

            public bool CanExecute(object? parameter)
            {
                return true;
            }

            public void Execute(object? parameter)
            {
                execute(parameter);
            }
            public ICommand nalami { get; set; }
        }
        #endregion
}