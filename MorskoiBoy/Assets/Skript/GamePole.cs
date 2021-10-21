using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePole : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject eLitters, eNumbers, ePole;
    //список букв
    GameObject[] Litters;
    //список цифр
    GameObject[] Numbers;
    //поле игр
    GameObject[,] Pole;

    // pole 10 na 10
    int lengPole = 10;

    void CreatePole()
    {
        Vector3 StartPoze = transform.position;

        float XX = StartPoze.x + 1;
        float YY = StartPoze.y - 1;
        float ZZ = StartPoze.z - 1;

        Litters = new GameObject[lengPole];
        Numbers = new GameObject[lengPole];

        // nadpisi dlya igri

        for (int Nadpis = 0; Nadpis < lengPole; Nadpis++)

        {
            Litters[Nadpis] = Instantiate(eLitters);
            Litters[Nadpis].transform.position = new Vector3(XX, StartPoze.y, StartPoze.z);
            Litters[Nadpis].GetComponent<Chanks>().Index = Nadpis;
            XX++;

            Numbers[Nadpis] = Instantiate(eNumbers);
            Numbers[Nadpis].transform.position = new Vector3(StartPoze.x, YY, StartPoze.z);
            Numbers[Nadpis].GetComponent<Chanks>().Index = Nadpis;
            YY--;


        }

        XX = StartPoze.x + 1;
        YY = StartPoze.y - 1;
        ZZ = StartPoze.z - 1;

        Pole = new GameObject[lengPole, lengPole];

        //цикл отрисовки поля по Y
        for (int Y = 0; Y < lengPole; Y++)
        {

            //цикл для X
            for (int X = 0; X < lengPole; X++)
            {
                Pole[X, Y] = Instantiate(ePole);
                Pole[X, Y].GetComponent<Chanks>().Index = 0;
                Pole[X, Y].transform.position = new Vector3(XX, YY, StartPoze.z);

                Pole[X, Y].GetComponent<ClickPole>().WhoPerent = this.gameObject;

                Pole[X, Y].GetComponent<ClickPole>().CoordX = X;
                Pole[X, Y].GetComponent<ClickPole>().CoordY = Y;

                XX++;
            }
            XX = StartPoze.x + 1;
            YY--;
        }


    }

    void Start()
    {
        CreatePole();
    }

    void Update()
    {

    }


    public void WhoClick(int X, int Y)
    {
        Pole[X, Y].GetComponent<Chanks>().Index = 1;
    }
}