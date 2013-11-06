using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LobbyCsharp.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICreateplayer" in both code and config file together.
    [ServiceContract]
    public interface ICreateplayer
    {
        [OperationContract]
        List<string> GetAllPlayers();
        [OperationContract]
        void AddNewPlayer(int PlayerId, string PlayerName);
        [OperationContract]
        int NewId();
        

    }
}
