﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LobbyCsharp.Web.DTO
{
    [DataContract]
    public class OPlayer
    {                                           
        [DataMember]                            
        public int PlayerId { get; set; }          
        [DataMember]                            
        public string PlayerName { get; set; }
        [DataMember]
        public string GameState;
        


      
    }
}