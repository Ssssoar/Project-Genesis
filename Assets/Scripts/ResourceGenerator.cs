using UnityEngine;

public class ResourceGenerator : MonoBehaviour{
    [Header("DEBUG")]
    [SerializeField] Resource DEBUGRESOURCETOADD;

    [ContextMenu("Create DEBUG")]
    void DEBUGCREATE(){
        ResourceUIGenerator.instance.CreateNewResource(DEBUGRESOURCETOADD);
    }
}
