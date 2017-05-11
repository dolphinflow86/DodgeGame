using UnityEngine;
using UnityEngine.UI;

public class SoundOnOff : MonoBehaviour {

    private bool soundOn;
    private Image img;

    public Sprite soundOnSprite;
    public Sprite soundOffSprite;

    private void Start()
    {
        img = GetComponent<Image>();
    }

    private void OnEnable()
    {
        if (soundOn)
        {
            img.sprite = soundOnSprite;
            AudioListener.pause = false;
        }
        else
        {
            img.sprite = soundOffSprite;
            AudioListener.pause = true;
        }
    }

    public void SoundToggle()
    {
        soundOn =! soundOn;
        if(soundOn)
        {
            img.sprite = soundOnSprite;
            AudioListener.pause = false;
        }
        else
        {
            img.sprite = soundOffSprite;
            AudioListener.pause = true;
        }
    }

}
