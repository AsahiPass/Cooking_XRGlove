using System;
using System.Collections;
using UnityEngine;

public class Stove : MonoBehaviour, IHasProgress {
    public event EventHandler<OnStateChangedEvnetArgs> OnStateChanged;
    public static event EventHandler<OnStateChangedEvnetArgs> OnAnyStateChanged;
    public class OnStateChangedEvnetArgs : EventArgs {
        public State state;
    }
    public event EventHandler<IHasProgress.OnProgressChangedEventArgs> OnProgressChanged;


    [SerializeField] public GameObject meatPattyCookedPrefab;
    [SerializeField] public Transform spawnPos;

    private State state;
    private float fryingTimer;
    private float fryingTimeMax = 2f;

    public enum State {
        Idle,
        Frying
    }

    public void StartFrying(GameObject meatPattyUncooked) {
        state = State.Frying;

        OnStateChanged?.Invoke(this, new OnStateChangedEvnetArgs {
            state = state
        });

        OnAnyStateChanged?.Invoke(this, new OnStateChangedEvnetArgs {
            state = state
        });

        fryingTimer = 0f;
        OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs {
            progressNormalized = fryingTimer / fryingTimeMax
        });

        StartCoroutine(FryCoroutine(meatPattyUncooked));
    }

    private IEnumerator FryCoroutine(GameObject meatPattyUncooked) {
        yield return new WaitForSeconds(fryingTimeMax);

        Destroy(meatPattyUncooked);
        Instantiate(meatPattyCookedPrefab, spawnPos.position, Quaternion.identity);

        state = State.Idle;

        OnStateChanged?.Invoke(this, new OnStateChangedEvnetArgs {
            state = state
        });

        OnAnyStateChanged?.Invoke(this, new OnStateChangedEvnetArgs {
            state = state
        });

        fryingTimer = 0f;
        OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs {
            progressNormalized = fryingTimer / fryingTimeMax
        });
    }

    private void Update() {
        if (state == State.Frying && fryingTimer < fryingTimeMax) { 
            fryingTimer += Time.deltaTime;
            OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs {
                progressNormalized = fryingTimer / fryingTimeMax
            });
        }
    }
}
