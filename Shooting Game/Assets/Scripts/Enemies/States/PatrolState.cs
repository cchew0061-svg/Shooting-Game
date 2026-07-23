using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    public int waypointIndex;
    public float waitTimer;

    public override void Enter()
    {
    }

    //if the player is seen by the enemy, changes the state to the attack state
    public override void Perform()
    {
		PatrolCycle();
		if(enemy.CanSeePlayer())
		{
			stateMachine.ChangeState(new AttackState());
		}
    }

    public override void Exit()
    {
    }

	//makes the enemy move from waypoint to waypoint with a 3 second pause
    public void PatrolCycle()
    {
		if(enemy.Agent.remainingDistance < 0.2)
		{
			waitTimer += Time.deltaTime;
			if(waitTimer > 3)
			{
				if(waypointIndex < enemy.enemyPath.waypoints.Count - 1)
				{
					waypointIndex++;
				}
				else
				{
					waypointIndex = 0;
				}
			enemy.Agent.SetDestination(enemy.enemyPath.waypoints[waypointIndex].position);
			waitTimer = 0;
			}
		}
    }
}
