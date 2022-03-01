using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace OOP_CheWeiHsu_Task12
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Client> clients = new List<Client>();
            //string doIt = @"Client.json";
            //using (var a = new MemoryStream(Encoding.Unicode.GetBytes(doIt)))
            using (StreamReader file= new StreamReader(@"Client.json"))
            {
                //DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(List<Client>));
                //Client client = (Client)deseralizer.ReadObject(a);
                //Console.WriteLine("ID= " + client.Id);
                //Console.WriteLine("First name: " + client.FirstName);
                //Console.WriteLine("Family name: " + client.FamilyName);
                //Console.WriteLine("Telephone number: " + client.TelephoneNumber);
                //Console.WriteLine("Email: " + client.Email);
                //Console.WriteLine("Preferred Type: " + client.PreferredType);
                //Console.WriteLine("Max rent possible: " + client.MaxRentPossible);

                var jsonString = file.ReadToEnd();
                //Deserilize the JSON data into a generic list of type Client objects
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Client>));
                clients = ser.ReadObject(ms) as List<Client>;

                //var ObjectInInterest = (from c in clients where c.FamilyName == "Ozier" select c).FirstOrDefault();
                //if (ObjectInInterest != null)
                //    ObjectInInterest.FirstName = "Wade Sr.";
                //var lastClient = clients.Last();
                //clients.Add(new Client(lastClient == null ? 0 : lastClient.Id + 1, "Luffy", "Monkey.D", "056 5236127", "luffy.monkey.d@edu.xamk.fi", "Villa", 680.00));
                //clients.Add(new Client() { });
                //clients.Remove()

                var ObjectInInterest = clients.FirstOrDefault(c => c.FamilyName == "Ritchie");
                if (ObjectInInterest != null)
                    ObjectInInterest.FirstName = "Lasse";
                clients.Remove(new Client(9, "Daemon", "Needley", "5571-033-1507", "needless.tosay@fastmail.se", "House", 910.0));

            }
            using (StreamWriter file = new StreamWriter(@"NewClient.json", true))//直接在右邊視窗建立一個新Json檔案，然後把資料寫入，如果是true的話，會直接把資料寫到大括號底下，直接省略上方已有的括號(意即不複寫，不覆蓋)
            {
                //Write serialized JSON stream back to the original file
                //serialize the cliet objects to the stream.
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Client>));
                ser.WriteObject(file.BaseStream, clients);//clients List是被寫入
                file.Close();
            }
            foreach (var c in clients)
            {
                Console.WriteLine(c.Id + " " + " " + c.FirstName + " " + c.FamilyName);
            }
            //https://docs.microsoft.com/en-us/dotnet/framework/wcf/feature-details/how-to-serialize-and-deserialize-json-data
            //此網址是資料來源所在
            
        }
        //private static void RemoveSomeItems()
        //{
        //    clients.Remove(new Client(9, "Daemon", "Needley", "5571-033-1507", "needless.tosay@fastmail.se", "House", 910.0));
        //}
    }
}
