using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Building
{
    public string name;
    public float cookiesPerSecond;
    public uint price;
    private int boughtCount;

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
