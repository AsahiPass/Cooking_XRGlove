using System;
using System.Collections.Generic;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour {
    [Serializable] 
    public struct IngredientSO_GameObject {
        public IngredientSO ingredientSO;
        public GameObject gameObject;
    }

    [SerializeField] private List<IngredientSO_GameObject> ingredientSOGameObjectList;

    private void Start() {
        foreach (IngredientSO_GameObject ingredientSOGameObject in ingredientSOGameObjectList) {
            ingredientSOGameObject.gameObject.SetActive(false);
        }
    }

    public void ShowVisual(IngredientSO addedIngredientSO) {
        foreach (IngredientSO_GameObject ingredientSOGameObject in ingredientSOGameObjectList) {
            if (ingredientSOGameObject.ingredientSO == addedIngredientSO) {
                ingredientSOGameObject.gameObject.SetActive(true);
            }
        }
    }
}
