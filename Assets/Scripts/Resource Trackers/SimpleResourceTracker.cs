using UnityEngine;
using UnityEngine.UIElements;

public class SimpleResourceTracker : ResourceTracker{
    [Header("References")]
    Button button;

    public override void RunInit(){
        base.RunInit();

        VisualElement root = ResourceUIGenerator.instance.root;
        button = root.Q("Buttons").Q(resource.id) as Button;

        button.RegisterCallback<ClickEvent>(CountSingle);
        
    }

    void OnDisable(){
        button.UnregisterCallback<ClickEvent>(CountSingle);
    }

    void CountSingle(ClickEvent evnt){
        AddResource(1);
    }
}
