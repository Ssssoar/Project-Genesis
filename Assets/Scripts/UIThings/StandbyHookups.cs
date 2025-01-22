using UnityEngine;
using System.Collections.Generic; //For List

public class StandbyHookups : MonoBehaviour{ //a script in charge of remembering every button that is waiting for a resource to appear before it is hookedup
    //=============SINGLETON
    public static StandbyHookups instance;
    void Awake(){
        if (StandbyHookups.instance != null)
            Destroy(this);
        else
            StandbyHookups.instance = this;
    }
    //=============SINGLETON END

    struct WaitingList{ //it represents a single resource being waited for, and all objects waiting for it as a list
        public string waitingFor;
        public List<IHookupable> onStandby;
        public WaitingList(string id){
            waitingFor = id;
            onStandby = new List<IHookupable>();
        }
    }

    List<WaitingList> waitLists = new List<WaitingList>();

    public void NewStandby(IHookupable standByer, string awaited){
        //check lists if there is one already waiting for this resource
        bool added = false;
        foreach(WaitingList list in waitLists){
            if (list.waitingFor == awaited){
                list.onStandby.Add(standByer);
                added = true;
                break;
            }
        }
        //if there isn't, create it and add it to the lists list.
        if (!added){
            WaitingList newList = new WaitingList(awaited);
            newList.onStandby.Add(standByer);
            waitLists.Add(newList);
        }
    }

    public void NotifyNewResource(string newId){
        foreach (WaitingList list in waitLists){
            if (newId == list.waitingFor){
                foreach(IHookupable button in list.onStandby){
                    button.HookUp(newId);
                }
                waitLists.Remove(list);
                break;
            }
        }
    }
}
