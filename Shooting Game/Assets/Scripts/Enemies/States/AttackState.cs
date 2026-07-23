using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    private float moveTimer;
    private float losePlayerTimer;

    private float shotTimer;

    public override void Enter()
    {
    }

	//if the enemy can see the player, shoots the player with a cooldown and moves randomly every 1-2 seconds
	//if the enemy loses the player for more than 6 seconds swaps back to the patrol state
    public override void Perform()
    {
		if(enemy.CanSeePlayer())
		{
			losePlayerTimer = 0;
			moveTimer += Time.deltaTime;
			shotTimer += Time.deltaTime;
			enemy.transform.LookAt(enemy.Player.transform);
			if(shotTimer > enemy.fireRate)
			{
				EnemyShoot();
			}
			if(moveTimer > Random.Range(1, 3))
			{
				enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
				moveTimer = 0;
			}
		}
		else
		{
			losePlayerTimer += Time.deltaTime;
			if(losePlayerTimer > 6)
			{
				stateMachine.ChangeState(new PatrolState());
			}
		}
    }

    public override void Exit()
    {
    }

	//spawns the bullet prefab at the enemy's gun barrel location and shoots it towards the player
    public void EnemyShoot()
    {
		Transform gunbarrel = enemy.gunBarrel;
		GameObject enemyBullet = GameObject.Instantiate(Resources.Load("Prefabs/EnemyBullet") as GameObject, gunbarrel.position, enemy.transform.rotation);
		Vector3 shootDirection = (enemy.Player.transform.position - gunbarrel.transform.position).normalized;
		enemyBullet.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(3, Vector3.up) * shootDirection * 40;
		shotTimer = 0;

    }
}
