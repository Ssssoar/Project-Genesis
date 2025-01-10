using UnityEngine;
using UnityEngine.UIElements;


[CreateAssetMenu(fileName = "Resource", menuName    = "Scriptable Objects/BaseResource")]
public class Resource : ScriptableObject{ //WHEN CREATING INHERITANCE REMEMBER TO CHECK RESOURCEGENERATOR.CS
    //A generic resource, with no extra behaviour
    public string id;
    public string buttonText;
    public string meterText;
    public VisualTreeAsset meterBlueprint;
    public int initialMax;

    public virtual void GenerateUI(VisualElement menuRoot){
        CreateBar(menuRoot);
    }

    internal void CreateBar(VisualElement root){
        VisualElement origin = root.Q("Resources") as VisualElement;
        VisualElement toAdd = meterBlueprint.Instantiate();
        toAdd.Q("ResourceName").name = id;
        (toAdd.Q(id).Q("Label") as Label).text = meterText;
        origin.Add(toAdd);
    }
}