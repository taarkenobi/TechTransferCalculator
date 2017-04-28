using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDisable : MonoBehaviour {

    [Header("COST BUTTONS")]
    public GameObject[] _buttons;

    [Header("TTO BUTTONS")]
    public bool forTTO = false;
    public GameObject[] _tto;

	// Use this for initialization
	void Start () {
        if (forTTO)
            TTOClick(0);
        else
            Click(0);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Click(int id)
    {
        print("Boton: " + id);

        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].GetComponent<Button>().interactable = true;
        }

        _buttons[id].GetComponent<Button>().interactable = false;

        GameObject.Find("AppControl").GetComponent<Control>().sMCost = id;
    }

    public void ClickResearch(int id)
    {
        print("Boton: " + id);

        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].GetComponent<Button>().interactable = true;
        }

        _buttons[id].GetComponent<Button>().interactable = false;

        GameObject.Find("AppControl").GetComponent<Control>().sRCost = id;
    }

    public void TTOClick(int status)
    {
        for (int i = 0; i < _tto.Length; i++)
        {
            _tto[i].GetComponent<Button>().interactable = true;
        }

        _tto[status].GetComponent<Button>().interactable = false;

        GameObject.Find("AppControl").GetComponent<Control>().wTTO = status;
    }

}
