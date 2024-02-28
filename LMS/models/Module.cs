using System.Collections.Generic;
using System;

namespace LMS.Models
{
    public class Module
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Item>? Items { get; set; }
        public Module(string? name, string? description, List<Item>? items)
        {
            Name = name;
            Description = description;
            Items = items;
            Console.WriteLine("Module Created");
        }
    }
}
