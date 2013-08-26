// Type: NiCoding_Development_Library.Voice_Operations.Text2Speech.Text2SpeechGeneric
// Assembly: NDL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D03E96A6-C992-4E9A-BE57-D6DDB9E706CB
// Assembly location: C:\Users\Gigawiz\Desktop\NDL.dll

using System.Speech.Synthesis;

namespace NiCoding_Development_Library.Voice_Operations.Text2Speech
{
  public class Text2SpeechGeneric
  {
    public static void speakText(string text)
    {
      SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
      speechSynthesizer.SetOutputToDefaultAudioDevice();
      speechSynthesizer.Speak(text);
      if (speechSynthesizer == null)
        return;
      speechSynthesizer.Dispose();
    }

    public static void speakTextAsync(string text)
    {
      SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
      speechSynthesizer.SetOutputToDefaultAudioDevice();
      speechSynthesizer.SpeakAsync(text);
      if (speechSynthesizer == null)
        return;
      speechSynthesizer.Dispose();
    }
  }
}
