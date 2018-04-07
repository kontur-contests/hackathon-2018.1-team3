using System.Collections.Generic;
using System.Linq;

namespace Weapons
{
    public class PlayerWeaponStorage
    {
        private static Dictionary<string, Weapon> playerWeapons;
        private static object lockObject;

        public PlayerWeaponStorage()
        {
            playerWeapons = new Dictionary<string, Weapon>();
            lockObject = new object();
        }

        public List<Weapon> GetAllPlayerWeapons()
        {
            lock (lockObject)
            {
                return playerWeapons.Values.ToList();
            }
        }

        public Weapon GetPlayerWeapon(string name)
        {
            lock (lockObject)
            {
                return playerWeapons.FirstOrDefault(w => w.Key == name).Value;
            }  
        }

        public Weapon GetCurrentPlayerWeapon()
        {
            lock (lockObject)
            {
                return playerWeapons.FirstOrDefault(w => w.Value.IsCurrent).Value;
            }
        }

        public void UpdateWeapon(Weapon weapon)
        {
            lock (lockObject)
            {
                var weaponInStorage = GetPlayerWeapon(weapon.Name);
                if (weaponInStorage != null)
                    playerWeapons.Remove(weaponInStorage.Name);
                playerWeapons.Add(weapon.Name, weapon);
            }
        }

        public void SetCurrentPlayerWeapon(Weapon weapon)
        {
            lock (lockObject)
            {
                var currentPlayerWeapon = GetCurrentPlayerWeapon();
                currentPlayerWeapon.IsCurrent = false;
                var newCurrentPlayerWeapon = GetPlayerWeapon(weapon.Name);
                if (newCurrentPlayerWeapon == null)
                {
                    playerWeapons.Add(weapon.Name, weapon);
                }
                else
                {
                    newCurrentPlayerWeapon.IsCurrent = true;
                }
            }
        }
    }
}