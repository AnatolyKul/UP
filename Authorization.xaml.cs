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

namespace PP.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {

        KindergartenEntities connection = new KindergartenEntities();
        public Authorization()
        {
            InitializeComponent();
        }

        private void Exit_Btn_3_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.Close();
        }

        private void Enter_Btn_Click(object sender, RoutedEventArgs e)
        {
            string log = Login_TB_2.Text;
            string pas = Password_B_2.Password;



            if ((log.Length == 0) && (pas.Length == 0))
            {
                MessageBox.Show("Все поля пустые!");
                return;
            }

            if (log.Length == 0)
            {
                MessageBox.Show("Поле логин пустое!");
                return;
            }

            if (pas.Length == 0)
            {
                MessageBox.Show("Поле пароль пустое!");
                return;
            }

            if (log.Length > 15)
            {
                MessageBox.Show("Максимальное количество символов для логина - 15!");
                return;
            }

            if (pas.Length > 10)
            {
                MessageBox.Show("Максимальное количество символов для пароля - 10!");
                return;
            }

            else
            {

                var user = connection.User.Where(us => us.Login == log && us.Password == pas).FirstOrDefault();
                {
                    if (user != null)
                    {
                        
                        
                        NavigationService.Navigate(Pages.Class1.work);
                    }
                    else
                    {
                        MessageBox.Show("Введены некорректные данные!!!");
                    }

                }
            }
        }
    }
}
