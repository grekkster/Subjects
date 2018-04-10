﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Tento kód byl generován nástrojem.
//     Verze modulu runtime:4.0.30319.42000
//
//     Změny tohoto souboru mohou způsobit nesprávné chování a budou ztraceny,
//     dojde-li k novému generování kódu.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Subjects.Models
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="SubjectDB")]
	public partial class SubjectsDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertKontakt(Kontakt instance);
    partial void UpdateKontakt(Kontakt instance);
    partial void DeleteKontakt(Kontakt instance);
    partial void InsertSubjekt(Subjekt instance);
    partial void UpdateSubjekt(Subjekt instance);
    partial void DeleteSubjekt(Subjekt instance);
    #endregion
		
		public SubjectsDataContext() : 
				base(global::Subjects.Properties.Settings.Default.SubjectDBConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public SubjectsDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SubjectsDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SubjectsDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SubjectsDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Kontakt> Kontakt
		{
			get
			{
				return this.GetTable<Kontakt>();
			}
		}
		
		public System.Data.Linq.Table<Subjekt> Subjekt
		{
			get
			{
				return this.GetTable<Subjekt>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Kontakt")]
	public partial class Kontakt : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Jmeno;
		
		private string _Prijmeni;
		
		private System.DateTime _DatumNarozeni;
		
		private string _Telefon;
		
		private System.Nullable<System.DateTime> _Vlozeno;
		
		private System.Nullable<int> _Ico;
		
		private EntityRef<Subjekt> _Subjekt;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnJmenoChanging(string value);
    partial void OnJmenoChanged();
    partial void OnPrijmeniChanging(string value);
    partial void OnPrijmeniChanged();
    partial void OnDatumNarozeniChanging(System.DateTime value);
    partial void OnDatumNarozeniChanged();
    partial void OnTelefonChanging(string value);
    partial void OnTelefonChanged();
    partial void OnVlozenoChanging(System.Nullable<System.DateTime> value);
    partial void OnVlozenoChanged();
    partial void OnIcoChanging(System.Nullable<int> value);
    partial void OnIcoChanged();
    #endregion
		
		public Kontakt()
		{
			this._Subjekt = default(EntityRef<Subjekt>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Jmeno", DbType="NVarChar(60) NOT NULL", CanBeNull=false)]
		public string Jmeno
		{
			get
			{
				return this._Jmeno;
			}
			set
			{
				if ((this._Jmeno != value))
				{
					this.OnJmenoChanging(value);
					this.SendPropertyChanging();
					this._Jmeno = value;
					this.SendPropertyChanged("Jmeno");
					this.OnJmenoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Prijmeni", DbType="NVarChar(60) NOT NULL", CanBeNull=false)]
		public string Prijmeni
		{
			get
			{
				return this._Prijmeni;
			}
			set
			{
				if ((this._Prijmeni != value))
				{
					this.OnPrijmeniChanging(value);
					this.SendPropertyChanging();
					this._Prijmeni = value;
					this.SendPropertyChanged("Prijmeni");
					this.OnPrijmeniChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DatumNarozeni", DbType="Date NOT NULL")]
		public System.DateTime DatumNarozeni
		{
			get
			{
				return this._DatumNarozeni;
			}
			set
			{
				if ((this._DatumNarozeni != value))
				{
					this.OnDatumNarozeniChanging(value);
					this.SendPropertyChanging();
					this._DatumNarozeni = value;
					this.SendPropertyChanged("DatumNarozeni");
					this.OnDatumNarozeniChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Telefon", DbType="NVarChar(16)")]
		public string Telefon
		{
			get
			{
				return this._Telefon;
			}
			set
			{
				if ((this._Telefon != value))
				{
					this.OnTelefonChanging(value);
					this.SendPropertyChanging();
					this._Telefon = value;
					this.SendPropertyChanged("Telefon");
					this.OnTelefonChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Vlozeno", DbType="DateTime")]
		public System.Nullable<System.DateTime> Vlozeno
		{
			get
			{
				return this._Vlozeno;
			}
			set
			{
				if ((this._Vlozeno != value))
				{
					this.OnVlozenoChanging(value);
					this.SendPropertyChanging();
					this._Vlozeno = value;
					this.SendPropertyChanged("Vlozeno");
					this.OnVlozenoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ico", DbType="Int")]
		public System.Nullable<int> Ico
		{
			get
			{
				return this._Ico;
			}
			set
			{
				if ((this._Ico != value))
				{
					if (this._Subjekt.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIcoChanging(value);
					this.SendPropertyChanging();
					this._Ico = value;
					this.SendPropertyChanged("Ico");
					this.OnIcoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Subjekt_Kontakt", Storage="_Subjekt", ThisKey="Ico", OtherKey="Ico", IsForeignKey=true)]
		public Subjekt Subjekt
		{
			get
			{
				return this._Subjekt.Entity;
			}
			set
			{
				Subjekt previousValue = this._Subjekt.Entity;
				if (((previousValue != value) 
							|| (this._Subjekt.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Subjekt.Entity = null;
						previousValue.Kontakt.Remove(this);
					}
					this._Subjekt.Entity = value;
					if ((value != null))
					{
						value.Kontakt.Add(this);
						this._Ico = value.Ico;
					}
					else
					{
						this._Ico = default(Nullable<int>);
					}
					this.SendPropertyChanged("Subjekt");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Subjekt")]
	public partial class Subjekt : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Ico;
		
		private string _Nazev;
		
		private string _Ulice;
		
		private string _Obec;
		
		private string _Psc;
		
		private string _Poznamka;
		
		private System.Nullable<System.DateTime> _Vlozeno;
		
		private EntitySet<Kontakt> _Kontakt;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIcoChanging(int value);
    partial void OnIcoChanged();
    partial void OnNazevChanging(string value);
    partial void OnNazevChanged();
    partial void OnUliceChanging(string value);
    partial void OnUliceChanged();
    partial void OnObecChanging(string value);
    partial void OnObecChanged();
    partial void OnPscChanging(string value);
    partial void OnPscChanged();
    partial void OnPoznamkaChanging(string value);
    partial void OnPoznamkaChanged();
    partial void OnVlozenoChanging(System.Nullable<System.DateTime> value);
    partial void OnVlozenoChanged();
    #endregion
		
		public Subjekt()
		{
			this._Kontakt = new EntitySet<Kontakt>(new Action<Kontakt>(this.attach_Kontakt), new Action<Kontakt>(this.detach_Kontakt));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ico", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Ico
		{
			get
			{
				return this._Ico;
			}
			set
			{
				if ((this._Ico != value))
				{
					this.OnIcoChanging(value);
					this.SendPropertyChanging();
					this._Ico = value;
					this.SendPropertyChanged("Ico");
					this.OnIcoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nazev", DbType="NVarChar(60)")]
		public string Nazev
		{
			get
			{
				return this._Nazev;
			}
			set
			{
				if ((this._Nazev != value))
				{
					this.OnNazevChanging(value);
					this.SendPropertyChanging();
					this._Nazev = value;
					this.SendPropertyChanged("Nazev");
					this.OnNazevChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ulice", DbType="NVarChar(60)")]
		public string Ulice
		{
			get
			{
				return this._Ulice;
			}
			set
			{
				if ((this._Ulice != value))
				{
					this.OnUliceChanging(value);
					this.SendPropertyChanging();
					this._Ulice = value;
					this.SendPropertyChanged("Ulice");
					this.OnUliceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Obec", DbType="NVarChar(60)")]
		public string Obec
		{
			get
			{
				return this._Obec;
			}
			set
			{
				if ((this._Obec != value))
				{
					this.OnObecChanging(value);
					this.SendPropertyChanging();
					this._Obec = value;
					this.SendPropertyChanged("Obec");
					this.OnObecChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Psc", DbType="NChar(5)")]
		public string Psc
		{
			get
			{
				return this._Psc;
			}
			set
			{
				if ((this._Psc != value))
				{
					this.OnPscChanging(value);
					this.SendPropertyChanging();
					this._Psc = value;
					this.SendPropertyChanged("Psc");
					this.OnPscChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Poznamka", DbType="NVarChar(MAX)")]
		public string Poznamka
		{
			get
			{
				return this._Poznamka;
			}
			set
			{
				if ((this._Poznamka != value))
				{
					this.OnPoznamkaChanging(value);
					this.SendPropertyChanging();
					this._Poznamka = value;
					this.SendPropertyChanged("Poznamka");
					this.OnPoznamkaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Vlozeno", DbType="DateTime")]
		public System.Nullable<System.DateTime> Vlozeno
		{
			get
			{
				return this._Vlozeno;
			}
			set
			{
				if ((this._Vlozeno != value))
				{
					this.OnVlozenoChanging(value);
					this.SendPropertyChanging();
					this._Vlozeno = value;
					this.SendPropertyChanged("Vlozeno");
					this.OnVlozenoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Subjekt_Kontakt", Storage="_Kontakt", ThisKey="Ico", OtherKey="Ico")]
		public EntitySet<Kontakt> Kontakt
		{
			get
			{
				return this._Kontakt;
			}
			set
			{
				this._Kontakt.Assign(value);
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
		
		private void attach_Kontakt(Kontakt entity)
		{
			this.SendPropertyChanging();
			entity.Subjekt = this;
		}
		
		private void detach_Kontakt(Kontakt entity)
		{
			this.SendPropertyChanging();
			entity.Subjekt = null;
		}
	}
}
#pragma warning restore 1591
