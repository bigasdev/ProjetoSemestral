using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : Interactable
{
    [SerializeField] Transform setPoint, cameraPoint;
    [SerializeField] SpriteRenderer lastSprite, nextSprite;
    [SerializeField] float cameraSize;
    [SerializeField] AudioClip som, ambient;
    Coroutine door;
    public override void Action()
    {
        door = StartCoroutine(Door());
    }
    IEnumerator Door(){
        SoundManager.Instance.PlaySfx(som);
        Engine.Instance.currentState = States.WAIT_UPDATE;
        Player.Instance.StopEverything();
        yield return new WaitForSeconds(som.length);
        var player = FindObjectOfType<Player>();
        var camera = GameObject.Find("Main Camera");
        var minimapCamera = GameObject.Find("MinimapCamera");
        camera.transform.position = cameraPoint.position;
        minimapCamera.transform.position = cameraPoint.position;
        camera.GetComponent<Camera>().orthographicSize = cameraSize;
        player.transform.position = setPoint.position;
        lastSprite.color = new Color(0.04313726f, 0.02352941f, 0.09019608f,1f);
        nextSprite.color = new Color(0.04313726f, 0.02352941f, 0.09019608f,0f);
        Engine.Instance.currentState = States.GAME_UPDATE;
        if(ambient != null) {
            SoundManager.Instance.ambient.Stop();
            SoundManager.Instance.PlayAmbient(ambient);
        }
        Desinteract();
    }
}
