using System;
using System.Windows;

 namespace KPhotels
{
    public partial class MainWindow : Window
    {
        public string conString = @"Data Source=.\SQLEXPRESS; Initial Catalog=databasehotels; Integrated Security=true;";

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new administration1();
            administration1.conString = conString;
            administration2.conString = conString;
            clients1.conString = conString;
            Numbers1.conString = conString;
            registration.conString = conString;


        }

        //по нажатию на кнопку возврат на главное меню
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            MainFrame.Navigate(new administration1());
            
        }
        //скрытие кнопки в зависимости от страницы
        private void Button_Exit(object sender, EventArgs e)
        {

            if (MainFrame.CanGoBack)
            {
                ButtonExit.Visibility = Visibility.Visible;
            }
            //проверка, открыта ли страница входа, если да, то кнопка Выход скрыта
            if (MainFrame.Content.ToString() == "KPhotels.administration1")
            {
            ButtonExit.Visibility = Visibility.Hidden;
            }
        }
      
    }
}
