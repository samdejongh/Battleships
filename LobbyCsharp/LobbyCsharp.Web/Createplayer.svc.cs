using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LobbyCsharp.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Createplayer" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Createplayer.svc or Createplayer.svc.cs at the Solution Explorer and start debugging.
    public class Createplayer : ICreateplayer
    {
        private DataClasses1DataContext dc;
        public Createplayer()
        {
            dc = new DataClasses1DataContext();
        }


        public List<string> GetAllPlayers()
        {         

            var players = from r in dc.Players
                          select r.PlayerName;
            List<string> AllPlayersNames = new List<string>();
            foreach (var r in players)
            {

                AllPlayersNames.Add(r); 
            }
            return AllPlayersNames;        
        }


        public int NewId()
        {
            int newid = ((from s in dc.Players
                           select s.PlayerId).Max())+1;
            return newid;

        }


        public void AddNewPlayer(int PlayerId, string PlayerName)
        {
            try
            {
                Player newplayer = new Player();
                newplayer.PlayerName = PlayerName;
                newplayer.PlayerId= PlayerId;

                 dc.Players.InsertOnSubmit(newplayer);
                 dc.SubmitChanges();
            }
            catch (Exception)
            {
            }       
        }
    }
}
