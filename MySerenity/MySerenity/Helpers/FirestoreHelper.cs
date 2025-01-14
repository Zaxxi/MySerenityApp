﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microcharts;
using MySerenity.Model;
using Xamarin.Forms;

namespace MySerenity.Helpers
{

    // interface to be implemented on both iOS and Android - used as each platform has specific code for firestore. 
    public interface IFirestore
    {
        bool SaveJournalEntry(JournalEntry entry);                             // saves journal entry to firestore
        Task<bool> DeleteJournalEntry(JournalEntry entry);                     // delete selected entry from firestore
        Task<bool> UpdateJournalEntry(JournalEntry entry);                     // Update selected entry in firestore
        Task<List<JournalEntry>> ReadAllJournalEntriesForUser();               // retrieve list of all entries for current authenticated user from firestore
        Task<List<JournalEntry>> ReadAllJournalEntriesForUser(string userID);  // retrieve list of all entries for given userID from firestore
        bool SaveUserRole(bool isClient);                                      // saves the user role to firestore upon account creation
        bool SaveSignUpQuestions(Clientquestionnaire questions);               // saves sign-up questions to firestore
        bool ClientLookingForTherapist(ClientTherapistRelationship relation);  // set a client to be looking for a therapist when signing up
        bool SaveTherapistInfo(TherapistInfo info);                            // Save the therapist signup info to firestor
        Task<string> GetUserRole();                                            // retrieves the user role from firestore for current authenticated user when logging in.
        Task<List<Clientquestionnaire>> ReadAllAvailableClients();             // gets a list of all unpaired clients to populate available client list
        Task<List<Clientquestionnaire>> ReadAllClientsForTherapist();          // gets a list of all clients paired with current therapist
        Task<bool> MatchTherapistWithClient(Clientquestionnaire entry);        // Update selected entry in firestore to match a client with a therapist
        bool SendMessage(Message message);                                     // Saves user's message to firestore
        Task<List<Message>> RetrieveConversation(string recieverID);           // Retrieves conversation from firestore
        Task<List<ChartEntry>> RetrieveMoodData();                             // Retrieves mood entry data from firestore to display on homepage graph
        Task<List<ChartEntry>> RetrieveMoodData(string userID);                // Retrieves mood entry data from firestore for a given userID to display on MyClientDetails graph
        Task<TherapistInfo> GetTherapistForClient();                           // Retrieves therapist info for client.
        Task<bool> UnmatchClientFromTherapist(TherapistInfo info);             // unmatch client from therapist - client side
        Task<bool> UnmatchTherapistFromClient(Clientquestionnaire client);     // unmatch therapist from client - therapist side
        Task<TherapistInfo> GetTherapistInfo();                                // Retrieves therapist info for authenticated therapist
        Task<bool> UpdateTherapistInfo(TherapistInfo info);                    // Update selected entry in firestore - when therapist updates their profile info
        Task<bool> SaveTherapistSchedule(TherapistWorkingDays schedule);       // stores the therapist working days in firestore.
        Task<TherapistWorkingDays> GetTherapistSchedule(string userID);        // retrieves the therapists working schedule
    }

    public class Firestore
    {
        // checks to see which operating system the app is being run on and runs the platform specific firestore code.
        private static IFirestore _firestore = DependencyService.Get<IFirestore>();

        public static bool SaveJournalEntry(JournalEntry entry)
        {
            return _firestore.SaveJournalEntry(entry);
        }

        public static Task<bool> Delete(JournalEntry entry)
        {
            return _firestore.DeleteJournalEntry(entry);
        }

        public static Task<bool> Update(JournalEntry entry)
        {
            return _firestore.UpdateJournalEntry(entry);
        }

        public static Task<List<JournalEntry>> ReadAllJournalEntriesForUser()
        {
            return _firestore.ReadAllJournalEntriesForUser();
        }

        public static Task<List<JournalEntry>> ReadAllJournalEntriesForUser(string userID)
        {
            return _firestore.ReadAllJournalEntriesForUser(userID);
        }

        public static bool SaveUserRole(bool isClient)
        {
            return _firestore.SaveUserRole(isClient);
        }

        public static bool SaveSignUpQuestions(Clientquestionnaire questions)
        {
            return _firestore.SaveSignUpQuestions(questions);
        }

        public static bool ClientLookingForTherapist(ClientTherapistRelationship relation)
        {
            return _firestore.ClientLookingForTherapist(relation);
        }

        public static bool SaveTherapistInfo(TherapistInfo info)
        {
            return _firestore.SaveTherapistInfo(info);
        }

        public static Task<string> GetUserRole()
        {
            return _firestore.GetUserRole();
        }

        public static Task<List<Clientquestionnaire>> ReadAllAvailableClients()
        {
            return _firestore.ReadAllAvailableClients();
        }

        public static Task<List<Clientquestionnaire>> ReadAllClientsForTherapist()
        {
            return _firestore.ReadAllClientsForTherapist();
        }

        public static Task<bool> MatchTherapistWithClient(Clientquestionnaire entry)
        {
            return _firestore.MatchTherapistWithClient(entry);
        }

        public static bool SendMessage(Message message)
        {
           return _firestore.SendMessage(message);
        }

        public static Task<List<Message>> RetrieveConversation(string recieverID)
        {
            return _firestore.RetrieveConversation(recieverID);
        }

        public static Task<List<ChartEntry>> RetrieveMoodData()
        {
            return _firestore.RetrieveMoodData();
        }

        public static Task<List<ChartEntry>> RetrieveMoodData(string userID)
        {
            return _firestore.RetrieveMoodData(userID);
        }

        public static Task<TherapistInfo> GetTherapistForClient()
        {
            return _firestore.GetTherapistForClient();
        }

        public static Task<bool> UnmatchClientFromTherapist(TherapistInfo info)
        {
            return _firestore.UnmatchClientFromTherapist(info);
        }

        public static Task<bool> UnmatchTherapistFromClient(Clientquestionnaire client)
        {
            return _firestore.UnmatchTherapistFromClient(client);
        }

        public static Task<TherapistInfo> GetTherapistInfo()
        {
            return _firestore.GetTherapistInfo();
        }

        public static Task<bool> UpdateTherapistInfo(TherapistInfo info)
        {
            return _firestore.UpdateTherapistInfo(info);
        }

        public static Task<bool> SaveTherapistSchedule(TherapistWorkingDays schedule)
        {
            return _firestore.SaveTherapistSchedule(schedule);
        }

        public static Task<TherapistWorkingDays> GetTherapistSchedule(string userID)
        {
            return _firestore.GetTherapistSchedule(userID);
        }
    }

}
    

