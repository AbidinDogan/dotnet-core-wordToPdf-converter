using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiExample.Model
{
    public class Person
    {
        public string Name { get; set; }
        public Person(string name)
        {
            this.Name = name;
        }
    }
}
