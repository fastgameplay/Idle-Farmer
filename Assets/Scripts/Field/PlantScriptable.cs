using UnityEngine;

[CreateAssetMenu(fileName = "New Plant", menuName = "Plants/Plant Scriptable")]
public class PlantScriptable : ScriptableObject {
    public GameObject Prefab;
    public float GrowthTime;
    public Vector2 GrowthRange;
}