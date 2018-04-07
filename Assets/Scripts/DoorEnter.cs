using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class PortalTile : MonoBehaviour {

    private PlayerAttributes playerAttrs;

    void Start()
    {
        playerAttrs = GetComponent<PlayerAttributes>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Door"))
        {
            var tilemap = other.gameObject.GetComponent<Tilemap>();
            if (tilemap.name == "Tilemap_door_up")
            {
                ChangeRoom(new Vector2(0, 1));
            }
            else if (tilemap.name == "Tilemap_door_down")
            {
                ChangeRoom(new Vector2(0, -1));
            }
            else if (tilemap.name == "Tilemap_door_left")
            {
                ChangeRoom(new Vector2(-1, 0));
            }
            else if (tilemap.name == "Tilemap_door_right")
            {
                ChangeRoom(new Vector2(1, 0));
            }
        }
    }

    private void ChangeRoom(Vector2 dir)
    {
        string nextRoom = playerAttrs.currentMap.GetRoomNameByCoords(playerAttrs.XOnMap + dir.x, playerAttrs.YOnMap + dir.y);
        SceneManager.LoadScene(nextRoom);
    }
}
