using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{

    [SerializeField] PlayerUIScript playerUIScript;
    [SerializeField] public float healthPoints;
    [SerializeField] public float rescuedCivCount;
    [SerializeField] public PlayerScript _player;
    [SerializeField] public AudioManager _audioManager;
    [SerializeField] private float levelEndCivCount;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        healthPoints = 0;
        levelEndCivCount = 30;
    }

   
    void FixedUpdate()
    {
        playerUIScript.updateHealthUIText(healthPoints);
        playerUIScript.updateRescuedCivUIText(rescuedCivCount);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void setHealthPoints(float hp)
    {
        healthPoints = hp;
    }
    public void increaseRescuedCivilianCount()
    {
        rescuedCivCount++;

        AudioManager.instance.PlaySFXAtPosition("Rescued", _player.transform.position);

        //Debug.Log("a civilian was rescued ");
    }

    public void lowerHealthPoints()
    {
        healthPoints--;
        playerUIScript.updateHealthUIText(healthPoints);
    }
    public void increaseHealthPoints()
    {
        healthPoints++;
        playerUIScript.updateHealthUIText(healthPoints);
    }

    public IEnumerator loadNextLevel(float seconds) //wait seconds for gate animation to end
    {
        Debug.Log("im in");

        if (rescuedCivCount >= levelEndCivCount)
        {
            yield return new WaitForSeconds(seconds);

            loadNextScene();
            Debug.Log("im in 2");
        }
        else
        {
            Debug.Log("There are still many more lives to save!");
        }

    }

    void loadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }




}
