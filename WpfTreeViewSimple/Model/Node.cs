using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfTreeViewSimple.Model {
    public class ViewModelBase: INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string PropertyChangedEvent) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyChangedEvent));
            }
        }
    }

    public class House:ViewModelBase
    {
        private int houseNumber;
        public int HouseNumber
        {
            get => houseNumber;
            set 
            { 
                houseNumber = value; 
                OnPropertyChanged(nameof(HouseNumber));
            }
        }
        public House(int number)
        {
            houseNumber = number;
        }
    }
    
   
    public class Street:ViewModelBase
    {
        private string streetName;
        private List<House> houses;
        public string StreetName
        {
            get => streetName;
            set 
            { 
                streetName = value; 
                OnPropertyChanged("StreetName");
            }
        }
        public List<House> Houses
        {
            get => houses;
            set { houses = value; OnPropertyChanged("Houses"); }
        }
 
        public Street(string strName)
        {
            streetName = strName;
            houses = new List<House>()
            {
                new House(1),
                new House(5),
                new House(11),
            };
        }
    }
    
    public class City:ViewModelBase
    {
        private string cityName;
        private List<Street> streetList;
        public string CityName 
        { 
            get => cityName;
            set { cityName = value; OnPropertyChanged("CityName"); } 
        }
        public List<Street> StreetList
        {
            get => streetList;
            set { streetList = value;OnPropertyChanged("StreetList"); }
        }
        public City(string name)
        {
            cityName = name;
            streetList = new List<Street>()
            {
                new Street("Улица 1"),
                new Street("Улица 2")
            };
        }
    }
    
    public class MainWindowViewModel:ViewModelBase
    {
        private List<City> cityList;
        public List<City> CityList
        {
            get => cityList;
            set { cityList = value; OnPropertyChanged("CityList"); }
        }
        public MainWindowViewModel()
        {
            cityList = new List<City>()
            {
                new City("Город 1"),
                new City("Город 2"),
                new City("Город 3"),
                new City("Город 4"),
            };
        }
    }

}