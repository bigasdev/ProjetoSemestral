using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conta : MonoBehaviour
{
    private static Conta instance;
    public static Conta Instance{
        get{
            if(instance == null){
                instance = FindObjectOfType<Conta>();
            }
            return instance;
        }
    }

    public bool logado;
}
