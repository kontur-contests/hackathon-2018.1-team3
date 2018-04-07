using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;

namespace Weapons
{
    public class PlayerWeaponStorage
    {
        private HashSet<Weapon> playerWeapons;

        public PlayerWeaponStorage()
        {
            playerWeapons = new HashSet<Weapon>();
        }

        public PlayerWeaponStorage(HashSet<Weapon> playerWeapons)
        {
            this.playerWeapons = playerWeapons;
        }

        public HashSet<Weapon> GetAllPlayerWeapons()
        {
            return playerWeapons;
        }

        public Weapon GetPlayerWeapon(int id)
        {
            return playerWeapons.FirstOrDefault(w => w.Id == id);
        }

        public Weapon GetCurrentPlayerWeapon()
        {
            return playerWeapons.FirstOrDefault(w => w.IsCurrent);
        }

        public void UpdateWeapon(Weapon weapon)
        {
            var weaponInStorage = GetPlayerWeapon(weapon.Id);
            if (weaponInStorage != null)
                playerWeapons.Remove(weaponInStorage);
            playerWeapons.Add(weapon);
        }

        public void SetCurrentPlayerWeapon(Weapon weapon)
        {
            var currentPlayerWeapon = GetCurrentPlayerWeapon();
            currentPlayerWeapon.IsCurrent = false;
            var newCurrentPlayerWeapon = GetPlayerWeapon(weapon.Id);
            if (newCurrentPlayerWeapon == null)
            {
                playerWeapons.Add(weapon);
            }
            else
            {
                newCurrentPlayerWeapon.IsCurrent = true;
            }
        }
    }
}