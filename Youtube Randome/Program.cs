using System.Net;

namespace locker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.Hour +":"+(DateTime.Now.Minute + ":" + DateTime.Now.Second + ":" + DateTime.Now.Millisecond + ":" + DateTime.Now.Microsecond));
            Console.WriteLine("type your link destenation (just chanel link )");
            //get link from user and Read Web page at line 12 with one()
            string [] sd = one(Console.ReadLine()).Split('"');
            //make new list
            List<string> Second = new List<string>();
            string First = "www.youtube.com";
            //Filter outputs and after chaeck all it get trues in to Secend list 
            foreach (string s in sd)
            {
                //for check video link and filter it 
                if (s.StartsWith("/watch?v="))
                {
                    //add trues 
                    Second.Add(s);
                }
                else
                {}
            }
            // check exist true outputs 
            if (Second.Count > 0)
            {
                Random link_num = new Random();
                Console.WriteLine(First + Second[link_num.Next(Second.Count - 1)]);
            }
            else
            {
                 
            }
        }
        static string one(string url)
        {
            //Check outputs not be null 
            if (url != null)
            {
                //Check links its for youtube and its for chanel 
                if ((url.StartsWith("www.youtube.com") || url.StartsWith("https://www.youtube.com/")) && (url[24] == '@' || url[16] == '@'))
                {
                    //try to Read code in webpage 
                    try
                    {
                        //Make Webrequest 
                        WebRequest Link_Reader = WebRequest.Create(url);
                        //Set Method For Http Reqoust 
                        Link_Reader.Method = "GET";
                        // Making Responce Requst for Read Code from Link-reader(Http) 
                        WebResponse page = Link_Reader.GetResponse();
                        // Making Stream for get text From responce 
                        StreamReader reader = new StreamReader(page.GetResponseStream());
                        // String form Stream To new Variable 
                        string Con = reader.ReadToEnd();
                        // Return it Back to Methoud Main 
                        return Con;
                    }
                    catch
                    {
                        Console.WriteLine("Link is incarect ");
                        return string.Empty;
                    }
                }
                // returning String.empty its for not get Erorr and handel it if you want can make reference and use it for proxy for varible 
                else
                {
                    Console.WriteLine("link is not youtube or its not link chanel ");
                    return string.Empty;
                }
            }
            else
            {
                Console.WriteLine("The entered address is wrong");
                return string.Empty;
            }

        }
    }
}