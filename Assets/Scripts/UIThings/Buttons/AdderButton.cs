using UnityEngine;
using UnityEngine.UIElements;

public class AdderButton : UIElement{
    [Header("AdderButton References")]
    public Button button;

    [Header("AdderButton Blueprints")]
    public UIButton genAsset;
    public AdderAsset asset;

    void Start(){
        gameObject.name = asset.buttonText + "Button";
    }

    protected override void OnEnable(){
        if (asset == null) return;
        Init();
    }

    public void Init(){
        asset = genAsset as AdderAsset;
        base.OnEnable();

        origin.Q("ResourceName").name = asset.id;
        button = origin.Q(asset.id) as Button;
        button.text = asset.buttonText;
        button.RegisterCallback<ClickEvent>(CountResource);
    }

    protected override void OnDisable(){
        button.UnregisterCallback<ClickEvent>(CountResource);
        base.OnDisable();
        button = null;
    }

    void CountResource(ClickEvent evnt){
        Debug.Log("DO THE MARIO");
    }
}