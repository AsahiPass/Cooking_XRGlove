using Oculus.Interaction;
using UnityEngine;

public class MeatPattyUncookedSnapInteractor : SnapInteractor {
    protected override void InteractableSelected(SnapInteractable interactable) {
        base.InteractableSelected(interactable);

        var stove = interactable.GetComponent<Stove>();
        if (stove != null) {
            GameObject meatPattyUncooked = this.transform.parent.gameObject;
            stove.StartFrying(meatPattyUncooked);
        }

        SnapInteractorDropNotifier.Instance.NotifyDrop(interactable.transform.position);
    }
}
