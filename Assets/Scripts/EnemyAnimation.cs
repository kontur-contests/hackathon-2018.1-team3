using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{

    private Animator anim;

    // Use this for initialization
    void Start()
    {

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var center = transform.position;
        var playerCenter = GameObject.Find("Player").transform.position;
        if (GetComponent<Enemy>().followActive)
        {

            switch (gameObject.tag)
            {
                case "Boss":
                    if (center.x < playerCenter.x)
                        anim.Play("BossRight");
                    else if (center.x > playerCenter.x)
                        anim.Play("BossLeft");
                    else if (center.y < playerCenter.y)
                        anim.Play("BossUp");
                    else if (center.y > playerCenter.y)
                        anim.Play("BossDown");
                    break;

                case "Cactus":
                    if (center.y < playerCenter.y)
                        anim.Play("CactusUp");
                    else if (center.y > playerCenter.y)
                        anim.Play("CactusDown");
                    break;
                case "ClownKarate":
                    if (center.x < playerCenter.x)
                        anim.Play("ClownKarateRight");
                    else if (center.x > playerCenter.x)
                        anim.Play("ClownKarateLeft");
                    else if (center.y < playerCenter.y)
                        anim.Play("ClownKarateUp");
                    else if (center.y > playerCenter.y)
                        anim.Play("ClownKarateDown");
                    break;
            }
        }
        if (GetComponent<Enemy>().attack)
        {
            switch (gameObject.tag)
            {
                case "Boss":
                    if (center.x < playerCenter.x)
                        anim.Play("BossStrikeRight");
                    else if (center.x > playerCenter.x)
                        anim.Play("BossStrikeLeft");
                    else if (center.y < playerCenter.y)
                        anim.Play("BossStrikeUp");
                    else if (center.y > playerCenter.y)
                        anim.Play("BossStrikeDown");
                    break;
                case "Cactus":
                    if (center.x < playerCenter.x)
                        anim.Play("CactusStrikeRight");
                    else if (center.x > playerCenter.x)
                        anim.Play("CactusStrikeLeft");
                    break;
                case "ClownKarate":
                    if (center.x < playerCenter.x)
                        anim.Play("ClownKarateStrikeRight");
                    else if (center.x > playerCenter.x)
                        anim.Play("ClownKarateStrikeLeft");
                    else if (center.y < playerCenter.y)
                        anim.Play("ClownKarateStrikeUp");
                    else if (center.y > playerCenter.y)
                        anim.Play("ClownKarateStrikeDown");
                    break;
            }
        }
    }
}
