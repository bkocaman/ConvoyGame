using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class RoadSpawner : MonoBehaviour
{
    public List<GameObject> roads;
    public GameObject roadsParent;
    public float offSet = 20f;

    public GameObject roadHorizontal;

    public GameObject spawnNewRoad;
    void Start()
    {
        if (roads != null && roads.Count > 0)
        {
            roads = roads.OrderBy(r => r.transform.position.z).ToList();
        }
       
    }

    public void SpawnNewRoad(int road)
    { 
            if (road == 0)
            {
                spawnNewRoad = Instantiate(roadHorizontal, transform.position, new Quaternion(0, 0, 0, 0));
                float newZ = roads[roads.Count - 1].transform.position.z + offSet;
                spawnNewRoad.transform.position = spawnNewRoad.transform.forward * newZ;
                spawnNewRoad.transform.position += spawnNewRoad.transform.up * roads[roads.Count - 1].transform.position.y;

            }

            spawnNewRoad.transform.parent = roadsParent.transform;
            roads.Add(spawnNewRoad);
        }
    }
 