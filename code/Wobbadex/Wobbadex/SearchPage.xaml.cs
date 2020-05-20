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
    public sealed partial class SearchPage : Page
    {       
        //Connection string using Window Authentication
        private readonly string connectionString =
        @"Server = DESKTOP-QA4COAS\SQLEXPRESS; Database = Wobbadex; Trusted_Connection = True";
        //determines what data is pulled from the database table
        private string query = "SELECT * FROM pokemon";
        private string whereClause;
        private string searchParameter;

        //page constructor
        public SearchPage()
        {
            this.InitializeComponent();            
        }       

        private void SearchParameter_Click(object sender, RoutedEventArgs e)
        {
            string option = ((MenuFlyoutItem)sender).Tag.ToString();
            this.searchParameter = option;
            
            switch (option)
            {
                case "pokemon_name":
                    searchDropDown.Content = "Name";
                    break;
                case "pokedex_number":
                    searchDropDown.Content = "Pokedex Number";
                    break;
                case "type":
                    searchDropDown.Content = "Type";
                    break;
                case "is_legendary":
                    searchDropDown.Content = "Legendary";                    
                    break;
                default:

                    break;
            }
        }

        private void RunSearch_Click(object sender, RoutedEventArgs e)
        {
            switch (this.searchParameter)
            {
                case "pokemon_name":
                    this.whereClause = $"WHERE {this.searchParameter} like \'{searchTextBox.Text}\'";
                    break;
                case "pokedex_number":
                    this.whereClause = $"WHERE {this.searchParameter} like \'{searchTextBox.Text}\'";
                    break;
                case "type":
                    this.whereClause = $"WHERE type1 like \'{searchTextBox.Text}\' or type2 like \'{searchTextBox.Text}\'";
                    break;
                case "is_legendary":
                    if(searchTextBox.Text == "1" || searchTextBox.Text == "0")
                    {
                        this.whereClause = $"WHERE {this.searchParameter} like \'{searchTextBox.Text}\'";
                    }
                    else switch (searchTextBox.Text.ToLower())
                    {
                        case "yes":
                            this.whereClause = $"WHERE {this.searchParameter} like \'1\'";
                            break;
                        case "no":
                            this.whereClause = $"WHERE {this.searchParameter} like \'0\'";
                            break;
                        case "true":
                            this.whereClause = $"WHERE {this.searchParameter} like \'1\'";
                            break;
                        case "false":
                            this.whereClause = $"WHERE {this.searchParameter} like \'0\'";
                            break;
                        default:
                            break;
                    }                    
                    break;
                default:
                    break;
            }

            DataTable pokemonTable = GetPokemon(this.connectionString, $"{this.query} {this.whereClause}");

            for (int i = 0; i < pokemonTable.Columns.Count; i++)
            {
                PokemonGrid.Columns.Add(new DataGridTextColumn()
                {
                    Header = pokemonTable.Columns[i].ColumnName,
                    Binding = new Binding { Path = new PropertyPath("[" + i.ToString() + "]") }
                });
            }
            var pokemonCollection = new ObservableCollection<object>();
            foreach (DataRow row in pokemonTable.Rows)
            {
                pokemonCollection.Add(row.ItemArray);
            }
            PokemonGrid.ItemsSource = pokemonCollection;
        }

        public DataTable GetPokemon(string connectionString, string query)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = query;
                DataTable pokemonTable = new DataTable();

                using (var dataAdapter = new SqlDataAdapter(command))
                {
                    dataAdapter.Fill(pokemonTable);
                }                
                return pokemonTable;
            }
        }        
    }
}
