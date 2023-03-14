using UnityEngine;

[CreateAssetMenu(fileName = "BackPackData", menuName = "Player/BackPack Scriptable")]
public class BackPackScriptable : ScriptableObject{
    public GameObject Prefab;
    public Color Color;
    public Vector3 MaxSize;
    public int MaxAmount;
}