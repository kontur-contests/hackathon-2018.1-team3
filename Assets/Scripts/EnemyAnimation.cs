using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour {

    private Animator anim;

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(GetComponent<Enemy>().followActive)
        {
            switch(gameObject.name)
            {
                case "Boss":
                    if (Input.GetAxisRaw("Horizontal") == 1)
                        anim.Play("BossRight");
                    else if (Input.GetAxisRaw("Horizontal") == -1)
                        anim.Play("BossLeft");
                    else if (Input.GetAxisRaw("Vertical") == 1)
                        anim.Play("BossUp");
                    else if (Input.GetAxisRaw("Vertical") == -1)
                        anim.Play("BossDown");
                        break;
                case "Cactus":
                    if (Input.GetAxisRaw("Vertical") == 1)
                        anim.Play("CactusUp");
                    else if (Input.GetAxisRaw("Vertical") == -1)
                        anim.Play("CactusDown");
                    break;
                case "ClownKarate":
                    if (Input.GetAxisRaw("Horizontal") == 1)
                        anim.Play("ClownRight");
                    else if (Input.GetAxisRaw("Horizontal") == -1)
                        anim.Play("ClownLeft");
                    else if (Input.GetAxisRaw("Vertical") == 1)
                        anim.Play("ClownUp");
                    else if (Input.GetAxisRaw("Vertical") == -1)
                        anim.Play("ClownDown");
                    break;
            }
        }
        if(GetComponent<Enemy>().attack)
        {
            switch (gameObject.name)
            {
                case "Boss":
                    if (Input.GetAxisRaw("Horizontal") == 1)
                        anim.Play("BossStrikeRight");
                    else if (Input.GetAxisRaw("Horizontal") == -1)
                        anim.Play("BossStrikeLeft");
                    else if (Input.GetAxisRaw("Vertical") == 1)
                        anim.Play("BossStrikeUp");
                    else if (Input.GetAxisRaw("Vertical") == -1)
                        anim.Play("BossStrikeDown");
                    break;
                case "Cactus":
                    if (Input.GetAxisRaw("Horizontal") == 1)
                        anim.Play("CactusStrikeRight");
                    else if (Input.GetAxisRaw("Horizontal") == -1)
                        anim.Play("CactusStrikeLeft");
                    break;
                case "ClownKarate":
                    if (Input.GetAxisRaw("Horizontal") == 1)
                        anim.Play("ClownStrikeRight");
                    else if (Input.GetAxisRaw("Horizontal") == -1)
                        anim.Play("ClownStrikeLeft");
                    else if (Input.GetAxisRaw("Vertical") == 1)
                        anim.Play("ClownStrikeUp");
                    else if (Input.GetAxisRaw("Vertical") == -1)
                        anim.Play("ClownStrikeDown");
                    break;
            }
        }
	}
}
