using System;
using SQLite;

namespace RadioFitCalendar.Models
{
    public class Achievement
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Date { get; set; }
        public int Type { get; set; }
    }
}