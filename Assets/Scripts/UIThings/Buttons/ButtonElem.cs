using UnityEngine;

public class ButtonElem : UIElement{
    [Header("ButtonElem References")]
    public Button button;

    [Header("ButtonElem Blueprints")]
    public UIButton genAsset;

    void Start(){
        gameObject.name = genAsset.buttonText + "Button";
    }

    protected override void OnEnable(){ 
        //base OnEnable is run inside Init()
        if (genAsset == null) return;
        Init();
    }

    public void Init(){
        base.OnEnable();

        origin.Q("ResourceName").name = genAsset.id;
        button = origin.Q(genAsset.id) as Button;
        button.text = genAsset.buttonText;

        Hookup();
        //get the callback from the corresponding tracker
        ResourceTracker tracker = TrackerIndexer.instance.GetTracker(asset.resource.id);
        if (tracker == null){
            StandbyHookups.instance.NewStandby(this , asset.resource.id);
        }else{
            HookUp(tracker);
        }
    }

    protected override void OnDisable(){
        //get the callback from the corresponding tracker
        ResourceTracker tracker = TrackerIndexer.instance.GetTracker(asset.resource.id);
        button.UnregisterCallback<ClickEvent>(tracker.CountResource);

        base.OnDisable();
        button = null;
    }

    public void HookUp(ResourceTracker trackerToHookup){
        button.RegisterCallback<ClickEvent>(trackerToHookup.CountResource);
    }

    public void HookUp(string id){
        ResourceTracker tracker = TrackerIndexer.instance.GetTracker(asset.resource.id);
        if (tracker != null)
            HookUp(tracker);
        else
            Debug.Log("HookUp attempted but no tracker matching id '" + id + "' was found");
    }
}
