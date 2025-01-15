using UnityEngine;
using System.Collections.Generic; //For dictionary

public class DisplayIndexer : MonoBehaviour{
    public static DisplayIndexer instance;
    void Awake(){
        if (DisplayIndexer.instance != null)
            Destroy(this);
        else
            DisplayIndexer.instance = this;
    }


    Dictionary<string , BarDisplay> displayIndex = new Dictionary<string , BarDisplay>();
    
    public void AddDisplay(BarDisplay display){
        displayIndex.Add(display.resource.id , display);
    }

    public BarDisplay GetDisplay(string resID){
        return displayIndex[resID];
    }
}
