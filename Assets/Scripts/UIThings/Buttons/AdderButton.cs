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
        //get the callback from the corresponding tracker
        ResourceTracker tracker = TrackerIndexer.instance.GetTracker(asset.resource.id);
        button.RegisterCallback<ClickEvent>(tracker.CountResource);
    }

    protected override void OnDisable(){
        //get the callback from the corresponding tracker
        ResourceTracker tracker = TrackerIndexer.instance.GetTracker(asset.resource.id);
        button.UnregisterCallback<ClickEvent>(tracker.CountResource);

        base.OnDisable();
        button = null;
    }
}