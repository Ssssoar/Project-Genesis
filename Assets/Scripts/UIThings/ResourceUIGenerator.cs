using UnityEngine;
using UnityEngine.UIElements;

public class UIGenerator : MonoBehaviour{
    public static UIGenerator instance;
    void Awake(){
        if (UIGenerator.instance != null)
            Destroy(this);
        else
            UIGenerator.instance = this;
    }

    [Header("References")]
    [SerializeField] UIDocument uIComp;
    internal VisualElement root;

    void OnEnable(){
        root = uIComp.rootVisualElement;
    }

    public void CreateDisplay(Resource res){
        BarDisplay newDisplay = Instantiate(res.display , transform);
        newDisplay.resource = res;
    }

    void CreateButton(Resource res){
        VisualElement origin = root.Q("Buttons") as VisualElement;
        VisualElement toAdd = res.buttonBlueprint.Instantiate();
        toAdd.Q("ResourceName").name = res.id;
        (toAdd.Q(res.id) as Button).text = res.buttonText;
        origin.Add(toAdd);
    }
}
