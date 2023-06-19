using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    [SerializeField] private float _minTime = 0.5f;
    [SerializeField] private float _maxTime = 1.2f;
    [SerializeField] private List<Light> _lights;

    private float _timer;

    void Start()
    {
        _timer = Random.Range(_minTime, _maxTime);
    }

    void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            foreach (var light in _lights)
            {
                light.enabled = !light.enabled;
            }
            _timer = Random.Range(_minTime, _maxTime);
        }
    }
}
