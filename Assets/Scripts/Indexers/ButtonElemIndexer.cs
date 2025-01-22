using UnityEngine;
using System.Collections.Generic; //For dictionary

public class ButtonElemIndexer : MonoBehaviour{
    public static ButtonElemIndexer instance;
    void Awake(){
        if (ButtonElemIndexer.instance != null)
            Destroy(this);
        else
            ButtonElemIndexer.instance = this;
    }


    Dictionary<string , ButtonElem> buttonIndex = new Dictionary<string , ButtonElem>();
    
    public void AddButton(ButtonElem button){
        buttonIndex.Add(button.genAsset.id , button);
    }

    public ButtonElem GetButton(string resID){
        try{
            return buttonIndex[resID];
        }catch{
            return null;
        }
    }
}
