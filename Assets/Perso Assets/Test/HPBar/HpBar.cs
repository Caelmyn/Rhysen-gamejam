using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HpBar : MonoBehaviour
{
    public float PercentLeft
    {
        get { return _percentLeft; }
        set
        {
            _percentLeft += value;
            if (_percentLeft > 100)
                _percentLeft = 100;
            if (_percentLeft < 0)
                _percentLeft = 0;
            Debug.Log(_percentLeft);
            this.transform.localScale = new Vector3(_percentLeft / 100, 1, 1);
            _texture.transform.localScale = new Vector3(1 / this.transform.localScale.x, 1, 1);
        }
    }

    [SerializeField] private RectTransform _texture;
    private float _percentLeft;

    void Start()
    {
        PercentLeft = 100;
    }
}
