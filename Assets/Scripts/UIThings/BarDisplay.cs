using UnityEngine;
using UnityEngine.UIElements;

public class BarDisplay : MonoBehaviour{
    [Header("Variables")] //these are all just the currently displayed values, the Display actually does no tracking on it's own
    int min;
    int max;
    int count;

    [Header("References")]
    VisualElement holder; //who holds the bar, the one outside
    VisualElement origin; //Everything that the bar is, the inner
    ProgressBar bar;

    [Header("Blueprints")] //by which I mean anything that is stored in the files and not as part of the current scene
    [SerializeField] VisualTreeAsset barBlueprint;
    [SerializeField] Resource resource; //MUST BE GIVEN AT TIME OF INSTANTIATION

    void OnEnable(){
        holder = ResourceUIGenerator.instance.root.Q("Resources");

        origin = barBlueprint.Instantiate();
        origin.Q("ResourceName").name = resource.id;
        (origin.Q(resource.id).Q("Label") as Label).text = resource.meterText;
        bar = origin.Q(resource.id).Q("Bar") as ProgressBar;
        holder.Add(origin);
    }

    void OnDisable(){
        holder.Remove(origin);
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
