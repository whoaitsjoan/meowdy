using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LifeControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Life1;
    public GameObject Life2;
    public GameObject Life3;
    public Sprite LifeFull;
    public Sprite LifeGone;
    public bool strike1;
    public bool strike2;
    public bool strike3;
    public List<GameObject> lives = new List<GameObject>();
    public SpriteRenderer SP1;
    public SpriteRenderer SP2;
    public SpriteRenderer SP3;
    public int livesLeft = 3;
    void Start()
    {
       
        strike1 = false;
        strike2 = false;
        strike3 = false;
        lives.Add(Life1);
        lives.Add(Life2);
        lives.Add(Life3);
        SP1 = Life1.GetComponent<SpriteRenderer>();
        SP2 = Life2.GetComponent<SpriteRenderer>();
        SP3 = Life3.GetComponent<SpriteRenderer>();
        for (int i = 0; i < lives.Count; i++)
        {
            lives[i].GetComponent<SpriteRenderer>().sprite = LifeFull;
            lives[i].SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (strike1)
        {
            SP1.sprite = LifeGone;
            SP1.color = new Color(0.75f, 0.5f, 0.5f, 0.75f);
            livesLeft--;
        }
        if (strike2)
        {
            SP2.sprite = LifeGone;
            SP2.color = new Color(0.75f, 0.5f, 0.5f, 0.75f);
            livesLeft--;
        }
        if (strike3)
        {
            SP3.sprite = LifeGone;
            SP3.color = new Color(0.75f, 0.5f, 0.5f, 0.75f);
            livesLeft--;
        }
        if(livesLeft == 0)
        {
            Debug.Log("You lost!");
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
            lives[i].GetComponent<SpriteRenderer>().sprite = LifeFull;
            lives[i].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            lives[i].SetActive(true);
           
        }
    }
}
