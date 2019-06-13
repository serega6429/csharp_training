using System;
using System.Collections.Generic;
using System.IO;
using WebAddressbookTests;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace addressbook_web_tests_generator
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = args[0];
            int count = Convert.ToInt32(args[1]);
            StreamWriter writer = new StreamWriter(args[2]);
            string format = args[3];
            if ((type != "contacts") && (type != "groups"))
            {
                System.Console.Out.Write("Unrecognized type " + type);
                Environment.Exit(1);
            }
            
            if (format == "csv")
            {
                if(type == "contacts")
                {
                    writeContactsToCsvFile(generateContactsList(count), writer);
                }
                else
                {
                    writeGroupsToCsvFile(generateGroupsList(count), writer);
                }
            }
            else if (format == "xml")
            {
                if (type == "contacts")
                {
                    writeContactsToXmlFile(generateContactsList(count), writer);
                }
                else
                {
                    writeGroupsToXmlFile(generateGroupsList(count), writer);
                }
            }
            else if (format == "json")
            {
                if (type == "contacts")
                {
                    writeContactsToJsonFile(generateContactsList(count), writer);
                }
                else
                {
                    writeGroupsToJsonFile(generateGroupsList(count), writer);
                }
            }
            else
            {
                System.Console.Out.Write("Unrecognized format " + format);
            }

            writer.Close();
        }

        private static List<ContactData> generateContactsList(int count)
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < count; i++)
            {
                contacts.Add(new ContactData(TestBase.GenerateRandomStrring(20),
                    TestBase.GenerateRandomStrring(20)));
            }
            return contacts;
        }
        private static List<GroupData> generateGroupsList(int count)
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomStrring(10))
                {
                    Header = TestBase.GenerateRandomStrring(100),
                    Footer = TestBase.GenerateRandomStrring(100)
                });
            }
            return groups;
        }
            

        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }
        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }
        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));   
        }
        static void writeContactsToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("${0},${1}",
                    contact.Firstname, contact.Lastname));
            }
        }
        static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }
        static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
