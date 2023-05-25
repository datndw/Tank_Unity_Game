using UnityEditor;
using UnityEngine;
using Enumerations;

namespace Entities
{


    public class Tank
    {
        public Bullet Bullet { get; set; }
        public Direction Direction { get; set; }
        public string Name { get; set; }
        public int Point { get; set; }
        public int Hp { get; set; }

        public GUID Guid { get; set; }
        public Vector3 Position { get; set; }

        public void Move(float x, float y)
        {
            this.Position = new Vector3(x, y, 0);
        }
    }
}