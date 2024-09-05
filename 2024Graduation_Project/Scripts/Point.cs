using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Point : MonoBehaviour
{
    [SerializeField] int point;
    [SerializeField] TextMeshPro display;
    [SerializeField] ParticleSystem pointParticle;

    Bank bank;
    void Start()
    {
        bank = FindAnyObjectByType<Bank>();
        point = Random.Range(1, 5) * 100;
    }

    void Update()
    {
        
        UpdateDisplay();
    }
   //void OnTriggerEnter(Collider other)
   //{
   //    Ball ball = other.gameObject.GetComponent<Ball>();
   //    if (ball != null)
   //    {
   //        ball.PointScaling();
   //    }
   //    if (bank != null)
   //    {
   //        bank.Deposit(point);
   //    }
   //    Destroy(this.gameObject);
   //}

    public void GetPoint()
    {
        if (bank != null)
        {
            bank.Deposit(point);
        }

        if (pointParticle != null)
        {
            ParticleSystem instantiateParticle = Instantiate(pointParticle, transform.position, transform.rotation);

            instantiateParticle.Play();

            float lifetime = 1f;
            Destroy(instantiateParticle.gameObject, lifetime);
        }
        Destroy(this.gameObject);
    }

    void UpdateDisplay()
    {
        display.text = "+" + point;
    }
}
