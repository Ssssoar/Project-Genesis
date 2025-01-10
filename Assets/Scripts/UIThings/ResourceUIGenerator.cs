using UnityEngine;
using UnityEngine.UIElements;

public class ResourceUIGenerator : MonoBehaviour{
    public static ResourceUIGenerator instance;
    void Awake(){
        if (ResourceUIGenerator.instance != null)
            Destroy(this);
        else
            ResourceUIGenerator.instance = this;
    }

    [Header("References")]
    [SerializeField] UIDocument uIComp;
    internal VisualElement root;

    void OnEnable(){
        root = uIComp.rootVisualElement;
    }

    public void CreateNewResource(Resource res){
        res.GenerateUI(root);
    }
}
