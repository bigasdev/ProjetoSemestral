using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Engine : MonoBehaviour
{
    public NotificationController notifications;
    public Volume postProcessing;
    private static Engine instance;
    public static Engine Instance{
        get{
            if(instance == null){
                instance = FindObjectOfType<Engine>();
            }
            return instance;
        }
    }
    [SerializeField] Light2D globalLight;
    [SerializeField] List<Light2D> lights;
    public States currentState;
    [SerializeField] AudioClip nightOst;
    [SerializeField] GameObject dialogo;
    [SerializeField] GameObject cutsceneFinal;
    [SerializeField] DialogoObject _dialogo;
    
    float tiltTimer;
    bool night;
    public Dictionary<string, Dictionary<string, Mission>> missionsContainer = new Dictionary<string, Dictionary<string, Mission>>();
    Missions holder;
    private void Start() {
        GetLights();
        holder = new Missions();
        missionsContainer.Add("primeiroSet", holder.primeiroSet);
        missionsContainer.Add("segundoSet", holder.segundoSet);
        missionsContainer.Add("terceiroSet", holder.terceiroSet);
        missionsContainer.Add("quartoSet", holder.quartoSet);
        missionsContainer.Add("quintoSet", holder.quintoSet);
        missionsContainer.Add("sextoSet", holder.sextoSet);
        //StartCoroutine(waitForDialogue());
        StartCoroutine(waitForCutscene());
    }
    IEnumerator waitForDialogue(){
        yield return new WaitForSeconds(1f);
        var d = Instantiate(dialogo);
        d.GetComponent<Dialogo>().Initialize("Chefe", "", null, _dialogo);
    }
    IEnumerator waitForCutscene(){
        yield return new WaitForSeconds(5f);
        Instantiate(cutsceneFinal);
    }

    void GetLights(){
        var _lights = FindObjectsOfType<Light2D>();
        foreach(Light2D _light in _lights){
            lights.Add(_light);
        }
        for(int i = 0; i < lights.Count; i++){
            if(lights[i].lightType == Light2D.LightType.Global) lights.Remove(lights[i]);
        }
    }

    public void SetNight(){
        globalLight.intensity = .25f;
        night = true;
        if(postProcessing.profile.TryGet<ChromaticAberration>(out var c)){
            c.active = true;
        }
        if(postProcessing.profile.TryGet<FilmGrain>(out var f)){
            f.active = true;
        }
        if(postProcessing.profile.TryGet<Vignette>(out var v)){
            v.active = true;
        }
        SoundManager.Instance.PlayOst(nightOst);
        SoundManager.Instance.ChangeVolume("Ost", .035f);
    }
    public void SetDay(){
        globalLight.intensity = 1f;
        night = false;
        if(postProcessing.profile.TryGet<ChromaticAberration>(out var c)){
            c.active = false;
        }
        if(postProcessing.profile.TryGet<FilmGrain>(out var f)){
            f.active = false;
        }
        if(postProcessing.profile.TryGet<Vignette>(out var v)){
            v.active = false;
        }
        SoundManager.Instance.StopOst();
        SoundManager.Instance.ChangeVolume("Ost", .035f);
    }
    
    void TiltLight(){
        tiltTimer += Time.deltaTime;

        if(tiltTimer <= 3.5f) return;

        var random = Random.Range(0, lights.Count);
        StartCoroutine(TiltLightAction(random));
        tiltTimer = 0;
    }
    IEnumerator TiltLightAction(int light){
        lights[light].intensity = .5f;
        yield return new WaitForSeconds(.1f);
        lights[light].intensity = .25f;
        yield return new WaitForSeconds(.1f);
        lights[light].intensity = .5f;
        yield return new WaitForSeconds(.1f);
        lights[light].intensity = 0f;
        yield return new WaitForSeconds(.5f);
        lights[light].intensity = 1f;
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Alpha0)){
            SetNight();
        }
        
        if(night) TiltLight();
    }
}
public enum States{
    GAME_UPDATE,
    WAIT_UPDATE,
    CUTSCENE,
    MINIGAME,
    DIALOGO,
    PAUSE
}
