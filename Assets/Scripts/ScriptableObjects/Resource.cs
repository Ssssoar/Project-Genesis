using UnityEngine;
using UnityEngine.UIElements;

public enum ResourceType {Generic}

[CreateAssetMenu(fileName = "Resource", menuName    = "Scriptable Objects/Resource")]
public class Resource : ScriptableObject{
    public string id;
    public string buttonText;
    public string meterText;
    public BarDisplay display;
    public int initialMax;
}
