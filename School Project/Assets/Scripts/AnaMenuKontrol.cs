 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnaMenuKontrol : MonoBehaviour {
    
    GameObject leveller,kilitler;
    void Start ()
    {
        
        PlayerPrefs.SetString("secilenNesne", "");
        leveller = GameObject.FindGameObjectWithTag("leveller");
        kilitler = GameObject.FindGameObjectWithTag("kilitler");

        for(int i=0;i<leveller.transform.childCount;i++)
        {
            leveller.transform.GetChild(i).gameObject.SetActive(false);
            kilitler.transform.GetChild(i).gameObject.SetActive(false);
        }
        
    }

    public void LevellerButton(int gelenButon)
    {
        
        SceneManager.LoadScene(gelenButon);
    }

    public void buttonSec(int gelenButon)
    {
        if(gelenButon==1)
        {
            if (PlayerPrefs.GetInt("gecilenLevel") == 3)
                SceneManager.LoadScene(3);
            else
                SceneManager.LoadScene(PlayerPrefs.GetInt("gecilenLevel") + 1);
        }
        else if (gelenButon == 2)
        {
            for (int i = 0; i < leveller.transform.childCount; i++)
            {
                leveller.transform.GetChild(i).gameObject.SetActive(true);
                kilitler.transform.GetChild(i).gameObject.SetActive(true);
            }

            for(int i=0;i<leveller.transform.childCount;i++)
            {
                if(i<=PlayerPrefs.GetInt("gecilenLevel"))
                {
                    leveller.transform.GetChild(i).gameObject.GetComponent<Button>().interactable = true;
                    kilitler.transform.GetChild(i).gameObject.SetActive(false);
                }
            }


        }
        else if (gelenButon == 3)
        {
            Application.Quit();
        }
    }
	
	
}
