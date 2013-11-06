using System;
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
    public partial class GamePanorama : PhoneApplicationPage
    {        //zelf public toegevoegd
        public LobbyService.LobbyServiceClient client;
        public LobbyService.OPlayer me;
        public enum FieldType {Water,Ship,Miss,Hit};
        public ObservableCollection<Field> YourField{ get; set; }
        public ObservableCollection<Field> OpponentsField { get; set; }
        

        // Constructor
        public GamePanorama()
        {
            InitializeComponent();

    
        }

        public class Field
        {
            public FieldType Type { get; set; }
            public int Coordinate { get; set; }
            public string image
            {
                get { 
                    string img =Convert.ToString(this.Type);
                    img+=".png";
                    return img;
                }
                
                set { }
            }
            public Field(FieldType thisfield, int coord )
            {
                this.Type = thisfield;
                this.Coordinate = coord;
            }
        }


        private void btnCheckforlobies_Click(object sender, RoutedEventArgs e)
        {

            client.GetAvailableLobbyRoomsAsync();

        }

        //GET PLAYER (normaal maak je eerst een speler aan, nu hard coded in database)
        void client_GetPlayerCompleted(object sender, LobbyService.GetPlayerCompletedEventArgs e)
        {
            me = (LobbyService.OPlayer)e.Result;
        }


        //Welke playrooms zijn aangemaakt, waarbij iswaiting = true (maw. een host is hier aan het wachten)
        void client_GetAvailableLobbyRoomsCompleted(object sender, LobbyService.GetAvailableLobbyRoomsCompletedEventArgs e)
        {
            foreach (var item in e.Result)
                lstPlayRooms.Items.Add(item);

            //lstPlayRooms.ItemsSource = e.Result;
        }


        //Welke room zijn beschikbaar ( iswaiting = true)
        void client_GetAvailableRoomsCompleted(object sender, LobbyService.GetAvailableRoomsCompletedEventArgs e)
        {
            List<LobbyService.OLobby> lobbyList = e.Result.ToList();
            lstPlayRooms.ItemsSource = lobbyList;

        }


        //Kies een lobby , dewelke je als playroom wil aanmaken
        private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            LobbyService.OLobby lobby = (LobbyService.OLobby)((ListBox)(sender)).SelectedItem;
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
            LobbyService.OPlayer p2 = new LobbyService.OPlayer() { PlayerId = 2, PlayerName = "Tim" };
            LobbyService.OLobbyRoom o = (LobbyService.OLobbyRoom)((ListBox)(sender)).SelectedItem;
            client.SubscribeToLobbyRoomAsync(p2, o.theLobby.LobbyId, o.hostPlayer.PlayerId);
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            client = new LobbyService.LobbyServiceClient();
            client.GetAvailableLobbyRoomsCompleted += client_GetAvailableLobbyRoomsCompleted;
            YourField = new ObservableCollection<Field>();
            for (int i = 1; i < 100; i++)
            {
                Field temp = new Field(FieldType.Water, i);
                this.YourField.Add(temp);
            }
            lstPlayerField.ItemsSource = YourField;
        }
    }
}