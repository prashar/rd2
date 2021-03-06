﻿using ReceipTax._1.Helpers;
using ReceipTax._1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace ReceipTax._1.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Delete_UpdateReceipt : Page
    {
        int Selected_ContactId = 0;
        DatabaseHelperClass Db_Helper = new DatabaseHelperClass();
        Receipt currentcontact = new Receipt();
        public Delete_UpdateReceipt()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Selected_ContactId = int.Parse(e.Parameter.ToString());
            currentcontact = Db_Helper.ReadReceipt(Selected_ContactId);//Read selected DB contact
            NametxtBx.Text = currentcontact.Vendor;//get contact Name
            PhonetxtBx.Text = currentcontact.Amount;//get contact PhoneNumber
            TaxTxBx.Text = currentcontact.Tax;
            ReceiptType.Text = currentcontact.ReceiptType.ToString();
            DateBx.Text = currentcontact.ReceiptDate;
            ImgLink.Text = currentcontact.ImageLink; 
        }

        private void UpdateContact_Click(object sender, RoutedEventArgs e)
        {
            currentcontact.Vendor = NametxtBx.Text;
            currentcontact.Amount = PhonetxtBx.Text;
            currentcontact.Tax = TaxTxBx.Text;
            Db_Helper.UpdateReceipt(currentcontact);//Update selected DB contact Id
            Frame.Navigate(typeof(ReadReceiptList));
        }
        private void DeleteContact_Click(object sender, RoutedEventArgs e)
        {
            Db_Helper.DeleteReceipt(Selected_ContactId);//Delete selected DB contact Id.
            Frame.Navigate(typeof(ReadReceiptList));
        }
    }
}
