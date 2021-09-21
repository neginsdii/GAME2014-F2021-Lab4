using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackButtonBehavour : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnBackButtonPressed()
    {
        SceneManager.LoadScene("Start");
    }
}
