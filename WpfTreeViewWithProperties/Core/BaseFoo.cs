using System;
using System.Collections.Generic;
using System.Reflection;

namespace WpfTreeViewWithProperties.Core {
    public class BaseFoo {
        public int PositionNumber { get; set; }
        public string PositionName { get; set; }
        public double PositionPower { get; set; }

        public Dictionary<string, object> FooFields
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
                if (field.Name == "FooFields") break;
                
                values[field.Name] = field.GetValue(obj);
            }
            return values;
        }
    }
}