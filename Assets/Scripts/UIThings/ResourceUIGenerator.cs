using UnityEngine;
using UnityEngine.UIElements;

public class ResourceUIGenerator : MonoBehaviour{
    [Header("DEBUG")]
    [SerializeField] string DEBUGNAMETOADD;

    [Header("References")]
    [SerializeField] UIDocument uIComp;
    [SerializeField] VisualTreeAsset meterBlueprint;
    [SerializeField] VisualTreeAsset buttonBlueprint;
    VisualElement root;

    void OnEnable(){
        root = uIComp.rootVisualElement;
    }

    [ContextMenu("Create DEBUG")]
    void DEBUGCREATE(){
        CreateNewResource(DEBUGNAMETOADD);
    }

    void CreateNewResource(string resourceName){
        CreateBar(resourceName);
        CreateButton(resourceName);
    }

    void CreateBar(string name){
        VisualElement origin = root.Q("Resources") as VisualElement;
        VisualElement toAdd = meterBlueprint.Instantiate();
        toAdd.Q("ResourceName").name = name;
        (toAdd.Q(name).Q("Label") as Label).text = name;
        origin.Add(toAdd);
    }

    void CreateButton(string name){
        VisualElement origin = root.Q("Buttons") as VisualElement;
        VisualElement toAdd = buttonBlueprint.Instantiate();
        toAdd.Q("ResourceName").name = name;
        (toAdd.Q(name) as Button).text = name;
        origin.Add(toAdd);
    }
}
