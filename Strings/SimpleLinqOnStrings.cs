using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class SimpleLinqOnStrings
    {
        public void GetOrderedResults(List<string> input)
        {
            List<Person> persons = new List<Person>();
            foreach (string item in input)
            {
                string[] temp = item.Split(' ');
                persons.Add(new Person(temp[0], temp[1], temp[2], temp[3]));
            }
            persons = persons
            .OrderBy(p => p.lName, StringComparer.CurrentCultureIgnoreCase)
            .ThenBy(p => p.fName, StringComparer.CurrentCultureIgnoreCase)
            .ThenBy(p => p.mInitial, StringComparer.CurrentCultureIgnoreCase)
            .ThenBy(p => p.age).Distinct().ToList();

            //persons = persons.Distinct().ToList();
            

            foreach (Person item in persons)
                Console.WriteLine(item.lName + "\t" + item.fName + "\t" + item.mInitial + "\t" + item.age);
        }

        private class Person 
        {
            public string fName, lName, mInitial;
            public int age;
            public Person(string first, string middle, string last, string old)
            {
                fName = first;
                mInitial = middle;
                lName = last;
                age = Convert.ToInt32(old);
            }

            public override bool Equals(object obj)
            {
                var item = obj as Person;

                if (item == null)
                {
                    return false;
                }

                return this.lName.ToLower().Equals(item.lName.ToLower()) 
                    && this.fName.ToLower().Equals(item.fName.ToLower()) 
                    && this.mInitial.ToLower().Equals(item.mInitial.ToLower()) 
                    && this.age.Equals(item.age);
            }

            public override int GetHashCode()
            {
                return this.lName.ToLower().GetHashCode() 
                    ^ this.fName.ToLower().GetHashCode() 
                    ^ this.mInitial.ToLower().GetHashCode() 
                    ^ this.age.GetHashCode();
            }


        }
    }
}
