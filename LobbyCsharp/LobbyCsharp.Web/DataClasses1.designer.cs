﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18051
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LobbyCsharp.Web
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Battleships")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertLobby(Lobby instance);
    partial void UpdateLobby(Lobby instance);
    partial void DeleteLobby(Lobby instance);
    partial void InsertPlayLobby(PlayLobby instance);
    partial void UpdatePlayLobby(PlayLobby instance);
    partial void DeletePlayLobby(PlayLobby instance);
    partial void InsertPlayer(Player instance);
    partial void UpdatePlayer(Player instance);
    partial void DeletePlayer(Player instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["BattleshipsConnectionString1"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Lobby> Lobbies
		{
			get
			{
				return this.GetTable<Lobby>();
			}
		}
		
		public System.Data.Linq.Table<PlayLobby> PlayLobbies
		{
			get
			{
				return this.GetTable<PlayLobby>();
			}
		}
		
		public System.Data.Linq.Table<Player> Players
		{
			get
			{
				return this.GetTable<Player>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Lobby")]
	public partial class Lobby : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _LobbyId;
		
		private string _LobbyName;
		
		private System.Nullable<int> _IsWaitingForPlayers;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnLobbyIdChanging(int value);
    partial void OnLobbyIdChanged();
    partial void OnLobbyNameChanging(string value);
    partial void OnLobbyNameChanged();
    partial void OnIsWaitingForPlayersChanging(System.Nullable<int> value);
    partial void OnIsWaitingForPlayersChanged();
    #endregion
		
		public Lobby()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LobbyId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int LobbyId
		{
			get
			{
				return this._LobbyId;
			}
			set
			{
				if ((this._LobbyId != value))
				{
					this.OnLobbyIdChanging(value);
					this.SendPropertyChanging();
					this._LobbyId = value;
					this.SendPropertyChanged("LobbyId");
					this.OnLobbyIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LobbyName", DbType="NChar(10)")]
		public string LobbyName
		{
			get
			{
				return this._LobbyName;
			}
			set
			{
				if ((this._LobbyName != value))
				{
					this.OnLobbyNameChanging(value);
					this.SendPropertyChanging();
					this._LobbyName = value;
					this.SendPropertyChanged("LobbyName");
					this.OnLobbyNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsWaitingForPlayers", DbType="Int")]
		public System.Nullable<int> IsWaitingForPlayers
		{
			get
			{
				return this._IsWaitingForPlayers;
			}
			set
			{
				if ((this._IsWaitingForPlayers != value))
				{
					this.OnIsWaitingForPlayersChanging(value);
					this.SendPropertyChanging();
					this._IsWaitingForPlayers = value;
					this.SendPropertyChanged("IsWaitingForPlayers");
					this.OnIsWaitingForPlayersChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.PlayLobby")]
	public partial class PlayLobby : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _PlayerId;
		
		private int _LobbyId;
		
		private System.Nullable<int> _HostPlayer;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnPlayerIdChanging(int value);
    partial void OnPlayerIdChanged();
    partial void OnLobbyIdChanging(int value);
    partial void OnLobbyIdChanged();
    partial void OnHostPlayerChanging(System.Nullable<int> value);
    partial void OnHostPlayerChanged();
    #endregion
		
		public PlayLobby()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PlayerId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int PlayerId
		{
			get
			{
				return this._PlayerId;
			}
			set
			{
				if ((this._PlayerId != value))
				{
					this.OnPlayerIdChanging(value);
					this.SendPropertyChanging();
					this._PlayerId = value;
					this.SendPropertyChanged("PlayerId");
					this.OnPlayerIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LobbyId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int LobbyId
		{
			get
			{
				return this._LobbyId;
			}
			set
			{
				if ((this._LobbyId != value))
				{
					this.OnLobbyIdChanging(value);
					this.SendPropertyChanging();
					this._LobbyId = value;
					this.SendPropertyChanged("LobbyId");
					this.OnLobbyIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HostPlayer", DbType="Int")]
		public System.Nullable<int> HostPlayer
		{
			get
			{
				return this._HostPlayer;
			}
			set
			{
				if ((this._HostPlayer != value))
				{
					this.OnHostPlayerChanging(value);
					this.SendPropertyChanging();
					this._HostPlayer = value;
					this.SendPropertyChanged("HostPlayer");
					this.OnHostPlayerChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Player")]
	public partial class Player : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _PlayerId;
		
		private string _PlayerName;
		
		private string _GameState;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnPlayerIdChanging(int value);
    partial void OnPlayerIdChanged();
    partial void OnPlayerNameChanging(string value);
    partial void OnPlayerNameChanged();
    partial void OnGameStateChanging(string value);
    partial void OnGameStateChanged();
    #endregion
		
		public Player()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PlayerId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int PlayerId
		{
			get
			{
				return this._PlayerId;
			}
			set
			{
				if ((this._PlayerId != value))
				{
					this.OnPlayerIdChanging(value);
					this.SendPropertyChanging();
					this._PlayerId = value;
					this.SendPropertyChanged("PlayerId");
					this.OnPlayerIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PlayerName", DbType="NChar(10)")]
		public string PlayerName
		{
			get
			{
				return this._PlayerName;
			}
			set
			{
				if ((this._PlayerName != value))
				{
					this.OnPlayerNameChanging(value);
					this.SendPropertyChanging();
					this._PlayerName = value;
					this.SendPropertyChanged("PlayerName");
					this.OnPlayerNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GameState", DbType="NChar(10)")]
		public string GameState
		{
			get
			{
				return this._GameState;
			}
			set
			{
				if ((this._GameState != value))
				{
					this.OnGameStateChanging(value);
					this.SendPropertyChanging();
					this._GameState = value;
					this.SendPropertyChanged("GameState");
					this.OnGameStateChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
