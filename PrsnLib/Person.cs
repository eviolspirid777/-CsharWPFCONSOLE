using System;
using System.Net;

namespace PrsnLib
{
    public class Person
    {
        public Fio? Fio { get; set; }
        public Curriculum? Curriculum { get; set; }
        public Address? Address { get; set; }
        public Contacts? Contacts { get; set; }
        public Person()
        {
            Fio = new Fio();
            Curriculum = new Curriculum();
            Address = new Address();
            Contacts = new Contacts();
        }
    };
}