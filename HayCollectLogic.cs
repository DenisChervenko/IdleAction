using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayCollectLogic : MonoBehaviour
{
    [SerializeField] private GameObject _dropAfterDestroy;
    [SerializeField] private float _collectSpeed;
    private Transform _pointForMove;

    static public bool _canTakeMoreHay = true;
    private bool _alreadyPicked = false;

    HayDestroy hayDestroy;
    HayWasCollected hayWasCollected;

    private void Start()
    {
        hayDestroy = gameObject.GetComponent<HayDestroy>();

        hayWasCollected = GameObject.Find("Hay").GetComponent<HayWasCollected>();
        _pointForMove = GameObject.Find("PointForMove").transform;
    }

    private void Update()
    {
        if(_canTakeMoreHay)
        {
            if(hayDestroy._hayWasDestroyed)
            {
                if(Vector3.Distance(_dropAfterDestroy.transform.position, _pointForMove.transform.position) < 0.2f)
                {
                    if(!_alreadyPicked)
                    {
                        hayWasCollected.IncreaseHayValue();

                        _dropAfterDestroy.SetActive(false);
                        _alreadyPicked = true;
                    }
                }

                _dropAfterDestroy.transform.position = Vector3.MoveTowards(_dropAfterDestroy.transform.position, _pointForMove.position, _collectSpeed);
            }
        }
    }

    public void CollectHay()
    {
        if(_canTakeMoreHay)
        {
            _alreadyPicked = false;
            _dropAfterDestroy.SetActive(true);
        }
    }

    public void RestorHayPosition()
    {
        _dropAfterDestroy.transform.localPosition = Vector3.zero;
    }
}
