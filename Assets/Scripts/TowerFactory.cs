using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform parent;
    
    Queue<Tower> towerQueue = new Queue<Tower>();

    int currentTowerNum = 0;

    public void AddTower(Waypoint baseWp)
    {
        if (currentTowerNum <= towerLimit)
        {
            currentTowerNum++;
            InstaniateNewTower(baseWp);
        }
        else
        {
            MoveExistingTower(baseWp);
        }
    }

    private void MoveExistingTower(Waypoint newBaseWp)
    {
        Tower oldTower = towerQueue.Dequeue();
        
        oldTower.baseWp.isPlacable = true;//free up block
        newBaseWp.isPlacable = false;

        oldTower.baseWp = newBaseWp;

        Vector3 towerPos = new Vector3(newBaseWp.transform.position.x, newBaseWp.transform.position.y + 10, newBaseWp.transform.position.z);
        oldTower.transform.position = towerPos;
        
        towerQueue.Enqueue(oldTower);
    }

    private void InstaniateNewTower(Waypoint baseWp)
    {
        Vector3 towerPos = new Vector3(baseWp.transform.position.x, baseWp.transform.position.y + 10, baseWp.transform.position.z);
        Tower newTower = Instantiate(towerPrefab, towerPos, Quaternion.identity);
        newTower.transform.parent = parent;
        baseWp.isPlacable = false;

        newTower.baseWp = baseWp;
        baseWp.isPlacable = false;

        towerQueue.Enqueue(newTower);
    }

    public void DestroyT(Tower tower)
    {
        tower= towerQueue.Dequeue();
        currentTowerNum--;
    }
}
