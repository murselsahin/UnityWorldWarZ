using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermiKontrol : MonoBehaviour {

    AudioSource audioSource;
    Rigidbody2D fizik;
    public int vurusGucu;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        fizik = GetComponent<Rigidbody2D>();
        fizik.velocity = new Vector2(1.2f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetVurusGucu(int  guc)
    {
        vurusGucu = guc;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="zombi1")
        {
            GetComponent<SpriteRenderer>().enabled = false;
            try
            {
                GetComponent<CircleCollider2D>().enabled = false;
            }catch
            {
                GetComponent<PolygonCollider2D>().enabled = false;
            }
            
            audioSource.Play();
            collision.gameObject.GetComponent<Zombi1Kontrol>().SetCan(vurusGucu);
            Destroy(this.gameObject,2f);
        }
        
        if(collision.gameObject.tag=="ekranDisi")
        {
            Destroy(this.gameObject);
        }
    }

    


}
