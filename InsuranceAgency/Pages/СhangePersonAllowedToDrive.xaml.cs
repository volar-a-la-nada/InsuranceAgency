﻿using InsuranceAgency.Struct;
using System;
using System.Windows;
using System.Windows.Controls;

namespace InsuranceAgency.Pages
{
    public partial class СhangePersonAllowedToDrive : Page
    {
        public СhangePersonAllowedToDrive()
        {
            InitializeComponent();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbSearch.Text.Length == 0)
            {
                tbSearchHint.Visibility = Visibility.Visible;
            }
            else
            {
                tbSearchHint.Visibility = Visibility.Hidden;
            }
        }

        PersonAllowedToDrive searchPersonAllowedToDrive;

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string search_temp = tbSearch.Text.Trim();
                string search = "";
                if (search_temp == "")
                {
                    throw new Exception("Строка поиска пуста");
                }
                foreach (var item in search_temp)
                {
                    if (char.IsDigit(item))
                    {
                        search += item;
                    }
                }

                searchPersonAllowedToDrive = Database.SearchPersonAllowedToDrive(search);

                tbFullName.Text = searchPersonAllowedToDrive.FullName;
                tbDrivingLicenceSeries.Text = "";
                tbDrivingLicenceNumber.Text = "";
                for (var i = 0; i < 4; i++) tbDrivingLicenceSeries.Text += searchPersonAllowedToDrive.DrivingLicence[i];
                for (var i = 4; i < 10; i++) tbDrivingLicenceNumber.Text += searchPersonAllowedToDrive.DrivingLicence[i];

                tbSearch.Text = "";
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void tbDrivingLicenceSeries_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbDrivingLicenceSeries.Text.Length == 0)
            {
                tbDrivingLicenceSeriesHint.Visibility = Visibility.Visible;
            }
            else
            {
                tbDrivingLicenceSeriesHint.Visibility = Visibility.Hidden;
            }
        }

        private void tbDrivingLicenceNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbDrivingLicenceNumber.Text.Length == 0)
            {
                tbDrivingLicenceNumberHint.Visibility = Visibility.Visible;
            }
            else
            {
                tbDrivingLicenceNumberHint.Visibility = Visibility.Hidden;
            }
        }


        private void btnChangePersonAllowedToDrive_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string fullName = tbFullName.Text.Trim();
                if (fullName == "")
                {
                    throw new Exception("Заполните поле ФИО");
                }

                string drivingLicenceSeries = tbDrivingLicenceSeries.Text.Trim();
                if (drivingLicenceSeries.Length != 4)
                {
                    throw new Exception("Серия водительского удостоверения должна содержать 4 цифры");
                }
                string drivingLicenceNumber = tbDrivingLicenceNumber.Text.Trim();
                if (drivingLicenceNumber.Length != 6)
                {
                    throw new Exception("Номер водительского удостоверения должен содержать 6 цифр");
                }
                string drivingLicence = drivingLicenceSeries + drivingLicenceNumber;
                foreach (var item in drivingLicence)
                {
                    if (!char.IsDigit(item))
                    {
                        throw new Exception("Серия и номер водительского удостоверения должны содержать только цифры");
                    }
                }


                PersonAllowedToDrive personAllowedToDrive = new PersonAllowedToDrive(searchPersonAllowedToDrive.ID, fullName, drivingLicence);

                Database.ChangePersonAllowedToDrive(personAllowedToDrive);

                MessageBox.Show("Водитель успешно изменён", "", MessageBoxButton.OK, MessageBoxImage.Information);

                tbFullName.Clear();
                tbDrivingLicenceSeries.Clear();
                tbDrivingLicenceNumber.Clear();
                tbException.Visibility = Visibility.Hidden;
            }
            catch (Exception exp)
            {
                tbException.Visibility = Visibility.Visible;
                tbException.Text = exp.Message;
            }
        }

        private void btnDeletePersonAllowedToDrive_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Database.DeletePersonAllowedToDrive(searchPersonAllowedToDrive.ID);

                MessageBox.Show("Водитель успешно удалён", "", MessageBoxButton.OK, MessageBoxImage.Information);

                tbFullName.Clear();
                tbDrivingLicenceSeries.Clear();
                tbDrivingLicenceNumber.Clear();
                tbException.Visibility = Visibility.Hidden;
            }
            catch (Exception exp)
            {
                tbException.Visibility = Visibility.Visible;
                tbException.Text = exp.Message;
            }
        }

    }
}
