using UnityEngine;

public class Ingredient : MonoBehaviour {
    [SerializeField] private IngredientSO ingredientSO;

    public IngredientSO GetIngredientSO() {
        return ingredientSO;
    }
}
