using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/AudioClipRefsSO")]
public class AudioClipRefsSO : ScriptableObject {
    public AudioClip[] chop;
    public AudioClip[] objectDrop;
    public AudioClip[] objectPickup;
    public AudioClip stoveSizzle;
    public AudioClip[] warning;
}
