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
        public string GetInfo() => $"Name: {Fio.Name}\nSurname: {Fio.Surname}\nPatron: {Fio.Patron}\nCourse: {Curriculum.Course}\nGroup: {Curriculum.Group}\nSpecialty: {Curriculum.Specialty}\nFaculty: {Curriculum.Faculty}\nPost Index: {Address.PstIndex}\nStreet: {Address.Street}\nCity: {Address.City}\nMail: {Contacts.Mail}\nPhone: {Contacts.Phone}";
    };
}