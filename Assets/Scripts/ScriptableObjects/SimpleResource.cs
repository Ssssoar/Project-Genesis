using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "SimpleResource", menuName = "Scriptable Objects/SimpleResource")]
//a simple resource that upon click generates a single instance
public class SimpleResource : Resource{
    public VisualTreeAsset buttonBlueprint;

    public override void GenerateUI(VisualElement menuRoot){
        base.GenerateUI(menuRoot);
        CreateButton(menuRoot);
    }

    void CreateButton(VisualElement root){
        VisualElement origin = root.Q("Buttons") as VisualElement;
        VisualElement toAdd = buttonBlueprint.Instantiate();
        toAdd.Q("ResourceName").name = id;
        (toAdd.Q(id) as Button).text = buttonText;
        origin.Add(toAdd);
    }
}
