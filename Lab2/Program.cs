using System;

namespace Lab2
{
    class Program 
    {


        static void Main(string[] args)
        {
            string search = Console.ReadLine();

            Search s1 = new Search(search);

            s1.GetURL();

            s1.GetData();

           
        }
        
    }

    class Search 
    {
        string search;
        string[] URL = new string[3] { "Uzhnu.com", "Youtube.com", "SteamStore.com" };

        public Search(string search) 
        {
            this.search = search;
        }

        public void GetData() 
        {
            Console.WriteLine( $"{DateTime.Now}");
        }      

        public void GetURL() 
        {
            for (int i = 0; i < URL.Length; i++)
            {
                Console.WriteLine(URL[i]);
            }
        }
        
    }
    
}
