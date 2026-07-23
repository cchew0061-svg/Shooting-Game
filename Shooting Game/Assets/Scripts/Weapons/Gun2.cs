using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun2 : MonoBehaviour
{
    public float damage = 20;
    public float range = 120;
    public float maxAmmunition = 5;
    public float ammunition;

    public Camera cam;

    public ParticleSystem particles;
    public GameObject NoAmmoUI;
    public TextMeshProUGUI ammoDisplay;

    // Start is called before the first frame update
    void Start()
    {
		cam = Camera.main;
		ammunition = maxAmmunition;
    }

    // stops ammunition from going above the maxAmmunition value and below 0, displays ammunition count
    void Update()
    {
		ammunition = Mathf.Clamp(ammunition, 0, maxAmmunition);  
		if(ammoDisplay!= null)
		{
			ammoDisplay.text = $"{ammunition}/{maxAmmunition}";
		}
    }

    //shoots enemy if aimed at, in range and has ammunition, otherwise runs coroutine
    public void ShootGun2()
    {
		if(ammunition != 0)
		{
			particles.Play();
		
			RaycastHit hit;
			if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
			{
			EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();
				if(enemyHealth != null)
			{
				enemyHealth.TakeDamage(damage);
				}
			}
			ammunition = ammunition - 1;
		}
		else
		{
			StartCoroutine(ShowNoAmmoUI());
		}
    }

    //displays text
    private IEnumerator ShowNoAmmoUI()
    {
		NoAmmoUI.gameObject.SetActive(true);
		yield return new WaitForSeconds(2f);
		NoAmmoUI.gameObject.SetActive(false);
    }

    //reloads gun to maximum ammunition count
    public void ReloadGun2()
    {
		ammunition = maxAmmunition;
    }
}
