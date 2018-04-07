using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;

namespace Weapons
{
    public class PlayerWeaponStorage
    {
        private static HashSet<Weapon> playerWeapons;
        private static object lockObject;

        public PlayerWeaponStorage()
        {
            playerWeapons = new HashSet<Weapon>();
            lockObject = new object();
        }

        public HashSet<Weapon> GetAllPlayerWeapons()
        {
            lock (lockObject)
            {
                return playerWeapons;
            }
        }

        public Weapon GetPlayerWeapon(int id)
        {
            lock (lockObject)
            {
                return playerWeapons.FirstOrDefault(w => w.Id == id);
            }  
        }

        public Weapon GetCurrentPlayerWeapon()
        {
            lock (lockObject)
            {
                return playerWeapons.FirstOrDefault(w => w.IsCurrent);
            }
        }

        public void UpdateWeapon(Weapon weapon)
        {
            lock (lockObject)
            {
                var weaponInStorage = GetPlayerWeapon(weapon.Id);
                if (weaponInStorage != null)
                    playerWeapons.Remove(weaponInStorage);
                playerWeapons.Add(weapon);
            }
        }

        public void SetCurrentPlayerWeapon(Weapon weapon)
        {
            lock (lockObject)
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
}