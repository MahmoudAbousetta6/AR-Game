using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CoronaDeathHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem coronaParticle;

    public void CoronaDeath()
    {
        Instantiate(coronaParticle, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}