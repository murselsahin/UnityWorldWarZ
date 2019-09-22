using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunKontrol : MonoBehaviour {
    public float can;
    public GameObject mermi;
    public float atesBeklemeSuresi;
    public Sprite spriteDururken;
    public Sprite[] spriteAtesEderken;
    SpriteRenderer spriteRenderer;
    int sayac = 0;
    bool bekleme = true;

    GameObject tumZemin;
    int zemininCocukIndexi;

  

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


    private void LateUpdate()
    {
        if (bekleme == false && ray.point == Vector2.zero)
        {

            Bekle();
        }
        else if (bekleme == true)
        {

            Bekle();
        }
        else if (bekleme == false && ray.point != Vector2.zero && ray.collider.tag == "zombi1")
        {
            Debug.Log("3.if");
            AtesEt();
        }
    }
    float atesZaman = 0;
    private void AtesEt()
    {
        
        atesZaman += Time.deltaTime;
        if(atesZaman>0.18f)
        {
            atesZaman = 0;
            if(sayac==1 || sayac==4)
            {
                var mermiM2=Instantiate(mermi, new Vector3(transform.position.x + 0.45f, transform.position.y, transform.position.z), Quaternion.identity);
                var mermiM3 = Instantiate(mermi, new Vector3(transform.position.x + 0.45f, transform.position.y+0.2f, transform.position.z), Quaternion.identity);
                var mermiM4 = Instantiate(mermi, new Vector3(transform.position.x + 0.45f, transform.position.y-0.2f, transform.position.z), Quaternion.identity);
                mermiM2.GetComponent<MermiKontrol>().SetVurusGucu(mermiGucu);
                mermiM3.GetComponent<MermiKontrol>().SetVurusGucu(mermiGucu);
                mermiM4.GetComponent<MermiKontrol>().SetVurusGucu(mermiGucu);

            }
            spriteRenderer.sprite = spriteAtesEderken[sayac%2];
            sayac++;
            
            if(sayac==8)
            {
                sayac = 0;
                bekleme = true;
            }
        }
    }


    float zaman = 0;
    private void Bekle()
    {
        spriteRenderer.sprite = spriteDururken;
        zaman += Time.deltaTime;
        if(zaman>atesBeklemeSuresi)
        {
            bekleme = false;
            zaman = 0;
        }
    }





    public void SetCocukIndex(int index)
    {

        zemininCocukIndexi = index;

    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            tumZemin.transform.GetChild(zemininCocukIndexi).GetComponent<Tiklama>().SetCollider(true);
            Destroy(this.gameObject);
        }
    }
}
