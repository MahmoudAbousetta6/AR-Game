using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;


public class SterilliumTapping : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private ParticleSystem sterilliumParticle;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;

    private int deathRange = 5;
    private Collider sterilliumCollider;
    private PlayableDirector sterilliumTimeline;

    private void Awake()
    {
        sterilliumTimeline = GetComponent<PlayableDirector>();
        sterilliumCollider = GetComponent<Collider>();
    }
    private void Start()
    {
        GameManager.instance.startPoint = startPoint;
        GameManager.instance.endPoint = endPoint;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(PlaySterilliumTimeline());
    }

    private IEnumerator PlaySterilliumTimeline()
    {
        sterilliumTimeline.Play();
        sterilliumCollider.enabled = false;
        yield return new WaitForSeconds(0.6f);
        sterilliumParticle.Play();
        yield return new WaitForSeconds(1f);
        sterilliumParticle.Stop();
        sterilliumCollider.enabled = true;
        DestroyCorona();
    }

    
    private void DestroyCorona()
    {
        for (int i = 0; i < Mathf.Min(deathRange, GameManager.instance.instantiatedCorona.Count); i++)
        {
            GameManager.instance.instantiatedCorona[i].CoronaDeath();
            GameManager.instance.instantiatedCorona.RemoveAt(i);
        }
    }
}