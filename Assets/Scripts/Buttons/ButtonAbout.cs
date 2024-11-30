using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAbout : MonoBehaviour
{
    public void OnAboutButtonClicked()
    {
        Debug.Log("About button clicked!");
        SceneManager.LoadScene("AboutScene");
    }
}
