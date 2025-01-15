using UnityEngine;
using System.Collections.Generic; //For dictionary

public class TrackerIndexer : MonoBehaviour{
    public static TrackerIndexer instance;
    void Awake(){
        if (TrackerIndexer.instance != null)
            Destroy(this);
        else
            TrackerIndexer.instance = this;
    }


    Dictionary<string , ResourceTracker> trackerIndex = new Dictionary<string , ResourceTracker>();
    
    public void AddTracker(ResourceTracker tracker){
        trackerIndex.Add(tracker.resource.id , tracker);
    }

    public ResourceTracker GetTracker(string resID){
        return trackerIndex[resID];
    }
}
