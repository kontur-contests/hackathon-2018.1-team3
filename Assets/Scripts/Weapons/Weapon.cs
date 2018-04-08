using UnityEngine;

namespace Weapons
{
    public abstract class Weapon: MonoBehaviour
    {
        private MeleeBullet Bullet { get; set; }
        public abstract string Name { get; set; }
        public bool IsCurrent { get; set; }
    }
}