using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.UIElements;

enum colorID { blue, green, red, grey }
public class MenuOption : MonoBehaviour
{
    List<string> colornamelist = new List<string>();
    [SerializeField]Sprite[] sequence = new Sprite[4];
    [SerializeField] Image childImage;
    colorID color;
    List<AudioClip> cliplist = new List<AudioClip>();
    string imageName;
    string[] nameParts;
    string namePartType;
    Button btn;
    // Start is called before the first frame update
    void Start()
    {
        colornamelist.Add(colorID.blue.ToString());
        colornamelist.Add(colorID.green.ToString());
        colornamelist.Add(colorID.red.ToString());
        colornamelist.Add(colorID.grey.ToString());

        btn = GetComponentInChildren<Button>();
        
        imageName = childImage.sprite.name;
        nameParts = imageName.Split('_');
        

        if(nameParts.Length > 0)
        {
            
           // sequence[imageName.Contains(color.ToString())?(int)]
            if(nameParts.Length > 2) 
            {
                namePartType = nameParts[0] + "_" + nameParts[1];
            }
            else
            {
                namePartType = nameParts[0];
            }
            Debug.Log(namePartType);
            //sequence[imageName.Contains(colorID.blue.ToString()) ? (int)colorID.blue : imageName.Contains(colorID.green.ToString()) ? (int)colorID.green : imageName.Contains(colorID.red.ToString()) ? (int)colorID.red : (int)colorID.grey] =childImage.sprite;
            for (int i = 0; i < sequence.Length; i++)
            {
                string filename = namePartType + "_" + colornamelist[i];
                Debug.Log(filename);
                Sprite[] sheet = Resources.LoadAll<Sprite>("Images/Button");
                foreach(Sprite sprite in sheet)
                {
                    if (sprite.name == filename)
                    {
                        
                        sequence[i] = sprite;
                    }
                }
                

               

            }
                
        }
        //catch reload button
        if (imageName.Contains("reload")||imageName.Contains("refresh")||imageName.Contains("restart"))
        {
            
            btn?.onClick.AddListener(ReloadDialog);
        }

        // catch right button
        if(imageName.Contains("right"))
        { 
            btn.onClick.AddListener(StartDialog);
        }
        // catch bin button
        if(!(imageName.Contains("right")|imageName.Contains("reload")||imageName.Contains("refresh")||imageName.Contains("restart"))) 
        {
            Debug.Log("Not a known button");
            btn.onClick.AddListener(PlayAudio);
        }
        


    }
    void ReadNameParts()
    {
        imageName = childImage.sprite.name;
        nameParts = imageName.Split('_');
    }
    private void PlayAudio()
    {
            Debug.Log(nameParts[nameParts.Length-1]);
            if (nameParts[nameParts.Length - 1]=="green")
            {
                EventControl.OnVoice?.Invoke(Resources.Load<AudioClip>("Audio/" + namePartType + "_warning"));
            //    AudioSource.PlayClipAtPoint(Resources.Load<AudioClip>("Audio/"+namePartType+"_warning"), Camera.main.transform.position);
                btn.image.sprite = sequence[0];

            }
            else if (nameParts[nameParts.Length - 1] == "blue")
            {
                EventControl.OnVoice?.Invoke(Resources.Load<AudioClip>("Audio/" + namePartType + "_angry"));
                //AudioSource.PlayClipAtPoint(Resources.Load<AudioClip>("Audio/" + namePartType + "_angry"), Camera.main.transform.position);
                btn.image.sprite = sequence[2];
            }
            else if (nameParts[nameParts.Length - 1] == "red")
            {
                EventControl.OnVoice?.Invoke(Resources.Load<AudioClip>("Audio/" + namePartType + "_block"));
    //            AudioSource.PlayClipAtPoint(Resources.Load<AudioClip>("Audio/" + namePartType + "_block"), Camera.main.transform.position);
                btn.image.sprite = sequence[3];
            }
            else if (nameParts[nameParts.Length - 1] == "grey")
            {
            EventControl.OnVoice?.Invoke(Resources.Load<AudioClip>("Audio/" + "nope"));
                //AudioSource.PlayClipAtPoint(Resources.Load<AudioClip>("Audio/" + "nope"), Camera.main.transform.position);
                //btn.image.sprite = sequence[3];
            }
        ReadNameParts();
    }
    private void StartDialog()
    {
        SceneManager.LoadSceneAsync("Introduction1");
    }

    void ReloadDialog()
    {
        SceneManager.LoadSceneAsync(0);
    }
   
}
