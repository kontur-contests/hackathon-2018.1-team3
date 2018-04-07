namespace Weapons
{
    public class Katana: Weapon
    {
        public override void Attack()
        {
            Instantiate(gameObject.AddComponent<KatanaBullet>());
        }
    }
}