using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OyunSonuKontrol : MonoBehaviour {
    Animator animator;
	public Button btnTekrar, btnAnaMenu;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
		btnTekrar.gameObject.SetActive (false);
		btnAnaMenu.gameObject.SetActive (false);
        animator.enabled = false;
	}

    public void OyunSonu()
    {
        animator.enabled = true;

		btnTekrar.gameObject.SetActive (true);
		btnAnaMenu.gameObject.SetActive (true);

    }
	public void btnSec(int gelen)
	{
		if (gelen == 1) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		} else if (gelen == 2) {
			SceneManager.LoadScene (0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
