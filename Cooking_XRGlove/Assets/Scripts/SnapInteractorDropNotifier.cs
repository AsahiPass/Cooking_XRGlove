using System;
using UnityEngine;

public class SnapInteractorDropNotifier : MonoBehaviour {
    public event EventHandler<OnAnyDropEventArgs> OnAnyDrop;
    public class OnAnyDropEventArgs : EventArgs {
        public Vector3 position;
    }

    public static SnapInteractorDropNotifier Instance { get; private set; }

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        }
        else {
            Instance = this;
        }
    }

    public void NotifyDrop(Vector3 position) {
        OnAnyDrop?.Invoke(this, new OnAnyDropEventArgs {
            position = position
        });
    }
}
