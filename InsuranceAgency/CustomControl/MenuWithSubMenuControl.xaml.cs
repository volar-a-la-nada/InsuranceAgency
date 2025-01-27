﻿using InsuranceAgency.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace InsuranceAgency.CustomControl
{
    public partial class MenuWithSubMenuControl : UserControl
    {
        public MenuWithSubMenuControl()
        {
            InitializeComponent();
            //Binding our ViewModel with the datacontext to read the Menu & SubMenuItemsData
            DataContext = new SideMenuViewModel();
        }


        public Thickness SubMenuPadding
        {
            get { return (Thickness)GetValue(SubMenuPaddingProperty); }
            set { SetValue(SubMenuPaddingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SubMenuPadding.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SubMenuPaddingProperty =
            DependencyProperty.Register("SubMenuPadding", typeof(Thickness), typeof(MenuWithSubMenuControl));



        public bool HasIcon
        {
            get { return (bool)GetValue(HasIconProperty); }
            set { SetValue(HasIconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HasIcon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HasIconProperty =
            DependencyProperty.Register("HasIcon", typeof(bool), typeof(MenuWithSubMenuControl));
    }
}
