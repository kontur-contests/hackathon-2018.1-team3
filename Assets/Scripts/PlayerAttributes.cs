using UnityEngine;
using UnityEngine.UI;
using Weapons;

public class PlayerAttributes : MonoBehaviour {

    public Text healthText;
    public Text strengthText;
    public Text agilityText;
    public Text enduranceText;
    public Text moneyText;
    public Text awsText;

    public int health = 100;
    public int maxHealth;
    //public string weapon1;
    //public string weapon2;
    public int strength = 1;
    public int agility = 1;
    public int endurance = 1;
    public int money = 1000;
    public int awesomeness = 1000;

    public Weapon CurrentPlayerWeapon;

    // Use this for initialization
    void Awake()
    {
         maxHealth = 50 + 50 * endurance;
         health = 100;
         updateText();
    }
    
    void Start ()
    {
        CurrentPlayerWeapon = new PlayerWeaponStorage().GetCurrentPlayerWeapon();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
            changeAwesomeness(awesomeness + 1);
	}

    void onDeath()
    {
        //TODO: 
    }

    void changeHealth(int newValue)
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
}
