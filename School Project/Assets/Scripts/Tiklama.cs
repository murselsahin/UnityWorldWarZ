using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiklama : MonoBehaviour
{
    public GameObject para, mayin, minigun, pistol, tank, taramali, bozuka;
    AudioSource audioSource;
    bool olustu = false;
    OyunKontrol oyunKontrol;
    private void OnMouseDown()
    {

        if (olustu == false)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            if (PlayerPrefs.GetString("secilenNesne") == "")
                return;
            GetComponent<BoxCollider2D>().enabled = false;

            int cocukIndex = transform.GetSiblingIndex();


            string secilenNesne = PlayerPrefs.GetString("secilenNesne");

            if (secilenNesne == "para")
            {
               var paraM = Instantiate(para, transform.position, transform.rotation);
                paraM.GetComponent<ParaKontrol>().SetCocukIndex(cocukIndex);
                
            }
            if (secilenNesne == "askerTaramali")
            {
               var taramaliM =  Instantiate(taramali, new Vector3(transform.position.x + 0.15f, transform.position.y + 0.01f, 0f), transform.rotation);
                taramaliM.GetComponent<AskerKontrol>().SetCocukIndex(cocukIndex);
            }
            if (secilenNesne == "askerPistol")
            {
               var pistolM =  Instantiate(pistol, new Vector3(transform.position.x + 0.15f, transform.position.y + 0.01f, 0f), transform.rotation);
                pistolM.GetComponent<PistolAskerKontrol>().SetCocukIndex(cocukIndex);
            }
            if (secilenNesne == "mayin")
            {
                var mayinM = Instantiate(mayin, new Vector3(transform.position.x, transform.position.y, 0f), transform.rotation);
                mayinM.GetComponent<MayinKontrol>().SetCocukIndex(cocukIndex);
            }
            if (secilenNesne == "askerBazuka")
            {
               var bozukaM =  Instantiate(bozuka, new Vector3(transform.position.x + 0.15f, transform.position.y + 0.01f, 0f), transform.rotation);
                bozukaM.GetComponent<BazukaAskerKontrol>().SetCocukIndex(cocukIndex);
            }
            if (secilenNesne == "minigun")
            {
               var minigunM = Instantiate(minigun, new Vector3(transform.position.x, transform.position.y, 0f), transform.rotation);
                minigunM.GetComponent<MinigunKontrol>().SetCocukIndex(cocukIndex);
            }
            if (secilenNesne == "tank")
            {
               var tankM = Instantiate(tank, new Vector3(transform.position.x, transform.position.y, 0f), transform.rotation);
                tankM.GetComponent<TankKontrol>().SetCocukIndex(cocukIndex);
            }


            audioSource.Play();

            oyunKontrol.SetToplamPara(PlayerPrefs.GetInt("parasi"));

            oyunKontrol.SetSecilmediSprite();
            PlayerPrefs.SetString("secilenNesne", "");
            PlayerPrefs.SetInt("parasi", 0);

            olustu = true;

        }
    }
   


    public void SetCollider(bool kontrol)
    {
        if (kontrol)
        {
            
            GetComponent<BoxCollider2D>().enabled = true;
            olustu = false;
            

        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        oyunKontrol = GameObject.FindGameObjectWithTag("oyunKontrol").GetComponent<OyunKontrol>();

        
       
    }
    void Update()
    {
        
    }
}
