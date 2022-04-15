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


namespace Agrigate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool IsChecked { get; set; }

        public ViewModel.ButtonFunc Func = new ViewModel.ButtonFunc();
        public MainWindow()
        {

            InitializeComponent();
            //WB.Source = new Uri("https://www.youtube.com/");
            ViewModel.ModelYT yT = new ViewModel.ModelYT();
            Grid.DataContext = yT.AllVideosinLib();
            this.DataContext = this;

        }


        private void GoToViewwer(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (OpenWithWindowsPlayer.IsChecked == false)
                {
                    View.View view = new View.View();
                    System.Uri uri = new Uri(URLOfVidoe.Text);
                    view.Player.Source = uri;
                    view.Show();
                }
                else
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(URLOfVidoe.Text) { UseShellExecute = true });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "\nВозникла критическая ошибка. Вы не найден путь для вопроизведения. Не выбран файл, или выбранный файл повреждён " +
                    "Убедитесь в правильности выбранного поля в списке загрузок, или ознакомтесь с руководством пользователя." +
                    "Если не получилось устранить ошибку самостоятельно- обратитесь к разработчику: soulniard@gmail.com"
                    , "Критическая ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Func.SaveVideoToDisk(Transp.Text, TranspN.Text);
                Refresh();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex + "\nВозникла критическая ошибка. Возможно введён неверный источник данных или " +
                    "возникла ошибка обработки запроса на сервисе. Повторите попытку позже, или ознакомтесь с руководством пользователя." +
                    "Для корректной работы программы следует использовать в качетсве источника данных сервис YouTube. Если не получилось устранить ошибку самостоятельно- обратитесь к разработчику: soulniard@gmail.com"
                    , "Критическая ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            ViewModel.ModelYT yT = new ViewModel.ModelYT();
            Grid.DataContext = null;
            Grid.DataContext = yT.AllVideosinLib();
        }
        private void Refresh()
        {
            ViewModel.ModelYT yT = new ViewModel.ModelYT();
            Grid.DataContext = null;
            Grid.DataContext = yT.AllVideosinLib();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Del(object sender, RoutedEventArgs e)
        {
            if (Transp.Text == null || Transp.Text == "" || Transp.Text == " ")
            {

            }
            else
            {
                System.IO.File.Delete(URLOfVidoe.Text);
                Refresh();
            }
        }

       
    }
}
