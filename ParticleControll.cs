using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControll : MonoBehaviour
{
    [SerializeField] private GameObject _shop;
    [SerializeField] private GameObject _upgrade;

    public void ActiveShop()
    {
        _shop.SetActive(true);
    }
    public void DisableShop()
    {
        _shop.SetActive(false);
    }

    public void ActiveUpgrade()
    {
        _upgrade.SetActive(true);
    }
    public void DisableUpgrade()
    {
        _upgrade.SetActive(false);
    }
}
