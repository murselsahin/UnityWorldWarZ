using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AskerKontrol : MonoBehaviour {
    public float can;
    public GameObject mermi;
    public float atesBeklemeSuresi;
    public Sprite[] spriteDururken;
    public Sprite[] spriteAtesEderken;
    SpriteRenderer spriteRenderer;
    int idleAnimSayac = 0;
    int atesAnimSayac = 0;
    bool yukariSay = true;
    bool bekleme = true;
	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        tumZemin = GameObject.FindGameObjectWithTag("tumZemin");
    }
    // Zombi ile Karşılaşma İşlemleri OPENING
    public int mermiGucu;
    public LayerMask layerMask;
    RaycastHit2D ray;

    private void FixedUpdate()
    {
        DusmanGorduMu();
    }
    private void DusmanGorduMu()
    {
        Vector3 rayYonum = new Vector3(5, transform.position.y);

        ray = Physics2D.Raycast(transform.position, transform.right, 5 - transform.position.x, layerMask); //düşmandan karaktere çizgi çizdiriyo 
        if (ray.point != Vector2.zero)
            Debug.DrawLine(transform.position, ray.point, Color.magenta);

    }

    public void SetCan(int vurusGucu)
    {

        can -= vurusGucu;
        if (can <= 0)
        {
            tumZemin.transform.GetChild(zemininCocukIndexi).GetComponent<Tiklama>().SetCollider(true);
            Destroy(this.gameObject);
        }


    }


    // Zombi ile Karşılaşma İşlemleri CLOSEING
    //
    public void SetCocukIndex(int index)
    {

        zemininCocukIndexi = index;

    }


    GameObject tumZemin;
    int zemininCocukIndexi;
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1)) //sağ tık yokolma işlemi
        {
            tumZemin.transform.GetChild(zemininCocukIndexi).GetComponent<Tiklama>().SetCollider(true);
            Destroy(this.gameObject);
        }
    }//

  

    float atesetZaman = 0;
    private void LateUpdate()
    {
        atesetZaman += Time.deltaTime;
        if(atesetZaman> atesBeklemeSuresi)
        {
            atesetZaman = 0;
            idleAnimSayac = 0;
            yukariSay = true;
            bekleme = false;
            
        }
        if (bekleme == false && ray.point == Vector2.zero) // karşıda zombi yoksa bekle
        {

            Bekle();
        }
        else if (bekleme == true)
        {

            Bekle();
        }
        else if (bekleme == false && ray.point != Vector2.zero && ray.collider.tag == "zombi1")
        {
            
            AtesEt();
        }

    }

    float beklemeTimer = 0;
    float silahTimer = 0;

    private void AtesEt()
    {
        atesetZaman = 0;
        silahTimer += Time.deltaTime;
        if (silahTimer > 0.18f)
        {

            silahTimer = 0;
            spriteRenderer.sprite = spriteAtesEderken[atesAnimSayac];
            if (atesAnimSayac == 0 || atesAnimSayac == 2)
            {
              var mermiM =   Instantiate(mermi, new Vector3(transform.position.x + 0.45f, transform.position.y, transform.position.z), Quaternion.identity);
                mermiM.GetComponent<MermiKontrol>().SetVurusGucu(mermiGucu);
            }
            if (yukariSay == true)
            {

                atesAnimSayac++;
                if (atesAnimSayac == spriteAtesEderken.Length)
                {

                    atesAnimSayac--;
                    atesAnimSayac--;
                    yukariSay = false;
                }
            }
            else
            {
                atesAnimSayac--;
                if (atesAnimSayac == -1)
                {
                    atesAnimSayac++;
                    atesAnimSayac++;
                    bekleme = true;
                    atesAnimSayac = 0;


                }
            }

        }
    }
    private void Bekle()
    {
        beklemeTimer += Time.deltaTime;
        if (beklemeTimer > 0.18f)
        {
            beklemeTimer = 0;
            spriteRenderer.sprite = spriteDururken[idleAnimSayac];
            if (yukariSay == true)
            {
                idleAnimSayac++;
                if (idleAnimSayac == spriteDururken.Length)
                {
                    idleAnimSayac--;
                    idleAnimSayac--;
                    yukariSay = false;
                }
            }
            else
            {
                idleAnimSayac--;
                if (idleAnimSayac == -1)
                {
                    idleAnimSayac++;
                    idleAnimSayac++;
                    yukariSay = true;
                }

            }
        }
    }
    
    
}
