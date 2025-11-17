using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeControl : MonoBehaviour
{
    
    public GameObject Life1, Life2, Life3;
    public Sprite LifeFull;
    public Sprite LifeGone;
    private bool strike1, strike2, strike3;
    public List<GameObject> lives = new List<GameObject>();
    public Image LVisual1;
    public Image LVisual2;
    public Image LVisual3;
    [SerializeField]
    private int livesLeft = 3;
    void Start()
    {
       
        strike1 = false;
        strike2 = false;
        strike3 = false;
        lives.Add(Life1);
        lives.Add(Life2);
        lives.Add(Life3);
        LVisual1 = LVisual1.GetComponent<Image>();
        LVisual2 = LVisual2.GetComponent<Image>();
        LVisual3 = LVisual3.GetComponent<Image>();
        for (int i = 0; i < lives.Count; i++)
        {
            lives[i].GetComponent<Image>().sprite = LifeFull;
            lives[i].SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    public void LoseLife()
    {
        livesLeft--;
         if (livesLeft == 2)
        {
            strike1 = true;
            LVisual1.sprite = LifeGone;
            LVisual1.color = new Color(0.75f, 0.5f, 0.5f, 0.75f);
            livesLeft--;
        }
        if (livesLeft == 1)
        {
            strike2 = true;
            LVisual2.sprite = LifeGone;
            LVisual2.color = new Color(0.75f, 0.5f, 0.5f, 0.75f);
            livesLeft--;
        }
        if (livesLeft == 0)
        {
            strike3 = true;
            LVisual3.sprite = LifeGone;
            LVisual3.color = new Color(0.75f, 0.5f, 0.5f, 0.75f);
            livesLeft--;
        }
        if(strike1 && strike2 && strike3)
        {
            GameController.instance.GameOver();
        }
    }

    public void ResetLives()
    {
        strike1 = false;
        strike2 = false;
        strike3 = false;
        livesLeft = 3;
        for (int i = 0; i < lives.Count; i++)
        {
            lives[i].GetComponent<Image>().sprite = LifeFull;
            lives[i].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            lives[i].SetActive(true);
           
        }
    }
}
