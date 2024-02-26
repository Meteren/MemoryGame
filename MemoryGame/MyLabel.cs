using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    class MyLabel : Label
    {

        string icon;
        public MyLabel(Point location, string icon)
            : base()
        {

            this.Location = location;
            this.Size = new Size(32, 32);
            this.icon = icon;
            this.Text = icon;
            this.Font = new Font("Arial", 12, FontStyle.Bold);
            
        }

        public string PIcon
        {
            get
            {
                return this.icon;
            }

        }

    }
}
