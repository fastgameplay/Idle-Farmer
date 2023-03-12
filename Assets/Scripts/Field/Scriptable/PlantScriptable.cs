using UnityEngine;

[CreateAssetMenu(fileName = "PlantData", menuName = "Field/Plant Scriptable")]
public class PlantScriptable : ScriptableObject {
    public GameObject Prefab;
    public float GrowthTime;
    public Vector2 GrowthRange;
}