using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinThrower : MonoBehaviour
{
    [SerializeField] Canvas _canvas;
    [SerializeField] CoinScriptable _coinData;
    [SerializeField] GoldText _goldText;
    Vector3 _centerPos;
    Vector3 _targetPos;
    void Awake(){
        
        _centerPos = new Vector3(Screen.width/2,Screen.height/2,0.0f);
        _targetPos = new Vector3(Screen.width*0.2f,Screen.height*0.95f,0.0f);
    }
    public void AddCoin(){
        StartCoroutine(IEThrowCoin());
    }
    IEnumerator IEThrowCoin(){
        RectTransform coinRectTransform = Instantiate(_coinData.Prefab, _canvas.transform).GetComponent<RectTransform>();
        coinRectTransform.position = _centerPos;

        Vector3 startPosition = coinRectTransform.position;
        float timeElapsed = 0f;

        while (timeElapsed <= _coinData.FlyTime)
        {
            timeElapsed += Time.deltaTime;
            coinRectTransform.position = Vector3.Lerp(startPosition, _targetPos, timeElapsed / _coinData.FlyTime);
            yield return null;
        }
        Destroy(coinRectTransform.gameObject);

        _goldText.Amount += _coinData.Price;
        _goldText.ShakeText();
    }


}
