using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CarLib
{

    // defining Custom Attribute class
    public sealed class CustomAttributeDescription : System.Attribute
    {
        public string Description { get; set; }

        public CustomAttributeDescription(string ADescription)
        {
            Description = ADescription;
        }

        public CustomAttributeDescription() { }

    }

    [Serializable, CustomAttributeDescription("BaseClass")]
    public abstract class Car
    {
        
        public int MaxSpeed { get; set; }        
        public abstract void TurboBoost();

    }

    [Serializable, CustomAttributeDescription("It is attribute description.There is Descendent of Car")]
    public class SportsCar : Car
    {
        public SportsCar() { MaxSpeed = 160; }
        public override void TurboBoost() { Console.WriteLine(MaxSpeed+" km/h"); }
    }



}
