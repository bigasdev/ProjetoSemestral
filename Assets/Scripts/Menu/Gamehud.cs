using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gamehud : MonoBehaviour
{
    public static Gamehud hud;
    [SerializeField] Button tab;
    [SerializeField] Text[] tasks;
    List<Mission> missoes = new List<Mission>();
    bool isShowing = false;
    private void Start() {
        tab.onClick.AddListener(() => InitializeTab(Player.Instance.currentMissions));
        hud = this;
    }
    private void Update() {
        tab.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(tab.GetComponent<RectTransform>().anchoredPosition, 
                                                                          new Vector2(tab.GetComponent<RectTransform>().anchoredPosition.x, y : isShowing ? 85 : -55), Time.deltaTime * 4);
    }
    public void InitializeTab(List<Mission> missions){
        isShowing = !isShowing;
        for(int i = 0; i < tasks.Length; i++){
            tasks[i].text = "";
        }
        if(missions == null) return;
        for(int i = 0; i < missions.Count; i++){
            tasks[i].text = missions[i].description +" "+$"{missions[i].objetivo.quantity}" + "/" + $"{missions[i].objetivo.maxQuantity}";
        }
    }
    public void RefreshTab(List<Mission> missions){
        for(int i = 0; i < tasks.Length; i++){
            tasks[i].text = "";
        }
        isShowing = true;
        if(missions == null) return;
        for(int i = 0; i < missions.Count; i++){
            tasks[i].text = missions[i].description +" "+$"{missions[i].objetivo.quantity}" + "/" + $"{missions[i].objetivo.maxQuantity}";
        } 
    } 
    public void HideTab(){
        isShowing = false;
    }
}
