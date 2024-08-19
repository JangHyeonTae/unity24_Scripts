using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCreate : MonoBehaviour
{
    [SerializeField] GameObject rock;
    [SerializeField] GameObject rockSpawn;
    [SerializeField] GameObject point;
    [SerializeField] GameObject pointSpawn;
    private bool stopSpawn = false;

    
    void Start()
    {
        StartCoroutine(RockSpawnRoutine());
        StartCoroutine(PointSpawnRoutine());
    }


    IEnumerator RockSpawnRoutine()
    {
        while(stopSpawn == false)
        {
            Vector3 rockPosition = new Vector3(Random.Range(0, 80), 2, Random.Range(0, 80));
            GameObject rockContainer = Instantiate(rock, rockPosition, Quaternion.identity);
            rockContainer.transform.parent = rockSpawn.transform;
            yield return new WaitForSeconds(Random.Range(3f,5f));
        }
    }

    IEnumerator PointSpawnRoutine()
    {
        while (stopSpawn == false)
        {
            
            Vector3 pointPosition = new Vector3(Random.Range(0, 80), 2, Random.Range(0, 80));
            GameObject pointContainer = Instantiate(point, pointPosition, Quaternion.identity);
            pointContainer.transform.parent = pointSpawn.transform;
            yield return new WaitForSeconds(Random.Range(4f,7f));
        }
    }

    public void OnSpawnStop()
    {   
        stopSpawn = true;
    }

}
