using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OyunGecisKontrol : MonoBehaviour {

    public GameObject zombiler;
    Animator animator;
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        animator.enabled = false;
        
	}
    float zaman = 0;
    private void LateUpdate()
    {
        if(zombiler.transform.childCount==0)
        {
            animator.enabled = true;
            zaman += Time.deltaTime;
            if (SceneManager.GetActiveScene().buildIndex > PlayerPrefs.GetInt("gecilenLevel"))
                PlayerPrefs.SetInt("gecilenLevel", SceneManager.GetActiveScene().buildIndex);
            if (zaman > 2f)
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
