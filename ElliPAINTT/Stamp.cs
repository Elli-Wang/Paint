using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElliPAINTT
{
    public class Stamp
    {
        public Image Image;
        public string Name;

        public override string ToString()
        {
            return Name;
        }

        public Stamp(Image Image, string name)
        {
            this.Image = Image;
            this.Name = name;
        }
    }
}
