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

        if (nextStates == null) return;

        int sizeNextStates = nextStates.Length;

        if (sizeNextStates <= 0) return;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (sizeNextStates > 0)
                UpdateMainState(nextStates[0]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (sizeNextStates > 1)
                UpdateMainState(nextStates[1]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (sizeNextStates > 2)
                UpdateMainState(nextStates[2]);
        }

        UpdateStoryTextByMainState();
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
