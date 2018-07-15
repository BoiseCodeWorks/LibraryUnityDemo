using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public GameObject MainEnemyGoal;
    public List<GameObject> MinorEnemyGoals;
    GameObject currentTarget;


	public GameObject GetTarget()
    {
        return currentTarget;
    }

    private void Update()
    {
        /**
         * if there is any goal still alive in minor goals 
         * send the current minor goal 
         * otherwise send the main goal
         */
        if (MainEnemyGoal == null)
        {
            Debug.Log("GAME OVER");
            return;
        }

         if(currentTarget == null)
        {
            if(MinorEnemyGoals.Count > 0)
            {
                currentTarget = MinorEnemyGoals[0];
                MinorEnemyGoals.Remove(currentTarget);
            }else
            {
                currentTarget = MainEnemyGoal;
            }
        }

    }



}
