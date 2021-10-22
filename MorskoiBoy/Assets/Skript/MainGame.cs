using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{

    //режим игры
    public int GameMode = 0;
    public GameObject PlayerPole, ComputerPole;

    void OnGUI()
    {
        //координаты центра экрана
        float CentrScreenX = Screen.width / 2; // x
        float CentrScreenY = Screen.height / 2; //y
        Rect LocationButton;

        GamePole PlayerPoleControl = PlayerPole.GetComponent<GamePole>();
        Camera cam;
        switch (GameMode)
        {
            // menu
            case 0:
                // component camera
                cam = GetComponent<Camera>();
                // obzor camera
                cam.orthographicSize = 8;
                // koordinati camera 
                this.transform.position = new Vector3(30, 0, -15);
                // создаем прямоугольник заднего  фона
                LocationButton = new Rect(new Vector2(CentrScreenX - 150, CentrScreenY - 50), new Vector2(300, 200));

                GUI.Box(LocationButton, "");

                // надпись меню игры

                LocationButton = new Rect(new Vector2(CentrScreenX - 40, CentrScreenY - 40), new Vector2(200, 30));
                GUI.Label(LocationButton, "МОРСКОЙ БОЙ");

                //knopka starta
                LocationButton = new Rect(new Vector2(CentrScreenX - 100, CentrScreenY), new Vector2(200, 30));

                if (GUI.Button(LocationButton, "НАЧАТЬ")) 
                                                          //если нажал кнопку то старт меняем на режим 1
                    GameMode = 1;
                //exit
                LocationButton = new Rect(new Vector2(CentrScreenX - 100, CentrScreenY + 40), new Vector2(200, 30));
                if (GUI.Button(LocationButton, "ВЫХОД"))
                    // nagal knopki vixoda
                    Application.Quit();

                break;

            case 1:
                cam = GetComponent<Camera>();
                cam.orthographicSize = 8;

                this.transform.position = new Vector3(0, 0, -17);

                LocationButton = new Rect(new Vector2(CentrScreenX - 150, 0), new Vector2(300, 200));

                GUI.Box(LocationButton, "");

                LocationButton = new Rect(new Vector2(CentrScreenX - 100, 50), new Vector2(200, 30));

                if (GUI.Button(LocationButton, "НАЗАД В МЕНЮ"))
                {
                    PlayerPoleControl.ClearPole();
                    GameMode = 0;
                }

                LocationButton = new Rect(new Vector2(CentrScreenX - 100, 90), new Vector2(200, 30));

                if (OnGUI.Button(LocationButton, "Разместить флот"))
                    PlayerPoleControl.EnterRandomsShip();

                if (PlayerPoleControl.LifeShip() == 20)
                {
                    LocationButton = new Rect(new Vector2(CentrScreenX - 100, 130), new Vector2(200, 30));
                    if (OnGUI.Button(LocationButton, "В БОY")) GameMode = 3;
                }

                break;
            case 3:
                this.transform.position = new Vector3(0, 100, -17);
                cam = GetComponent<Camera>();
                cam.orthographicSize = 18;
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
