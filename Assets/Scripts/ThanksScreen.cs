using UnityEngine;
using UnityEngine.UI;

public class ThanksScreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Button thanks;
    public Button start;
    public Button X;
    public GameObject thanksScreen;
    public bool thanksActive;
    void Start()
    {
        thanksActive = false;
        thanksScreen.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void ThanksUp()
    {
        thanksActive=true;
        thanksScreen.SetActive(true);
        thanks.interactable = false;
        start.interactable = false;
        X.interactable = true;
    }

    public void ThanksDown() 
    { 
        thanksActive=false;
        X.interactable = false;
        thanksScreen.SetActive(false);
        thanks.interactable = true;
        start.interactable = true;
        
    
    }
}
