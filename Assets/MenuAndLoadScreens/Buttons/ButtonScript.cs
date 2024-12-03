using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void OnPlayButtonClicked()
    {
        Debug.Log("Play button clicked!");
        SceneManager.LoadScene(2);
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
}
