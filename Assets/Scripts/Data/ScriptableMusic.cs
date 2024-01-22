using UnityEngine;

[CreateAssetMenu(menuName = "MusicAsset")]
public class ScriptableMusic : ScriptableObject
{
    public AudioClip music;
    public float BPM;
}
