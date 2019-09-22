using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartPistolKontrol : MonoBehaviour {

    public int para;
    public Sprite[] sprites;
    OyunKontrol oyunKontrol;
    private void OnMouseDown()
    {
       oyunKontrol.SetSecilmediSprite();
        PlayerPrefs.SetString("secilenNesne", "");
        PlayerPrefs.SetInt("parasi", 0);

        if (oyunKontrol.GetToplamPara() >= para)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[1];
            PlayerPrefs.SetString("secilenNesne", "askerPistol");
            PlayerPrefs.SetInt("parasi", para);
        }
    }

    public void setSprite()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[0];
    }

    // Use this for initialization
    void Start () {
        oyunKontrol = GameObject.FindGameObjectWithTag("oyunKontrol").GetComponent<OyunKontrol>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
