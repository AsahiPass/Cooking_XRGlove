using System;
using Oculus.Interaction;
using Unity.VisualScripting;
using UnityEngine;

public class CookedIngredientSnapInteractor : SnapInteractor {
    public static event EventHandler<EventArgs> OnAnyDrop;

    protected override void InteractableSelected(SnapInteractable interactable) {
        base.InteractableSelected(interactable);

        GameObject cookedIngredient = this.transform.parent.gameObject;

        GameObject plate = interactable.gameObject;

        PlateCompleteVisual plateCompleteVisual = plate.GetComponentInChildren<PlateCompleteVisual>();
        IngredientSO cookedIngredientSO = cookedIngredient.GetComponent<Ingredient>().GetIngredientSO();

        if (plateCompleteVisual != null) {
            plateCompleteVisual.ShowVisual(cookedIngredientSO);
        }

        if (plate.GetComponent<Plate>() != null) {
            plate.GetComponent<Plate>().AddIngredient(cookedIngredientSO);
        }

        SnapInteractorDropNotifier.Instance.NotifyDrop(interactable.transform.position);

        Destroy(cookedIngredient);
    }
}
