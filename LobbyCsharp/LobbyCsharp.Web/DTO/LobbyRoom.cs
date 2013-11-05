using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LobbyCsharp.Web.DTO
{
    [DataContract]
    public class OLobbyRoom
    {
        [DataMember]
        public OLobby theLobby { get; set; }

        [DataMember]
        public List<OPlayer> playerList { get; set; }

        [DataMember]
        public OPlayer hostPlayer { get; set; }
    }
}