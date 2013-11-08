using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace LobbyCsharp
{
    public partial class MainPage : UserControl
    {
        ServiceReference1.LobbyServiceClient client;

        ServiceReference1.OPlayer me;
        public List<string> ExestingPLayerList { get; set; }

        public MainPage()
        {
            InitializeComponent();
            ExestingPLayerList = new List<string>();
            client = new ServiceReference1.LobbyServiceClient();

            client.GetAllPlayersCompleted+=client_GetAllPlayersCompleted;
            client.GetAllPlayersAsync();
            
            
            client.GetPlayerCompleted += client_GetPlayerCompleted;
            client.GetPlayerAsync(1);

            
            client.GetAvailableRoomsCompleted += client_GetAvailableRoomsCompleted;
            client.GetAvailableRoomsAsync();

            client.GetAvailableLobbyRoomsCompleted += client_GetAvailableLobbyRoomsCompleted;
            client.GetAvailableLobbyRoomsAsync();
        }

        void client_GetAllPlayersCompleted(object sender, ServiceReference1.GetAllPlayersCompletedEventArgs e)
        {
            foreach (var item in e.Result)
                ExestingPLayerList.Add(item.ToString());
        }


        //GET PLAYER (normaal maak je eerst een speler aan, nu hard coded in database)
        void client_GetPlayerCompleted(object sender, ServiceReference1.GetPlayerCompletedEventArgs e)
        {
            me = (ServiceReference1.OPlayer)e.Result;
        }


        //Welke playrooms zijn aangemaakt, waarbij iswaiting = true (maw. een host is hier aan het wachten)
        void client_GetAvailableLobbyRoomsCompleted(object sender, ServiceReference1.GetAvailableLobbyRoomsCompletedEventArgs e)
        {            
            foreach (var item in e.Result)
                lstPlayRooms.Items.Add(item);

            //lstPlayRooms.ItemsSource = e.Result;
        }


        //Welke room zijn beschikbaar ( iswaiting = true)
        void client_GetAvailableRoomsCompleted(object sender, ServiceReference1.GetAvailableRoomsCompletedEventArgs e)
        {
            List<ServiceReference1.OLobby> lobbyList = e.Result.ToList();
            lstbox.ItemsSource = lobbyList;

        }


        //Kies een lobby , dewelke je als playroom wil aanmaken
        private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ServiceReference1.OLobby lobby = (ServiceReference1.OLobby)((ListBox)(sender)).SelectedItem;
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
            ServiceReference1.OPlayer p2 = new ServiceReference1.OPlayer() { PlayerId = 2, PlayerName = "Tim" };
            ServiceReference1.OLobbyRoom o = (ServiceReference1.OLobbyRoom)((ListBox)(sender)).SelectedItem;
            client.SubscribeToLobbyRoomAsync(p2, o.theLobby.LobbyId, o.hostPlayer.PlayerId);
        }
    }
}
