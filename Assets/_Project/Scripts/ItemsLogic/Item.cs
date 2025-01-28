using UnityEngine;

public class Item : MonoBehaviour
{
    public BoxCollider _boxCol {  get; private set; }
    public bool isObjectRaised;
    private void Awake() => _boxCol = GetComponent<BoxCollider>();
}
