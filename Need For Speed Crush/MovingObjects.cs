using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Need_For_Speed_Crush
{
    public class MovingObjects
    {
        public List<PictureBox> objects { get; set; }
        int x { get; set; }
        int y { get; set; }

        Random r = new Random();

        public MovingObjects()
        {
        }

        public MovingObjects(List<PictureBox> objects)
        {
            this.objects = objects;
        }


        public void createObject(PictureBox flyingObject)
        {
                x = r.Next(15, 380-flyingObject.Width);
                flyingObject.Location = new Point(x, 0);
        }

        public void fuelMove(int speed)
        {
            if (objects[0].Top >= 500){
                createObject(objects[0]);
            }
            else
            {
                objects[0].Top += speed;
            }
        }

        public void carMove(int speed)
        {
            foreach (PictureBox car in objects)
            {
                if (car.Top>= 500)
                {
                    createObject(car);
                }
                else
                {
                    car.Top += speed;
                }
            }
        }

        public void HeartLost(MyCar myCar)
        {
            foreach (PictureBox position in objects)
            {
                if (myCar.IsTouching(position))
                {
                    myCar.RemoveLive();
                    if (myCar.position.Location.X > position.Location.X)
                    {
                        myCar.invincible = true;
                    }
                    else
                    {
                        myCar.invincible = true;
                    }
                }
            }            
        }

        public void RefilFuel(MyCar myCar)
        {   
            PictureBox fuel = objects[0];
            if (myCar.IsTouching(fuel))
            {
                x = r.Next(15, 380 - fuel.Width);
                fuel.Location = new Point(x, -80);
                myCar.fuel += 20;
            }
        }
    }
}
