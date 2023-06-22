using System;
using System.Collections.Generic;
using System.Reflection;
using WpfTreeBD.Core.ServiceSystems;

namespace WpfTreeBD.Core {
    /// <summary>
    /// Базовый элемент системы с основными парметрами
    /// </summary>
    public class BaseNode {
        /// <summary>
        /// Идентификатор для БД
        /// </summary>
        public string SelfId { get;set; }
        /// <summary>
        /// Идентификаторы зависимых объектов
        /// </summary>
        public List<string> ChildrenId { get; set; }
        /// <summary>
        /// Имя систему, устройства, элемента
        /// </summary>
        public string SelfName { get; set; }
        /// <summary>
        /// Базовый текст для интерфейса
        /// set должен быть переписан для каждого значиваемого классаы
        /// </summary>
        public string UIText { get; protected set; }
        /// <summary>
        /// Словарь свойств объекта 
        /// </summary>
        public Dictionary<string, object> Fields
        {
            get=>GetValues(this);
            set=>SetValues(value);
        }
        /// <summary>
        /// Установить свойства объекта при помощи словаря
        /// </summary>
        /// <param name="values"></param>
        private void SetValues(Dictionary<string, object> values) {
            foreach (KeyValuePair<string, object> kvp in values) {
                PropertyInfo prop = GetType().GetProperty(kvp.Key);
                if (prop != null && prop.CanWrite) {
                    prop.SetValue(this, kvp.Value);
                }
            }
        }
        /// <summary>
        /// Получить свойства объекта словарём
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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
        
        public BaseNode() {
            SelfId = IdGenerator.GenerateId();
            SelfName = FixText.EmptyText;
            ChildrenId = FixText.EmptyList;
        }        
        public BaseNode(string selfName, List<string> childrenId) {
            SelfId = IdGenerator.GenerateId();
            SelfName = selfName;
            ChildrenId = childrenId;
        }
        public BaseNode(string selfId, string selfName, List<string> childrenId) {
            SelfId = selfId;
            SelfName = selfName;
            ChildrenId = childrenId;
        }
    }
}