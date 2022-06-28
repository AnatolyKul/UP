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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {

        KindergartenEntities connection = new KindergartenEntities();
        public Registration()
        {
            InitializeComponent();
        }

        private void Exit_Btn_2_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.Close();
        }

        private void Reg_Btn_Click(object sender, RoutedEventArgs e)
        {
            string login = Login_TB.Text;
            string password = Password_B.Password;

            if ((login.Length == 0) && (password.Length == 0))
            {
                MessageBox.Show("Все поля пустые!");
                return;
            }

            if (login.Length == 0)
            {
                MessageBox.Show("Поле логин пустое!");
                return;
            }

            if (password.Length == 0)
            {
                MessageBox.Show("Поле пароль пустое!");
                return;
            }

            if (login.Length > 15)
            {
                MessageBox.Show("Максимальное количество символов для логина - 15!");
                return;
            }

            if (password.Length > 10)
            {
                MessageBox.Show("Максимальное количество символов для пароля - 10!");
                return;
            }

            User isExist = connection.User.Where(global => global.Login == login).FirstOrDefault();

            if (isExist != null)
            {
                MessageBox.Show("Такой пользователь уже зарегистрирован!");
            }

            else
            {


                User user = new User();
                user.Login = login;
                user.Password = password;
                user.Role = "Зам. зав. по УВР";
                connection.User.Add(user);




                int result = connection.SaveChanges();
                if (result == 1)
                {
                    Login_TB.Text = "";
                    Password_B.Password = "";
                    MessageBox.Show("Пользователь успешно добавлен");
                }


                NavigationService.Navigate(Pages.Class1.work);
                MessageBox.Show("Вы успешно зарегистрированы");
            }
        }
    }
}
