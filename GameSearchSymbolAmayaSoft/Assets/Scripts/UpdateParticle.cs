using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateParticle : MonoBehaviour
{
    private ParticleSystem _particle;

    private void Start()
    {
        _particle = gameObject.GetComponent<ParticleSystem>();
    }

    public void StartParticle()
    {
        _particle.Play();
        
    }


    public void StopParticle()
    {
        _particle.gameObject.SetActive(false);
        _particle.gameObject.SetActive(true);
    }

}
