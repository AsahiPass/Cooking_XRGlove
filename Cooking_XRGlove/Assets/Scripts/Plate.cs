using System;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour {
    public event EventHandler<OnIngredientAddedEventArgs> OnIngredientAdded;
    public class OnIngredientAddedEventArgs : EventArgs {
        public IngredientSO ingredientSO;
    }

    private List<IngredientSO> addedIngredientSOList;

    private void Awake() {
        addedIngredientSOList = new List<IngredientSO>();
    }

    public void AddIngredient(IngredientSO ingredientSO) {
        addedIngredientSOList.Add(ingredientSO);
        OnIngredientAdded?.Invoke(this, new OnIngredientAddedEventArgs {
            ingredientSO = ingredientSO
        });
    }

    public List<IngredientSO> GetAddedIngredientSOList() {
        return addedIngredientSOList;
    }
}
