using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LobbyCsharp.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LobbyService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LobbyService.svc or LobbyService.svc.cs at the Solution Explorer and start debugging.
    public class LobbyService : ILobbyService
    {
        private DataClasses1DataContext dc;
        public LobbyService()
        {
            dc = new DataClasses1DataContext();
        }


        /*
         * 
         */
        public List<DTO.OLobby> GetAvailableRooms()
        {
            var rooms = from r in dc.Lobbies
                        where (int)r.IsWaitingForPlayers == 1
                        select r;

            List<DTO.OLobby> lobbies = new List<DTO.OLobby>();
            foreach (var r in rooms)
            {
                DTO.OLobby l  = new DTO.OLobby(){ LobbyId = r.LobbyId, LobbyName = r.LobbyName};

                lobbies.Add(l);

            }

            return lobbies;

        }

        public void CreatePlayLobby(DTO.OPlayer host, int lobby)
        {

            try
            {
                PlayLobby pLobby = new PlayLobby();
                pLobby.HostPlayer = (int)host.PlayerId;
                pLobby.LobbyId = lobby;
                pLobby.PlayerId = (int)host.PlayerId;

                dc.PlayLobbies.InsertOnSubmit(pLobby);
                dc.SubmitChanges();
            }
            catch (Exception)
            {

            }

        }

        public List<DTO.OLobbyRoom> GetAvailableLobbyRooms()
        {
            var result = from l in dc.Lobbies
                         join pl in dc.PlayLobbies
                         on l.LobbyId equals pl.LobbyId
                         where l.IsWaitingForPlayers == 1
                         select new {l.LobbyId, l.LobbyName, pl.HostPlayer};



            List<DTO.OLobbyRoom> list = new List<DTO.OLobbyRoom>();
            foreach (var item in result)
            {
                DTO.OLobbyRoom lr = new DTO.OLobbyRoom() { hostPlayer = new DTO.OPlayer() { PlayerId = (int)item.HostPlayer }, theLobby = new DTO.OLobby() { LobbyId = item.LobbyId, LobbyName = item.LobbyName } };
                list.Add(lr);
            }
            return list;
        }

        public void SubscribeToLobbyRoom(DTO.OPlayer player, int lobby, int host)
        {
            try
            {
                PlayLobby pLobby = new PlayLobby();
                pLobby.HostPlayer = host;
                pLobby.LobbyId = lobby;
                pLobby.PlayerId = (int)player.PlayerId;

                dc.PlayLobbies.InsertOnSubmit(pLobby);
                dc.SubmitChanges();
            }
            catch (Exception)
            {

            }
        }

        public void StartPlay(DTO.OPlayer hostPlayer)
        {

            var lst = from l in dc.PlayLobbies
                      where l.HostPlayer == hostPlayer.PlayerId
                      select new {l.LobbyId};


            var update = (from l in dc.Lobbies
                      where l.LobbyId == lst.Single().LobbyId
                      select l).Single();

            update.IsWaitingForPlayers = 0;
            
            dc.SubmitChanges();

        }

        public DTO.GameObject SendGameUpdate(DTO.OPlayer player)
        {
            throw new NotImplementedException();
        }


        public void SubscribeToLobbyRoom(DTO.OPlayer player, int lobby)
        {
            try
            {
                PlayLobby pLobby = new PlayLobby();               
                pLobby.LobbyId = lobby;
                pLobby.PlayerId = (int)player.PlayerId;

                dc.PlayLobbies.InsertOnSubmit(pLobby);
                dc.SubmitChanges();
            }
            catch (Exception)
            {

            }
        }


        public DTO.OPlayer GetPlayer(int id)
        {
            var pl = (from p in dc.Players
                         where p.PlayerId == id
                         select p).Single();

            return new DTO.OPlayer() { PlayerId = pl.PlayerId, PlayerName = pl.PlayerName };

        }

    }
}
