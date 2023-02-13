﻿using System;
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
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        DBContainer db;
        public AuthorizationWindow()
        {
            
            InitializeComponent();
            db = new DBContainer();
        }
        

        private void AuthorizationClick(object sender, RoutedEventArgs e)
        {
            if (db.Users.Select(item => item.Login + " " + item.Password).Contains(login.Text + " " + password.Password))
            {
                MessageBox.Show("Вы авторизованы");
            }
            else 
            {
                MessageBox.Show("Ошибка логина/пароля");
            }
        }

        private void RegitrationClick(object sender, RoutedEventArgs e)
        {
            RegistrationWindow rw = new RegistrationWindow();
            rw.Show();
            this.Close();
        }
    }
}
