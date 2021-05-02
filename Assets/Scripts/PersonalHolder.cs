using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


public class PersonalHolder : MonoBehaviour, IMechComponent
{
    [SerializeField] private List<Arsenal> items;

    private Mech mech;

    private Dictionary<Items, GameObject> gameObject_holder;

    [SerializeField]
    public enum Items
    {
        SelectingCircle
    }

    private void Awake()
    {
        FillHolder();
    }

    public void ConnectWithMech(Mech mech)
    {
        this.mech = mech;
        mech.holder = this;
    }

    public void Setup()
    {
        FillHolder();
    }

    public void Activate(Items item)
    {
        gameObject_holder[item].SetActive(true);
    }

    public GameObject GetItem(Items item)
    {
        return gameObject_holder[item];
    }

    private void FillHolder()
    {
        gameObject_holder = new Dictionary<Items, GameObject>();

        for (int i = 0; i < items.Count; i++)
        {
            gameObject_holder.Add(items[i].Item, items[i].Reference);
        }
    }



    [System.Serializable]
    private class Arsenal
    {
        public Items Item;
        public GameObject Reference;
    }
}
