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
        Type compType = ResourceTypeFromEnum(res.type);
        GameObject created = new GameObject(res.id , compType);
        created.transform.parent = transform;
        ResourceTracker resComp = created.GetComponent<ResourceTracker>();
        resComp.resource = res;
        resComp.RunInit();
    }

    Type ResourceTypeFromEnum(ResourceType resEnum){
        switch(resEnum){
            case(ResourceType.Generic):
            return typeof(ResourceTracker);
        }
        return typeof(Transform);
    }
}
