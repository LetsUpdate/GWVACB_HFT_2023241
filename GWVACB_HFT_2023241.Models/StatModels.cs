using System;

namespace GWVACB_HFT_2023241.Models
{
    
    public class NameValue
    {
        public string Name { get; set; }
        public int  Value { get; set; }

        public void Act(Action<string> a)
        {
            a(this.ToString());
        }

        public override string ToString()
        {
            return $"{Name}: {Value}";
        }
    }
}