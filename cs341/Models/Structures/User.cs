using System;
using System.Collections.Generic;
using cs341.Structures;

namespace cs341.Structures
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public bool? IsAdmin { get; set; }
        public bool? IsGuest { get; set; }
        public Dictionary<Item, int> Cart { get; set; }
    }
}
