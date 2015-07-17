using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttributedCarLibrary
{
    // 使用了命名属性
    [Serializable]
    [VehicleDescription(Description = "My rocjig Harley")]
    public class Motocycle
    {
    }

    [SerializableAttribute]
    [ObsoleteAttribute("Use another vehicle!")]
    [VehicleDescription("The old gray mare, she ain't what she used to be...")]
    public class HorseAndBuggy 
    {
    }

    [VehicleDescription("A very long, slow, but feature-rich auto")]
    public class Winnebago 
    {
    }
}
