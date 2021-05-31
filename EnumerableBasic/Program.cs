using System;
using System.Collections.Generic;
using System.Collections;
namespace EnumerableBasic
{

    class Person {
        public Person(string firstName, string lastName){
            this.firstName = firstName;
            this.lastName = lastName;
        }
        public string firstName;
        public string lastName;
    }
    class People: IEnumerable {
        private Person[] _people;
        public People(Person [] pArray){
            _people = pArray;
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return (IEnumerator) GetPeopleEnumrator();
        }
        public PeopleEnum GetPeopleEnumrator(){
            return new PeopleEnum(_people);
        }
    }
    class PeopleEnum:IEnumerator {
        public Person[] _people;
        int position = -1;
        public PeopleEnum(Person[] arr){
            _people = arr;
        }
        public bool MoveNext(){
            position ++;
            return (position < _people.Length);
        }

        public void Reset(){
            position = -1;
        }

        object IEnumerator.Current
    {
        get
        {
            return CurrentPosition;
        }
    }

    public Person CurrentPosition
    {
        get
        {
            try
            {
                return _people[position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }
    }
    class Program
    {
        public static IEnumerable<int> getSequence( int index){
            for(int i = 0; i < index; i++){
                yield return i;
            }
        }
        static void Main(string[] args)
        {
           foreach(int i in getSequence(12))
           Console.WriteLine(i);


        Person[] peopleArray ={
            new Person("John", "Smith"),
            new Person("Jim", "Johnson"),
            new Person("Sue", "Rabon"),
        };


        People peopleList = new People(peopleArray);
        foreach (Person p in peopleList)
            Console.WriteLine(p.firstName + " " + p.lastName);
        }
    }
}
