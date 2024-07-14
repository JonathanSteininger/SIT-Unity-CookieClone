using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public GameObject textChange;
    private TMP_Text textComponent;

    public GameObject buildingList;


    private uint cookieCount = 0;
    private uint clickPower = 0;
    private float cookiesPerSecond = 0;


    public List<Building> buildings;


    // Start is called before the first frame update
    void Start()
    {
        textComponent = textChange.GetComponent <TMP_Text>();
        setCookieText();
        return;
    }

    
    // Update is called once per frame
    void Udate()
    {
        updateCookiesPerSecond();
        setCookieText();
        

        return;
    }

    private void updateCookiesPerSecond()
    {
        

    }
    private void setCookieText() {
        textComponent.text = cookieCount.ToString();
    }

    public void increaseSize()
    {

    }
}


