using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenu : MonoBehaviour
{
    public void OnMenuButtonClicked()
    {
        Debug.Log("Menu button clicked!");
        SceneManager.LoadScene("MenuScene");
    }
}
