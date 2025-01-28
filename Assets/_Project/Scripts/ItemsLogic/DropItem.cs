using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DropItem : MonoBehaviour
{
    [SerializeField] private List<BoolFreeСell> points;
    private List<Item> _item;

    [Inject]
    public void Construct(List<Item> items)
    {
        _item = items;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        { 
            for (var i = 0; i < _item.Count; i++)
            {
                if (points[i].isPoints == false && _item[i].isObjectRaised == true)
                {
                    points[i].isPoints = true;
                    _item[i]._boxCol.transform.parent = points[i].transform.parent;
                    _item[i]._boxCol.transform.position = points[i].transform.position;
                    _item[i]._boxCol.transform.rotation = Quaternion.identity;
                    _item[i]._boxCol.enabled = false;
                    CameraRay._countItem = 0;
                }
            }
        }
    }
}