using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestView : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;


    private void Awake()
    {
        //    inputField.onValidateInput += OnValidateInput;
        inputField.contentType = TMP_InputField.ContentType.Custom;
        inputField.inputType = TMP_InputField.InputType.Standard;
        inputField.keyboardType = TouchScreenKeyboardType.ASCIICapable;
        //inputField.characterValidation = TMP_InputField.CharacterValidation.Alphanumeric;
        inputField.characterValidation = TMP_InputField.CharacterValidation.CustomValidator;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private char OnValidateInput(string test, int charIndex, char addedChar)
    {
        // ‘SŠp=>”¼Šp(ascii‚É•ÏŠ·
        int code = System.Convert.ToInt32(addedChar);
        if( code>=0xff01 && code <= 0xff5e)
        {
            code = code - 0xff01 + 0x0021;
            addedChar = System.Convert.ToChar(code);
        }
        // 0-9,A-Z,a-z ‚Ì‚Æ‚«
        if( (code>=0x30 && code<=0x39)
         || (code>=0x41 && code<=0x5a)
         || (code>=0x61 && code<=0x7a))
        {
            return char.ToUpper(addedChar);
        }
        // ‚»‚êˆÈŠO‚Í“ü—Í‚È‚µ.
        return '\0';
    }
}
