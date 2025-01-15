using UnityEngine;

[CreateAssetMenu(fileName = "Button", menuName = "Scriptable Objects/Button")]
public class UIButton : ScriptableObject{
    public string id;
    public string buttonText;
    public AdderButton button;
}
