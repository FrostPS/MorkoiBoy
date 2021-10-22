using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePole : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject eLitters, eNumbers, ePole;

    public bool HideShip = false;
    //список букв
    GameObject[] Litters;
    //список цифр
    GameObject[] Numbers;
    //поле игр
    GameObject[,] Pole;

    // pole 10 na 10
    int lengPole = 10;

    //количество кораблей на поле
    public int[] ShipsCount = { 0, 4, 3, 2, 1 };

    bool CountShips()
    {
        //обьявляем переменную для подсчета кораблей
        int Amaunt = 0;

        //суммируем все значения
        foreach (int Ship in ShipsCount) Amaunt += Ship;

        //если сумма не ноль значит ещё что ставить на поле
        if (Amaunt != 0) return true;

        //если сумма получилась 0 значит корабли кончились 
        return false;
    }

        //функция очистки поля игры
    void ClearPole()
    {
        //возвращаем корабли в ангар
        ShipsCount = new int[] { 0, 4, 3, 2, 1 }; //записываем количество кораблей
        ListShip.Clear();
        //цикл отрисовки поля по Y
        for (int Y = 0; Y < lengPole; Y++)
        { 
            //цикл открисовки поля по X
            for (int X=0;X<lengPole; X++)
            {
                Pole[X, Y].GetComponent<Chanks>().Index = 0;
            }
        }
    }

    void EnterRandomShip()
    {
        ClearPole();
        //номер выбранного корбля
        int SelectShip = 4;

        //координаты по которым будем ставить корабль
        int X, Y;
        //полжение корабля на поле вертикаль горизонталь
        int Direction;

        while (CountShips())
        {
            //получаем 2 координаты по которым будем ставить корабль
            X = Random.Range(0, 10); //позиция по X
            Y = Random.Range(0, 10); //позиция по Y
            //получаем направления 0 вертикаль 1 горизонталь
            Direction = Random.Range(0, 2);
            if (EnterDeck(SelectShip, Direction, X, Y)) 
            {
                //если получилось установить то уменьшаем количество кораблей
                ShipsCount[SelectShip]--;
                //если у нас закончились корабли данного типа то выбираем следующие
                if (ShipsCount[SelectShip] == 0)
                {
                    //смещаемся на следующую группу кораблей
                    SelectShip--;
                }
            }

        }
    }


    struct TestCoord
    {
        public int X, Y;
    }

    struct Ship
    {
        public TestCoord[] ShipCoord;
    }

    List<Ship> ListShip = new List<Ship>();
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
                Pole[X, Y].GetComponent<Chanks>().HideChank = HideShip;

                Pole[X, Y].transform.position = new Vector3(XX, YY, StartPoze.z);

                Pole[X, Y].GetComponent<ClickPole>().WhoPerent = this.gameObject;

                Pole[X, Y].GetComponent<ClickPole>().CoordX = X;
                Pole[X, Y].GetComponent<ClickPole>().CoordY = Y;


                //HideShip
                XX++;
            }
            XX = StartPoze.x + 1;
            YY--;
        }


    }

    bool TestEnterDeck(int X, int Y)
    {
        if ((X > -1) && (Y > -1) && (X < 10) && (Y < 10))
        {
            //|?|?|?|
            //|?|X|?|
            //|?|?|?|

            int[] XX = new int[9], YY = new int[9];

            XX[0] = X + 1; XX[1] = X; XX[2] = X - 1;
            YY[0] = Y + 1; YY[1] = Y + 1; YY[2] = Y + 1;

            XX[3] = X + 1; XX[4] = X; XX[5] = X - 1;
            YY[3] = Y; YY[4] = Y; YY[5] = Y;

            XX[6] = X + 1; XX[7] = X; XX[8] = X - 1;
            YY[6] = Y - 1; YY[7] = Y - 1; YY[8] = Y - 1;

            for (int I = 0; I < 9; I++)
            {
                if ((XX[I] > -1) && (YY[I] > -1) && (XX[I] < 10) && (YY[I] < 10))
                {
                    if (Pole[XX[I], YY[I]].GetComponent<Chanks>().Index != 0) return false;
                }
            }
            return true;
        }
        return false;
    }

    TestCoord[] TestEnterShipDirect(int ShipType, int XD, int YD, int X, int Y)
    {
        TestCoord[] ResultCoord = new TestCoord[ShipType];
        for (int P = 0; P < ShipType; P++)
        {

            if (TestEnterDeck(X, Y))
            {
                ResultCoord[P].X = X;
                ResultCoord[P].Y = Y;
            }
            else
                return null;

            X += XD;
            Y += YD;
        }
        return ResultCoord;
    }


    TestCoord[] TestEnterShip(int ShipType, int Derection, int X, int Y)
    {
        TestCoord[] ResultCoord = new TestCoord[ShipType];

        if (TestEnterDeck(X, Y))
        {
            switch (Derection)
            {
                case 0:
                    ResultCoord = TestEnterShipDirect(ShipType, 1, 0, X, Y);
                    if (ResultCoord == null) ResultCoord = TestEnterShipDirect(ShipType, -1, 0, X, Y);

                    break;
                case 1:
                    ResultCoord = TestEnterShipDirect(ShipType, 0, 1, X, Y);
                    if (ResultCoord == null) ResultCoord = TestEnterShipDirect(ShipType, 0, 1, X, Y);

                    break;
            }
            return ResultCoord;
        }

        return null;
    }

    bool EnterDeck(int ShipType, int Derection, int X, int Y)
    {
        TestCoord[] P = TestEnterShip(ShipType, Derection, X, Y);

        if (P != null)
        {
            foreach (TestCoord T in P)
            {
                Pole[T.X, T.Y].GetComponent<Chanks>().Index = 1;
            }

            Ship Deck;
            //сохраняем его координаты
            Deck.ShipCoord = P;

            //сохраняем корабль в список
            ListShip.Add(Deck);

            //сообщаем что мы поставили корабль
            return true;
        }
        return false;
    }

    void Start()
    {
        CreatePole();

        EnterRandomShip();
    }

    void Update()
    {

    }


    public void WhoClick(int X, int Y)
    {
        //  if (TestEnterDeck(X,Y)) Pole[X, Y].GetComponent<Chanks>().Index = 1;
        //EnterDeck(1, 1, X, Y);
        Shoot(X, Y);
    }

    bool Shoot(int X, int Y)
    {
        int PoleSelect = Pole[X, Y].GetComponent<Chanks>().Index;
        bool Result = false;
        switch (PoleSelect)
        {
            //промах
            case 0:
                Pole[X, Y].GetComponent<Chanks>().Index = 2;
                Result = false;
                break;
            //попадание
            case 1:
                Pole[X, Y].GetComponent<Chanks>().Index = 3;
                Result = true;
                break;
        }
        return Result;
    }

    //функция попадания по кораблю
    bool TestShoot(int X, int Y)
    {
        bool Result = false;
        foreach (Ship Test in ListShip)
        {
            foreach (TestCoord Paluba in Test.ShipCoord)
            {
                if ((Paluba.X == X) && (Paluba.Y == Y))
                {
                    int CountKill = 0;
                    foreach (TestCoord KillPaluba in Test.ShipCoord)
                    {
                        int TestBlock = Pole[KillPaluba.X, KillPaluba.Y].GetComponent<Chanks>().Index;
                        if (TestBlock == 3) CountKill ++;
                    }
                    if (CountKill == Test.ShipCoord.Length)
                        Result = true;
                    else
                        Result = false;

                    return Result;
                }
            }
        }
        return Result;
    }

    public int LifeShip()
    {
        int countLife = 0;
        foreach (Ship Test in ListShip)
        {
            foreach (TestCoord Paluba in Test.ShipCoord)
            {
                int TestBlock = Pole[Paluba.X, Paluba.Y].GetComponent<Chanks>().Index;
                if (TestBlock == 1) countLife++;
            }
        }
        return countLife;
    }

}