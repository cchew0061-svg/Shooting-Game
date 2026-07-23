using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 80f;
    private float currentHealth;
    private float lerpTimer;
    public float chipSpeed = 2f;
    public Image frontHealthBar;
    public Image backHealthBar;

    public KillCounterScript killCounterScript;

    //enemies start with max health
    void Start()
    {
        currentHealth = maxHealth;
        killCounterScript = GameObject.Find("KillCounter").GetComponent<KillCounterScript>();
    }

    //stops enemy health from going above the maxhealth and below 0, updates the enemy's healthbar
    void Update()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateEnemyHealthUI();
    }

    //reduces health, dies if health reaches 0 or less
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        lerpTimer = 0f;
        if(currentHealth <= 0f)
        {
            Die();
            killCounterScript.killCounter += 1;
        }
    }

    //destroys the game object
    private void Die()
    {
        Destroy(gameObject);
    }

    //changes the enemy's visual healthbar
    public void UpdateEnemyHealthUI()
    {
		float fillFront = frontHealthBar.fillAmount;
		float fillBack = backHealthBar.fillAmount;
		float healthFraction = currentHealth / maxHealth;
		if(fillBack > healthFraction)
		{
			frontHealthBar.fillAmount = healthFraction;
			lerpTimer += Time.deltaTime;
			float percentComplete = lerpTimer / chipSpeed;
			percentComplete = percentComplete * percentComplete;
			backHealthBar.fillAmount = Mathf.Lerp(fillBack, healthFraction, percentComplete);
		}
    }
}
