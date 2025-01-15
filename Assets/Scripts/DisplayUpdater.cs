using UnityEngine;

public class DisplayUpdater : MonoBehaviour{
    public static DisplayUpdater instance;
    void Awake(){
        if (DisplayUpdater.instance != null)
            Destroy(this);
        else
            DisplayUpdater.instance = this;
    }


    [Header("Parameters")]
    [SerializeField] float autoUpdateTime = 1;

    [Header("Variables")]
    float timer;

    void Start(){
        timer = autoUpdateTime;
    }

    // Update is called once per frame
    void Update(){
        timer -= Time.deltaTime;
        if (timer <= 0f){
            timer += autoUpdateTime;
            UpdateAllDisplays();
        }
    }

    void UpdateAllDisplays(){
        foreach (BarDisplay display in DisplayIndexer.instance.GetAllDisplays()){
            UpdateDisplay(display);
        }
    }

    public void UpdateDisplay(BarDisplay display){
        display.UpdateAll();
    }

    public void UpdateDisplay(string id){
        UpdateDisplay( DisplayIndexer.instance.GetDisplay(id) );
    }
}
