using BulletLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBulletLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            PoolBullet pool = PoolBullet.Instance;
            pool.SetMaxPoolSize(10);

            
            while (true)
            {
                Bullet bullet = pool.AcquireBullet();
                bullet.Move(new Point());
                pool.ReleaseBullet(bullet);
            }
        }
    }
}
