using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
//This script goes on every slot in the inventory


public class StoreSlot : MonoBehaviour, IPointerClickHandler
{
    public GameObject item;
    public string ID;
    public double value;
    public string type;
    public bool empty;
    public Transform slotIconGO;
    public Sprite icon;
    GameObject shopMenu;
    [SerializeField]
    private TextMeshProUGUI dmgvalue;
    [SerializeField]
    private TextMeshProUGUI costvalue;
    public GameObject ItemStore;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        try 
        {
        UpdateStats(item);
        }
        catch { 
        }//Slot is blank

    }

     void Start()
    {
        slotIconGO = transform.GetChild(0);
        shopMenu=   GameObject.Find("Ui/Shop/ItemStats");//Gets ui
        dmgvalue = shopMenu.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        costvalue = shopMenu.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        ItemStore = GameObject.FindGameObjectWithTag("ItemStoreage");//Gets where item is storaged
        
    }

    public void UpdateSlot() 
    {
        this.transform.GetChild(0).GetComponent<Image>().sprite = icon;
     //   Debug.Log("Item "+item.name);
    }

    private void UpdateStats(GameObject item)
    {
       // Debug.Log("SLot " + item.name);
       
        costvalue.SetText(item.GetComponent<ItemInfo>().cost.ToString());
        dmgvalue.SetText(item.GetComponent<ItemInfo>().value.ToString());
        for(int i=0;i< ItemStore.transform.childCount;i++) { //Destroys old objects, <---- Wipes item from slot needs fix
       
            Destroy(ItemStore.transform.GetChild(i).gameObject);
        }
        GameObject clone = Instantiate(item);
        clone.transform.SetParent(ItemStore.transform, true);//Sets as child of ItemStorage
    }


}

