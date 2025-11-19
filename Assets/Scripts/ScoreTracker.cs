using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    public static ScoreTracker instance;
    public TextMeshProUGUI cashText;
    public TextMeshProUGUI finalCount;
    private int cashCount;
    public List<AudioClip> coinSound = new List<AudioClip>();
    public AudioSource coinSource;

    public Image fish1, fish2, fish3, fish4;
    public int fishCollected;
   
    void Start()
    {
        instance = this;
        cashCount = 0;
        fishCollected = 0;
        fish1.color = new Color(0.75f, 0.5f, 0.5f, 0.75f);
        fish2.color = new Color(0.75f, 0.5f, 0.5f, 0.75f);
        fish3.color = new Color(0.75f, 0.5f, 0.5f, 0.75f);
        fish4.color = new Color(0.75f, 0.5f, 0.5f, 0.75f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCash(StateManager state)
    {
        //only the cat lover gives more cash so we can check that first
        if(state.gameObject.name.Contains("CatLover"))
        cashCount += 80;
        //otherwise, give half that amount
        else
        cashCount += 40;
        //either way, the cash text gets updated accordingly
        cashText.text = "CASH: $" + cashCount;
        int rand = Random.Range(0, coinSound.Count);
        coinSource.clip = coinSound[rand];
        coinSource.Play();
    }

    public void AddFish()
    {
       fishCollected++; 

       if (fishCollected == 1)
        fish1.color = Color.white;
       else if (fishCollected == 2)
        fish2.color = Color.white;
       else if (fishCollected == 3)
        fish3.color = Color.white;
       else if (fishCollected == 4)
        fish4.color = Color.white;
        
    }
    public void FinalScore()
    {
        finalCount.text = "Final Count: $" + cashCount;
    }
}
