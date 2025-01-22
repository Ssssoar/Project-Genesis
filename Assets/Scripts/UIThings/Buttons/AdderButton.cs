using UnityEngine;
using UnityEngine.UIElements;

public class AdderButton : UIElement{

    [Header("AdderButton Blueprints")]
    AdderAsset asset;

    public void Init(){
        asset = genAsset as AdderAsset;
        if (asset == null){
            Debug.Log("genAsset on AdderButtons should be of type AdderAsset");
        }

        base.OnEnable();

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