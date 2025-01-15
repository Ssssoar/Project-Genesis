using UnityEngine;
using UnityEngine.UIElements;

public class UIElement : MonoBehaviour{
    [Header("References")]
    VisualElement holder; //who holds the Element, the one outside
    protected VisualElement origin; //Everything that the Element is, the inner

    [Header("Parameters")]
    [SerializeField] string holderName;

    [Header("Blueprints")] //by which I mean anything that is stored in the files and not as part of the current scene
    [SerializeField] VisualTreeAsset blueprint; //from which the element will be built

    protected virtual void OnEnable(){
        holder = UIGenerator.instance.root.Q(holderName);

        origin = blueprint.Instantiate();
        holder.Add(origin);
    }

    protected virtual void OnDisable(){
        holder.Remove(origin);
    }
}

