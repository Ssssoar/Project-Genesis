using UnityEngine;
using UnityEngine.UIElements;

public class ResourceUIGenerator : MonoBehaviour{
    [Header("DEBUG")]
    [SerializeField] Resource DEBUGRESOURCETOADD;

    [Header("References")]
    [SerializeField] UIDocument uIComp;
    VisualElement root;

    void OnEnable(){
        root = uIComp.rootVisualElement;
    }

    [ContextMenu("Create DEBUG")]
    void DEBUGCREATE(){
        CreateNewResource(DEBUGRESOURCETOADD);
    }

    void CreateNewResource(Resource res){
        CreateBar(res);
        CreateButton(res);
    }

    void CreateBar(Resource res){
        VisualElement origin = root.Q("Resources") as VisualElement;
        VisualElement toAdd = res.meterBlueprint.Instantiate();
        toAdd.Q("ResourceName").name = res.id;
        (toAdd.Q(res.id).Q("Label") as Label).text = res.pluralName;
        origin.Add(toAdd);
    }

    void CreateButton(Resource res){
        VisualElement origin = root.Q("Buttons") as VisualElement;
        VisualElement toAdd = res.buttonBlueprint.Instantiate();
        toAdd.Q("ResourceName").name = res.id;
        (toAdd.Q(res.id) as Button).text = res.singularName;
        origin.Add(toAdd);
    }
}
