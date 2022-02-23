using System.Collections.Generic;
using UnityEngine;
public class EnemyCarSpawn : MonoBehaviour
{
    public List<GameObject> enemyCarSpawn;
    public List<GameObject> cars;

    public float enemyCarSpeed = 5f;

    GameObject spawnedCar;
    int spawnPoint;

    UIManagerScript UIManagerScript;
    void Start()
    {
        UIManagerScript = GameObject.Find("Canvas").GetComponent<UIManagerScript>();
        if (UIManagerScript.isGameStarting)
        {
            foreach (Transform child in transform)
            {
                if (child.tag == "SpawnPoint")
                {
                    enemyCarSpawn.Add(child.gameObject);
                }
            }

            spawnPoint = chooseSpawner();
            int chooseCar = Random.Range(0, cars.Count);
            enemyCarSpeed = Random.Range(5, 20);

            spawnedCar = Instantiate(cars[chooseCar], enemyCarSpawn[spawnPoint].transform.position, new Quaternion(0, 180, 0, 0));
            Destroy(spawnedCar, 10f);
        }
    }

    private void Update()
    {
        spawnedCar.transform.Translate(new Vector3(0, 1, enemyCarSpeed) * Time.deltaTime);
    }

    int chooseSpawner()
    {
        float rand = Random.value;
        if (rand <= .9f) return Random.Range(0, enemyCarSpawn.Count - 1);
        return enemyCarSpawn.Count - 1;
    }
}
