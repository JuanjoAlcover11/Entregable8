using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    //Array para meter todos los clips de audio
    public AudioClip[] clips;
    //Variable de tipo entero que representa la cancion que esta sonando
    private int song;
    //AudioSource para reproducir los audios
    private AudioSource AudioSource;

    //Array para meter todos los nombres de las canciones
    public string[] songTitles;
    //Texto para el titulo de la cancion
    public TextMeshProUGUI songText;

    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        //Reproduir la primera cancion
        AudioSource.PlayOneShot(clips[song]);
    }

    void Update()
    {
        //Hacemos que aparezca en pantalla el nombre de la cancion que esta sonando
        songText.text = songTitles[song]; 
    }

    public void PauseButtom()
    {
        //Hacemos pausar el audio al pulsar el boton
        AudioSource.Pause();
    }

    public void PlayButtom()
    {
        //Hacemos reproducir el audio al pulsar el boton
        AudioSource.UnPause();
    }

    public void NextButtom()
    {
        //Aumentamos en 1 el valor de la variable para pasar a la siguiente cancion
        song++;
        //Hacemos que si pasamos de la ultima cancion se reproduzca la primera
        if (song >= clips.Length)
        {
            song = 0;
        }
        //Paramos la cancion anterior
        AudioSource.Stop();
        //Hacemos que se reproduzca la nueva
        AudioSource.PlayOneShot(clips[song]);
    }

    public void PreviousButtom()
    {
        //Reducimos en 1 el valor de la variable para pasar a la cancion anterior
        song--;
        //Hacemos que si pasamos de la primera cancion se reproduzca la ultima
        if (song < 0)
        {
            song = clips.Length - 1;
        }
        //Paramos la cancion anterior
        AudioSource.Stop();
        //Hacemos que se reproduzca la nueva
        AudioSource.PlayOneShot(clips[song]);
    }

    public void ShuffleButtom()
    {
        //Paramos la cancion anterior
        AudioSource.Stop();
        //Hacemos que el valor entero sea aleatorio
        song = Random.Range(0, clips.Length);
        //Hacemos que se reproduzca la nueva
        AudioSource.PlayOneShot(clips[song]);

    }
}
