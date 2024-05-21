using CarDealership.DataBase;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using MultiWindowInterfaceLibary;
using LogLibary;
using CarDealershipLibrary;

namespace CarDealership
{
    public partial class MainWindow : Window
    {
        private string _nameCar, _haveCar;
        private int _priceCar, _discount, _idCar;

        CarDealershipDataBase dataBase = new CarDealershipDataBase();
        ConfigurationAssemblyWindow assemblyWindow = new ConfigurationAssemblyWindow();
        MultiWindow multiWindow = new MultiWindow();
        Log log = new Log();
        public MainWindow()
        {
            InitializeComponent();
            multiWindow.GetMultiWindow(assemblyWindow);
            DataLoad();
        }

        public void DataLoad()
        {
            CarsGrid.ItemsSource = dataBase.Cars.ToList();
        }

        private void SortByAvailability_Click(object sender, RoutedEventArgs e)
        {
            log.LogButtonSortByAvailability();
            CarsGrid.ItemsSource = dataBase.Cars.Where(p => p.Availability == "Да").ToList();
        }

        private void SortByAbsence_Click(object sender, RoutedEventArgs e)
        {
            log.LogButtonSortByNonAvailability();
            CarsGrid.ItemsSource = dataBase.Cars.Where(p => p.Availability == "Нет").ToList();
        }

        private void GetTotalSum_Click(object sender, RoutedEventArgs e)
        {
            int sum = _priceCar + ConfigurationAssemblyWindow.GetForm._priceSpoiler + ConfigurationAssemblyWindow.GetForm._priceColor + ConfigurationAssemblyWindow.GetForm._priceEngine;
            YourTotalSum.Text = sum.ToString();
        }

        private void BuyCar_Click(object sender, RoutedEventArgs e)
        {
            log.LogButtonBuy();

            if (ConfigurationAssemblyWindow.GetForm._nameSpoiler == null)
            {
                ConfigurationAssemblyWindow.GetForm._nameSpoiler = " ";
                ConfigurationAssemblyWindow.GetForm._priceSpoiler = 0;
            }
            else if (ConfigurationAssemblyWindow.GetForm._nameColor == null)
            {
                ConfigurationAssemblyWindow.GetForm._nameColor = " ";
                ConfigurationAssemblyWindow.GetForm._priceColor = 0;
            }
            else if (ConfigurationAssemblyWindow.GetForm._nameEngine == null)
            {
                ConfigurationAssemblyWindow.GetForm._nameEngine = " ";
                ConfigurationAssemblyWindow.GetForm._priceEngine = 0;
            }

            if(_nameCar == null)
            {
                MessageBox.Show("Вы не выбрали автомобиль!");
            }
            else
            {
                if(_haveCar == "Да")
                {
                    IBuilder carBuilder = new CarBuilder();
                    Director director = new Director(
                        carBuilder,
                        _nameCar,
                        ConfigurationAssemblyWindow.GetForm._nameSpoiler,
                        ConfigurationAssemblyWindow.GetForm._nameColor,
                        ConfigurationAssemblyWindow.GetForm._nameEngine,
                        _priceCar,
                         ConfigurationAssemblyWindow.GetForm._priceSpoiler,
                         ConfigurationAssemblyWindow.GetForm._priceColor,
                         ConfigurationAssemblyWindow.GetForm._priceEngine,
                         _discount);
                    director.CreateYourCar();
                    Car car = carBuilder.GetResult();
                    MessageBox.Show("Заказа оформлен! Ваш чек с названием <MyCheque> лежит в папке Release!");

                    Cheques cheques = new Cheques()
                    {
                        idCar = _idCar,
                        idSpoiler = ConfigurationAssemblyWindow.GetForm._idSpoiler,
                        idColor = ConfigurationAssemblyWindow.GetForm._idColor,
                        idEngine = ConfigurationAssemblyWindow.GetForm._idEngine
                    };
                    dataBase.Cheques.Add(cheques);
                    dataBase.SaveChanges();
                    MessageBox.Show("Ваш чек занесён в базу данных!");
                }
                else
                {
                    MessageBox.Show("Автомобиля нет в наличии!");
                }
            }
        }

        private void CarsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            log.LogCarsGrid();

            var select = CarsGrid.SelectedItem as Cars;
            _nameCar = select.Mark;
            _priceCar = select.Price;
            _discount = select.Discount;
            _haveCar = select.Availability;
            _idCar = select.idCar;
        }
    }
}
