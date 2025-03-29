using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public static int oranges = 0;
    public static int kiwis = 0;
    public static int strawberries = 0;
    public static int princessItems = 0;
    public int totalGoal = 30;
    [SerializeField] private Text orangesText;
    [SerializeField] private Text kiwisText;
    [SerializeField] private Text strawberriesText;
    [SerializeField] private Text princessItemsText;
    private SceneLoader sceneLoader;
    [SerializeField] private AudioSource collectionSoundEffect;
    [SerializeField] private AudioClip megaOrangeSound;
    [SerializeField] private AudioClip megaStrawberrySound;
    [SerializeField] private AudioClip kiwiSound;
    [SerializeField] private AudioClip strawberrySound;
    [SerializeField] private AudioClip princessObjects;
    private void Start()
    {
        sceneLoader = SceneLoader.Instance;
        oranges = PlayerPrefs.GetInt("OrangesCount", 0);
        orangesText.text = "Oranges: " + oranges;
        if (kiwisText != null)
        {
            kiwis = PlayerPrefs.GetInt("KiwisCount", 0);
            kiwisText.text = "Kiwis: " + kiwis;
        }
        strawberries = PlayerPrefs.GetInt("StrawberriesCount", 0);
        strawberriesText.text = "Strawberries: " + strawberries;

        princessItems = PlayerPrefs.GetInt("PrincessItemsCount", 0);
        princessItemsText.text = "Princess Items: " + princessItems;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Oranges"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            oranges++;
            orangesText.text = "Oranges: " + oranges;
            
            PlayerPrefs.SetInt("OrangesCount", oranges);
        }
        if (collision.gameObject.CompareTag("MegaOrange"))
        {
            collectionSoundEffect.PlayOneShot(megaOrangeSound);
            Destroy(collision.gameObject);
            oranges += 20;
            orangesText.text = "Oranges: " + oranges;
            PlayerPrefs.SetInt("OrangesCount", oranges);
        }
        if (collision.gameObject.CompareTag("Kiwis"))
        {
            collectionSoundEffect.PlayOneShot(kiwiSound);
            Destroy(collision.gameObject);
            kiwis++;
            kiwisText.text = "Kiwis: " + kiwis;
            PlayerPrefs.SetInt("KiwisCount", kiwis);
        }
        if (collision.gameObject.CompareTag("MegaKiwi"))
        {
            collectionSoundEffect.PlayOneShot(kiwiSound);
            Destroy(collision.gameObject);
            kiwis += 20;
            kiwisText.text = "Kiwis: " + kiwis;
            PlayerPrefs.SetInt("KiwisCount", kiwis);
        }
        if (collision.gameObject.CompareTag("Strawberry"))
        {
            collectionSoundEffect.PlayOneShot(strawberrySound); // add this
            Destroy(collision.gameObject);
            strawberries++;
            strawberriesText.text = "Strawberries: " + strawberries;
            PlayerPrefs.SetInt("StrawberriesCount", strawberries);
        }
        if (collision.gameObject.CompareTag("MegaStrawberry"))
        {
            Debug.Log("MEGA STRAWBERRY COLLECTED!");
            collectionSoundEffect.PlayOneShot(megaStrawberrySound);
            Destroy(collision.gameObject);
            strawberries += 20;
            strawberriesText.text = "Strawberries: " + strawberries;
            PlayerPrefs.SetInt("StrawberriesCount", strawberries);
        }
        if (collision.gameObject.CompareTag("PrincessItem"))
        {
            collectionSoundEffect.PlayOneShot(princessObjects);
            Destroy(collision.gameObject);
            princessItems++;
            princessItemsText.text = "Princess Items: " + princessItems;
            PlayerPrefs.SetInt("PrincessItemsCount", princessItems);
            PlayerPrefs.Save();
        }
        if (collision.gameObject.CompareTag("Finish"))
        { 
            Debug.Log("FINISH LINE!");
            if (SceneManager.GetActiveScene().buildIndex == 11)
            {
                sceneLoader.CheckWinConditions(oranges, kiwis, strawberries, princessItems);
            }
        }
        
       
    }
    public static void Reset()
    {
        PlayerPrefs.SetInt("OrangesCount", 0);
        PlayerPrefs.SetInt("KiwisCount", 0);
        PlayerPrefs.SetInt("StrawberriesCount", 0);
        PlayerPrefs.SetInt("PrincessItemsCount", 0);
        PlayerPrefs.Save();
    }

}
