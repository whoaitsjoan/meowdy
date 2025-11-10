using UnityEngine;
using UnityEngine.EventSystems;

public class UISoundTrigger : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [Header("Interaction Types")]
        [SerializeField] private InteractionSoundType soundType = InteractionSoundType.Unspecified;
        [SerializeField] private InteractionSoundOn playType = InteractionSoundOn.PointerDown;

    [Header("UI Sound Manager")]
    [SerializeField] private UIInteractionSoundsManager soundManager;

    private void Reset() { soundManager = FindFirstObjectByType<UIInteractionSoundsManager>();  }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (soundManager = null)
            Debug.LogError("UI Sound Manager has not been set.", this);

    }

    public void PlaySound() { soundManager.PlaySound(soundType, this); }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (playType == InteractionSoundOn.PointerDown && soundManager != null)
            soundManager.PlaySound(soundType, this);
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        if (playType == InteractionSoundOn.PointerUp && soundManager != null)
        {
            soundManager.PlaySound(soundType, this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
