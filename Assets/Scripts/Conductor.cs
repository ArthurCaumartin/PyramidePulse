    using UnityEngine;
using UnityEngine.Events;

//* Source : https://www.gamedeveloper.com/audio/coding-to-the-beat---under-the-hood-of-a-rhythm-game-in-unity

//? Home : BPM = 117, Duration = 5:15
//? Rollo : BPM = 138
//? Boo! : BPM = 109

public class Conductor : MonoBehaviour
{
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

    void Awake()
    {
        instance = this;
        //! Durée en seconde entre les beats
        secPerBeat = 60 / songBpm;

        //! Temps en ?millisecondes? ou la song commence
        dspSongTime = (float)AudioSettings.dspTime;

        musicSource.Play();
    }

    void Update()
    {
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
}