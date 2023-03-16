using System.Collections;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class GoldText : MonoBehaviour
{
    public int Amount{
        get{
            return _targetAmount;
        }
        set{
            if(value < 0)
                throw new System.Exception("Gold Amount Value is negative");
            
            _targetAmount = value;
            StopAllCoroutines();
            StartCoroutine(IELerpAmount(_targetAmount));
            //animate text from current to givven
        }
    }
    private int currentAmount{
        set{
            _tmpText.text = value.ToString();
            _amount = value;
        }
    }

    TextMeshProUGUI _tmpText;
    int _amount;
    int _targetAmount;

    void Awake(){
        _tmpText = GetComponent<TextMeshProUGUI>();
        //Load On Awake
        currentAmount = _targetAmount = PlayerPrefs.GetInt("Gold",0);
    }

    public void ShakeText(){
        //TODO: anim.shake();
    }
    IEnumerator IELerpAmount(int targetAmount)
    {
        float timeElapsed = 0f;
        int startValue = _amount;

        while (timeElapsed < 0.5f)
        {
            currentAmount = Mathf.RoundToInt(Mathf.Lerp(startValue, targetAmount, timeElapsed / 0.5f));
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        currentAmount = targetAmount;
    }
    
    void OnDestroy()
    {
        //Save On Destroy
        PlayerPrefs.SetInt("Gold",_targetAmount);
    }
}