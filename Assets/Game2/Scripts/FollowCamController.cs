using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform _trackingTarget;
    [SerializeField] private float _xOffset = 4;
    [SerializeField] private float _yOffset = 2;
    [SerializeField] private float _followSpeed = 5;
    [SerializeField] private bool _isXLocked = false;
    [SerializeField] private bool _isYLocked = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xTarget = _trackingTarget.position.x + _xOffset;
        float yTarget = _trackingTarget.position.y + _yOffset;
        float xNew = transform.position.x;
        if (!_isXLocked)
        {
            xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime
            * _followSpeed);
        }
        float yNew = transform.position.y;
        if (!_isYLocked)
        {
            yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime
            * _followSpeed);
        }
        transform.position = new Vector3(xNew, yNew, transform.position.z);
    }
}
