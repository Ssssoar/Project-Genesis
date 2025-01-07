using UnityEngine;
using System;

public class ResourceGenerator : MonoBehaviour{
    [Header("DEBUG")]
    [SerializeField] Resource DEBUGRESOURCETOADD;

    [ContextMenu("Create DEBUG")]
    void DEBUGCREATE(){
        ResourceUIGenerator.instance.CreateNewResource(DEBUGRESOURCETOADD);
        CreateResource(DEBUGRESOURCETOADD);
    }

    void CreateResource(Resource res){
        Type comp = typeof(Transform);
        switch (res.type){
            case(ResourceType.Generic):
                comp = typeof(ResourceTracker);
            break;
        }
        GameObject created = new GameObject(res.id , comp);
        created.transform.parent = transform;
    }
}
