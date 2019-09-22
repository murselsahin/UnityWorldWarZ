using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayinKontrol : MonoBehaviour {
    public float can;
    public Sprite[] kurulurkenSprite;
    public Sprite kurulduSprite;
    bool kurulduMu = false;
    SpriteRenderer spriteRenderer;
    public float kurulmaZamani;
    AudioSource audioSource;
    Animator animator;
    // Use this for initialization


    void Start () {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        tumZemin = GameObject.FindGameObjectWithTag("tumZemin");
        animator = GetComponent<Animator>();

        animator.enabled = false;
       
    }//
    public void SetCocukIndex(int index)
    {

        zemininCocukIndexi = index;

    }


    GameObject tumZemin;
    int zemininCocukIndexi;
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            tumZemin.transform.GetChild(zemininCocukIndexi).GetComponent<Tiklama>().SetCollider(true);
            Destroy(this.gameObject);
        }
    }//


    private void LateUpdate()
    {
        if(kurulduMu==false)
        {
            MayinKurul();
        }
        
    }

    public bool MayinAktifMi()
    {
        return kurulduMu;
    }
    
    public void Patla()
    {
        audioSource.Play();
        animator.enabled = true;
        tumZemin.transform.GetChild(zemininCocukIndexi).GetComponent<Tiklama>().SetCollider(true);
       Destroy(this.gameObject,0.5f);
    }

    public void YokOl()
    {
        tumZemin.transform.GetChild(zemininCocukIndexi).GetComponent<Tiklama>().SetCollider(true);
        Destroy(this.gameObject);
    }


    float kurulAnimZaman = 0;
    float zaman = 0;
    int sayac = 0;
    private void MayinKurul()
    {
        zaman += Time.deltaTime;
        kurulAnimZaman += Time.deltaTime;
        if (zaman>kurulmaZamani)
        {
            spriteRenderer.sprite = kurulduSprite;
            kurulduMu = true;
        }
        else if(kurulAnimZaman>0.20f)
        {
            spriteRenderer.sprite = kurulurkenSprite[sayac % 2];
            sayac++;
            kurulAnimZaman = 0;
        }
        

    }

    

}
