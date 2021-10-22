using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{


    //режим игры
    public int GameMode = 0;
    void OnGUI()
    {
        //координаты центра экрана
        float CentrScreenX = Screen.width / 2; // x
        float CentrScreenY = Screen.height / 2; //y

        switch (GameMode)
        {
            // menu
            case 0:
                // component camera
                Camera cam = GetComponent<Camera>();
                // obzor camera
                cam.orthographicSize = 8;
                // koordinati camera 
                this.transform.position = new Vector3(0, 0, -10);
                // создаем прямоугольник заднего  фона
                Rect LocationButton = new Rect(new Vector2(CentrScreenX - 150, CentrScreenY - 50), new Vector2(300, 200));

                GUI.Box(LocationButton, "");

                // надпись меню игры

                LocationButton = new Rect(new Vector2(CentrScreenX - 40, CentrScreenY - 40), new Vector2(200, 30));
                GUI.Label(LocationButton, "МЕНЮ ИГРЫ");

                //knopka starta
                LocationButton = new Rect(new Vector2(CentrScreenX - 100, CentrScreenY), new Vector2(200, 30));

                if (GUI.Button(LocationButton, "СТАРТ")) ; //где то ошибкааааа
                                                           //если нажал кнопку то старт меняем на режим 1
                GameMode = 1;
                //exit
                LocationButton = new Rect(new Vector2(CentrScreenX - 100, CentrScreenY + 40), new Vector2(200, 30));
                if (GUI.Button(LocationButton, "выход"))
                    // nagal knopki vixoda
                    Application.Quit();

                break;

        }
    }








    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
