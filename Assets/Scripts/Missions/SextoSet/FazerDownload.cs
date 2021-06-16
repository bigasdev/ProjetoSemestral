using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FazerDownload : MissionObjective
{
    public FazerDownload(int _quantity) : base(_quantity){
        nome = "Faça o download dos arquivos";
    }
    public override void AddObjetivo()
    {
        DownloadPc.onComplete += OnTask;
    }
    public override void RemoveObjetivo()
    {
        DownloadPc.onComplete -= OnTask;
    }
}
