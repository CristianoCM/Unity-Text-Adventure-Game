using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    // Box that shows story text on screen
    [SerializeField] Text storyText;
    // First state of the text
    [SerializeField] State startingState;
    // Main state, what's actually happening now in the game
    private State mainState;

    // Start is called before the first frame update
    void Start()
    {
        UpdateMainState(startingState);
        UpdateStoryTextByMainState();
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        var nextStates = mainState.GetNextStates();

        for (int i = 0; i < nextStates.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                UpdateMainState(nextStates[i]);
                UpdateStoryTextByMainState();
            }
        }
    }

    private void UpdateMainState(State newState)
    {
        if (newState != null)
            mainState = newState;
    }

    private void UpdateStoryTextByMainState()
    {
        string newTxt = mainState.GetStateStory();

        if (!storyText.text.Equals(newTxt))
            storyText.text = newTxt;
    }
}
