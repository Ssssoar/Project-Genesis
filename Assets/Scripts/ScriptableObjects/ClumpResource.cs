using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "ClumpResource", menuName = "Scriptable Objects/ClumpResource")]
//a group of resources with a single button that will generate one of them, depending on ammount of a parent resource
public class ClumpResource : Resource{
    [System.NonSerialized] new internal ResourceType type = ResourceType.Clump;
    public VisualTreeAsset buttonBlueprint;
    
}
