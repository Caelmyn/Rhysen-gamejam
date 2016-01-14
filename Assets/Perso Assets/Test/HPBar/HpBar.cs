using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HpBar : MonoBehaviour
{
    public int PercentLeft
    {
        get { return _percentLeft; }
        set
        {
            _percentLeft += value;
            if (_percentLeft > 100)
                _percentLeft = 100;
            if (_percentLeft < 0)
                _percentLeft = 0;
        }
    }

    [SerializeField] private RectTransform _texture;
    private int _percentLeft;

    void Start()
    {
    }
}
