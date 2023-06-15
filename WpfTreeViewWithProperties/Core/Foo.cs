using System.Collections.Generic;
using System.Reflection;

namespace WpfTreeViewWithProperties.Core {
    public class Foo {
        public int MyInt { get; set; }
        public string MyString { get; set; }
        public double MyDouble { get; set; }

        public void SetValues(Dictionary<string, object> values) {
            foreach (KeyValuePair<string, object> kvp in values) {
                PropertyInfo prop = GetType().GetProperty(kvp.Key);
                if (prop != null && prop.CanWrite) {
                    prop.SetValue(this, kvp.Value);
                }
            }
        }

        public Dictionary<string, object> GetValues() {
            Dictionary<string, object> values = new Dictionary<string, object>();
            foreach (PropertyInfo prop in GetType().GetProperties()) {
                if (prop.CanRead) {
                    values[prop.Name] = prop.GetValue(this);
                }
            }

            return values;
        }
    }
}