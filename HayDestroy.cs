using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayDestroy : MonoBehaviour
{
    [SerializeField] private GameObject _dropAfterDestroy;
    [SerializeField] private GameObject _hay;
    [SerializeField] private float _timeBetwenSpawn;
    private float _elapsedTime;

    private Collider _collider;

    public bool _hayWasDestroyed = false;

    HayCollectLogic hayCollectLogic;

    private void Start()
    {
        _collider = gameObject.GetComponent<BoxCollider>();
        hayCollectLogic = gameObject.GetComponent<HayCollectLogic>();
    }

    private void FixedUpdate()
    {
        if(_hayWasDestroyed)
        {
            _elapsedTime += Time.fixedDeltaTime;

            if(_elapsedTime >= _timeBetwenSpawn)
            {
                RestartLifeHay();
                _elapsedTime = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Silo"))
        {
            DestroyHay();
        }
    }

    //DRY was say goodbye
    private void DestroyHay()
    {
        _hayWasDestroyed = true;

        _hay.SetActive(false);
        _collider.enabled = false;

        hayCollectLogic.CollectHay();
    }

    private void RestartLifeHay()
    {
        _hayWasDestroyed = false;

        _hay.SetActive(true);
        _dropAfterDestroy.SetActive(false);
        _collider.enabled = true;

        hayCollectLogic.RestorHayPosition();
    }
}
