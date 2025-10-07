using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateIconsUI : MonoBehaviour {
    [SerializeField] private Plate plate;
    [SerializeField] private Transform iconTemplate;

    private void Awake() {
        iconTemplate.gameObject.SetActive(false);
    }

    private void Start() {
        plate.OnIngredientAdded += Plate_OnIngredientAdded;
    }

    private void Plate_OnIngredientAdded(object sender, Plate.OnIngredientAddedEventArgs e) {
        UpdateVisual(e.ingredientSO);
    }

    private void UpdateVisual(IngredientSO addedIngredientSO) {
        // 复制一个 iconTemplate，并设置为当前对象的子物体
        Transform iconTransform = Instantiate(iconTemplate, transform);

        iconTransform.gameObject.SetActive(true);
        iconTransform.GetComponent<PlateIconsSingleUI>().SetSprite(addedIngredientSO);
    }
}
