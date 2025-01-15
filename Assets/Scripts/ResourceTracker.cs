using UnityEngine;
using UnityEngine.UIElements;

public class ResourceTracker : MonoBehaviour{
    [Header("Parameters")]
    internal Resource resource;

    [Header("Variables")]
    int max;
    int min;
    int count;

    void OnEnable(){
        if (resource != null)
            RunInit();
    }

    public void RunInit(){
        min = 0;
        max = resource.initialMax;
        
    }

    public void CountResource(ClickEvent evnt){
        count++;
        if (count > max) 
            count = max;
    }
}
