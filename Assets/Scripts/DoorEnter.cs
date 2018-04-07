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
            var tilemap = other.gameObject.GetComponent<Tilemap>();
            if (tilemap.name == "Tilemap_door_up")
            {
                ChangeRoom(new Vector2Int(0, 1), new Vector3(0.3f, -3.7f, -1));
            }
            else if (tilemap.name == "Tilemap_door_down")
            {
                ChangeRoom(new Vector2Int(0, -1), new Vector3(-0.35f, 4, -1));
            }
            else if (tilemap.name == "Tilemap_door_left")
            {
                ChangeRoom(new Vector2Int(-1, 0), new Vector3(5.5f, 0.5f, -1));
            }
            else if (tilemap.name == "Tilemap_door_right")
            {
                ChangeRoom(new Vector2Int(1, 0), new Vector3(-5.7f, 0, -1));
            }
        }
    }

    private void ChangeRoom(Vector2Int dir, Vector3 playerPos)
    {
        playerAttrs.XOnMap += dir.x;
        playerAttrs.YOnMap += dir.y;
        string nextRoom = playerAttrs.currentMap.GetRoomNameByCoords(playerAttrs.XOnMap, playerAttrs.YOnMap);
        gameObject.transform.position = playerPos;
        SceneManager.LoadScene(nextRoom);
    }
}
