using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToStartLogic : MonoBehaviour
{
    [SerializeField] private GameObject[] _allInterfaceElement;

    public void OnClickStart()
    {
        for(int i = 0; i <= (_allInterfaceElement.Length - 1); i++)
        {
            _allInterfaceElement[i].SetActive(true);
        }

        gameObject.SetActive(false);
    }
}
