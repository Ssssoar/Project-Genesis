using UnityEngine;
using UnityEngine.UIElements;

public class ResourceGenerator : MonoBehaviour{
    [Header("DEBUG")]
    [SerializeField] string DEBUGNAMETOADD;

    [Header("References")]
    [SerializeField] UIDocument uIComp;
    [SerializeField] VisualTreeAsset meterBlueprint;
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
    }

    void CreateBar(string name){
        VisualElement origin = root.Q("Resources") as VisualElement;
        VisualElement toAdd = meterBlueprint.Instantiate();
        toAdd.Q("ResourceName").name = name;
        origin.Add(toAdd);
    }
}
