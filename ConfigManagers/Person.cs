using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ConfigMgrExample.ConfigManagers
{
    public enum Sex
    {
        MALE,FEMALE
    }
    public class Person : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("age", IsRequired = true)]
        public int Age
        {
            get { return (int)this["age"]; }
            set { this["age"] = value; }
        }

        [ConfigurationProperty("sex", IsRequired = true)]
        public Sex Sex
        {
            get { return (Sex)this["sex"]; }
            set { this["sex"] = value; }
        }

        [ConfigurationProperty("is-employeed", IsRequired = true)]
        public bool IsEmployeed
        {
            get { return (bool)this["is-employeed"]; }
            set { this["is-employeed"] = value; }
        }


    }
    public class PersonCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new Person();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Person)element).Name;
        }

        // Lets you use foreach and indexing directly
        public Person this[int index]
        {
            get { return (Person)BaseGet(index); }
        }

        public new Person this[string name]
        {
            get { return (Person)BaseGet(name); }
        }

        // This tells the config system that child elements are named
        protected override string ElementName
        {
            get { return "person"; }
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }
    }
    public class PersonConfigurationManager : ConfigurationSection
    {
        [ConfigurationProperty("", IsDefaultCollection = true)]
        public PersonCollection Persons
        {
            get { return (PersonCollection)this[""]; }
        }
    }
}
