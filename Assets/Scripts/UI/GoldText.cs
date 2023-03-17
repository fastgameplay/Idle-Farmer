using System.Collections;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
[RequireComponent(typeof(GoldTextAnim))]
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
            _anim.PlayShake();
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
    [SerializeField] float _secondsToFill;
    TextMeshProUGUI _tmpText;
    GoldTextAnim _anim;
    int _amount;
    int _targetAmount;

    void Awake(){
        _tmpText = GetComponent<TextMeshProUGUI>();
        _anim = GetComponent<GoldTextAnim>();
        //Load On Awake
        currentAmount = _targetAmount = PlayerPrefs.GetInt("Gold",0);
    }

    IEnumerator IELerpAmount(int targetAmount)
    {
        float timeElapsed = 0f;
        int startValue = _amount;

        while (timeElapsed < _secondsToFill)
        {
            currentAmount = Mathf.RoundToInt(Mathf.Lerp(startValue, targetAmount, timeElapsed / _secondsToFill));
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