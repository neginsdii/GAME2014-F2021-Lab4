using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    private int nextSceneIndex;
    private int previousSceneIdex;
    void Start()
    {
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        previousSceneIdex = SceneManager.GetActiveScene().buildIndex - 1;
    }

    // Update is called once per frame
    public void OnNextButtonPressed()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }

    // BackButton Pressed event handler
    public void OnBackButtonPressed()
    {
        SceneManager.LoadScene(previousSceneIdex);
    }
}
