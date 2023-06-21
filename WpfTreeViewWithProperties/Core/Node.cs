using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WpfTreeViewWithPropertys.ViewModel;

namespace WpfTreeViewWithProperties.Core {
    public interface IHierarchical {
        string GetId();
        List<string> GetChildrensId();
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
        
        public Dictionary<string, object> Fields
        {
            get=>GetValues(this);
            set=>SetValues(value);
        }

        private void SetValues(Dictionary<string, object> values) {
            foreach (KeyValuePair<string, object> kvp in values) {
                PropertyInfo prop = GetType().GetProperty(kvp.Key);
                if (prop != null && prop.CanWrite) {
                    prop.SetValue(this, kvp.Value);
                }
            }
        }

        private static Dictionary<string, object> GetValues(object obj)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();
            Type type = obj.GetType();
            PropertyInfo[] fields = type.GetProperties();
            foreach (PropertyInfo field in fields)
            {
                if (field.Name == "Fields") break;
                
                values[field.Name] = field.GetValue(obj);
            }
            return values;
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
                OnPropertyChanged("SomeName");
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
}