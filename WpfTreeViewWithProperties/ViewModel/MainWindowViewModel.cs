using System.Collections.Generic;
using System.Collections.ObjectModel;
using WpfTreeViewWithProperties.Core;

namespace WpfTreeViewWithPropertys.ViewModel {
    public class MainWindowViewModel: ViewModelBase {
        private List<ElectricPanel> _electricPanelList;

        public List<ElectricPanel> ElectricPanelList
        {
            get => _electricPanelList;
            set
            {
                _electricPanelList = value;
                OnPropertyChanged(nameof(ElectricPanelList));
            }
        }

        private static IHierarchical _selectedItem;

        public IHierarchical SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                LoadData();
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
        
        public ObservableCollection<KeyValue> KeyValuePairs { get; set; }
        private void LoadData()
        {
            KeyValuePairs = new ObservableCollection<KeyValue>();
            foreach (KeyValuePair<string, object> kvp in ((Base) _selectedItem).Fields)
            {
                KeyValuePairs.Add(new KeyValue { Key = kvp.Key, Value = kvp.Value });
                OnPropertyChanged(nameof(KeyValuePairs));
            }
        }


        public MainWindowViewModel() {
            _selectedItem = null;
            List<ElectricConsumer> electricConsumers = new List<ElectricConsumer>()
            {
                new ElectricConsumer(Base.SystemName.ElectricConsumer, "Потребитель 1"),
                new ElectricConsumer(Base.SystemName.ElectricConsumer, "Потребитель 2"),
                new ElectricConsumer(Base.SystemName.ElectricConsumer, "Потребитель 3")
            };
            List<ElectricalCable> electricalCable = new List<ElectricalCable>()
            {
                new ElectricalCable(Base.SystemName.ElectricalCable, "Кабель к потребителю 1"),
                new ElectricalCable(Base.SystemName.ElectricConsumer, "Кабель к потребителю 2"),
                new ElectricalCable(Base.SystemName.ElectricConsumer, "Кабель к потребителю 3")
            };
            List<AutomaticCircuitBreaker> automaticCircuitBreaker = new List<AutomaticCircuitBreaker>()
            {
                new AutomaticCircuitBreaker(Base.SystemName.AutomaticCircuitBreaker, "Автомат к потребителю 1"),
                new AutomaticCircuitBreaker(Base.SystemName.AutomaticCircuitBreaker, "Автомат к потребителю 2"),
                new AutomaticCircuitBreaker(Base.SystemName.AutomaticCircuitBreaker, "Автомат к потребителю 3")
            };
            List<ElectricFeeder> electricFeeders = new List<ElectricFeeder>()
            {
                new ElectricFeeder(
                    "ф1",
                    new List<IHierarchical>()
                    {
                        electricConsumers[0],
                        electricalCable[0],
                        automaticCircuitBreaker[0]
                    }
                ),
                new ElectricFeeder(
                    "ф2",
                    new List<IHierarchical>()
                    {
                        electricConsumers[1],
                        electricalCable[1],
                        automaticCircuitBreaker[1]
                    }
                ),
                new ElectricFeeder(
                    "ф3",
                    new List<IHierarchical>()
                    {
                        electricConsumers[2],
                        electricalCable[2],
                        automaticCircuitBreaker[2]
                    }
                ),
            };
            List<ElectricBus> electricBuses = new List<ElectricBus>()
            {
                new ElectricBus(
                    "1 СШ",
                    new List<IHierarchical>(electricFeeders)
                ),
                new ElectricBus(
                    "2 СШ",
                    new List<IHierarchical>(electricFeeders)
                ),
            };

            _electricPanelList = new List<ElectricPanel>()
            {
                new ElectricPanel(
                    "ЩР1",
                    new List<IHierarchical>(electricBuses)
                )
            };
        }
    }

    public class KeyValue {
        public string Key { get; set; }
        public object Value { get; set; }
    }
}