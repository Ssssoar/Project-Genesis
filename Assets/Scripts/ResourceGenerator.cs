using UnityEngine;
using System;

public class ResourceGenerator : MonoBehaviour{
    [Header("DEBUG")]
    [SerializeField] Resource DEBUGRESOURCETOADD;


    [ContextMenu("Create DEBUG")]
    void DEBUGCREATE(){
        CreateResource(DEBUGRESOURCETOADD);
    }

    void CreateResource(Resource res){
        ResourceUIGenerator.instance.CreateNewResource(res);
        CreateTracker(res);
    }

    void CreateTracker(Resource res){
        Type compType = TrackerFromResource(res);
        GameObject created = new GameObject(res.id , compType);
        created.transform.parent = transform;
        ResourceTracker resComp = created.GetComponent<ResourceTracker>();
        if (resComp == null) return;
        resComp.resource = res;
        resComp.RunInit();
    }

    Type TrackerFromResource(Resource res){
        if ((res as ClumpResource) != null)
            //returnSomething
        if ((res as SimpleResource) != null)
            return typeof(SimpleResourceTracker);
        return typeof(ResourceTracker);
    }
}
