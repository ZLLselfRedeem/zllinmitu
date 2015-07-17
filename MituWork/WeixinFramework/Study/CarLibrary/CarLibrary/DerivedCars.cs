using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CarLibrary
{
    public class SportsCar : Car
    {
        public SportsCar() 
        {
        }

        public SportsCar(string name, int maxSp, int currSp) 
            :base(name, maxSp, currSp)
        {
        }

        public override void TurboBoost()
        {
            MessageBox.Show("Rannubg speed!", "Faster is better...");
        }
    }

    public class MiniVan : Car 
    {
        public MiniVan() 
        {
        }

        public MiniVan(string name, int maxSp, int currSp)
            : base(name, maxSp, currSp)
        { 
        }

        public override void TurboBoost()
        {
            egnState = EngineState.engineDead;
            MessageBox.Show("Eek! OK I am good!", "Your engine block exploded!");
        }
    }
}
