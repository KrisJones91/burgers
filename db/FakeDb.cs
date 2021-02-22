using System.Collections.Generic;
using burgers.Models;

namespace burgers.db
{
    public class FakeDb
    {
        public static List<Burger> Burgers { get; set; } = new List<Burger>();
    }
}