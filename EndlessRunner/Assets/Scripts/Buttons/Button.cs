using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void buttonClick()
    {
        Debug.Log("Click");
        SceneManager.LoadScene("GamePlay");
    }
}
