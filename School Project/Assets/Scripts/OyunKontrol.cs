using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OyunKontrol : MonoBehaviour {

    public int toplamPara = 500;
    KartMinigunKontrol kartMinigunKontrol;
    KartTankKontrol kartTankKontrol;
    KartParaKontrol kartParaKontrol;
    KartBazukaKontrol kartBazukaKontrol;
    KartTaramaliKontrol kartTaramaliKontrol;
    KartPistolKontrol kartPistolKontrol;
    KartMayinKontrol kartMayinKontrol;
    public Text textPara;
    // Use this for initialization
    void Start () {
        PlayerPrefs.SetString("secilenNesne", "");
        PlayerPrefs.SetInt("parasi", 0);

        kartMinigunKontrol = GameObject.FindGameObjectWithTag("kartMinigun").GetComponent<KartMinigunKontrol>();
        kartTankKontrol = GameObject.FindGameObjectWithTag("kartTank").GetComponent<KartTankKontrol>();
        kartParaKontrol = GameObject.FindGameObjectWithTag("kartPara").GetComponent<KartParaKontrol>();
        kartBazukaKontrol = GameObject.FindGameObjectWithTag("kartBazukaAsker").GetComponent<KartBazukaKontrol>();
        kartTaramaliKontrol = GameObject.FindGameObjectWithTag("kartTaramaliAsker").GetComponent<KartTaramaliKontrol>();
        kartPistolKontrol = GameObject.FindGameObjectWithTag("kartPistolAsker").GetComponent<KartPistolKontrol>();
        kartMayinKontrol = GameObject.FindGameObjectWithTag("kartMayin").GetComponent<KartMayinKontrol>();

        textPara.text = toplamPara.ToString();

    }

    public void SetSecilmediSprite()
    {
        kartMinigunKontrol.setSprite();
        kartTankKontrol.setSprite();
        kartParaKontrol.setSprite();
        kartBazukaKontrol.setSprite();
        kartTaramaliKontrol.setSprite();
        kartPistolKontrol.setSprite();
        kartMayinKontrol.setSprite();
    }

    public void SetParaArttir(int para)
    {
        toplamPara += para;
        textPara.text = toplamPara.ToString();
    }

    public int GetToplamPara()
    {
        return toplamPara;
    }

    public void SetToplamPara(int para)
    {
        toplamPara -= para;
        textPara.text = toplamPara.ToString();
    }
        
	
	// Update is called once per frame
	void Update () {
		
	}
}
