using UnityEngine;

[CreateAssetMenu(fileName = "CoinData", menuName = "Coin/Coin Scriptable")]
public class CoinScriptable : ScriptableObject
{
    public GameObject Prefab;
    public float FlyTime;
    public int Price;
}
