using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Building
{
    [SerializeField]
    private string name;
    public string Name { get { return name; } set { name = value; changed = true; } }
    [SerializeField]
    private float cookiesPerSecond; 
    public float CookiesPerSecond { get { return cookiesPerSecond; } set { cookiesPerSecond = value; changed = true; } }
    [SerializeField]
    private uint price;
    public uint Price { get { return price; } set { price = value; changed = true; } }
    [SerializeField]
    private uint boughtCount;
    public uint BoughtCount { get { return boughtCount; } set { boughtCount = value; changed = true; } }

    //make sure this is not below 1. will override this later with gamemanager object
    private float boughtMulti = 1.2f;



    private bool changed = false;

    public float totalCookiesPerSecond => cookiesPerSecond * boughtCount;

    public float getFinalPrice() => price * Mathf.Max((boughtCount * boughtMulti), 1);
    public float getFinalPrice(uint BuildingCount) => price * Mathf.Max(((float)BuildingCount) * boughtMulti, 1);

    public bool hasChanged => changed;

    public bool Buy(uint count, ref float totalMoneyOut)
    {
        return CheckBuy(boughtCount, count, totalMoneyOut, ref totalMoneyOut);
    }

    public bool Sell(uint count, float sellMultiplier, ref float totalMoneyOut)
    {
        if (count == 0) return false;
        for(; count > 0; count--)
        {
            if(boughtCount <= 0)
            {
                return true;
            }

            totalMoneyOut += sellMultiplier * getFinalPrice(boughtCount - 1);
        }
        return true;
    }
    public bool SellAll(float sellMultiplier, ref float totalMoneyOut)
    {
        return Sell(uint.MaxValue, sellMultiplier, ref totalMoneyOut);
    }

    private bool CheckBuy(uint tempBoughtCount, uint countRemain, float remainingMoney, ref float TotalMoneyOut)
    {
        //failed to buy previouse.
        if (remainingMoney < 0)
            return false;
        //Was able to buy all buildings.
        if (countRemain <= 0)
        {
            TotalMoneyOut = remainingMoney;
            return true;
        }

        //loop. if successfull, buy all of them frfr.
        if (CheckBuy(tempBoughtCount + 1, countRemain - 1, remainingMoney - getFinalPrice(tempBoughtCount), ref TotalMoneyOut))
        {
            boughtCount++;
            return true;
        }

        //runs if above check failed.
        return false;
    }

    public float makeCookies(float deltaTime)
    {
        if (boughtCount == 0) return 0;
        return deltaTime * (cookiesPerSecond * boughtCount);
    }
}
