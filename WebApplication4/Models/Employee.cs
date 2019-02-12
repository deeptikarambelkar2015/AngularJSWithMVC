using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Employee
    {
        private int _id;
        private string _name;
        private int _age;
        private string _jobTitle;

        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public int age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
            }
        }

        public string jobTitle
        {
            get
            {
                return _jobTitle;
            }
            set
            {
                _jobTitle = value;
            }
        }
    }
}