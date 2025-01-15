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
    [SerializeField] Transform displayParent;
    [SerializeField] Transform buttonParent;
    internal VisualElement root;

    void OnEnable(){
        root = uIComp.rootVisualElement;
    }

    public void CreateDisplay(Resource res){
        BarDisplay newDisplay = Instantiate(res.display , displayParent);
        newDisplay.resource = res;
        newDisplay.Init(); //VERY ICKY I DON'T LIKE THIS
        DisplayIndexer.instance.AddDisplay(newDisplay);
    }

    public void CreateButton(UIButton asset){
        AdderButton newButton = Instantiate(asset.button , buttonParent);
        newButton.genAsset = asset;
        newButton.Init(); //VERY ICKY I DON'T LIKE THIS
    }
}
