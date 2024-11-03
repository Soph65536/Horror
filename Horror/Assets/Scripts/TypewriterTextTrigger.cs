using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TypewriterTextTrigger : MonoBehaviour
{
    const float SpeedAtEndingPosLerp = 0.01f;
    private Vector3 EndingPlayerPosition = new Vector3(0, 1.5f, 15f);

    [SerializeField] private string displayText;
    [SerializeField] private AudioClip soundToPlay;
    [SerializeField] private Color TextColour;

    [SerializeField] private bool EndsGame;
    [SerializeField] private AudioClip EndingSound;

    private bool EndingGame;

    private TypeWriterSubtitles typeWriterSubtitles;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        EndingGame = false;

        typeWriterSubtitles = GameObject.FindObjectOfType<TypeWriterSubtitles>().GetComponent<TypeWriterSubtitles>();
        audioSource = GameObject.FindFirstObjectByType<PlayerMovement>().GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (EndingGame)
        {
            audioSource.gameObject.transform.position = Vector3.Lerp(audioSource.gameObject.transform.position, EndingPlayerPosition, SpeedAtEndingPosLerp);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //if nothing is currently being displayed in typewritersubtitles then write the text
        if (!typeWriterSubtitles.CurrentlyWritingText)
        {
            if (!EndingGame)
            {
                typeWriterSubtitles.changeTextColour(TextColour);
                typeWriterSubtitles.StartCoroutine("TypeWriteText", displayText);
                audioSource.PlayOneShot(soundToPlay);

                if (EndsGame)
                {
                    if (!EndingGame) { StartCoroutine("EndGame"); }
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    private IEnumerator EndGame()
    {
        EndingGame = true;
        yield return new WaitForSeconds(13f);
        audioSource.PlayOneShot(EndingSound);
        audioSource.gameObject.GetComponentInChildren<Animator>().SetTrigger("Ending");
        yield return new WaitForSeconds(5f);

        Application.Quit();
    }
}
