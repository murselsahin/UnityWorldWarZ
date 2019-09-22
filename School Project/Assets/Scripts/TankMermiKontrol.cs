using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMermiKontrol : MonoBehaviour {


    AudioSource audioSource;
    Rigidbody2D fizik;
    public Sprite[] sprite;
    public int vurusGucu;
    SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        fizik = GetComponent<Rigidbody2D>();
        fizik.velocity = new Vector2(1.2f, 0);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    float zaman = 0;
    int sayac = 0;
    private void LateUpdate()
    {
        zaman += Time.deltaTime;
        if(zaman>0.18f)
        {
            spriteRenderer.sprite = sprite[sayac % 2];
            sayac++;
        }
        
    }
    public void SetVurusGucu(int guc)
    {
        vurusGucu = guc;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "zombi1")
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<PolygonCollider2D>().enabled = false;
            audioSource.Play();
            collision.gameObject.GetComponent<Zombi1Kontrol>().SetCan(vurusGucu);
            Destroy(this.gameObject,2f);
        }
        if (collision.gameObject.tag == "ekranDisi")
        {
            Destroy(this.gameObject);
        }
    }



}
