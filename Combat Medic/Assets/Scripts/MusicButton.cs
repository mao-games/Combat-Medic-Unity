using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    [SerializeField]
    private Sprite MusicOn;

    [SerializeField]
    private Sprite MusicOff;

    [SerializeField]
    private Sprite SoundOn;

    [SerializeField]
    private Sprite SoundOff;

    [SerializeField]
    private Button Sound;

    [SerializeField]
    private Button Music;

    public void MusicChange()
    {
        if(Music.image.sprite == MusicOn)
        {
            Music.image.sprite = MusicOff;
        }
        else
        {
            Music.image.sprite = MusicOn;
        }
    }
    public void SoundChange()
    {
        if (Sound.image.sprite == SoundOn)
        {
            Sound.image.sprite = SoundOff;
        }
        else
        {
            Sound.image.sprite = SoundOn;
        }
    }
}
