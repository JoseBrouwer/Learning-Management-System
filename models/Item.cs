using System;

namespace LMS.Models
{
    public class Item
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Path { get; set; }
        public Item(string? name, string? description, string? path)
        {
            Name = name;
            Description = description;
            Path = path;
            Console.WriteLine("Item Created");
        }
    }
}