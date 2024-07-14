using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingTile : MonoBehaviour
{
    public GameObject buyButtonObject;
    public GameObject sellButtonObject;
    public GameObject nameTextObject;
    public GameObject priceTextObject;
    public GameObject countTextObject;
    public GameObject CPSTextObject;
    public GameObject totalCPSTextObject;


    private ButtonReferences _buyButton;
    private ButtonReferences _sellButton;

    private TextReference _nameText;
    private TextReference _priceText;
    private TextReference _countText;
    private TextReference _CPSText;
    private TextReference _totalCPSText;


    private Building buildingStats = null;

    public Building getBuildingStats()
    {
        if (buildingStats == null)
        {
            return null;
        }
        return buildingStats;
    }



    private class TextReference
    {
        public GameObject gameObject;
        public TMP_Text textComponent;
        public TextReference(GameObject text)
        {
            gameObject = text;
            textComponent = gameObject.GetComponent<TMP_Text>();
        }

        public void UpdateText(string text)
        {
            if (text == null)
            {
                Debug.Log("inputed Text missing");
                return;
            }
            if (textComponent == null)
            {
                Debug.Log("Missing textComponent somehow. (Should not be possible (unless manually done))");
                return;
            }
            textComponent.text = text;
        }
    }
    private class ButtonReferences
    {
        public GameObject gameObject;
        public Button buttonComponent;
        public TextReference textReference;
        public ButtonReferences(GameObject button)
        {
            gameObject = button;
            buttonComponent = button.GetComponent<Button>();
            textReference = new TextReference(button.transform.Find("Text (TMP)").gameObject);
        }
        public void UpdateText(string text)
        {
            if (textReference == null)
            {
                Debug.Log("missing textReference in button. Can't update text.");
                return;
            }
            textReference.UpdateText(text);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GetReferences();
    }

    private void GetReferences()
    {
        Debug.Log("Loading BuildingTile References");
        try
        {
            _buyButton = new ButtonReferences(buyButtonObject);
            _sellButton = new ButtonReferences(sellButtonObject);

            _nameText = new TextReference(nameTextObject);
            _priceText = new TextReference(priceTextObject);
            _countText = new TextReference(countTextObject);
            _CPSText = new TextReference(CPSTextObject);
            _totalCPSText = new TextReference(totalCPSTextObject);
        } catch (Exception e)
        {
            Debug.Log($"Error loading BuildingTile references. : ${e.Message}");
            throw e;
        }
    }


    public void updateText()
    {
        if (buildingStats == null)
        {
            Debug.Log("BuildingStats not declared. Skipping updating UI.");
            return;
        }
        _nameText.UpdateText(buildingStats.name);
        _priceText.UpdateText($"Price: ${buildingStats.price} Cookies");
        _countText.UpdateText($"Count: ${buildingStats.boughtCount}");
        _CPSText.UpdateText($"CPS: ${buildingStats.cookiesPerSecond}");
        _totalCPSText.UpdateText($"Total CPS: ${buildingStats.totalCookiesPerSecond}");
        // Could later make this change dynamically.
        _buyButton.UpdateText("Buy");
        _sellButton.UpdateText("Sell");
    }

    // Update is called once per frame
    void Update()
    {
        updateText();
    }
}
