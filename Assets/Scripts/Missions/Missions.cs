using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Missions
{
    public static Dictionary<string, Mission> primeiroSet = new Dictionary<string, Mission>(){
        {"Encontrarchefe", 
        new Mission("Encontre a chefe", "Vá encontrar a chefe na praça de alimentação", 
        new EncontrarChefe(1))}
    };
    public static Dictionary<string, Mission> segundoSet = new Dictionary<string, Mission>(){
        {"ConversarClientes", 
        new Mission("Converse com os clientes", "Vá conversar com os clientes", 
        new ConversaComClientes(2))} ,
        {"RecolherLampadas", 
        new Mission("Recolha as lâmpadas caidas", "Vá recolher as lâmpadas caidas no chão", 
        new PegarLampadasCaidas(5))}     
    };
    public static Dictionary<string, Mission> terceiroSet = new Dictionary<string, Mission>(){
        {"AcharColar", 
        new Mission("Ache o colar na sala da bagunça", "Vá procurar o colar", 
        new AcharColar(1))},
        {"ConversarClientes", 
        new Mission("Converse com os clientes", "Vá conversar com os clientes", 
        new ConversaComClientes(2))} ,
        {"RecolherLampadas", 
        new Mission("Recolha as lâmpadas caidas", "Vá recolher as lâmpadas caidas no chão", 
        new PegarLampadasCaidas(5))}     
    };

    public static Dictionary<string, Mission> quartoSet = new Dictionary<string, Mission>(){
        {"EncontrarBilhetes", 
        new Mission("Encontre os bilhetes perdidos!", "Vá procurar os bilhetes", 
        new BilhetesPerdidos(3))},
        {"ConversarClientes", 
        new Mission("Converse com os clientes", "Vá conversar com os clientes", 
        new ConversaComClientes(2))} ,
        {"ConversarNaruto", 
        new Mission("Converse com o npc vestido de naruto", "Vá conversar com o naruto", 
        new ConversarNaruto(1))}     
    };

    public static Dictionary<string, Mission> quintoSet = new Dictionary<string, Mission>(){
        {"ConsertarEnergia", 
        new Mission("Conserte a energia do shopping!", "Vá consertar a energia", 
        new ConsertarEnergia(1))},
        {"ConversarClientes", 
        new Mission("Converse com os clientes", "Vá conversar com os clientes", 
        new ConversaComClientes(2))} ,
        {"EncontreChefe", 
        new Mission("Encontre a chefe na sala do almoxarifado", "Vá conversar com a chefe", 
        new EncontreAChefeNoAlmoxerifado(1))}     
    };

    public static Dictionary<string, Mission> sextoSet = new Dictionary<string, Mission>(){
        {"ConsertarEnergia", 
        new Mission("Conserte a energia do shopping!", "Vá consertar a energia", 
        new ConsertarEnergia(1))},
        {"ConversarClientes", 
        new Mission("Converse com os clientes", "Vá conversar com os clientes", 
        new ConversaComClientes(2))} ,
        {"FazerDownload", 
        new Mission("Faça o download dos arquivos no escritório", "Vá fazer o download", 
        new FazerDownload(1))},
        {"Jantar", 
        new Mission("Vá jantar na praça de alimentação", "Vá jantar", 
        new Jantar(1))}     
    };
}
