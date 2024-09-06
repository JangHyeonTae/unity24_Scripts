using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCreate : MonoBehaviour
{
    [SerializeField] GameObject rock;
    [SerializeField] GameObject rockSpawn;
    [SerializeField] GameObject point;
    [SerializeField] GameObject pointSpawn;
    [SerializeField] GameObject win;
    [SerializeField] GameObject winSpawn;
    private bool stopSpawn = false;

    public bool transPoint = false;
    
    void Start()
    {
        StartCoroutine(RockSpawnRoutine());
        StartCoroutine(PointSpawnRoutine());
        StartCoroutine(WinSpawnRoutine());
    }


    IEnumerator RockSpawnRoutine()
    {
        while(stopSpawn == false)
        {
            Vector3 rockPosition = new Vector3(Random.Range(0, 80), 5, Random.Range(0, 80));
            GameObject rockContainer = Instantiate(rock, rockPosition, Quaternion.identity);
            rockContainer.transform.parent = rockSpawn.transform;
            yield return new WaitForSeconds(Random.Range(3f,5f));
        }
    }

    IEnumerator PointSpawnRoutine()
    {
        while (stopSpawn == false)
        {
            
            Vector3 pointPosition = new Vector3(Random.Range(0, 80), 3, Random.Range(0, 80));
            GameObject pointContainer = Instantiate(point, pointPosition, Quaternion.identity);
            pointContainer.transform.parent = pointSpawn.transform;
            yield return new WaitForSeconds(Random.Range(4f,7f));
        }
    }

    IEnumerator WinSpawnRoutine()
    {
        while(stopSpawn == false)
        {
            Vector3 winPosition = new Vector3(Random.Range(3, 70), 0, Random.Range(3, 70));
            GameObject winContainer = Instantiate(win, winPosition, Quaternion.identity);
            winContainer.transform.parent = winSpawn.transform;
            yield return new WaitForSeconds(Random.Range(8f, 20f));
        }
    }


    public void IsTransPoint()
    {
        transPoint = true;
    }
    public void OnSpawnStop()
    {   
        stopSpawn = true;
    }

}
