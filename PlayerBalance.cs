using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBalance : MonoBehaviour
{
    [SerializeField] private TMP_Text _balancePlayerText;
    static public int _playerBalance;

    ParticleControll particleControll;

    private void Start()
    {
        particleControll = GameObject.Find("ParticleController").GetComponent<ParticleControll>();
    }

    public void GetReward()
    {
        _balancePlayerText.text = Convert.ToString(_playerBalance);
        HayCollectLogic._canTakeMoreHay = true;

        if(_playerBalance >= 20)
        {
            if(UpgradeZone._canUpdateMore)
            {
                particleControll.ActiveUpgrade();
            }
        }
        else
        {
            particleControll.DisableUpgrade();
        }
    }

    public void UpdateBalance()
    {
        _balancePlayerText.text = Convert.ToString(_playerBalance);
    }
}
