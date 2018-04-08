using UnityEngine;
using UnityEngine.Tilemaps;

public class DoorManagement : MonoBehaviour {
    
    public Sprite doorUpOpen;
    public Sprite doorUpClosed;
    public Sprite wallUp;

    public Sprite doorDownOpen;
    public Sprite doorDownClosed;
    public Sprite wallDown;

    public Sprite doorLeftOpen;
    public Sprite doorLeftClosed;
    public Sprite wallLeft;

    public Sprite doorRightOpen;
    public Sprite doorRightClosed;
    public Sprite wallRight;

    public void OnSceneChanged()
    {
        var doorUp = GameObject.Find("DoorUp");
        var doorDown = GameObject.Find("DoorDown");
        var doorLeft = GameObject.Find("DoorLeft");
        var doorRight = GameObject.Find("DoorRight");
        var playerAttrs = GameObject.Find("Player").GetComponent<PlayerAttributes>();

        if (playerAttrs.currentMap.GetRoomNameByCoords(playerAttrs.XOnMap + 1, playerAttrs.YOnMap) == "")
        {
            doorRight.GetComponent<SpriteRenderer>().sprite = wallRight;
            doorRight.GetComponent<BoxCollider2D>().enabled = false;
            doorRight.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        if (playerAttrs.currentMap.GetRoomNameByCoords(playerAttrs.XOnMap - 1, playerAttrs.YOnMap) == "")
        {
            doorLeft.GetComponent<SpriteRenderer>().sprite = wallLeft;
            doorLeft.GetComponent<BoxCollider2D>().enabled = false;
            doorLeft.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        if (playerAttrs.currentMap.GetRoomNameByCoords(playerAttrs.XOnMap, playerAttrs.YOnMap + 1) == "")
        {
            doorUp.GetComponent<SpriteRenderer>().sprite = wallUp;
            doorUp.GetComponent<BoxCollider2D>().enabled = false;
            doorUp.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        if (playerAttrs.currentMap.GetRoomNameByCoords(playerAttrs.XOnMap, playerAttrs.YOnMap - 1) == "")
        {
            doorDown.GetComponent<SpriteRenderer>().sprite = wallDown;
            doorDown.GetComponent<BoxCollider2D>().enabled = false;
            doorDown.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    // Use this for initialization
    void Start ()
    {
        OnSceneChanged();
    }
}
