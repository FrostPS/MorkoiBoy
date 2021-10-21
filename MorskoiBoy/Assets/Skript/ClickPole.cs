using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPole : MonoBehaviour
{
    public GameObject WhoPerent = null;

    public int CoordX, CoordY;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (WhoPerent != null)
        {
            WhoPerent.GetComponent<GamePole>().WhoClick(CoordX, CoordY);
        }
    }

}
