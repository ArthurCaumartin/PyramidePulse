using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//* Source : https://www.gamedeveloper.com/audio/coding-to-the-beat---under-the-hood-of-a-rhythm-game-in-unity

//? Home : BPM = 117, Duration = 5:15
//? Rollo : BPM = 138
//? Boo! : BPM = 109

public class Conductor : MonoBehaviour
{
    public List<ScriptableMusic> musicList;
    public static Conductor instance;
    [Header("Song Infos :")]
    [SerializeField] float songBpm;
    float secPerBeat;
    float songPositionInSecond;
    float songPositionInBeats;
    float dspSongTime;

    [Header("Loop :")]
    [SerializeField] float beatsPerLoop;
    int completedLoops = 0;
    float loopPositionInBeats;
    [SerializeField] AudioSource musicSource;
    public UnityEvent OnBoucleCompleted;
    private bool canPlay = true;

    void Awake()
    {
        instance = this;
        musicSource.clip = musicList[0].music;
        songBpm = musicList[0].BPM;
        //! Durée en seconde entre les beats
        secPerBeat = 60 / songBpm;

        //! Temps en ?millisecondes? ou la song commence
        dspSongTime = (float)AudioSettings.dspTime;

        musicSource.Play();
    }

    void Update()
    {
        if(!canPlay)
            return;

        print(AudioSettings.dspTime);
        //! determine how many seconds since the song started
        songPositionInSecond = (float)(AudioSettings.dspTime - dspSongTime);

        //! determine how many beats since the song started
        songPositionInBeats = songPositionInSecond / secPerBeat;

        //* Compare la position du song par rapport au rythme demander pour la boucle
        if(songPositionInBeats >= (completedLoops + 1) * beatsPerLoop)
        {
            completedLoops++;
            //! renvoie 1 ou 2
            // OnBoucleCompleted.Invoke((int)songPositionInBeats % 2);
            OnBoucleCompleted.Invoke();
            //print("loop beat");
        }

        loopPositionInBeats = songPositionInBeats - completedLoops * beatsPerLoop;
    }

    public float GetLoopPositionInBeats()
    {
        return loopPositionInBeats;
    }

    public float GetSecondPerBeat()
    {
        return secPerBeat;
    }

    public void Pause(bool value)
    {
        canPlay = !value;

        if(value)
            musicSource.Pause();
        else
            musicSource.UnPause();
    }
}