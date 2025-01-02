using UnityEngine;
using UnityEngine.UIElements;

public class Resource : MonoBehaviour{
    [Header("Parameters")]
    [SerializeField] string resourceName;
    [SerializeField] string startingMin;
    [SerializeField] string startingMax;

    [Header("Variables")]
    int min;
    int max;
    int count;

    [Header("References")]
    [SerializeField] UIDocument uiComp;
    VisualElement root;
    Button button;
    ProgressBar bar;

    void OnEnable(){

        root = uiComp.rootVisualElement;

        button = root.Q("Buttons").Q(resourceName) as Button;
        bar = root.Q("Resources").Q(resourceName).Q("Bar") as ProgressBar;

        button.RegisterCallback<ClickEvent>(CountResource);
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
