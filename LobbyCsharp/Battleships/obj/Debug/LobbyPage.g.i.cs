﻿#pragma checksum "D:\Dropbox\MM systems 5\Gamelobby Demo\LobbyCsharp\Battleships\LobbyPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9CD0F9DE043B6AEC327013CAF61633EE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Battleships {
    
    
    public partial class LobbyPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Button btnCheckforlobies;
        
        internal System.Windows.Controls.ListBox lstPlayRooms;
        
        internal System.Windows.Controls.ListBox lstGameMembers;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Battleships;component/LobbyPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.btnCheckforlobies = ((System.Windows.Controls.Button)(this.FindName("btnCheckforlobies")));
            this.lstPlayRooms = ((System.Windows.Controls.ListBox)(this.FindName("lstPlayRooms")));
            this.lstGameMembers = ((System.Windows.Controls.ListBox)(this.FindName("lstGameMembers")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
        }
    }
}
