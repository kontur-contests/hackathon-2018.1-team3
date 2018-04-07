using UnityEngine;

namespace Weapons
{
    public abstract class Weapon: MonoBehaviour
    {
        private MeleeBullet Bullet { get; set; }
        public string Name { get; set; }
        public bool IsCurrent { get; set; }

        public virtual void Attack()
        {
            Instantiate(Bullet);
        }
    }
}