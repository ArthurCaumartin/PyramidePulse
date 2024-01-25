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
    public float secPerBeat;
    public float songPositionInSecond;
    public float songPositionInBeats;
    public float dspSongTime;
    public float dpsPauseDelay;
    public float startPauseDps;

    [Header("Loop :")]
    [SerializeField] float beatsPerLoop;
    public int completedLoops = 0;
    public float loopPositionInBeats;
    [SerializeField] AudioSource audioSource;
    public UnityEvent<float> OnBoucleCompleted;
    public bool canPlay = true;

    public void Initialize(int indexOfTheMusic)
    {
        audioSource = GetComponentInChildren<AudioSource>();
        audioSource.Stop();
        audioSource.clip = musicList[indexOfTheMusic].music;
        songBpm = musicList[indexOfTheMusic].BPM;

        //! Durée en seconde entre les beats
        secPerBeat = 60 / songBpm;

        //! Temps en ?millisecondes? ou la song commence
        dspSongTime = (float)AudioSettings.dspTime;
        dpsPauseDelay = 0;
        //print(AudioSettings.dspTime);

        audioSource.Play();
    }

    void Awake()
    {
        instance = this;

        Initialize(0);
    }

    void Update()
    {
        if(!canPlay)
            return;
        // print(AudioSettings.dspTime);
        //! determine how many seconds since the song started
        songPositionInSecond = (float)AudioSettings.dspTime - dspSongTime - dpsPauseDelay;

        //! determine how many beats since the song started
        songPositionInBeats = songPositionInSecond / secPerBeat;

        //* Compare la position du song par rapport au rythme demander pour la boucle
        if(songPositionInBeats >= (completedLoops + 1) * beatsPerLoop)
        {
            completedLoops++;
            //! renvoie 1 ou 2
            // OnBoucleCompleted.Invoke((int)songPositionInBeats % 2);

            OnBoucleCompleted.Invoke(secPerBeat);
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
        {
            startPauseDps = (float)AudioSettings.dspTime;
            audioSource.Pause();
        }
        else
        {
            dpsPauseDelay = (float)AudioSettings.dspTime - startPauseDps;
            Debug.Log(dpsPauseDelay);
            audioSource.UnPause();
        }
    }
}