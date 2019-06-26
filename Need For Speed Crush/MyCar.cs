using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Need_For_Speed_Crush
{
    public class MyCar
    {
        public PictureBox position { get; set; }
        
        public int fuel = 100;
        public int lives = 3;

        public bool invincible = false;

        public MyCar()
        {
        }

        public MyCar(PictureBox position)
        {
            this.position = position;
        }

        public void RemoveLive()
        {
            if (invincible == false)
            {
                lives--;
            }    
        }

        public void FuelLost()
        {
            if (invincible == false)
            {
                fuel -= 5;
            }
        }

        public bool IsTouching(PictureBox enemy)
        {
            if (position.Location.X + position.Width < enemy.Location.X)
                return false;
            if (enemy.Location.X + enemy.Width < position.Location.X)
                return false;
            if (position.Location.Y + position.Height < enemy.Location.Y)
                return false;
            if (enemy.Location.Y + enemy.Height < position.Location.Y)
                return false;
            return true;
        }


    }
}
