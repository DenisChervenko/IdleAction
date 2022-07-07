using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeZone : MonoBehaviour
{
    [SerializeField] private GameObject[] _upgradeMesh;
    [SerializeField] private GameObject[] _wheels;

    [SerializeField] private int[] _updatePrice;

    private int _currentUpdateIndex;
    static public bool _canUpdateMore = true;

    TraktorControll traktorControll;
    PlayerBalance playerBalance;
    ParticleControll particleControll;

    private void Start()
    {
        particleControll = GameObject.Find("ParticleController").GetComponent<ParticleControll>();
        playerBalance = GameObject.Find("BalancePlayer").GetComponent<PlayerBalance>();
        traktorControll = GameObject.Find("Player").GetComponent<TraktorControll>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            UpgradePlayer();
        }
    }

    private void UpgradePlayer()
    {
        if(PlayerBalance._playerBalance >= _updatePrice[_currentUpdateIndex == 0 ? _currentUpdateIndex + 1 : _currentUpdateIndex])
        {
            if((_upgradeMesh.Length - 1) != _currentUpdateIndex)
            {
                _upgradeMesh[_currentUpdateIndex].SetActive(false);
                _wheels[_currentUpdateIndex].SetActive(false);

                _currentUpdateIndex++;

                _upgradeMesh[_currentUpdateIndex].SetActive(true);
                _wheels[_currentUpdateIndex].SetActive(true);

                traktorControll._speedMove += 10;
                traktorControll._speedRotate += 6;

                playerBalance.GetReward();
                PlayerBalance._playerBalance -= _updatePrice[_currentUpdateIndex];
                particleControll.DisableUpgrade();

                _canUpdateMore = false;
                playerBalance.UpdateBalance();
            }
        }
    }
}
