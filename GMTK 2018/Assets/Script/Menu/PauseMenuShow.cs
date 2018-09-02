using UnityEngine;
using System.Collections;

public class PauseMenuShow : MonoBehaviour
{

    public GameObject menu; // Assign in inspector
    private bool isShowing;

    void Start()
    {
        menu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            isShowing = !isShowing;
            menu.SetActive(isShowing);
        }
    }
}