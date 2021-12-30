using System;
using UnityEngine;

public class HeroInput : MonoBehaviour
{
    public event Action<Vector3> TapOnScreenEvent;
    public event Action ReleaseScreenEvent;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 worldPointOfClick = hit.point;
                    TapOnScreenEvent?.Invoke(worldPointOfClick);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            ReleaseScreenEvent?.Invoke();
        }
    }
}