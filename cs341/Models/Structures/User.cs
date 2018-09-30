using System;
using System.Collections.Generic;
using cs341.Structures;

namespace cs341.Structures
{
    public class User
    {
        int Id { get; set; }
        string Username { get; set; }
        bool? IsAdmin { get; set; }
        List<Item> Cart { get; set; }
    }
}
