using UnityEngine;

namespace Weapons
{
    public abstract class Weapon: MonoBehaviour
    {
        protected abstract MeleeBullet Bullet { get; }
        public string Name { get; set; }
        public abstract float AttackValue { get; set; }
        public bool IsCurrent { get; set; }

        public void Attack()
        {
            Instantiate(Bullet);
        }
    }
}