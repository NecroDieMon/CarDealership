using CarDealership.DataBase;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using LogLibary;

namespace CarDealership
{
    public partial class ConfigurationAssemblyWindow : Window
    {
        public string _nameSpoiler, _nameColor, _nameEngine;
        public int _priceSpoiler, _priceColor, _priceEngine;
        public int _idSpoiler, _idColor, _idEngine;

        public static ConfigurationAssemblyWindow GetForm;

        CarDealershipDataBase dataBase = new CarDealershipDataBase();
        Log log = new Log();
        public ConfigurationAssemblyWindow()
        {
            InitializeComponent();
            DataLoad();
            GetForm = this;
        }

        public void DataLoad()
        {
            SpoilersGrid.ItemsSource = dataBase.Spoilers.ToList();
            ColorsGrid.ItemsSource = dataBase.Colors.ToList();
            EnginesGrid.ItemsSource = dataBase.Engines.ToList();
        }

        private void SpoilersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            log.LogSpoilersGrid();

            var select = SpoilersGrid.SelectedItem as Spoilers;
            _nameSpoiler = select.NameSpoiler;
            _priceSpoiler = select.PriceSpoiler;
            _idSpoiler = select.idSpoiler;
        }

        private void ColorsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            log.LogColorsGrid();

            var select = ColorsGrid.SelectedItem as DataBase.Colors;
            _nameColor = select.NameColor;
            _priceColor = select.PriceColor;
            _idColor = select.idColor;
        }

        private void EnginesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            log.LogEnginesGrid();

            var select = EnginesGrid.SelectedItem as Engines;
            _nameEngine = select.NameEngines;
            _priceEngine = select.PriceEngine;
            _idEngine = select.idEngine;
        }
    }
}
