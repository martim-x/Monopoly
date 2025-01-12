using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] GameObject StartTransition;
    public void OnPlayButtonClicked()
    {
        Debug.Log("Play button clicked!");
        StartTransition.SetActive(true);
        Invoke("GameStart", 1f);
    }
    public void OnMenuButtonClicked()
    {
        Debug.Log("Play button clicked!");
    }
    public void OnAboutButtonClicked()
    {
        Debug.Log("Play button clicked!");
    }
    public void OnExitButtonClicked()
    {
        Debug.Log("Exit button clicked!");
    }
    void GameStart()
    {
        SceneManager.LoadScene(2);
    }
}
