using TMPro;
using UnityEngine;

[CreateAssetMenu(
    fileName = "UpperLetterValidator",
    menuName = "TextMeshPro/Create Upper Letter Validator",
    order = 0
)]
public class TMP_UpperLetterValidator : TMP_InputValidator
{
    // 入力された文字のチェックと変換
    public override char Validate(ref string text, ref int pos, char ch)
    {
        // 全角=>半角(asciiに変換
        int code = System.Convert.ToInt32(ch);
        if (code >= 0xff01 && code <= 0xff5e)
        {
            code = code - 0xff01 + 0x0021;
            ch = System.Convert.ToChar(code);
        }
        // 0-9,A-Z,a-z のとき
        if ((code >= 0x30 && code <= 0x39)
         || (code >= 0x41 && code <= 0x5a)
         || (code >= 0x61 && code <= 0x7a))
        {
            return char.ToUpper(ch);
        }
        // それ以外は入力なし.
        return '\0';
    }
}

