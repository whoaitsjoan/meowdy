using UnityEngine;
using UnityEngine.EventSystems;

public class openOptions : MonoBehaviour
{
    public GameObject optionsScreen;
    public GameObject optionsFirstButton, optionsClosedButton;


    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionsFirstButton);

    }

    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionsClosedButton);
    }

}
