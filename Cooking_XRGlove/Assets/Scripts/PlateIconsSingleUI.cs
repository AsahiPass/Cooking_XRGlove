using UnityEngine;
using UnityEngine.UI;

public class PlateIconsSingleUI : MonoBehaviour {
    [SerializeField] private Image image;

    public void SetSprite(IngredientSO ingredientSO) {
        image.sprite = ingredientSO.sprite;
    }
}
