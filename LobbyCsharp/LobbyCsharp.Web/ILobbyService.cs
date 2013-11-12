using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LobbyCsharp.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILobbyService" in both code and config file together.
    [ServiceContract]
    public interface ILobbyService
    {
        // Lobby contracts
        [OperationContract]
        List<DTO.OLobby> GetAvailableRooms();

        [OperationContract]
        void CreatePlayLobby(DTO.OPlayer host, int lobby);

        [OperationContract]
        List<DTO.OLobbyRoom> GetAvailableLobbyRooms();

        [OperationContract]
        void SubscribeToLobbyRoom(DTO.OPlayer player, int lobby, int host);

        [OperationContract]
        void StartPlay(DTO.OPlayer hostPlayer);
        [OperationContract]
        int newlobbyid();

        /*[OperationContract]
        DTO.OPlayer GetPlayer(int id);*/

        // 
        [OperationContract]
        DTO.GameObject SendGameUpdate(DTO.OPlayer player);

        // Create Player Contracts

        [OperationContract]
        List<string> GetAllPlayers();
        [OperationContract]
        void AddNewPlayer(int PlayerId, string PlayerName);
        [OperationContract]
        int NewId();
        [OperationContract]
        string whichGameState(string PlayerNameName);
                
        //
        [OperationContract]
        bool LoggIn(string Name, string Paswoord);

        // select current player
        [OperationContract]
        DTO.OPlayer CurrentPlayer(string name);

        [OperationContract]
        void DeleteLobby(int id);

    }
}
