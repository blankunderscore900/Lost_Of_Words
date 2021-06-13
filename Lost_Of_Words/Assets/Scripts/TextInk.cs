using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class TextInk : MonoBehaviour
{
    public TextAsset inkJSON;
    private Story story;

    // Start is called before the first frame update
    void Start()
    {
        story = new Story(inkJSON.text);
        Debug.Log(loadStoryChunk());

        for(int i = 0; i < story.currentChoices.Count; i++)
        {
            Debug.Log(story.currentChoices[i].text);
        }

        //Debug.Log(story.currentChoices);

        story.ChooseChoiceIndex(0);
        Debug.Log(loadStoryChunk());
        Debug.Log(loadStoryChunk());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    string loadStoryChunk()
    {
        string text = "";
        if (story.canContinue)
        {
            text = story.ContinueMaximally();
        }
        return text;
    }


}
