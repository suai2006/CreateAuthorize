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
using System.Windows.Shapes;

namespace CreateAuthorize
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        DBContainer db = new DBContainer();
        public RegistrationWindow()
        {
            InitializeComponent();
        }
        

        private void RegistrationClick(object sender, RoutedEventArgs e)
        {
            if (login.Text == "" || password.Password == "" || firstName.Text == "" || lastName.Text == "" || middleName.Text == "")
            {
                MessageBox.Show("Пустые поля");
                return;
            }
            if (db.Users.Select(item => item.Login).Contains(login.Text))
            {
                MessageBox.Show("Такой пользователь существует");
                return;
            }

            User newUser = new User() { 
                Login = login.Text,
                Password = password.Password,
                FirstName = firstName.Text,
                LastName = lastName.Text,
                MiddleName = middleName.Text
            };
            db.Users.Add(newUser);
            db.SaveChanges();
            MessageBox.Show("Вы успешно зарегистрированны");
            AuthorizationWindow aw = new AuthorizationWindow();
            aw.Show();
            this.Close();
        }
        private void CancelClick(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow aw = new AuthorizationWindow();
            aw.Show();
            this.Close();
        }
    }
}
