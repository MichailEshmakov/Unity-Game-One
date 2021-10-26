using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class TableMover : MonoBehaviour
{
    [SerializeField] private SpeedKeeper _speedKeeper;
    [SerializeField] private float _speedCoefficient;

    private RawImage _image;
    private float _imagePositionX;

    private void Awake()
    {
        _image = GetComponent<RawImage>();
        _imagePositionX = _image.uvRect.x;
    }

    private void Update()
    {
        _imagePositionX += _speedCoefficient * _speedKeeper.Speed * Time.deltaTime;
        if (_imagePositionX > 1)
            _imagePositionX %= 1;

        _image.uvRect = new Rect(_imagePositionX, 0, _image.uvRect.width, _image.uvRect.height);
    }
}
