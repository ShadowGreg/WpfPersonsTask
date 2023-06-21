using System.Collections.Generic;
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
                OnPropertyChanged("CityList");
            }
        }

        private static IHierarchical _selectedItem;

        public IHierarchical SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
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
}