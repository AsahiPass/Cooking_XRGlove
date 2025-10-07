using System;
using UnityEngine;
using static Oculus.Interaction.Context;

public class Knife : MonoBehaviour {
    public event EventHandler<OnAnyCutEventArgs> OnAnyCut;
    public class OnAnyCutEventArgs : EventArgs {
        public Vector3 position;
    }

    public static Knife Instance;

    private float lastCutTime;
    private float cutCooldown = 0.2f;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        }
        else {
            Instance = this;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (Time.time - lastCutTime < cutCooldown)
            return;
        lastCutTime = Time.time;

        Cuttable cuttable = other.GetComponentInParent<Cuttable>();
        if (cuttable != null) {
            cuttable.Cut();

            OnAnyCut?.Invoke(this, new OnAnyCutEventArgs {
                position = other.transform.position
            });
        }
    }
}
