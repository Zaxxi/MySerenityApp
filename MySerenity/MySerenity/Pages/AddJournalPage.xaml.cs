﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySerenity.Extensions;
using MySerenity.Helpers;
using MySerenity.Model;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace MySerenity.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddJournalPage : ContentPage
    {
        public AddJournalPage()
        {
            InitializeComponent();
            this.On<iOS>().SetUseSafeArea(true); // makes app use full screen on iOS.
        }

        // used to load the journal entry page when selecting a journal entry from the list to view details.
        // bring up a journal page where you can view an old entry but can't edit the details.
        public AddJournalPage(JournalEntry entry)
        {
            // picker index to know which index corresponds to what value
            //< x:String > &#x1F604; Happy</x:String>
            //< x:String > &#x1F642; Okay</x:String>
            //< x:String > &#x1F610; Neutral</x:String>
            //< x:String > &#x1F641; Not Okay</x:String>
            //< x:String > &#x1F61e; Unhappy</x:String>

            int moodDate = 0;

            if (entry.JournalEntryMoodData == 0) moodDate = 4;
            if (entry.JournalEntryMoodData == 1) moodDate = 3;
            if (entry.JournalEntryMoodData == 2) moodDate = 2;
            if (entry.JournalEntryMoodData == 3) moodDate = 1;
            if (entry.JournalEntryMoodData == 4) moodDate = 0;

            InitializeComponent();
            journalTitle.Text = entry.JournalEntryTitle;
            journalText.Text = entry.JournalEntryText;
            picker.SelectedIndex = entry.JournalEntryMoodData;
            journalTitle.IsReadOnly = true;
            journalText.IsReadOnly = true;
            picker.IsEnabled = false;
            picker.SelectedIndex = moodDate;
            SaveButton.IsEnabled = false;
            ToolBarTitle.Text = entry.JournalEntryTitle;
        }

        // when the user has finished their journal entry they click the Save icon 
        // takes the Title, text and mood data from the entry boxes and sets the time of the entry
        // then submits the journal to firebase.
        private void SubmitJournal_clicked(object sender, EventArgs e)
        {

            // picker index to know which index corresponds to what value
            //< x:String > &#x1F604; Happy</x:String>
            //< x:String > &#x1F642; Okay</x:String>
            //< x:String > &#x1F610; Neutral</x:String>
            //< x:String > &#x1F641; Not Okay</x:String>
            //< x:String > &#x1F61e; Unhappy</x:String>

            int moodData = 0;

            if (picker.SelectedIndex == 0) moodData = 5;
            if (picker.SelectedIndex == 1) moodData = 4;
            if (picker.SelectedIndex == 2) moodData = 3;
            if (picker.SelectedIndex == 3) moodData = 2;
            if (picker.SelectedIndex == 4) moodData = 1;

            // created the new Journal Entry to map to Firebase.
            var newEntry = new JournalEntry()
            {
                JournalEntryTitle = journalTitle.Text,
                JournalEntryText = journalText.Text,
                JournalEntryEntryTime = System.DateTime.Now.ToString(new CultureInfo("en-GB")),
                JournalEntryMoodData = moodData
            };

            // submits the entry to firestore and displays the outcome message to the user then returns them to the Journal Entry list view.
            bool result = Firestore.SaveJournalEntry(newEntry);
            DisplayAlert("Entry Saved", result ? "Saved Successfully" : "Saved Failed", "Ok");
            Navigation.PopAsync();
        }
    }
}