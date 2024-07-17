using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public GameObject textChange;
    private TMP_Text textComponent;

    public GameObject buildingTilePrefab;
    public GameObject buildingList;




    public float cookieCount = 0f;
    public float sellBuildingMulti = 0.5f;
    private float clickPower = 1;





    public List<Building> buildings;


    // Start is called before the first frame update
    void Start()
    {
        textComponent = textChange.GetComponent<TMP_Text>();
        setCookieText();
        fillBuildingList();
        return;
    }

    
    // Update is called once per frame

    void Update()
    {
        setCookieText();
        collectCookeis(Time.deltaTime);
        return;
    }
    private void fillBuildingList()
    {
        Vector3 _getOffsetPosition(GameObject _buildingTile, uint count)
        {
            float x = _buildingTile.transform.localPosition.x;
            float gap = 5f;
            float y = _buildingTile.transform.localPosition.y - ((_buildingTile.GetComponent<RectTransform>().sizeDelta.y + gap) * count);
            float z = 0;
            Debug.Log($"BuildingLocation: x)${x} y)${y} z)${z}");
            return new Vector3(x,y,z);
        }
        for (uint i = 0; i < buildings.Count; i++) {
            GameObject buildingTile = Instantiate(buildingTilePrefab, buildingList.transform);
            BuildingTile bt = buildingTile.GetComponent<BuildingTile>();
            bt.setBuilding(buildings[(int)i]);
            bt.setGameManager(this.gameObject);
            buildingTile.transform.localPosition = _getOffsetPosition(buildingTile, i);
        }
    }


    private void setCookieText() {
        textComponent.text = $"Cookies: ${Mathf.Floor(cookieCount)}";
    }

    private void collectCookeis(float deltatime)
    {
        foreach(Building building in buildings)
        {
            cookieCount += building.makeCookies(deltatime);
        }
    }

    public void ClickCookieButton()
    {
        cookieCount += clickPower;
    }
}


