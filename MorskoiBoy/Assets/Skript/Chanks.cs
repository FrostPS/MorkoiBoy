using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chanks : MonoBehaviour
{

    public Sprite[] imgs;

    public int Index = 0;

    void ChangeImgs()
    {
        if (imgs.Length > Index)
        {
            GetComponent<SpriteRenderer>().sprite = imgs[Index];
        }
    }

    void Start()
    {
        ChangeImgs();
    }

    void Update()
    {
        ChangeImgs();
    }
}
