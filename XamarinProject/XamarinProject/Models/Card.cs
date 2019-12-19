using SQLite;
using System;

namespace XamarinProject.Models
{
    public class Card
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Attribute { get; set; }
        public string Quality { get; set; }
        public string Rarity { get; set; }
        public int Level { get; set; }
        public int Amount { get; set; }
    }
}