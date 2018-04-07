namespace Weapons
{
    public class Katana: Weapon
    {
        private MeleeBullet _bullet;

        protected override MeleeBullet Bullet
        {
            get { return _bullet; }
        }

        private void Start()
        {
            _bullet = gameObject.AddComponent<KatanaBullet>();
        }
    }
}