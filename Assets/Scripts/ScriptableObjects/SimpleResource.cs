using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "SimpleResource", menuName = "Scriptable Objects/SimpleResource")]
//a simple resource that upon click generates a single instance
public class SimpleResource : Resource{
    [System.NonSerialized] new internal ResourceType type = ResourceType.Generic;
    public VisualTreeAsset buttonBlueprint;
}
