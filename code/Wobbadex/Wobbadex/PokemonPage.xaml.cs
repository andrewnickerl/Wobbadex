using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Toolkit.Uwp.UI.Controls;
using WobbadexClassLibrary;
using System.Data;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Wobbadex
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PokemonPage : Page
    {
        public PokemonPage()
        {
            this.InitializeComponent();
            //this.pokemonRepository = GetPokemon(this.connectionString);

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM pokemon";
                DataTable pokemonTable = new DataTable();

                using (var dataAdapter = new SqlDataAdapter(command))
                {
                    dataAdapter.Fill(pokemonTable);
                }

                for (int i = 0; i < pokemonTable.Columns.Count; i++)
                {
                    PokemonGrid.Columns.Add(new DataGridTextColumn() 
                    {
                        Header = pokemonTable.Columns[i].ColumnName,
                        Binding = new Binding { Path = new PropertyPath("[" + i.ToString() + "]") }
                    });
                }

                var pokemonCollection = new ObservableCollection<object>();
                foreach(DataRow row in pokemonTable.Rows)
                {
                    pokemonCollection.Add(row.ItemArray);
                }

                PokemonGrid.ItemsSource = pokemonCollection;
            }
            
        }

        //public readonly ObservableCollection<Pokemon> pokemonRepository;
        ////Connection string using Window Authentication
        private readonly string connectionString =
        @"Server = DESKTOP-QA4COAS\SQLEXPRESS; Database = Wobbadex; Trusted_Connection = True";

        ////populates pokemonRepository from DB using connectionString
        //public ObservableCollection<Pokemon> GetPokemon(string connectionString)
        //{
        //    const string GetPokemonQuery = "SELECT * FROM pokemon";

        //    var pokemonCollection = new ObservableCollection<Pokemon>();

        //    SqlConnection conn = new SqlConnection(connectionString);
        //    conn.Open();
        //    if (conn.State == System.Data.ConnectionState.Open)
        //    {
        //        SqlCommand cmd = conn.CreateCommand();
        //        cmd.CommandText = GetPokemonQuery;
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            var pokemon = new Pokemon();
        //            pokemon.PokedexNumber = reader.GetInt32(0);
        //            pokemon.Name = reader.GetString(1);
        //            pokemon.Abilities = reader.GetString(2);
        //            pokemon.Type1 = reader.GetString(3);
        //            if (reader.IsDBNull(Convert.ToInt32(pokemon.Type2))) pokemon.Type2 = "";
        //            else pokemon.Type2 = reader.GetString(4);
        //            pokemon.Hp = reader.GetInt32(5);
        //            pokemon.Attack = reader.GetInt32(6);
        //            pokemon.Defense = reader.GetInt32(7);
        //            pokemon.SpAtk = reader.GetInt32(8);
        //            pokemon.SpDef = reader.GetInt32(9);
        //            pokemon.Speed = reader.GetInt32(10);
        //            pokemon.BaseEggSteps = reader.GetInt32(11);
        //            pokemon.BaseHappiness = reader.GetInt32(12);
        //            pokemon.CaptureRate = reader.GetInt32(13);
        //            pokemon.Classification = reader.GetString(14);
        //            pokemon.ExperienceGrowth = reader.GetInt32(15);
        //            if (reader.IsDBNull(Convert.ToInt32(pokemon.HeightM))) pokemon.HeightM = null;
        //            else pokemon.HeightM = reader.GetFloat(16);
        //            if (reader.IsDBNull(Convert.ToInt32(pokemon.WeightKg))) pokemon.HeightM = null;
        //            else pokemon.WeightKg = reader.GetFloat(17);
        //            if (reader.IsDBNull(Convert.ToInt32(pokemon.PercentageMale))) pokemon.HeightM = null;
        //            else pokemon.PercentageMale = reader.GetFloat(18);
        //            pokemon.Generation = reader.GetInt32(19);
        //            pokemon.Legendary = reader.GetBoolean(20);
        //            pokemon.AgainstBug = reader.GetFloat(21);
        //            pokemon.AgainstDark = reader.GetFloat(22);
        //            pokemon.AgainstDragon = reader.GetFloat(23);
        //            pokemon.AgainstElectric = reader.GetFloat(24);
        //            pokemon.AgainstFairy = reader.GetFloat(25);
        //            pokemon.AgainstFight = reader.GetFloat(26);
        //            pokemon.AgainstFire = reader.GetFloat(27);
        //            pokemon.AgainstFlying = reader.GetFloat(28);
        //            pokemon.AgainstGhost = reader.GetFloat(29);
        //            pokemon.AgainstGrass = reader.GetFloat(30);
        //            pokemon.AgainstGround = reader.GetFloat(31);
        //            pokemon.AgainstIce = reader.GetFloat(32);
        //            pokemon.AgainstNormal = reader.GetFloat(33);
        //            pokemon.AgainstPoison = reader.GetFloat(34);
        //            pokemon.AgainstPsychic = reader.GetFloat(35);
        //            pokemon.AgainstRock = reader.GetFloat(36);
        //            pokemon.AgainstSteel = reader.GetFloat(37);
        //            pokemon.AgainstWater = reader.GetFloat(38);

        //            pokemonCollection.Add(pokemon);
        //        }
        //        return pokemonCollection;
        //    }
        //    else return null;
        //}
    }
}
