using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletLibrary
{
    public class Bullet
    {
        public string ImagePath { get; set; }
        public Image Image { get; set; }
        public Point Position { get; set; }
        public void Move(Point p)
        {
            Position = p;
            Console.WriteLine($"x: {p.X} y: {p.Y}");
        }
    }

    public class PoolBullet
    {
        private Stack<Bullet> bullets = null;
        private int maxPoolSize = 0;
        private static PoolBullet instance;
        public static PoolBullet Instance
        {
            get
            {
                if (instance is null)
                    instance = new PoolBullet();
                return instance;
            }
        }
        public void SetMaxPoolSize(int size)
        {
            if (bullets is null)
            {
                bullets = new Stack<Bullet>(size);
                for (int i = 0; i < size / 3; i++)
                {
                    bullets.Push(new Bullet
                    {
                        ImagePath = "http://www.freeiconspng.com/uploads/bullet-png-pictures-1.png",
                        Position = new Point()
                    });
                }
            }
            maxPoolSize = size;
        }
        public Bullet AcquireBullet()
        {
            if (bullets?.Count > 0)
                return bullets.Pop();
            else
                return new Bullet();
        }
        public void ReleaseBullet(Bullet bullet)
        {
            if (bullets?.Count < maxPoolSize)
            {
                bullets.Push(bullet);
            }
        }
    }
}
