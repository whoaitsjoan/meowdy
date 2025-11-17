using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class progressBar : MonoBehaviour
{

    // max progress amount (time, health, levels, etc)
    public float maxTime;
    // current progress made
    public float current;
    //referencing the image we will use to convey progress, likely an image that fills/ empties with progress made
    public Image bar;
    public UnityEvent timesUp;
    // create variable timeLeft
    public float timeLeft;


    void Start()
    {
      
    }
    void Update()
    {
        //Debug.Log(bar.fillAmount);
        // if updating per frame, get current fill here
        // can update per frame if using it as a timer

        current += Time.deltaTime;
        GetCurrentFill();

        
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0.1)
        {
            GameController.instance.GameOver();
        }
    }

    void GetCurrentFill()
    {
        float fillAmount = current / maxTime;
        bar.fillAmount = fillAmount;
    }

    
}
