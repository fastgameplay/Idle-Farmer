using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class StorageText : MonoBehaviour{
    public int MaxAmount{private get; set;}

    public int Amount{
        set{
            CheckValue(value);
            _tmpText.text = value + "/" + MaxAmount;
        }
    }
    TextMeshProUGUI _tmpText;

    void Awake(){
        _tmpText = GetComponent<TextMeshProUGUI>();
    }

    void CheckValue(int value){
        if(value < 0 || value > MaxAmount){
            throw new System.Exception("Value is out of range");
        }
    }
}
