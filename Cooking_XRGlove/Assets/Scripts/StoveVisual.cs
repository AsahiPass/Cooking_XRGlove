using UnityEngine;

public class StoveVisual : MonoBehaviour {
    [SerializeField] private Stove stove;
    [SerializeField] private GameObject stoveOnVisual;
    [SerializeField] private GameObject sizzlingParticles;

    private void Start() {
        stove.OnStateChanged += Stove_OnStateChanged;
    }

    private void Stove_OnStateChanged(object sender, Stove.OnStateChangedEvnetArgs e) {
        if (e.state == Stove.State.Idle) {
            stoveOnVisual.SetActive(false);
            sizzlingParticles.SetActive(false);
        }
        else if (e.state == Stove.State.Frying) {
            stoveOnVisual.SetActive(true);
            sizzlingParticles.SetActive(true);
        }
    }
}
