using System;


namespace TimeSavers
{
    internal class CodeSnippets
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public CodeSnippets(string name)
        {
            Name = name;
        }

        public void GreetUser(string user)
        {
            do
            {
                while (true)
                {
                    if (true)
                    {
                        Console.WriteLine($"Hello {0}", user);
                    }
                }
            } while (true);
        }


    }
}
