using UnityEngine;
using UnityEngine.UIElements;

public class ResourceTracker : MonoBehaviour{
    [Header("Parameters")]
    internal Resource resource;

    [Header("Variables")]
    int max;
    int min;
    int count;

    [Header("References")]
    ProgressBar bar;

    void OnEnable(){
        if (resource != null)
            RunInit();
    }

    public virtual void RunInit(){

        VisualElement root = ResourceUIGenerator.instance.root;

        bar = root.Q("Resources").Q(resource.id).Q("Bar") as ProgressBar;

        min = 0;
        max = resource.initialMax;
    }

    public int AddResource(int toAdd){ //anyone who wants to add an ammount of this resource will call this
        int overflow = 0; //if attempting to add more than will fit, the overflow will be informed as the return
        count += toAdd;
        if (count > max){
            overflow = count - max;
            count = max;
        }
        UpdateBar();
        return overflow;

    }

    void UpdateBar(){
        bar.highValue = max;
        bar.lowValue = min;
        bar.title = count + " / " + max;
        bar.value = count;
    }
}
