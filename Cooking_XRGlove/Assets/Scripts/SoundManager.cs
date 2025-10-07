using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class SoundManager : MonoBehaviour {
    [SerializeField] private AudioClipRefsSO audioClipRefsSO;

    private Dictionary<int, AudioSource> loopAudioSources;

    private void Awake() {
        loopAudioSources = new Dictionary<int, AudioSource>();
    }

    private void Start() {
        Stove.OnAnyStateChanged += Stove_OnAnyStateChanged;
        SnapInteractorDropNotifier.Instance.OnAnyDrop += SnapInteractorDropNotifier_OnAnyDrop;
        Knife.Instance.OnAnyCut += Knife_OnAnyCut;
    }

    private void Knife_OnAnyCut(object sender, Knife.OnAnyCutEventArgs e) {
        PlayAudioClip(audioClipRefsSO.chop, e.position);
    }

    private void SnapInteractorDropNotifier_OnAnyDrop(object sender, SnapInteractorDropNotifier.OnAnyDropEventArgs e) {
        PlayAudioClip(audioClipRefsSO.objectDrop, e.position);
    } 

    private void Stove_OnAnyStateChanged(object sender, Stove.OnStateChangedEvnetArgs e) {
        Stove stove = sender as Stove;
        int instanceID = stove.GetInstanceID();

        if (e.state == Stove.State.Idle) {
            StopLoop(instanceID);
        }
        else if (e.state == Stove.State.Frying) {
            StartLoop(instanceID, stove.transform.position, audioClipRefsSO.stoveSizzle);
        }
    }

    private void StartLoop(int instanceID, Vector3 position, AudioClip audioClip) {
        GameObject obj = new GameObject($"LoopAudio_{instanceID}");
        obj.transform.position = position;

        AudioSource audioSource = obj.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.loop = true;
        audioSource.Play();

        loopAudioSources.Add(instanceID, audioSource);
    }

    private void StopLoop(int instanceID) {
        if (loopAudioSources.TryGetValue(instanceID, out AudioSource audioSource)) {
            audioSource.Stop();
            Destroy(audioSource.gameObject);

            loopAudioSources.Remove(instanceID);
        }
    }

    public void PlayAudioClip(AudioClip audioClip, Vector3 position) {
        AudioSource.PlayClipAtPoint(audioClip, position);
    }

    public void PlayAudioClip(AudioClip[] audioClips, Vector3 position) {
        PlayAudioClip(audioClips[Random.Range(0, audioClips.Length)], position);
    }
}
