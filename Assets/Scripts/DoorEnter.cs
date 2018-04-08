using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class DoorEnter : MonoBehaviour {

    private PlayerAttributes playerAttrs;

    void Start()
    {
        playerAttrs = FindObjectOfType<PlayerAttributes>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Door"))
        {
            if (other.gameObject.name == "DoorUp")
            {
                ChangeRoom(new Vector2Int(0, 1), new Vector3(0.3f, -3.7f, -1));
            }
            else if (other.gameObject.name == "DoorDown")
            {
                ChangeRoom(new Vector2Int(0, -1), new Vector3(-0.35f, 3.5f, -1));
            }
            else if (other.gameObject.name == "DoorLeft")
            {
                ChangeRoom(new Vector2Int(-1, 0), new Vector3(5.5f, 0.5f, -1));
            }
            else if (other.gameObject.name == "DoorRight")
            {
                ChangeRoom(new Vector2Int(1, 0), new Vector3(-5.7f, 0, -1));
            }
        }
    }

    private void ChangeRoom(Vector2Int dir, Vector3 playerPos)
    {
        string nextRoom = playerAttrs.currentMap.GetRoomNameByCoords(playerAttrs.XOnMap + dir.x, playerAttrs.YOnMap + dir.y);
        if (nextRoom != "")
        {
            playerAttrs.XOnMap += dir.x;
            playerAttrs.YOnMap += dir.y;
            gameObject.transform.position = playerPos;
            SceneManager.LoadScene(nextRoom);
            
        }
    }
}
