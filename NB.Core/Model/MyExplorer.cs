using System.Collections.Generic;

namespace NB.Core.Model
{
    public class MyExplorer
    {
        public MyExplorer()
        {
            Path = new List<string>();
        }

        public string Root { get; set; }
        public List<string> Path { get; set; }

        public override string ToString()
        {
            return Root;
        }
    }
}
