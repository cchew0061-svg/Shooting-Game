using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    private float health;
    private float lerpTimer;
    public float maxHealth = 100;
    public float chipSpeed = 2f;
    public Image frontHealthBar;
    public Image backHealthBar;

    public GameObject gameOverUI;

    public bool isDead;

    private InputManager inputManager;
    private PlayerDead playerDead;
    private InventoryManager inventoryManager;

	private KillCounterScript killCounterScript;
	public TextMeshProUGUI killCount;

    void Start()
    { 
		inputManager = GetComponent<InputManager>();
		playerDead = GetComponent<PlayerDead>();
		inventoryManager = GameObject.Find("Inventory").GetComponent<InventoryManager>();
		killCounterScript = GameObject.Find("KillCounter").GetComponent<KillCounterScript>();

		health = maxHealth;
    }

    void Update()
    {
		//prevents health from going below 0 and above the maximum health value
        health = Mathf.Clamp(health, 0, maxHealth);
		//updates the player's healthbar
		UpdateHealthUI();
		//heals the player if E is pressed and player's health is not the maximum health
		if(isDead == false)
		{
			if(inputManager.onFoot.Heal.triggered)
			{
				if(health != maxHealth)
				{
					inventoryManager = GameObject.Find("Inventory").GetComponent<InventoryManager>();
					inventoryManager.UseItem("Medical Kit");
				}
			}
		}
    }

    //shows players health bar and updates it
    public void UpdateHealthUI()
    {
		float fillFront = frontHealthBar.fillAmount;
		float fillBack = backHealthBar.fillAmount;
		float healthFraction = health / maxHealth;
		if(fillBack > healthFraction)
		{
			frontHealthBar.fillAmount = healthFraction;
			lerpTimer += Time.deltaTime;
			float percentComplete = lerpTimer / chipSpeed;
			percentComplete = percentComplete * percentComplete;
			backHealthBar.fillAmount = Mathf.Lerp(fillBack, healthFraction, percentComplete);
		}
		if(fillFront < healthFraction)
		{
			backHealthBar.fillAmount = healthFraction;
			lerpTimer += Time.deltaTime;
			float percentComplete = lerpTimer / chipSpeed;
			percentComplete = percentComplete * percentComplete;
			frontHealthBar.fillAmount = Mathf.Lerp(fillFront, backHealthBar.fillAmount, percentComplete);
		}
    }

    //reduces players health
    public void TakeDamage(float damage)
    {
		health -= damage;
		lerpTimer = 0f;
		if(health <= 0)
		{
			PlayerDead();
			isDead = true;
		}
    }

    //increases players health
    public void RestoreHealth(float healAmount)
    {
		health += healAmount;
		lerpTimer = 0f;
	}

    //triggers the endscreen sequence, disables onfoot action map, enables dead action map
    public void PlayerDead()
    {
		GetComponent<Endscreen>().StartFade();	
		StartCoroutine(ShowGameOverUI());
		inputManager.DeadOnEnable();
		inputManager.OnFootOnDisable();
    }

    //shows game over text
    private IEnumerator ShowGameOverUI()
    {
		yield return new WaitForSeconds(2f);
		gameOverUI.gameObject.SetActive(true);
		killCount.gameObject.SetActive(true);
		killCount.text = $"Kill Count: {killCounterScript.killCounter}";
    }
}

