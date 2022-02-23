using UnityEngine;
public class SpawnManager : MonoBehaviour
{   
    private RoadSpawner roadSpawner;  
    public int road;
    void Start()
    {
        roadSpawner = GetComponent<RoadSpawner>();
       
    }

    public void RoadSpawnTrigger()
    {
        roadSpawner.SpawnNewRoad(road);
        
    }

}
