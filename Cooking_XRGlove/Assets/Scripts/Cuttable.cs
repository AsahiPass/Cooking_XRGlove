using System;
using UnityEngine;

public class Cuttable : MonoBehaviour, IHasProgress {
    public event EventHandler<IHasProgress.OnProgressChangedEventArgs> OnProgressChanged;

    [SerializeField] public Transform ingredientTransform;
    [SerializeField] public GameObject ingredientSlices;

    private int totalCutsRequired = 3;
    private int cutsCompleted = 0;

    public void Cut() {
        cutsCompleted++;

        OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs {
            progressNormalized = (float)cutsCompleted / totalCutsRequired
        });

        if (cutsCompleted == totalCutsRequired) {
            Destroy(ingredientTransform.gameObject);
            Instantiate(ingredientSlices, ingredientTransform.position, ingredientTransform.rotation);
        }
    }
}
