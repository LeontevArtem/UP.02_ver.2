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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UP._02_ver._2.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        MainWindow mainWindow;
        public Main(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }
        public void UserClick(object sender, MouseButtonEventArgs e)
        {
            mainWindow.OpenPage(new Pages.Users.UserMain(mainWindow,this));
        }
        public void EquipmentClick(object sender, MouseButtonEventArgs e)
        {
            mainWindow.OpenPage(new Pages.Equipment.EquipmentMain(mainWindow,this));
        }
    }
}
