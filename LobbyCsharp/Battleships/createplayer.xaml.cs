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
        public CreatePlayer.CreateplayerClient client;
        public bool playerexists = false;
        public List<string> ExestingPLayerList { get; set; }
        public string NewLoginName { get; set; }
        public string NewPassword { get; set; }
        public int NewId { get; set; }
        public createplayer()
        {
            InitializeComponent();            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewLoginName = newLogintbx.Text;
            NewPassword = newPasswordtbx.Text;


            client.GetAllPlayersCompleted += client_GetAllPlayersCompleted;
            client.GetAllPlayersAsync();

            foreach (var item in ExestingPLayerList)
            {
                if (item == NewLoginName)
                {
                    MessageBox.Show("Username Already exists");
                    playerexists = true;
                }
            }
            if (playerexists == false)
            {
                client.AddNewPlayerCompleted += client_AddNewPlayerCompleted;
                client.NewIdAsync();

                client.NewIdCompleted += client_NewIdCompleted;
                client.AddNewPlayerAsync(NewId, NewLoginName);
            }
            MessageBox.Show("jep");

            
        }

        void client_NewIdCompleted(object sender, CreatePlayer.NewIdCompletedEventArgs e)
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

        void client_GetAllPlayersCompleted(object sender, CreatePlayer.GetAllPlayersCompletedEventArgs e)
        {
            foreach (var item in e.Result)
                ExestingPLayerList.Add(item.ToString());
           // List<CreatePlayer.OPlayer> AllPlayerNamesList = e.Result.ToList();
            

        }
    }
}