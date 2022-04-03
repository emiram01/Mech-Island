using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private float _max;
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private PlayerManager _player;
    public float curr;

    private void Start()
    {
        curr = _max;
    }
    
    private void Update()
    {
        GetCurrFill();

        if(curr > _max)
        {
            curr = _max;
        }
    }

    public void TakeDamage(float damage)
    {
        curr -= damage;

        if(curr <= 0)
        {
            _player.canMove = false;
            _player.cam.canMoveCam = false;
            Invoke(nameof(Die), 1.5f);
        }
    }

    private void Die()
    {
        _gameOver.SetActive(true);
        Invoke(nameof(LoadMenu), 3.5f);
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void GetCurrFill()
    {
        float fill = curr / _max;
        _image.fillAmount = fill;
    }
}
