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

    private class TextReference
    {
        public GameObject gameObject;
        public TMP_Text textComponent;
        public TextReference(GameObject text)
        {
            gameObject = text;
            textComponent = gameObject.GetComponent<TMP_Text>();
        }
    }
    private class ButtonReferences
    {
        public Button buttonComponent;
        public GameObject textObject;
        public TextReference textReference;
        public ButtonReferences(GameObject button)
        {
            buttonComponent = button.GetComponent<Button>();
            textObject = button.transform.Find("Text (TMP)").gameObject;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        
    }

    private void GetReferences()
    {
        _buyButton = buy

    }


    public void updateText()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
