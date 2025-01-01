using UnityEngine;
using UnityEngine.UIElements;

public class PlungusCount : MonoBehaviour{
    [Header("Variables")]
    [SerializeField] int min;
    [SerializeField] int max;
    int count;

    [Header("References")]
    [SerializeField] UIDocument uiComp;
    VisualElement root;
    Button button;
    ProgressBar bar;

    void OnEnable(){
        root = uiComp.rootVisualElement;
        button = root.Q("Buttons").Q("Plungus") as Button;
        bar = root.Q("Resources").Q("Plungus").Q("Bar") as ProgressBar;

        button.RegisterCallback<ClickEvent>(CountResource);
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
