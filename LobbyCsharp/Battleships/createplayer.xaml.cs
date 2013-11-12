using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;


namespace Battleships
{
    public partial class createplayer : PhoneApplicationPage
    {
        public ServiceCloud.LobbyServiceClient client;
        public bool playerexists = false;
        public List<string> ExistingPLayerList { get; set; }
        public string NewLoginName { get; set; }
        public string NewPassword { get; set; }
        public int NewId { get; set; }
       
        public createplayer()
        {
            InitializeComponent();
            ExistingPLayerList = new List<string>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            client = new ServiceCloud.LobbyServiceClient();
       

            NewLoginName = newLogintbx.Text;
            NewPassword = newPasswordtbx.Text;


            client.GetAllPlayersCompleted += client_GetAllPlayersCompleted;
            client.GetAllPlayersAsync();
            
        }

        void client_NewIdCompleted(object sender, ServiceCloud.NewIdCompletedEventArgs e)
        {
            NewId = e.Result;
        }

        void client_AddNewPlayerCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                MessageBox.Show("Add new user succeeded");
            }
        }

        void client_GetAllPlayersCompleted(object sender, ServiceCloud.GetAllPlayersCompletedEventArgs e)
        {
            foreach (var item in e.Result)
                ExistingPLayerList.Add(item);

           //List<CreatePlayer.OPlayer> AllPlayerNamesList = e.Result.ToList();

            foreach (var item in ExistingPLayerList)
            {
                if (playerexists == false)
                {
                    if (item.Replace(" ", string.Empty) == NewLoginName)
                    {
                        MessageBox.Show("Username Already exists");
                        playerexists = true;
                        NavigationService.Navigate(new Uri("/GamePanorama.xaml", UriKind.Relative));
                    }
                }                
            }
            if (playerexists == false)
            {
                client.AddNewPlayerCompleted += client_AddNewPlayerCompleted;
                client.NewIdAsync();

                client.NewIdCompleted += client_NewIdCompleted;
                client.AddNewPlayerAsync(NewId, NewLoginName);
                NavigationService.Navigate(new Uri("/GamePanorama.xaml", UriKind.Relative));
                //playerexists = true;
            }

        }
    }
}