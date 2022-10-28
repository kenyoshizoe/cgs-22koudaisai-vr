using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PCBController : MonoBehaviour
{
    [SerializeField] SolderHole LEDLeftFootHole;
    [SerializeField] SolderHole LEDRightFootHole;
    [SerializeField] GameObject LED;
    [SerializeField] GameObject holderedLED;
    [SerializeField] GameObject holderedLEDLight;
    [SerializeField] SolderHole resisterLeftFootHole;
    [SerializeField] SolderHole resisterRightFootHole;
    [SerializeField] GameObject resister;
    [SerializeField] GameObject holderedResister;

    [SerializeField] int solderingTime = 100;
    [SerializeField] GameObject pushSwitch;

    [SerializeField] TextMeshProUGUI guideText = default;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip[] voices;

    bool solderCompleted = false;

    enum GameState
    {
        Start, ResisterInserted, LEDInserted, Soldered, Cleared
    }
    GameState gameState = GameState.Start;

    SolderHole[] holes;

    void Start()
    {
        holderedResister.SetActive(false);
        holderedLED.SetActive(false);
        holes = new SolderHole[] { LEDLeftFootHole, LEDRightFootHole, resisterLeftFootHole, resisterRightFootHole };
        foreach (var hole in holes)
        {
            hole.isSoldered = false;
            hole.solderingTime = solderingTime;
        }
    }

    void Update()
    {
        // check insert and snap
        if (LEDLeftFootHole.footTouching && LEDRightFootHole.footTouching && !LEDLeftFootHole.isInserted)
        {
            // snap LED
            Object.Destroy(LED);
            holderedLED.SetActive(true);
            LEDLeftFootHole.isInserted = true;
            LEDRightFootHole.isInserted = true;
        }
        if (resisterLeftFootHole.footTouching && resisterRightFootHole.footTouching && !resisterLeftFootHole.isInserted)
        {
            // snap resister
            Object.Destroy(resister);
            holderedResister.SetActive(true);

            resisterLeftFootHole.isInserted = true;
            resisterRightFootHole.isInserted = true;
        }

        // check solder completed
        if (!solderCompleted)
        {
            bool completed = true;
            foreach (var hole in holes)
            {
                completed &= hole.isSoldered;
            }
            solderCompleted = completed;
        }

        if (solderCompleted)
        {
            holderedLEDLight.SetActive(pushSwitch.GetComponent<Switch>().isPushed);
        }

        switch (gameState)
        {
            case GameState.Start:
                guideText.text = "抵抗を基板に取り付けてください";
                if (resisterLeftFootHole.isInserted)
                {
                    source.PlayOneShot(voices[1]);
                    gameState = GameState.ResisterInserted;
                }
                break;
            case GameState.ResisterInserted:
                guideText.text = "LEDを基板に取り付けてください";
                if (LEDLeftFootHole.isInserted)
                {
                    source.PlayOneShot(voices[2]);
                    gameState = GameState.LEDInserted;
                }
                break;
            case GameState.LEDInserted:
                guideText.text = "基板を裏返し、はんだ付けしてください";
                if (solderCompleted)
                {
                    source.PlayOneShot(voices[3]);
                    gameState = GameState.Soldered;
                }
                break;
            case GameState.Soldered:
                guideText.text = "基盤表側のスイッチを押して、LEDを点灯させてください";
                if (pushSwitch.GetComponent<Switch>().isPushed)
                {
                    source.PlayOneShot(voices[4]);
                    gameState = GameState.Cleared;
                }
                break;
            case GameState.Cleared:
                guideText.text = "ゲームクリア！ 基板の完成です！";
                break;
            default:
                break;
        }
    }
}
