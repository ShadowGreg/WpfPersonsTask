using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace WpfTreeViewWithProperties.Core {
    public interface IHierarchical {
        string GetId();
        List<string> GetChildrensId();
    }

    public class ViewModelBase: INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string PropertyChangedEvent) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyChangedEvent));
            }
        }
    }

    public abstract class Base: ViewModelBase {
        public string Id { get; set; }

        /// <summary>
        /// для последующего формирования из бд
        /// </summary>
        public enum SystemName {
            ElectricPanel,
            ElectricBus,
            ElectricFeeder,
            AutomaticCircuitBreaker,
            ElectricalCable,
            ElectricConsumer
        }
    }

    public class ElectricConsumer: Base, IHierarchical {
        public string GetId() => Id;

        public List<string> GetChildrensId() {
            return null;
        }

        public SystemName InSystemName { get; set; }

        private string _someName;

        public string SomeName
        {
            get => _someName;
            protected set
            {
                _someName = value;
                OnPropertyChanged("ElectricConsumer_SomeName");
            }
        }

        public ElectricConsumer(SystemName systemName, string someName) {
            InSystemName = systemName;
            _someName = someName;
        }
    }

    public class ElectricalCable: ElectricConsumer {
        public ElectricalCable(SystemName systemName, string someName): base(systemName, someName) { }
    }

    public class AutomaticCircuitBreaker: ElectricConsumer {
        public AutomaticCircuitBreaker(SystemName systemName, string someName): base(systemName, someName) { }
    }

    public class ElectricFeeder: Base, IHierarchical {
        public string GetId() => Id;
        private List<string> _childrensId;

        public List<string> GetChildrensId() {
            return _childrens.Select(child => child.GetId()).ToList();
        }

        private List<IHierarchical> _childrens;

        public List<IHierarchical> Childrens
        {
            get => _childrens;
            set
            {
                _childrens = value;
                OnPropertyChanged("ElectricFeeder_Childrens");
            }
        }

        public ElectricFeeder(string id, List<IHierarchical> childrens) {
            Id = id;
            _childrens = childrens;
        }
    }

    public class ElectricBus: ElectricFeeder {
        public ElectricBus(string id, List<IHierarchical> childrens): base(id, childrens) { }
    }

    public class ElectricPanel: ElectricFeeder {
        public ElectricPanel(string id, List<IHierarchical> childrens): base(id, childrens) { }
    }

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

        public MainWindowViewModel() {
            List<ElectricConsumer> electricConsumers = new List<ElectricConsumer>()
            {
                new ElectricConsumer(Base.SystemName.ElectricConsumer,"Потребитель 1"),
                new ElectricConsumer(Base.SystemName.ElectricConsumer,"Потребитель 2"),
                new ElectricConsumer(Base.SystemName.ElectricConsumer,"Потребитель 3")
            };
            List<ElectricalCable> electricalCable = new List<ElectricalCable>()
            {
                new ElectricalCable(Base.SystemName.ElectricalCable,"Кабель к потребителю 1"),
                new ElectricalCable(Base.SystemName.ElectricConsumer,"Кабель к потребителю 2"),
                new ElectricalCable(Base.SystemName.ElectricConsumer,"Кабель к потребителю 3")
            };
            List<AutomaticCircuitBreaker> automaticCircuitBreaker = new List<AutomaticCircuitBreaker>()
            {
                new AutomaticCircuitBreaker(Base.SystemName.AutomaticCircuitBreaker,"Автомат к потребителю 1"),
                new AutomaticCircuitBreaker(Base.SystemName.AutomaticCircuitBreaker,"Автомат к потребителю 2"),
                new AutomaticCircuitBreaker(Base.SystemName.AutomaticCircuitBreaker,"Автомат к потребителю 3")
            };
            List<ElectricFeeder> electricFeeders = new List<ElectricFeeder>()
            {
                new ElectricFeeder(
                    "1",
                    new List<IHierarchical>()
                    {
                        electricConsumers[0],
                        electricalCable[0],
                        automaticCircuitBreaker[0]
                    }
                    ),
                new ElectricFeeder(
                    "2",
                    new List<IHierarchical>()
                    {
                        electricConsumers[1],
                        electricalCable[1],
                        automaticCircuitBreaker[1]
                    }
                ),
                new ElectricFeeder(
                    "3",
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