using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Resource", menuName = "Scriptable Objects/Resource")]
public class Resource : ScriptableObject{
    [SerializeField] string singularName;
    [SerializeField] string pluralName;
    [SerializeField] VisualTreeAsset meterBlueprint;
    [SerializeField] VisualTreeAsset buttonBlueprint;
}
