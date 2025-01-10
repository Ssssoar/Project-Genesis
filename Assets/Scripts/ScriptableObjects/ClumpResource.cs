using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "ClumpResource", menuName = "Scriptable Objects/ClumpResource")]
//a group of resources with a single button that will generate one of them, depending on ammount of a parent resource
public class ClumpResource : SimpleResource{
    [System.Serializable]
    public struct ClumpMember{
        [SerializeField] Resource res;
        [SerializeField] int price; //cost of the source resource needed to generate this as opposed to other clumps
    }

    public Resource costResource; //the resource that is spent to try and generates sons
    public ClumpMember[] clumpResources;
    
    
}
