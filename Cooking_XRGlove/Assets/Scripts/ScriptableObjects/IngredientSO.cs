using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/IngredientSO")]
public class IngredientSO : ScriptableObject {
    public string name;
    public Sprite sprite;
    public GameObject prefab;
}
