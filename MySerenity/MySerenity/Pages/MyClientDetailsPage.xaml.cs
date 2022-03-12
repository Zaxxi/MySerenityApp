﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySerenity.Helpers;
using MySerenity.Model;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MySerenity.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyClientDetailsPage : ContentPage
    {
        private Clientquestionnaire _clientDetails;

        public MyClientDetailsPage()
        {
            InitializeComponent();
            _clientDetails = new Clientquestionnaire();
        }

        public MyClientDetailsPage(Clientquestionnaire info)
        {
            InitializeComponent();
            ClientNameEntry.Text = info.ClientName;
            ClientGenderEntry.Text = info.Gender;
            ClientAgeEntry.Text = info.Age.ToString();
            ClientTherapyReasonsEntry.Text = info.ReasonsForTherapy;

            _clientDetails = info;
        }


        private async void PrivateMessage_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PrivateMessagePage(_clientDetails));
        }

        
        public async Task OpenBrowser()
        {
            try
            {
                await Browser.OpenAsync("https://myserenityvideocalling.z33.web.core.windows.net", BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                // An unexpected error occured. No browser may be installed on the device.
            }
        }

        private async void Call_OnClicked(object sender, EventArgs e)
        {
            await OpenBrowser();
        }
    }
}