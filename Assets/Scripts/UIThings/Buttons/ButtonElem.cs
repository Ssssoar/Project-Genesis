using UnityEngine;
using UnityEngine.UIElements;

public class ButtonElem : UIElement{
    [Header("ButtonElem References")]
    public Button button;

    [Header("ButtonElem Blueprints")]
    public UIButton genAsset;

    void Start(){
        gameObject.name = genAsset.buttonText + "Button";
    }

    protected override void OnEnable(){ 
        //base OnEnable is run inside Init()
        if (genAsset == null) return;
        Init();
    }

    public virtual void Init(){
        base.OnEnable();

        origin.Q("ResourceName").name = genAsset.id;
        button = origin.Q(genAsset.id) as Button;
        button.text = genAsset.buttonText;

        
        button.RegisterCallback<ClickEvent>(OnClickedButton);
    }

    protected override void OnDisable(){
        button.UnregisterCallback<ClickEvent>(OnClickedButton);

        base.OnDisable();
        button = null;
    }

    protected virtual void OnClickedButton(ClickEvent evnt){
        Debug.Log("Default button Click Function to be overriden");
    }
}
