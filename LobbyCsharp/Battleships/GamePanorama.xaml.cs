﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace Battleships
{
    public enum GameState
    {
        NotLoggedIn = 0,
        LoggedIn = 1,
        Lobby = 2,
        WaitTurn = 3,
        PlayTurn = 4
    }
    public partial class GamePanorama : PhoneApplicationPage
    {        //zelf public toegevoegd
        public ServiceCloud.LobbyServiceClient client;
        public ServiceCloud.OPlayer me;
        public enum FieldType { Water, Ship, Miss, Hit };
        public ObservableCollection<Field> YourField { get; set; }
        public ObservableCollection<Field> OpponentsField { get; set; }
        public List<string> ExistingPLayerList { get; set; }
        public bool loggedin { get; set; }

        // Constructor
        public GamePanorama()
        {
            InitializeComponent();
            ExistingPLayerList = new List<string>();
        }

        public class Field
        {
            public FieldType Type { get; set; }
            public int Coordinate { get; set; }
            public string image
            {
                get
                {
                    string img = Convert.ToString(this.Type);
                    img += ".png";
                    return img;
                }

                set { }
            }
            public Field(FieldType thisfield, int coord)
            {
                this.Type = thisfield;
                this.Coordinate = coord;
            }
        }


        private void btnCheckforlobies_Click(object sender, RoutedEventArgs e)
        {

            client.GetAvailableLobbyRoomsAsync();

        }

        /*
        //GET PLAYER (normaal maak je eerst een speler aan, nu hard coded in database)
        void client_GetPlayerCompleted(object sender, ServiceCloud.GetPlayerCompletedEventArgs e)
        {
            me = (ServiceCloud.OPlayer)e.Result;
        }*/
/*
 * 
 ********************************LOBBY********************************* 
 * 
*/

        //Welke playrooms zijn aangemaakt, waarbij iswaiting = true (maw. een host is hier aan het wachten)
        void client_GetAvailableLobbyRoomsCompleted(object sender, ServiceCloud.GetAvailableLobbyRoomsCompletedEventArgs e)
        {
            foreach (var item in e.Result)
                lstPlayRooms.Items.Add(item);

            //lstPlayRooms.ItemsSource = e.Result;
        }


        //Welke room zijn beschikbaar ( iswaiting = true)
        void client_GetAvailableRoomsCompleted(object sender, ServiceCloud.GetAvailableRoomsCompletedEventArgs e)
        {
            List<ServiceCloud.OLobby> lobbyList = e.Result.ToList();
            lstPlayRooms.ItemsSource = lobbyList;

        }


        //Kies een lobby , dewelke je als playroom wil aanmaken
        private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ServiceCloud.OLobby lobby = (ServiceCloud.OLobby)((ListBox)(sender)).SelectedItem;
            client.CreatePlayLobbyCompleted += client_CreatePlayLobbyCompleted;
            client.CreatePlayLobbyAsync(me, lobby.LobbyId);
        }


        //aanmaak van een playroom
        void client_CreatePlayLobbyCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            //update van playroom listbox, roep opnieuw service aan en kijk of er 
            //nieuwe playrooms beschikbaar zijn
            client.GetAvailableLobbyRoomsAsync();
        }


        //Kies een playroom waarbij je jezelf wil aanmelden
        private void lstPlayRooms_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            //Als voorbeeld gaan we speler 2 laten aanmelden in de playroom
            ServiceCloud.OPlayer p2 = new ServiceCloud.OPlayer() { PlayerId = 2, PlayerName = "Tim" };
            ServiceCloud.OLobbyRoom o = (ServiceCloud.OLobbyRoom)((ListBox)(sender)).SelectedItem;
            client.SubscribeToLobbyRoomAsync(p2, o.theLobby.LobbyId, o.hostPlayer.PlayerId);
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            client = new ServiceCloud.LobbyServiceClient();
            client.GetAvailableLobbyRoomsCompleted += client_GetAvailableLobbyRoomsCompleted;
            YourField = new ObservableCollection<Field>();
            for (int i = 1; i < 100; i++)
            {
                Field temp = new Field(FieldType.Water, i);
                this.YourField.Add(temp);
            }
            lstPlayerField.ItemsSource = YourField;
        }
/*
 * 
 **************************************Register/LogIn************************************ 
 * 
*/
        private void btnCreatePlayer_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/createplayer.xaml", UriKind.Relative));
        }

        private void btnUseExistingPlayer_Click(object sender, RoutedEventArgs e)
        {
            /*client.GetAllPlayersCompleted += client_GetAllPlayersCompleted;
            client.GetAllPlayersAsync();*/

            client.LoggInCompleted += client_LoggInCompleted;
            client.LoggInAsync(exstplyrbox.Text,passwordbox.Text);

        }

        void client_LoggInCompleted(object sender, ServiceCloud.LoggInCompletedEventArgs e)
        {
            loggedin = e.Result;
            if (loggedin == true)
            {
                MessageBox.Show("Logged In");
                btnCheckforlobies.IsEnabled = true;
                client.CurrentPlayerCompleted += client_CurrentPlayerCompleted;

                inlogscreen.Visibility = System.Windows.Visibility.Collapsed;
                lobbyscreen.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Loggin Failed!");
            }
        }
        

       /* void client_GetAllPlayersCompleted(object sender, ServiceCloud.GetAllPlayersCompletedEventArgs e)
        {
            foreach (var item in e.Result)
            //ExistingPLayerList.Add(item.ToString());
            //foreach (var item in ExistingPLayerList)
            {
                if (item.Replace(" ", string.Empty) == exstplyrbox.Text)
                {
                    MessageBox.Show("Logged In");
                    btnCheckforlobies.IsEnabled = true;
                    client.CurrentPlayerCompleted += client_CurrentPlayerCompleted;                    
                    
                }
            }
        }*/

        void client_CurrentPlayerCompleted(object sender, ServiceCloud.CurrentPlayerCompletedEventArgs e)
        {
            me = (ServiceCloud.OPlayer)e.Result;            
        }

        private void exstplyrbox_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            exstplyrbox.Text = "";
        }
    }
}