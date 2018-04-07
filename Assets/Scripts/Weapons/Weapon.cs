namespace Weapons
{
    public abstract class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public abstract float Attack { get; set; }
        public bool IsCurrent { get; set; }
    }
}