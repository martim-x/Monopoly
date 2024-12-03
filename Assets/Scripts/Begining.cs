using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Begining : MonoBehaviour
{
    public void OnCall()
    {
        SceneManager.LoadScene(1);
    }
    public void OtherCall()
    {
        Destroy(gameObject);
    }
}
