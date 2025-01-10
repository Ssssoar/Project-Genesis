using UnityEngine;
using UnityEngine.UIElements;

public enum ResourceType {Base, Generic, Clump}

[CreateAssetMenu(fileName = "Resource", menuName    = "Scriptable Objects/BaseResource")]
public class Resource : ScriptableObject{
    //A generic resource, with no extra behaviour
    public string id;
    [System.NonSerialized] internal ResourceType type = ResourceType.Base; //inheritors should manually set this
    public string buttonText;
    public string meterText;
    public VisualTreeAsset meterBlueprint;
    public int initialMax;
    public void FunctionDefinition(){
        Debug.Log("Something");
    }
}