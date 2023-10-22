using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShootingGallery : MonoBehaviour
{
    public GameObject message;
    public GameObject HUD_points;
    public TextMeshProUGUI pointsTxt;
    public Transform shootingPosition;
    public Transform exitPosition;
    public int goalPoints = 0;
    private Transform player;
    private int points = 0;

    public int Points { get => points; set => points = value; }

    private void Update()
    {
        player.GetComponent<FPSController>().enabled = true;
        pointsTxt.text = $"{points} points";
        if (points >= goalPoints)
            Inactive();
    }

    private void Inactive()
    {
        player.GetComponent<FPSController>().enabled = false;
        player.position = exitPosition.position;
        player.GetComponent<CharacterController>().enabled = true;
        HUD_points.SetActive(false);
        points = 0;
    }

    private void Active()
    {
        player.position = shootingPosition.position;
        player.GetComponent<CharacterController>().enabled = false;
        HUD_points.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.transform;
            StartCoroutine(CloseMessage());
            Active();
        }
    }
    private IEnumerator CloseMessage()
    {
        yield return new WaitForSeconds(2f);
        message.SetActive(false);
    }
}
