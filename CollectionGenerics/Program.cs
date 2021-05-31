using System;
using System.Collections.Generic;
namespace CollectionGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> stringArr = new List<string>();
            stringArr.Add("fist");
            stringArr.AddRange(new List<String> {"Second", "Third"});
            foreach(string s in stringArr)
            Console.WriteLine(s);
            
            Dictionary<string, int> hashtable = new Dictionary<string, int>();
            hashtable["tom"] = 12;
            hashtable["tom"] += 1;
            Console.WriteLine(hashtable.ContainsKey("asd"));
            int value;
            if (hashtable.TryGetValue("tom", out value)){
                Console.WriteLine(value);
            }
        }
    }
}
