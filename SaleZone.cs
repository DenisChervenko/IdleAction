using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaleZone : MonoBehaviour
{
    [SerializeField] private int _countHayForIncreaseBalance;
    [SerializeField] private int _rewardForHay;

    private int _hayWasSaleForOneTime;

    HayWasCollected hayWasCollected;
    PlayerBalance playerBalance;
    ParticleControll particleControll;

    private void Start()
    {
        particleControll = GameObject.Find("ParticleController").GetComponent<ParticleControll>();
        playerBalance = GameObject.Find("BalancePlayer").GetComponent<PlayerBalance>();
        hayWasCollected = GameObject.Find("Hay").GetComponent<HayWasCollected>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            IncreaseBalance();
        }
    }

    private void IncreaseBalance()
    {
        if(hayWasCollected._countHayWasVisualise >= _countHayForIncreaseBalance)
        {
            for(int i = 1; i <= hayWasCollected._countHayWasVisualise; i++)
            {
                
                if(i % _countHayForIncreaseBalance == 0.0f)
                {
                    PlayerBalance._playerBalance += _rewardForHay;
                    playerBalance.GetReward();
                }
            }

            hayWasCollected.ResetCollectedHay();
            particleControll.DisableShop();
        }
    }
}
