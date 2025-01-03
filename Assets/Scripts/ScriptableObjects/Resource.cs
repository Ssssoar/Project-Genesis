using UnityEngine;

[CreateAssetMenu(fileName = "Resource", menuName = "Scriptable Objects/Resource")]
public class Resource : ScriptableObject{
    [SerializeField] string name;
    [SerializeField] string plural;
    [SerializeField] VisualTreeAsset meterBlueprint;
    [SerializeField] VisualTreeAsset buttonBlueprint;
}
