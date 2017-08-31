using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    // defining Custom Attribute class
    public sealed class CustomAttribute : System.Attribute
    {
        public string Description { get; set; }
        public CustomAttribute(string ADescription)
        {
            Description = ADescription;
        }

        public CustomAttribute() { }

    }

    public abstract class Numbers
    {
       public int[] Content { get; set; }        
    }

    [CustomAttribute("EvenNumbersClass")]
    public  class EvenNumbers:Numbers
    {
        
    }

    [CustomAttribute("NotEvenNumbersClass")]
    public  class NotEvenNumbers:Numbers
    {
        
    }

    [CustomAttribute("EvenNumbers")]
    public class AllNumbers : Numbers
    {

    }




}
