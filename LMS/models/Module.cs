using System.Collections.Generic;
using System;

namespace LMS.Models
{
    public class Module
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Item>? Items { get; set; }
        public Module(string? name="", string? description = "")
        {
            Name = name;
            Description = description;
            Items = new List<Item>();
            Items.Add(new Item { Name = "Testing Items", Description = "TEST", Path = "TEST PATH" });
            Console.WriteLine("Module Created");
        }
        public override string ToString()
        {
            return $"NAME:{Name}\nDESCRIPTION:{Description}";
        }
    }
}
