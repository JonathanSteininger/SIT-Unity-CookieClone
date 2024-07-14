using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Building
{
    public string name;
    public float cookiesPerSecond; 
    public uint price;
    public int boughtCount; 

    public float CookiesPerSecond { get { return cookiesPerSecond; } set { name = value; changed = true; } }
    public uint Price { get { return price; } set { name = value; changed = true; } }
    public string Name { get { return name; } set { name = value; changed = true; } }
    public int BoughtCount { get { return boughtCount; } set { name = value; changed = true; } }


    private bool changed = false;


    public float totalCookiesPerSecond => cookiesPerSecond * boughtCount;

    public bool hasChanged()
    {


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public float makeCookies(Time gameTime)
    {
        if (boughtCount == 0) return 0;
        return Time.deltaTime * (cookiesPerSecond * boughtCount);
    }
}
