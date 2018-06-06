using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public PlayerController playerShip;
    public RockHolder rockHolder;
    public OrbHolder orbHolder;
    public GameObject selectionCanvas;
    public GameObject mainMenu;
	public AudioSource gamemusic;
    public AudioSource finalfantasy;
    public Follow follow;
    public GameObject endGame;
    public GameObject player;

    void Start () {
	
	}

	void Update () {
        Debug.Log(PlayerController.health);
        if (PlayerController.health <= 0 && playerShip.enabled)
        {
            
            endGame.SetActive(true);
            playerShip.enabled = false;
            Destroy(player);
        }
           

	}

	public void OnStartPressed()
	{

		mainMenu.SetActive (false);
		playerShip.enabled = true;
        rockHolder.enabled = true;
        orbHolder.enabled = true;
        gamemusic.enabled = true;
        finalfantasy.enabled = true;
        selectionCanvas.SetActive(false);
        follow.enabled=true;
    }
}
