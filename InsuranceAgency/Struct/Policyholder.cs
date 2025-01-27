﻿using System;

namespace InsuranceAgency.Struct
{
    public class Policyholder
    {
        public int ID { get; }
        public string FullName { get; }
        public DateTime Birthday { get; }
        public string Telephone { get; }
        public string Passport { get; }
        

        public Policyholder(string fullName, DateTime birthday, string telephone, string passport)
        {
            FullName = fullName;
            Birthday = birthday;
            Telephone = telephone;
            Passport = passport;
        }
        public Policyholder(int id, string fullName, DateTime birthday, string telephone, string passport)
        {
            ID = id;
            FullName = fullName;
            Birthday = birthday;
            Telephone = telephone;
            Passport = passport;
        }
    }
}
