using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public InputField Name;
    [SerializeField] Button startButton;
    public static string PlayerName;


    void Update()
    {
        if (string.IsNullOrEmpty(Name.text))
        {
            startButton.gameObject.SetActive(false);
        }
        else
            startButton.gameObject.SetActive(true);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
        PlayerName = Name.text;
    }
}
