// Type: NiCoding_Development_Library.Voice_Operations.Text2Speech.Text2SpeechMale
// Assembly: NDL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D03E96A6-C992-4E9A-BE57-D6DDB9E706CB
// Assembly location: C:\Users\Gigawiz\Desktop\NDL.dll

using System.Speech.Synthesis;

namespace NiCoding_Development_Library.Voice_Operations.Text2Speech
{
  public class Text2SpeechMale
  {
    public static void speakTextAsyncAdultMale(string text)
    {
      SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
      speechSynthesizer.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Adult);
      speechSynthesizer.SetOutputToDefaultAudioDevice();
      speechSynthesizer.SpeakAsync(text);
      if (speechSynthesizer == null)
        return;
      speechSynthesizer.Dispose();
    }

    public static void speakTextAsyncSeniorMale(string text)
    {
      SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
      speechSynthesizer.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Senior);
      speechSynthesizer.SetOutputToDefaultAudioDevice();
      speechSynthesizer.SpeakAsync(text);
      if (speechSynthesizer == null)
        return;
      speechSynthesizer.Dispose();
    }

    public static void speakTextAsyncChildMale(string text)
    {
      SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
      speechSynthesizer.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Child);
      speechSynthesizer.SetOutputToDefaultAudioDevice();
      speechSynthesizer.SpeakAsync(text);
      if (speechSynthesizer == null)
        return;
      speechSynthesizer.Dispose();
    }

    public static void speakTextAsyncTeenMale(string text)
    {
      SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
      speechSynthesizer.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Teen);
      speechSynthesizer.SetOutputToDefaultAudioDevice();
      speechSynthesizer.SpeakAsync(text);
      if (speechSynthesizer == null)
        return;
      speechSynthesizer.Dispose();
    }
  }
}
