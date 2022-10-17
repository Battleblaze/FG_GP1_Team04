using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour

{
    [SerializeField] private GameObject firstSelected;
    private EventSystem eventSystem;

    void OnEnable()
    {
        this.eventSystem = EventSystem.current;

        this.eventSystem.SetSelectedGameObject(this.firstSelected);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

   public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }
}
