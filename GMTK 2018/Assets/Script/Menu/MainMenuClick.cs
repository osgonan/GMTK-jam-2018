using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuClick : MonoBehaviour
{

    public Button yourButton;
    public Button yourButton2;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        Button btn2 = yourButton2.GetComponent<Button>();
        btn2.onClick.AddListener(QuitGame);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
    void QuitGame()
    {
        Application.Quit();
    }
}
