using TMPro;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public TextMeshProUGUI cashCount;
    public TextMeshProUGUI finalCount;

    public GameObject fish1, fish2, fish3, fish4;
    private int fishCollected;

    void Start()
    {
        fishCollected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCash()
    {
        
    }
    public void FinalScore()
    {
        int.TryParse(cashCount.text, out int finalScore);
        finalCount.text = "Final Count: " + finalScore;
    }
}
