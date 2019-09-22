using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombi1Kontrol : MonoBehaviour {

    public int can;
    public int vurusGucu;
    Animator animator;

    AudioSource[] audioSource;
    Rigidbody2D fizik;
    public float yurumeHizi;
    bool olduMu = false;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        fizik = GetComponent<Rigidbody2D>();
        GetComponent<BoxCollider2D>().isTrigger = true;
        audioSource = GetComponents<AudioSource>();
        fizik.velocity = new Vector2(-yurumeHizi, 0);
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z); //sola don
        
        //animator.SetTrigger("Saldir");
        //animator.SetTrigger("Yuru");



    }

    public void SetCan(int mermiGucu)
    {
        can -= mermiGucu;
        if(can<=0)
        {
            fizik.velocity = Vector2.zero;
            olduMu = true;
            animator.SetTrigger("Olum");
            Destroy(this.gameObject, 1.8f);
        }
    }

    GameObject temasEdilen = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(olduMu==false)
        {
            if(collision.gameObject.tag=="oyunSonu")
            {
                collision.gameObject.GetComponent<OyunSonuKontrol>().OyunSonu();
            }
        }
    }

    
    


    float zaman =0;
    private void OnTriggerStay2D(Collider2D collision)
    {
        try
        {
            if (olduMu == false)
            {
                if (collision.gameObject.tag == "para")
                {
                    if (!audioSource[1].isPlaying)
                        audioSource[1].Play();

                    temasEdilen = collision.gameObject;
                    fizik.velocity = new Vector2(0, 0);
                    animator.SetTrigger("Saldir");
                    animator.ResetTrigger("Yuru");
                    zaman += Time.deltaTime;
                    if (zaman > 1f)
                    {

                        collision.gameObject.GetComponent<ParaKontrol>().YokOl();

                        zaman = 0;
                    }
                }
                else if (collision.gameObject.tag == "mayin")
                {
                    if (!audioSource[1].isPlaying)
                        audioSource[1].Play();
                    temasEdilen = collision.gameObject;
                    fizik.velocity = new Vector2(0, 0);

                    if (collision.gameObject.GetComponent<MayinKontrol>().MayinAktifMi()) //mayin aktif ise
                    {

                        Destroy(this.gameObject);
                        collision.gameObject.GetComponent<MayinKontrol>().Patla();
                        return;
                    }
                    animator.SetTrigger("Saldir");
                    animator.ResetTrigger("Yuru");
                    zaman += Time.deltaTime;
                    if (zaman > 1f)
                    {

                        collision.gameObject.GetComponent<MayinKontrol>().YokOl();

                        zaman = 0;
                    }
                }
                else if (collision.gameObject.tag == "askerPistol")
                {
                    if (!audioSource[1].isPlaying)
                        audioSource[1].Play();
                    temasEdilen = collision.gameObject;
                    fizik.velocity = new Vector2(0, 0);
                    animator.SetTrigger("Saldir");
                    animator.ResetTrigger("Yuru");
                    zaman += Time.deltaTime;
                    if (zaman > 1f)
                    {
                        collision.gameObject.GetComponent<PistolAskerKontrol>().SetCan(vurusGucu);
                        zaman = 0;
                    }
                }
                else if (collision.gameObject.tag == "askerBazuka")
                {
                    if (!audioSource[1].isPlaying)
                        audioSource[1].Play();
                    temasEdilen = collision.gameObject;
                    fizik.velocity = new Vector2(0, 0);
                    animator.SetTrigger("Saldir");
                    animator.ResetTrigger("Yuru");
                    zaman += Time.deltaTime;
                    if (zaman > 1f)
                    {
                        collision.gameObject.GetComponent<BazukaAskerKontrol>().SetCan(vurusGucu);
                        zaman = 0;
                    }
                }
                else if (collision.gameObject.tag == "tank")
                {
                    if (!audioSource[1].isPlaying)
                        audioSource[1].Play();
                    temasEdilen = collision.gameObject;
                    fizik.velocity = new Vector2(0, 0);
                    animator.SetTrigger("Saldir");
                    animator.ResetTrigger("Yuru");
                    zaman += Time.deltaTime;
                    if (zaman > 1f)
                    {
                        collision.gameObject.GetComponent<TankKontrol>().SetCan(vurusGucu);
                        zaman = 0;
                    }
                }
                else if (collision.gameObject.tag == "minigun")
                {
                    if (!audioSource[1].isPlaying)
                        audioSource[1].Play();
                    temasEdilen = collision.gameObject;
                    fizik.velocity = new Vector2(0, 0);
                    animator.SetTrigger("Saldir");
                    animator.ResetTrigger("Yuru");
                    zaman += Time.deltaTime;
                    if (zaman > 1f)
                    {
                        collision.gameObject.GetComponent<MinigunKontrol>().SetCan(vurusGucu);
                        zaman = 0;
                    }
                }
                else if (collision.gameObject.tag == "askerTaramali")
                {
                    if (!audioSource[1].isPlaying)
                        audioSource[1].Play();
                    temasEdilen = collision.gameObject;
                    fizik.velocity = new Vector2(0, 0);
                    animator.SetTrigger("Saldir");
                    animator.ResetTrigger("Yuru");
                    zaman += Time.deltaTime;
                    if (zaman > 1f)
                    {
                        collision.gameObject.GetComponent<AskerKontrol>().SetCan(vurusGucu);
                        zaman = 0;
                    }
                }


            }
        }
        catch
        {
            temasEdilen = null;
        }
    }

    private void FixedUpdate()
    {
        if (olduMu == false)
        {
            if (temasEdilen == null)
            {
                audioSource[1].Stop();
                fizik.velocity = new Vector2(-yurumeHizi, 0);
                animator.SetTrigger("Yuru");
                animator.ResetTrigger("Saldir");
                zaman = 0;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       if(olduMu==false)
        {
            if(collision.gameObject.tag=="ekranDisi")
            {
                audioSource[0].Play();
                
            }
        }
        
    }



    // Update is called once per frame
    void Update () {
       
	}
}
