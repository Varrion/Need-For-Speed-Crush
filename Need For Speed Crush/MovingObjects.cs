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

        Random r = new Random();

        public MovingObjects()
        {
        }

        public MovingObjects(List<PictureBox> objects)
        {
            this.objects = objects;
        }


        private Point ValidPosition(Random r, int left, int width, int top)
        {
            Point p = new Point();
            p.X = r.Next(left + objects[0].Width, left + width - objects[0].Width);
            p.Y = top;
            return p;
        }
        public void CreateObject(PictureBox flyingObject,int top)
        {
            flyingObject.Location = ValidPosition(r, 15, 365, top);
        }

        public void FuelMove(int speed)
        {
            if (objects[0].Top >= 500){
                CreateObject(objects[0],-600);
            }
            else
            {
                objects[0].Top += speed;
            }
        }

        public void RefilFuel(MyCar myCar)
        {
            PictureBox fuel = objects[0];
            if (myCar.IsTouching(fuel))
            {
                CreateObject(fuel,-600);
                if (myCar.fuel + 25 > 100)
                {
                    myCar.fuel = 100;
                }
                else
                {
                    myCar.fuel += 20;
                }

            }
        }

        public void FixCar(MyCar myCar)
        {
            PictureBox fixCar = objects[0];
            if (myCar.IsTouching(fixCar))
            {
                CreateObject(fixCar, -3000);
                if (myCar.lives < 3)
                {
                    myCar.lives++;
                }
            }
        }

        public void FixCarMove(int speed)
        {
            if (objects[0].Top >= 500)
            {
                CreateObject(objects[0], -3000);
            }
            else
            {
                objects[0].Top += speed;
            }
        }

        public void CarMove(int speed)
        {
            foreach (PictureBox car in objects)
            {
                if (car.Top>= 500)
                {
                    CreateObject(car,-100);
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
    }
}
