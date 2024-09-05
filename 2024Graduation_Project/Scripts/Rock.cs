using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] int penalty = 500;
    [SerializeField] ParticleSystem bombParticle;

    Bank bank;
    void Start()
    {
        bank = FindAnyObjectByType<Bank>();
    }


    //void OnTriggerEnter(Collider other)
    //{
    //    Ball ball = other.gameObject.GetComponent<Ball>();
    //    if (ball != null)
    //    {
    //        ball.MinusScale();
    //    }
    //    if (bank != null)
    //    {
    //        bank.Withdraw(penalty);
    //    }
    //    Destroy(this.gameObject);
    //}
    public void PenaltyPoint()
    {
        if (bank != null)
        {
            bank.Withdraw(penalty);
        }

        if(bombParticle != null)
        {
            ParticleSystem instantiateParticle = Instantiate(bombParticle, transform.position, transform.rotation);

            instantiateParticle.Play();

            float lifetime = 1f;
            Destroy(instantiateParticle.gameObject, lifetime);
        }

        Destroy(this.gameObject);
    }
}
