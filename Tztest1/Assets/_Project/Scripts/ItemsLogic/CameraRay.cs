using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class CameraRay : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private Transform _targetPos;
    private float _distance = 10f;
     
    public static int _countItem;
      
    private void Awake()
    {
        _playerCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            TouchRay();
        }
    }

    public void TouchRay()
    {
        RaycastHit hit;
        Ray ray = new Ray(_playerCamera.transform.position, _playerCamera.transform.forward);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, _distance))
            {
                if (Input.touchCount > 0)
                {
                    Item item = hit.collider.GetComponent<Item>();

                    if (item != null && _countItem < 1)
                    {
                        _countItem++;
                        item.transform.position = _targetPos.position;
                        item.transform.SetParent(_targetPos.parent);
                        item.isObjectRaised = true;
                    }
                }

            }
        }
    }
}


