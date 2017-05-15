using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class Control : MonoBehaviour {
    public GameObject profitPreview;
    public GameObject successToMarket;
    public GameObject successToResearch;
    public GameObject feeInput;
    public GameObject royaltyInput;
    public GameObject mountBase;
    public GameObject mountBase2;
    public GameObject mountDice;
    public GameObject costMarket;
    public GameObject ipText;
    public GameObject lpText;
    public GameObject ttopText;
    public GameObject MountPlaceholder;
    public GameObject MountDicePlaceholder;


    public float inventionProfit = 0;
    public int mountB = 0;
    public int mountD = 0;
    public float successM = 10;
    public float successR = 10;
    public float s2M = 0;
    public float s2R = 0;
    public int sRCost = 0;
    public float sRRCost = 0;
    public float sMRCost = 0;
    public int sMCost = 0;
    public float feeMount = 0;
    public float royaltyMount = 0;

    public GameObject ButtonsControl;
    public int wTTO = 0;

    public float iProfit;
    public float lProfit;
    public float ttoProfit;
    public float profit;

    public string inventorName;
    public string licenceeName;
    public string ttoName;
    public float inventorEstimatedMultiply;
    public float licenceeEstimatedMultiply;
    public int ttoEstimatedMount;
    public float ttoEstimatedMount2N;
    public GameObject DDInventorName;
    public GameObject DDLicenceeName;
    public GameObject DDTTOName;
    public GameObject ieObj;
    public GameObject leObj;
    public GameObject teObj;

    [Header("Screens")]
    public int state = 0;
    public GameObject[] mountBaseObj;
    public GameObject[] oScreens;

    [Header("PopUp")]
    public GameObject popup;
	// Use this for initialization
	void Start () {
        StartCoroutine(PreviewUpdate(1.0f));
        StartCoroutine(UpdateSubProfit(1.0f));

        //SendEmail();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateNames()
    {
        inventorName = DDInventorName.GetComponentInChildren<Text>().text;
        licenceeName = DDLicenceeName.GetComponentInChildren<Text>().text;
        ttoName = DDTTOName.GetComponentInChildren<Text>().text;
        print(inventorName);
        print(licenceeName);
        print(ttoName);
    }

    public void UpdateEstimates()
    {
        float.TryParse(ieObj.GetComponent<InputField>().text, out inventorEstimatedMultiply);
        float.TryParse(leObj.GetComponent<InputField>().text, out licenceeEstimatedMultiply);
        int.TryParse(teObj.GetComponent<InputField>().text, out ttoEstimatedMount);
        print(inventorEstimatedMultiply);
        print(licenceeEstimatedMultiply);
        print(ttoEstimatedMount);
        if (DDTTOName.GetComponent<Dropdown>().value != 0)
        {
            mountB = ttoEstimatedMount;
            mountD = 0;
            MountPlaceholder.GetComponent<Text>().text = "" + ttoEstimatedMount;
            MountDicePlaceholder.GetComponent<Text>().text = "0";
            ButtonsControl.GetComponent<ButtonDisable>().TTOClick(1);
        }
        else
        {
            ButtonsControl.GetComponent<ButtonDisable>().TTOClick(0);
        }

    }

    public void UpdateMountBase()
    {
        int.TryParse(mountBase.GetComponent<InputField>().text, out mountB);
    }

    public void UpdateMountBase2()
    {
        int.TryParse(mountBase2.GetComponent<InputField>().text, out mountB);
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

            ttoEstimatedMount2N = ttoEstimatedMount * (successM / 10 + 0.1f) * (successR / 10 + 0.1f);
            s2M = successM / 10 + sMBase;
            s2R = successR / 10 + sRBase;
            sRRCost = 200000 * sRCost;
            sMRCost = 100000 * sMCost;
            inventionProfit = mountB + mountD * 100000;

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

            ttoProfit = Mathf.Round(ttoProfit / 50000) * 50000;
            iProfit = Mathf.Round(iProfit / 50000) * 50000;
            lProfit = Mathf.Round(lProfit / 50000) * 50000;
            //profit = (mountB + mountD * 100000) * (successM / 10 + sMBase) * (successR / 10 + sRBase);
            //tto
            ttopText.GetComponent<Text>().text = "$ " + ttoProfit.ToString("n0");
            //inventor
            ipText.GetComponent<Text>().text = "$ " + iProfit.ToString("n0");
            //licencee
            lpText.GetComponent<Text>().text = "$ " + lProfit.ToString("n0");
        }
    }

    public void ChangeScreen(int screen)
    {
        state = screen;
        for (int i = 0; i < oScreens.Length; i++)
        {
            oScreens[i].SetActive(false);
        }
        oScreens[screen].SetActive(true);

        if ((screen == 3) || (screen == 2))
        {
            for (int j = 0; j < mountBaseObj.Length; j++)
            {
                mountBaseObj[j].SetActive(false);
            }
            if (screen == 2)
            {
                mountBaseObj[0].SetActive(true);
                mountBaseObj[1].SetActive(true);
            }
            if (screen == 3)
                mountBaseObj[2].SetActive(true);
        }

    }

    public void CallPopUp(bool status)
    {
        popup.SetActive(status);
    }

    public void SendEmail()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("Error. Check internet connection!");
        }
        else
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("techtransferin@gmail.com");
            mail.To.Add("techtransferout@gmail.com");
            mail.Subject = "EMAIL PRUEBA";
            mail.Body = licenceeName + "|||" + inventorName + "|||" + ttoName + "|||" + inventorEstimatedMultiply + "|||" 
                + licenceeEstimatedMultiply + "|||" + ttoEstimatedMount + "|||" + ttoEstimatedMount2N + "|||" + s2R + "|||" + s2M + "|||"
                + sRRCost + "|||" + sMRCost + "|||" + inventionProfit + "|||" + profit + "|||" + feeMount + "|||" + royaltyMount + "|||"
                + ttoProfit + "|||" + lProfit + "|||" + iProfit;

            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
            smtpServer.Port = 587;
            smtpServer.Credentials = new System.Net.NetworkCredential("techtransferin@gmail.com", "Techtransfer17-") as ICredentialsByHost;
            smtpServer.EnableSsl = true;
            ServicePointManager.ServerCertificateValidationCallback =
                delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                { return true; };
            smtpServer.Send(mail);
            Debug.Log("success!!, mensaje enviado.");

            CallPopUp(false);
        }
    }
}
