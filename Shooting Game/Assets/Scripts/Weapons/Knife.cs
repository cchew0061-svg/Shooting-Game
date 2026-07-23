using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Knife : MonoBehaviour
{

    public float range = 2;
    public float damage = 10;


    public Camera cam;

    public ParticleSystem particles;

    public TextMeshProUGUI ammoDisplay;

    // Start is called before the first frame update
    void Start()
    {
	cam = Camera.main;
    }

    //changes ammo display text to null
    void Update()
    {
		if(ammoDisplay!= null)
		{
			ammoDisplay.text = null;
		}
    }

    //attacks enemy if looked at and in range
    public void Attack()
    {
	particles.Play();
	
	RaycastHit hit;
	if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
	{
	    Debug.Log(hit.transform.name + "with knife");
	    EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();
	    if(enemyHealth != null)
	    {
		enemyHealth.TakeDamage(damage);
	    }
	}

    }
}

