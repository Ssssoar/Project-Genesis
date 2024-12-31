using UnityEngine;
using UnityEngine.UIElements;

public class SampleUIWorker : MonoBehaviour{
    [SerializeField] UIDocument uiDoc;
    Button btn;
    int count;
    void OnEnable(){
        btn = uiDoc.rootVisualElement.Q("Button") as Button;
        btn.RegisterCallback<ClickEvent>(CountOne);
    }

    void OnDisable(){
        btn.UnregisterCallback<ClickEvent>(CountOne);
    }

    void CountOne(ClickEvent evt){
        count++;
        btn.text = "Count " + count;
    }
}
