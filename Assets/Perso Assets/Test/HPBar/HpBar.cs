﻿using UnityEngine;
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
            this.transform.localScale = new Vector3(_percentLeft / 100, 1, 1);
            //_texture.transform.localScale = new Vector3(1 / this.transform.localScale.x, 1, 1);
            _image.uvRect = new Rect(0, 0, this.transform.localScale.x, 1);
        }
    }

    //[SerializeField] private RectTransform _texture;
    private RawImage _image;
    private float _percentLeft;

    void Start()
    {
        _image = GetComponent<RawImage>() as RawImage;
        if (_image == null)
            Debug.LogError("This component hasn't RawImage component attached");
        PercentLeft = 100;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            PercentLeft = -10;
        if (Input.GetKeyDown(KeyCode.Z))
            PercentLeft = 10;
    }
}