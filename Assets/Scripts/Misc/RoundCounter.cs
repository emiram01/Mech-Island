using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundCounter : MonoBehaviour
{
    [SerializeField] private RectTransform _rt;
    [SerializeField] private Sprite[] _digits;
    [SerializeField] private Image[] _positions;
    public bool canStart;

    void Start()
    {
        for(int i = 0; i < _positions.Length; i++)
            _positions[i].sprite = _digits[0];
    }

    public void UpdateRoundCounter(int currentRound)
    {
        currentRound++;
        int[] digitArray = GetDigitArray(currentRound);

        switch(digitArray.Length)
        {
            case 1:
                _rt.localPosition = new Vector2(-320, -160);
                _positions[0].sprite = _digits[0];
                _positions[1].sprite = _digits[0];
                _positions[2].sprite = _digits[digitArray[0]];
                break;
            case 2:
                _rt.localPosition = new Vector2(-300, -160);
                _positions[0].sprite = _digits[0];
                _positions[1].sprite = _digits[digitArray[0]];
                _positions[2].sprite = _digits[digitArray[1]];
                break;
            case 3:
                _rt.localPosition = new Vector2(-280, -160);
                _positions[0].sprite = _digits[digitArray[0]];
                _positions[1].sprite = _digits[digitArray[1]];
                _positions[2].sprite = _digits[digitArray[2]];
                break;
        }
    }

    public void CanStartNextRound()
    {
        canStart = true;
    }

    private int[] GetDigitArray(int num)
    {
        List<int> intList = new List<int>();
        while(num > 0)
        {
            intList.Add(num % 10);
            num = num / 10;
        }
        intList.Reverse();
        return intList.ToArray();
    }
}
