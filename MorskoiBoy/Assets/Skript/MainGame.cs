using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{


    //����� ����
    public int GameMode = 0;
    void OnGUI()
    {
        //���������� ������ ������
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
                // ������� ������������� �������  ����
                Rect LocationButton = new Rect(new Vector2(CentrScreenX - 150, CentrScreenY - 50), new Vector2(300, 200));

                GUI.Box(LocationButton, "");

                // ������� ���� ����

                LocationButton = new Rect(new Vector2(CentrScreenX - 40, CentrScreenY - 40), new Vector2(200, 30));
                GUI.Label(LocationButton, "���� ����");

                //knopka starta
                LocationButton = new Rect(new Vector2(CentrScreenX - 100, CentrScreenY), new Vector2(200, 30));

                if (GUI.Button(LocationButton, "�����")) ; //��� �� ����������
                                                           //���� ����� ������ �� ����� ������ �� ����� 1
                GameMode = 1;
                //exit
                LocationButton = new Rect(new Vector2(CentrScreenX - 100, CentrScreenY + 40), new Vector2(200, 30));
                if (GUI.Button(LocationButton, "�����"))
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
