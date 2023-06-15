using System;
using System.Collections.Generic;

namespace WpfPersonsTask.Data {
    public class Person {
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<Cat> Cats { get; set; }

        public static Person[] GetPersons() {
            List<Cat> cats = new List<Cat>()
            {
                new Cat(){Age=5,Name="Pussy"},
                new Cat(){Age=1,Name="Pupsik"},
                new Cat(){Age=2,Name="Nulick"},
                new Cat(){Age=5,Name="City"},
            };
            Person[] persons = new Person[]
            {
                new Person() { Name = "John", LastName = "Dir", Cats = new List<Cat>()
                {
                    new Cat(){Age=5,Name="Pussy1"},
                    new Cat(){Age=3,Name="Pussy2"},
                    new Cat(){Age=4,Name="Pussy3"}
                }},
                new Person() { Name = "John", LastName = "Smith" , Cats = new List<Cat>()
                {
                    new Cat(){Age=4,Name="Pussy4"}
                }},
                new Person() { Name = "Ethon", LastName = "Jhon"  , Cats = new List<Cat>()
                {
                    new Cat(){Age=4,Name="Pussy5"}
                }},
                new Person() { Name = "John", LastName = "Harris"  , Cats = new List<Cat>()
                {
                    new Cat(){Age=4,Name="Pussy6"}
                }},
                new Person() { Name = "Олег", LastName = "Иванов" , Cats = new List<Cat>()
                {
                    new Cat(){Age=4,Name="Pussy7"}
                }},
                new Person() { Name = "Пётр", LastName = "Смирнов"  , Cats = new List<Cat>()
                {
                    new Cat(){Age=4,Name="Pussy8"}
                }},
                new Person() { Name = "Семён", LastName = "Альтов" },
                new Person() { Name = "Гога", LastName = "Джугашвилли" }
            };
            return persons;
        }
    }
}