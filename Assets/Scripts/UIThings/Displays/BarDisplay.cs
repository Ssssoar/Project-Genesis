using UnityEngine;
using UnityEngine.UIElements;

public class BarDisplay : UIElement{
    [Header("Variables")] //these are all just the currently displayed values, the Display actually does no tracking on it's own
    int min;
    int max;
    int count;

    [Header("BarDisplay References")]
    ProgressBar bar;

    [Header("BarDisplay Blueprints")] //by which I mean anything that is stored in the files and not as part of the current scene
    public Resource resource; //MUST BE GIVEN AT TIME OF INSTANTIATION

    void Start(){
        gameObject.name = resource.id + "Bar";
    }

    protected override void OnEnable(){
        if (resource == null) return;
        Init();
    }

    public void Init(){
        base.OnEnable();

        origin.Q("ResourceName").name = resource.id;
        (origin.Q(resource.id).Q("Label") as Label).text = resource.meterText;
        bar = origin.Q(resource.id).Q("Bar") as ProgressBar;
    }

    protected override void OnDisable(){
        base.OnDisable();
        min = 0;
        max = 0;
        count = 0;
        bar = null;
    }

    void UpdateBar(int count){
        bar.title = count + " / " + max;
        bar.value = count;
    }

    void UpdateLimits(int newMax, int newMin){
        min = newMin;
        max = newMax;
        bar.highValue = max;
        bar.lowValue = min;
        bar.title = count + " / " + max;
    }
}
