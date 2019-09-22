using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParaKontrol : MonoBehaviour {

    public float can;
    OyunKontrol oyunKontrol;
    bool paraVarMi = false;

    public Sprite paraYok;
    public Sprite paraVar;


    AudioSource audioSource;

    SpriteRenderer spriteRenderer;

    public float paraVermeZamanAraligi;
    public int kacParaVersin;

    int zemininCocukIndexi;
    GameObject tumZemin;


	void Start () {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        oyunKontrol = GameObject.FindGameObjectWithTag("oyunKontrol").GetComponent<OyunKontrol>();
        spriteRenderer.sprite = paraYok;
        zaman = 0;
        paraVarMi = false;
        tumZemin = GameObject.FindGameObjectWithTag("tumZemin");
    }

    public void SetCocukIndex(int index)
    {

        zemininCocukIndexi = index;
        
    }

    public void YokOl()
    {
        tumZemin.transform.GetChild(zemininCocukIndexi).GetComponent<Tiklama>().SetCollider(true);
        Destroy(this.gameObject);
    }



    private void OnMouseOver()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            if (paraVarMi == true)
            {
                audioSource.Play();
                spriteRenderer.sprite = paraYok;
                paraVarMi = false;
                oyunKontrol.SetParaArttir(kacParaVersin);

            }
        }
        if (Input.GetMouseButtonDown(1))
        {
           
            tumZemin.transform.GetChild(zemininCocukIndexi).GetComponent<Tiklama>().SetCollider(true);
            Destroy(this.gameObject);
        }
    }

    float zaman = 0;
    private void LateUpdate()
    {
        if(paraVarMi==false)
        {
            zaman += Time.deltaTime;
            if(zaman>paraVermeZamanAraligi)
            {
                paraVarMi = true;
                spriteRenderer.sprite = paraVar;
                zaman = 0;
                
            }
        }

        

        
    }

    

    
}
