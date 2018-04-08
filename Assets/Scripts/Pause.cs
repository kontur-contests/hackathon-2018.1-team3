using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public float timer;
    public bool isPause;
    public bool guipuse;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timer;
        if (Input.GetKeyDown(KeyCode.Escape) && isPause == false)
        {
            isPause = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPause == true)
        {
            isPause = false;
        }
        if (isPause == true)
        {
            timer = 0;
            guipuse = true;

        }
        else if (isPause == false)
        {
            timer = 1f;
            guipuse = false;
        }
    }

    public void OnGUI()
    {
        if (guipuse == true)
        {
            Cursor.visible = true;// включаем отображение курсора
            if (GUI.Button(new Rect((float)(Screen.width / 3), (float)(Screen.height / 2) - 100f, 700f, 45f), "Продолжить"))
            {
                isPause = false;
                timer = 0;
                Cursor.visible = false;
            }
            /*
            if (GUI.Button(new Rect((float)(Screen.width / 2), (float)(Screen.height / 2) - 100f, 150f, 45f), "Сохранить"))
            {

            }
            if (GUI.Button(new Rect((float)(Screen.width / 2), (float)(Screen.height / 2) - 50f, 150f, 45f), "Загрузить"))
            {

            }
            */
            if (GUI.Button(new Rect((float)(Screen.width / 3), (float)(Screen.height / 2) - 50f, 700f, 45f), "Меню"))
            {
                isPause = false;
                timer = 0;
                SceneManager.LoadScene("MainMenu"); // здесь при нажатии на кнопку загружается другая сцена, вы можете изменить название сцены на свое
            }
        }
    }
}
