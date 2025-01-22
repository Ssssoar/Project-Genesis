using UnityEngine;
using UnityEngine.UIElements;

public class ResourceTracker : MonoBehaviour{
    [Header("Parameters")]
    internal Resource resource;

    [Header("Variables")]
    internal int max;
    internal int min;
    internal int count;

    void OnEnable(){
        if (resource != null)
            RunInit();
    }

    public void RunInit(){
        min = 0;
        max = resource.initialMax;
        
    }

    public void CountResource(ClickEvent evnt , int ammount){
        count += ammount;
        if (count > max) 
            count = max;
        DisplayUpdater.instance.UpdateDisplay(resource.id);
    }
}
