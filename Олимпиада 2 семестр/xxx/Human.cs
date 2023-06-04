using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xxx
{
    internal class Human
    {
        string Name;
        string Code;
        List<Human> unders = new List<Human>();

        public Human(string code, Human under, string name = "Unknown name")
        {
            Name = name;
            Code = code;
            unders.Add(under);
        }

        public Human(string code, string name = "Unknown name")
        {
            Name = name;
            Code = code;
        }

        public void Append(Human hmn)
        {
            unders.Add(hmn);
        }

        public List<Human> GetListOfUnders() { { return unders; } }
        public string GetName() { { return Name; } }
        public void SetName(string name) { Name = name; }
        public string GetCode() { return Code; }

        public static void ReplaceName(List<Human> list, string code, string newName)
        {
            foreach (var item in list)
            {
                if (item.Code == code && item.Name == "Unknown name") { item.Name = newName; }
                ReplaceName(item.GetListOfUnders(), code, newName);
            }
        }
    }
}