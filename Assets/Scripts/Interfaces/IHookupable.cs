using UnityEngine;

public interface IHookupable{ //to define a thing that needs to hookup to a resource
    void HookUp(string id);
    void HookUp(ResourceTracker trackerToHookup);
}
