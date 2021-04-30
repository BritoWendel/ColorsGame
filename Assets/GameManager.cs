using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    //variáveis para armazenar os arquivos de audio que serão tocados
    public AudioClip audioVermelho, audioRosa, audioLaranja, audioBranco, audioAzul, audioAmarelo, audioVerde, audioPreto;
    public Sprite[] images; //variaveis para guardar as figuras
    public Sprite Duvida, Triste, Feliz;

    private AudioSource AudioSource; //objeto que recebe audio e toca
    public Image Imagem; //objeto que recebe a figura que será mostrada
    public Button btnVermelho, btnRosa, btnLaranja, btnAzul, btnAmarelo, btnVerde, btnPreto, btnBranco;
    public Image Expressoes;

    private bool Jogar = true;
    private Cores CorDoBotao = Cores.nenhuma;
    private Cores CorDaImagem = Cores.nenhuma;
    private float tempo = 0;

    private void Start()//método start é chamado quando a cena é iniciada
    { 
        AudioSource = GetComponent<AudioSource>(); //obtem o objeto AudioSource
    }
    private void Update()
    {
        if (Jogar)
        {
            // sorteia imagem e determina as cores
            Expressoes.sprite = Duvida;
            int n = Random.Range(0, 23);
            Imagem.sprite = images[n];
            DeterminarCorDaImagem(n);
            HabilitarBotoes(true);
            Jogar = false;
        }
        if (CorDoBotao != Cores.nenhuma)
        {
            //espera até se apertado a cor certa
            if (CorDaImagem == CorDoBotao)
            {
                Expressoes.sprite = Feliz;
                HabilitarBotoes(false);
                tempo += Time.deltaTime;
                if (tempo > 3) //quando acertado espera tres segundo e reinicia o jogo
                {
                    ResetarCores();
                    Jogar = true;
                    tempo = 0;
                }
            }
            else
            {
                Expressoes.sprite = Triste;
            }
        }
    }
    void ResetarCores()
    {
        CorDoBotao = Cores.nenhuma;
        CorDaImagem = Cores.nenhuma;
    }
    void DeterminarCorDaImagem(int n)
    {
        bool vermelho = n == 0 || n == 3 || n ==14;
        bool amarelo = n == 1 || n == 10 || n == 17;
        bool azul = n == 2 || n == 16 || n == 19;
        bool laranja = n == 4 || n == 6 || n == 12;
        bool branco = n == 5 || n == 13 || n == 15;
        bool preto = n == 7 || n == 9 || n == 11;
        bool rosa = n == 8 || n == 18 || n == 22;
        bool verde = n == 20 || n == 21 || n == 23;
        if (vermelho)
            CorDaImagem = Cores.vermelho;
        else if (amarelo)
            CorDaImagem = Cores.amarelo;
        else if (azul)
            CorDaImagem = Cores.azul;
        else if (laranja)
            CorDaImagem = Cores.laranja;
        else if (branco)
            CorDaImagem = Cores.branco;
        else if (preto)
            CorDaImagem = Cores.preto;
        else if (rosa)
            CorDaImagem = Cores.rosa;
        else if (verde)
            CorDaImagem = Cores.verde;
        else
            CorDaImagem = Cores.nenhuma;
    }
    void HabilitarBotoes(bool value)
    {
        //value = true or false para habilitar ou o oposto
        btnVermelho.enabled = value;
        btnRosa.enabled = value; 
        btnLaranja.enabled = value;
        btnAzul.enabled = value; 
        btnAmarelo.enabled = value; 
        btnVerde.enabled = value; 
        btnPreto.enabled = value; 
        btnBranco.enabled = value;
    }
    public void Tocar(int audio)
    {
        //funcão que define o arquivo de audio no AudioSource e tocao  audio quando um botão é precionado
        if (audio == 0)
        {
            AudioSource.clip = audioVermelho;
            CorDoBotao = Cores.vermelho;
        }
        else if (audio == 1)
        {
            AudioSource.clip = audioRosa;
            CorDoBotao = Cores.rosa;
        }
        else if (audio == 2)
        {
            AudioSource.clip = audioLaranja;
            CorDoBotao = Cores.laranja;
        }
        else if (audio == 3)
        {
            AudioSource.clip = audioBranco;
            CorDoBotao = Cores.branco;
        }            
        else if (audio == 4)
        {
            AudioSource.clip = audioAzul;
            CorDoBotao = Cores.azul;
        }            
        else if (audio == 5)
        {
            AudioSource.clip = audioAmarelo;
            CorDoBotao = Cores.amarelo;
        }
        else if (audio == 6)
        {
            AudioSource.clip = audioVerde;
            CorDoBotao = Cores.verde;
        }            
        else if (audio == 7)
        {
            AudioSource.clip = audioPreto;
            CorDoBotao = Cores.preto;
        }
        else
        {
            //trocar para outro audio default futuramente
            AudioSource.clip = null;
            CorDoBotao = Cores.nenhuma;
        }
        if(AudioSource.clip != null)
            AudioSource.Play();
    }
}
public enum Cores
{
    vermelho, 
    rosa, 
    laranja, 
    azul, 
    amarelo, 
    verde, 
    preto, 
    branco,
    nenhuma
}
