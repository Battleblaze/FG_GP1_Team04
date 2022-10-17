using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptionsMenu : MonoBehaviour
{

    [SerializeField] private GameObject activeButton;
    private EventSystem eventSystem;

    void OnEnable()
    {
        this.eventSystem = EventSystem.current;

        this.eventSystem.SetSelectedGameObject(this.activeButton);
    }
}
