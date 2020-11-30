using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private int numberOfCorona;
    [SerializeField] private float instantiateDuration;
    [SerializeField] private GameObject coronaPrefab;
    [HideInInspector] public Transform startPoint;
    [HideInInspector] public Transform endPoint;
    [HideInInspector] public List<CoronaDeathHandler> instantiatedCorona;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public void ShowCorona()
    {
        StartCoroutine(CoronaInstantation());
    }

    private IEnumerator CoronaInstantation()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < numberOfCorona; i++)
        {
            CoronaDeathHandler coronaObject = Instantiate(coronaPrefab, new Vector3(Random.Range(startPoint.position.x, endPoint.position.x), endPoint.position.y, Random.Range(startPoint.position.z, endPoint.position.z)), Quaternion.identity).GetComponent<CoronaDeathHandler>();
            instantiatedCorona.Add(coronaObject);
            yield return new WaitForSeconds(instantiateDuration);
        }
    }
}