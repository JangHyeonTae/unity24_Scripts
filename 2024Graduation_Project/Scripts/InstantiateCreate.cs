using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class InstantiateCreate : MonoBehaviour
{
    [SerializeField] GameObject rock;
    [SerializeField] GameObject rockSpawn;
    [SerializeField] GameObject point;
    [SerializeField] GameObject pointSpawn;
    [SerializeField] GameObject ball;
    [SerializeField] GameObject ballSpawn;
    private bool stopSpawn = false;

    public bool transPoint = false;
    
    void Start()
    {
        StartCoroutine(RockSpawnRoutine());
        StartCoroutine(PointSpawnRoutine());
        StartCoroutine(BallSpawnRoutine());
    }

    [PunRPC]
    IEnumerator RockSpawnRoutine()
    {
        while(stopSpawn == false)
        {
            Vector3 rockPosition = new Vector3(Random.Range(0, 80), 5, Random.Range(0, 80));
            GameObject rockContainer = PhotonNetwork.Instantiate("Rock", rockPosition, Quaternion.identity);
            rockContainer.transform.parent = rockSpawn.transform;
            yield return new WaitForSeconds(Random.Range(3f,5f));
        }
    }

    [PunRPC]
    IEnumerator PointSpawnRoutine()
    {
        while (stopSpawn == false)
        {
            
            Vector3 pointPosition = new Vector3(Random.Range(0, 80), 3, Random.Range(0, 80));
            GameObject pointContainer = PhotonNetwork.Instantiate("Point", pointPosition, Quaternion.identity);
            pointContainer.transform.parent = pointSpawn.transform;
            yield return new WaitForSeconds(Random.Range(4f,7f));
        }
    }

    [PunRPC]
    IEnumerator BallSpawnRoutine()
    {
        while(stopSpawn == false)
        {
            Vector3 ballPosition = new Vector3(Random.Range(3, 70), 3, Random.Range(3, 70));
            GameObject ballContainer = PhotonNetwork.Instantiate("Ball", ballPosition, Quaternion.identity);
            ballContainer.transform.parent = ballSpawn.transform;
            yield return new WaitForSeconds(Random.Range(3f, 10f));
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
