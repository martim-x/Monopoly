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
    public void OnExitButtonClicked()
    {
        SceneManager.LoadScene(1);
    }
    void GameStart()
    {
        SceneManager.LoadScene(2);
    }
    public void TurnEnd()
    {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Player"))
        {
            item.GetComponent<PlayerScript>().isMyMove = false; 
            item.GetComponent<PlayerScript>().DoesDiceKnown = false;
        }
    }
    public void Confirm()
    {
        GameObject.FindGameObjectWithTag("Alert").SetActive(false);
    }
}
