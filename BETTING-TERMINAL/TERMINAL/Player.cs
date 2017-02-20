﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TERMINAL
{
    internal class Player
    {
        public Player(string firstName, string lastName, DateTime birtDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birtDate;
        }

        string firstName;
        string lastName;
        DateTime birthDate;
                        
        public string FirstName
        {
            get
            {
                return firstName;
            }

            private set
            {
                firstName = (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(value)) ? null : value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            private set
            {
                lastName = (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(value)) ? null: value;
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return birthDate;
            }

            private set
            {
                int age = DateTime.Now.Year - value.Year;
                birthDate = (age >= 18)? DateTime.MinValue: value;
            }
        }

        public override string ToString()
        {
            return ($" {firstName} {lastName}");
        }
        
    }
}
