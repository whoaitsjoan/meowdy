using System.Collections.Generic;
using UnityEngine;

public class FishMonger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject HeadAndHands;
    public SpriteRenderer HHimage;
    public SpriteRenderer Fimage;
    public GameObject Feet;
    public Color a = new Color(253, 229, 208, 1);
    public Color b = new Color(249, 210, 184, 1);
    public Color c = new Color(245, 192, 158, 1);
    public Color d = new Color(232, 171, 126, 1);
    public Color e = new Color(213, 148, 106, 1);
    public Color f = new Color(194, 126, 85, 1);
    public Color g = new Color(174, 102, 66, 1);
    public Color h = new Color(153, 96, 46, 1);
    public Color i = new Color(137, 83, 36, 1);
    public Color j = new Color(120, 70, 25, 1);
    public Color k = new Color(104, 59, 15, 1);
    public Color l = new Color(88, 49, 7, 1);
    public List<Color> skinTones = new List<Color>();
    void Start()
    {
        HHimage = HeadAndHands.GetComponent<SpriteRenderer>();
        Fimage = Feet.GetComponent<SpriteRenderer>();
        skinTones.Add(a);
        skinTones.Add(b);
        skinTones.Add(c);
        skinTones.Add(d);
        skinTones.Add(e);
        skinTones.Add(f);
        skinTones.Add(g);
        skinTones.Add(h);
        skinTones.Add(i);
        skinTones.Add(j);
        skinTones.Add(k);
        skinTones.Add(l);
        int rand = Random.Range(0, 11);
        HHimage.color = skinTones[rand];
        Color feetC = Random.ColorHSV();
        Fimage.color = feetC;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
