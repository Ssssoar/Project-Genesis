using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Resource", menuName    = "Scriptable Objects/Resource")]
public class Resource : ScriptableObject{
    public string id;
    public string singularName;
    public string pluralName;
    public VisualTreeAsset meterBlueprint;
    public VisualTreeAsset buttonBlueprint;
}
