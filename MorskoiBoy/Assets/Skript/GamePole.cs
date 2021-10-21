using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePole : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject eLiters, eNums, ePole;
    //список букв
    GameObject[] Liters;
    //список цифр
    GameObject[] Nums;
    //поле игр
    GameObject[,] Pole;

    // pole 10 na 10
    int lengPole = 10;

    void CreatePole()
    {
        Vector3 StartPoze = transform.position;

        float XX = StartPoze.x + 1;
        float YY = StartPoze.y - 1;

        Liters = new GameObject[lengPole];
        Nums = new GameObject[lengPole];
        
        // nadpisi dlya igri
        for(int Nadpis = 0; Nadpis < lengPole; Nadpis++)
        {
            Liters[Nadpis] = Instantiate(eLiters);
            Liters[Nadpis].transform.position = new Vector3(XX, StartPoze.y, StartPoze.z);
            Liters[Nadpis].GetComponent<Chanks>().Index = Nadpis;
            XX++;

            Nums[Nadpis] = Instantiate(eNums);
            Nums[Nadpis].transform.position = new Vector3(StartPoze.x, YY, StartPoze.z);
            Nums[Nadpis].GetComponent<Chanks>().Index = Nadpis;
            YY--;


        }

        XX = StartPoze.x + 1;
        YY = StartPoze.y - 1;

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
                XX++;
            }
            XX = StartPoze.x +1;
            YY--;
        }









    }


    void Start()
    {
        CreatePole();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
