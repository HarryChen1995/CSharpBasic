using System;
using System.Net;
using System.IO;
using System.Text;
using System.Text.Json;
namespace HttpRequst
{
    public class Person {
    public string name {
        set;
        get;
    }
    public int age{
        get;
        set;
    }
    public override string ToString()
    {
        return "I am " + name + "my age is " + age.ToString(); 
    }
}
   
    class Program
    {
        public static void fetchJson(){
             HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://localhost:1000/get");
             using(HttpWebResponse response = (HttpWebResponse)request.GetResponse())
             using (Stream stream = response.GetResponseStream())
             using (StreamReader reader = new StreamReader(stream))
             {
                string data = reader.ReadToEnd();
                Person p = JsonSerializer.Deserialize<Person>(data);
                Console.WriteLine(p);
             }

        }

        public static void postJson(){
            Person person = new Person(){
                name = "harry", age = 12
            };
            string json = JsonSerializer.Serialize(person);
            byte[] jsonData = Encoding.UTF8.GetBytes(json);
            HttpWebRequest postRequest = (HttpWebRequest) HttpWebRequest.Create("http://localhost:1000/post");
            postRequest.ContentLength = jsonData.Length;
            postRequest.ContentType = "application/json";
            postRequest.Method = "POST";
            using(Stream requestStream = postRequest.GetRequestStream()){
                requestStream.Write(jsonData, 0, jsonData.Length);
                requestStream.Close();
            }
            using(HttpWebResponse response = (HttpWebResponse) postRequest.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using(StreamReader streamReader = new StreamReader(stream))
            {
                string data = streamReader.ReadToEnd();
                Console.WriteLine(data);
            }

        }
        static void Main(string[] args)
        {
            try{
            fetchJson();
            postJson();
            }
            catch(WebException exp){
                Console.WriteLine(exp.Message);
            }
            
       
   
        }
    }
}


