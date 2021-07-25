using MEC;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] TMP_Text titleText;
    [SerializeField] TMP_Text descriptionText;

    [SerializeField] GameObject fadingMaskGO;
    [SerializeField] float fadeInTime;
    [SerializeField] float minTransparency;
    [SerializeField] float maxTransparency;

    public IEnumerator<float> GameOver()
    {
        yield return Timing.WaitUntilDone(Timing.RunCoroutine(FadeObjectsBehindMenu()));
        SetGameOverText();
        gameObject.SetActive(true);
        // AudioManager.instance.musicSource.Pause();
        Debug.Log("Game over!");
    }

    public void Restart()
    {
        Timing.KillCoroutines();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        // ResetStaticVariables() delegate in GameManager.cs on scene unload
    }

    public void GoToMainMenu()
    {
        Timing.KillCoroutines();
        SceneManager.LoadSceneAsync(Constants.mainMenuBuildIndex);
        // ResetStaticVariables() delegate in GameManager.cs on scene unload
    }

    public IEnumerator<float> FadeObjectsBehindMenu()
    {
        fadingMaskGO.SetActive(true);
        float timer = 0;
        while (timer < fadeInTime)
        {
            Color maskColor = fadingMaskGO.GetComponent<Image>().color;
            fadingMaskGO.GetComponent<Image>().color = new Color(maskColor.r, maskColor.g, maskColor.b, Mathf.Lerp(minTransparency, maxTransparency, timer / fadeInTime));
            timer += Time.deltaTime;
            yield return Timing.WaitForOneFrame;
        }
    }

    public void SetGameOverText()
    {
        List<int> winningPlayers = PlayerController.GetWinningPlayers();
        if (winningPlayers.Count == 1)
        {
            descriptionText.text = $"Player {winningPlayers[0]} won!";
        }
        else
        {
            descriptionText.text = "It's a draw!";
        }
    }
}