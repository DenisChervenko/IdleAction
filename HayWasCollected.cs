using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HayWasCollected : MonoBehaviour
{
    [SerializeField] private TMP_Text _hayValueText;
    [SerializeField] private TMP_Text _maxValueForHay;
    [SerializeField] private int _countHayBeforIncrementHayValueText;
    private int _countCollectedHay;

    static public int _maxCountForCollectHay = 40;
    
    public int _countHayWasVisualise;

    ParticleControll particleControll;

    private void Start()
    {
        particleControll = GameObject.Find("ParticleController").GetComponent<ParticleControll>();
        _maxValueForHay.text = Convert.ToString(_maxCountForCollectHay);
    }
    

    public void IncreaseHayValue()
    {
        _countCollectedHay++;

        if(_countCollectedHay == _countHayBeforIncrementHayValueText)
        {
            _countHayWasVisualise++;
            _hayValueText.text = Convert.ToString(_countHayWasVisualise);

            if(_countHayWasVisualise >= _countHayBeforIncrementHayValueText)
            {
                particleControll.ActiveShop();
            }

            if(_countHayWasVisualise >= _maxCountForCollectHay)
            {
                _countHayWasVisualise = _maxCountForCollectHay;
                _hayValueText.text = Convert.ToString(_countHayWasVisualise);

                HayCollectLogic._canTakeMoreHay = false;
            }

            _countCollectedHay = 0;
        }
    }

    public void ResetCollectedHay()
    {
        _countCollectedHay = 0;
        _countHayWasVisualise = 0;
        _hayValueText.text = Convert.ToString(_countHayWasVisualise);
    }
}
