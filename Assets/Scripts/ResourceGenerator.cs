using UnityEngine;
using System;

public class ResourceGenerator : MonoBehaviour{
    [Header("DEBUG")]
    [SerializeField] Resource DEBUGRESOURCETOADD;
    [SerializeField] UIButton DEBUGBUTTONTOADD;


    [ContextMenu("Create Res DEBUG")]
    void DEBUGCREATE(){
        CreateResource(DEBUGRESOURCETOADD);
    }    
    
    [ContextMenu("Create Button DEBUG")]
    void DEBUGCREATE2(){ //electric boogaloo
        CreateButton(DEBUGBUTTONTOADD);
    }

    void CreateButton(UIButton button){
        UIGenerator.instance.CreateButton(button);
    }

    void CreateResource(Resource res){
        UIGenerator.instance.CreateDisplay(res);
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
