using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] private int _max;
    [SerializeField] private float _currentAmount;
    [SerializeField] private int _regenRate;

    private void Update()
    {
        Regen();
    }

    public float GetCurrentAmount() { return _currentAmount; }

    public int GetMax() { return _max; }

    public void SetRegenRate(int newRegenRate)
    {
        _regenRate = newRegenRate;
    }
    
    public void BuffMax(int buff)
    {
        _max += buff;
    }

    public void Regen()
    {
        if(_currentAmount < _max)
            _currentAmount += _regenRate * Time.deltaTime;

        if(_currentAmount >= _max)
            _currentAmount = _max - 0.4f;
    }

    public void Drain(float drainAmount)
    {
        _currentAmount -= drainAmount;

        if(_currentAmount <= 0)
            _currentAmount = 0;
    }

    public void QuickRegen(int regenAmount)
    {
        _currentAmount += regenAmount;
    }

    public bool HasStat(int staminaNeeded)
    {
        return _currentAmount >= staminaNeeded;
    }
}
