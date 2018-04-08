using UnityEngine;
using Weapons;

public class PlayerAnimation : MonoBehaviour {

    private Animator anim;
    private Weapon playerWeapon;

    // Use this for initialization
    void Start() {

        playerWeapon = PlayerAttributes.CurrentPlayerWeapon;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

        playerWeapon = GetComponent<PlayerAttributes>().CurrentPlayerWeapon;
        if (playerWeapon != null)
        {
            switch (playerWeapon.name)
            {
                case "Katana":
                    if (Input.GetKey(KeyCode.W))
                        anim.Play("KatanaUp");
                    else if (Input.GetKey(KeyCode.D))
                        anim.Play("KatanaRight");
                    else if (Input.GetKey(KeyCode.S))
                        anim.Play("KatanaDown");
                    else if (Input.GetKey(KeyCode.A))
                        anim.Play("KatanaLeft");
                    break;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
                anim.Play("SimpleUp");
            else if (Input.GetKey(KeyCode.D))
                anim.Play("SimpleRight");
            else if (Input.GetKey(KeyCode.S))
                anim.Play("SimpleDown");
            else if (Input.GetKey(KeyCode.A))
                anim.Play("SimpleLeft");
        }
    }
}
