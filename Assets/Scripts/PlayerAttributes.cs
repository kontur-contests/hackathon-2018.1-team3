using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Weapons;

public class PlayerAttributes : MonoBehaviour
{//TODO: Should be singletone;
    public static Direction Direction;
    
    public Text healthText;
    public Text strengthText;
    public Text agilityText;
    public Text enduranceText;
    public Text moneyText;
    public Text awsText;

    #region serializableAttributes
    public int health = 100;
    public int maxHealth;
    //public string weapon1;
    //public string weapon2;
    public int strength = 1;
    public int agility = 1;
    public int endurance = 1;
    public int money = 1000;
    public int awesomeness = 1000;
    public int flaskCharges = 2;

    public static Weapon CurrentPlayerWeapon;
    public int XOnMap;
    public int YOnMap;
    public LevelMap currentMap;
    #endregion

    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        maxHealth = 50 + 50 * endurance;
        health = maxHealth;//?
        currentMap = new LevelMap("comp1");
        XOnMap = 0;//I'm not entirely shre if this is called once per game or once per level. 
        YOnMap = 0;
        var currentPlayerWeapon = new PlayerWeaponStorage().GetCurrentPlayerWeapon();
        CurrentPlayerWeapon = currentPlayerWeapon
            ? currentPlayerWeapon
            : gameObject.AddComponent<Katana>();
        updateText();
    }

    void Start()
    {
        var currentPlayerWeapon = new PlayerWeaponStorage().GetCurrentPlayerWeapon();
        CurrentPlayerWeapon = currentPlayerWeapon
            ? currentPlayerWeapon
            : gameObject.AddComponent<Katana>();
    }

    void onDeath()
    {
        Debug.Log("You died!!!");
    }

    void ChangeHealth(int newValue)
    {
        health = newValue;
        updateText();
    }

    void changeStrength(int newValue)
    {
        strength = newValue;
        updateText();
    }

    void changeAgility(int newValue)
    {
        agility = newValue;
        updateText();

    }
    void changeEndurance(int newValue)
    {
        endurance = newValue;
        updateText();
    }

    void changeMoney(int newValue)
    {
        money = newValue;
        updateText();
    }

    void changeAwesomeness(int newValue)
    {
        awesomeness = newValue;
        updateText();
    }

    void updateText()
    {
        if (health > 0)
            healthText.text = health.ToString();
        else
        {
            healthText.text = "0";
            onDeath();
        }

        strengthText.text = strength.ToString();
        agilityText.text = agility.ToString();
        enduranceText.text = endurance.ToString();
        moneyText.text = money.ToString();
        awsText.text = awesomeness.ToString();
    }

    public void ChangeHealthValue(int change)
    {
        health += change;
        updateText();
    }
}
