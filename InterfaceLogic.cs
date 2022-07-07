using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfaceLogic : MonoBehaviour
{
    [SerializeField] private GameObject _continueButton;
    [SerializeField] private GameObject _homeButton;
    [SerializeField] private GameObject _pauseButton;

    public void OnClickPause()
    {
        _pauseButton.SetActive(false);
        _homeButton.SetActive(true);
        _continueButton.SetActive(true);

        Time.timeScale = 0;
    }

    public void OnClickHome()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void OnClickContinue()
    {
        Time.timeScale = 1;
        _pauseButton.SetActive(true);
        _homeButton.SetActive(false);
        _continueButton.SetActive(false);
    }
}
