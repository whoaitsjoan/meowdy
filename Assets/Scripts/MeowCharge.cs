
using UnityEngine;

public class MeowCharge : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer imageCharge;

    private bool isPowerUp = false;
    private bool isDirectionUp = true;
    public float chargePower = 0.0f;
    [SerializeField]
    private float powerSpeed = 100.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPowerUp)
            PowerActive();
    }

    void PowerActive()
    {
        if (isDirectionUp)
        {
            chargePower += Time.deltaTime * powerSpeed;
            if (chargePower >= 100)
            {
                isDirectionUp = false;
                chargePower = 100.0f;
            }
        }
        else
        {
            chargePower -= Time.deltaTime * powerSpeed;
            if(chargePower <= 0)
            {
                isDirectionUp = true;
                chargePower = 0.0f;
            }
        }
    }

    public void StartChargeUp()
    {
        isPowerUp = true;
        chargePower = 0.0f;
        isDirectionUp = true;
    }
    
    public void EndChargeUp()
    {
        isPowerUp = false;
    }
}
