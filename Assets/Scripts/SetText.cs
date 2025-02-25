using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetText : MonoBehaviour
{
    
    public TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ChangeText(string name)
    {
        textMeshPro.SetText(name);
    }
    // Update is called once per frame
    void Update()
    {
        if(textMeshPro != null && textMeshPro.text == "New Text")
        {
            textMeshPro.SetText("Brak wybranej karty");
            
        }
       
    }
}
