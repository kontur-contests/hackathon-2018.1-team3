using UnityEngine;
using Weapons;

public class PlayerAnimation : MonoBehaviour
{

    private Animator anim;
    private Weapon playerWeapon;

    // Use this for initialization
    void Start()
    {

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        /*
        if (playerWeapon != null)
        {
            switch (playerWeapon.name)
            {
                case "Katana":
                */
        var direction = PlayerAttributes.Direction;

        if (Input.GetKey(KeyCode.W))
            anim.Play("KatanaUp");
        else if (Input.GetKey(KeyCode.D))
            anim.Play("KatanaRight");
        else if (Input.GetKey(KeyCode.S))
            anim.Play("KatanaDown");
        else if (Input.GetKey(KeyCode.A))
            anim.Play("KatanaLeft");

        if (Input.GetKeyUp("space"))
        {
            if (direction == Direction.Right)
                anim.Play("KatanaStrikeRight");
            else if (direction == Direction.Left)
                anim.Play("KatanaStrikeLeft");
            else if (direction == Direction.Top)
                anim.Play("KatanaStrikeUp");
            else if (direction == Direction.Down)
                anim.Play("KatanaStrikeDown");

        }
        /*
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
*/
    }
}