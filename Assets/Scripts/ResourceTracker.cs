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
    Button button;
    ProgressBar bar;

    void OnEnable(){
        if (resource != null)
            RunInit();
    }

    public void RunInit(){

        VisualElement root = UIGenerator.instance.root;

        button = root.Q("Buttons").Q(resource.id) as Button;
        bar = root.Q("Resources").Q(resource.id).Q("Bar") as ProgressBar;

        button.RegisterCallback<ClickEvent>(CountResource);

        min = 0;
        max = resource.initialMax;
        
    }

    void OnDisable(){
        button.UnregisterCallback<ClickEvent>(CountResource);
    }

    void CountResource(ClickEvent evnt){
        count++;
        if (count > max) 
            count = max;
        else
            UpdateBar();
    }

    void UpdateBar(){
        bar.highValue = max;
        bar.lowValue = min;
        bar.title = count + " / " + max;
        bar.value = count;
    }
}
