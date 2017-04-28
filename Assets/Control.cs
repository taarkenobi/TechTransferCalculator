using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour {
    public GameObject profitPreview;
    public GameObject successToMarket;
    public GameObject successToResearch;
    public GameObject feeInput;
    public GameObject royaltyInput;
    public GameObject mountBase;
    public GameObject mountDice;
    public GameObject costMarket;
    public GameObject ipText;
    public GameObject lpText;
    public GameObject ttopText;


    public int mountB = 0;
    public int mountD = 0;
    public float successM = 10;
    public float successR = 10;
    public int sRCost = 0;
    public int sMCost = 0;
    public float feeMount = 0;
    public float royaltyMount = 0;

    public int wTTO = 0;

    public float iProfit;
    public float lProfit;
    public float ttoProfit;
    public float profit;
	// Use this for initialization
	void Start () {
        StartCoroutine(PreviewUpdate(1.0f));
        StartCoroutine(UpdateSubProfit(1.0f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateMountBase()
    {
        int.TryParse(mountBase.GetComponent<InputField>().text, out mountB);
    }

    public void UpdateMountDice()
    {
        int.TryParse(mountDice.GetComponent<InputField>().text, out mountD);
    }

    public void UpdateMarketDice()
    {
        float.TryParse(successToMarket.GetComponent<InputField>().text, out successM);
        
    }

    public void UpdateResearchDice()
    {
        float.TryParse(successToResearch.GetComponent<InputField>().text, out successR);

    }

    public void UpdateInventorMount()
    {
        float.TryParse(feeInput.GetComponent<InputField>().text, out feeMount);
        float.TryParse(royaltyInput.GetComponent<InputField>().text, out royaltyMount);

    }


    IEnumerator PreviewUpdate(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            float sMBase = 0.1f;
            if (sMCost == 0)
                sMBase = 0.1f;
            else if (sMCost == 1)
                sMBase = 0.4f;
            else if (sMCost == 2)
                sMBase = 0.6f;

            float sRBase = 0.1f;
            if (sRCost == 0)
                sRBase = 0.1f;
            else if (sRCost == 1)
                sRBase = 0.4f;
            else if (sRCost == 2)
                sRBase = 0.6f;


            profit = (mountB + mountD * 100000) * (successM/10 + sMBase) * (successR/10 + sRBase);
            print(successM / 10);
            print(successR / 10 + 0.1f);

            profitPreview.GetComponent<Text>().text = "$ " + profit.ToString("n0");
        }
    }

    IEnumerator UpdateSubProfit(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);

            if (wTTO == 1)
                ttoProfit = profit * 0.1f + 50000;
            else
                ttoProfit = 0;

            float uProfit = profit - ttoProfit;

            iProfit = profit * (royaltyMount / 100) + feeMount;

            lProfit = uProfit - iProfit;
            //profit = (mountB + mountD * 100000) * (successM / 10 + sMBase) * (successR / 10 + sRBase);
            //tto
            ttopText.GetComponent<Text>().text = "$ " + ttoProfit.ToString("n0");
            //inventor
            ipText.GetComponent<Text>().text = "$ " + iProfit.ToString("n0");
            //licencee
            lpText.GetComponent<Text>().text = "$ " + lProfit.ToString("n0");
        }
    }
}
