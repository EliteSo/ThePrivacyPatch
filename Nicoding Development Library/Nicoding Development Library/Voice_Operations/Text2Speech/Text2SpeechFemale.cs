// Type: NiCoding_Development_Library.Voice_Operations.Text2Speech.Text2SpeechFemale
// Assembly: NDL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D03E96A6-C992-4E9A-BE57-D6DDB9E706CB
// Assembly location: C:\Users\Gigawiz\Desktop\NDL.dll

using System.Speech.Synthesis;

namespace NiCoding_Development_Library.Voice_Operations.Text2Speech
{
  public class Text2SpeechFemale
  {
    public static void speakTextAsyncAdultFemale(string text)
    {
      SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
      speechSynthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);
      speechSynthesizer.SetOutputToDefaultAudioDevice();
      speechSynthesizer.SpeakAsync(text);
      if (speechSynthesizer == null)
        return;
      speechSynthesizer.Dispose();
    }

    public static void speakTextAsyncSeniorFemale(string text)
    {
      SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
      speechSynthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Senior);
      speechSynthesizer.SetOutputToDefaultAudioDevice();
      speechSynthesizer.SpeakAsync(text);
      if (speechSynthesizer == null)
        return;
      speechSynthesizer.Dispose();
    }

    public static void speakTextAsyncChildFemale(string text)
    {
      SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
      speechSynthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Child);
      speechSynthesizer.SetOutputToDefaultAudioDevice();
      speechSynthesizer.SpeakAsync(text);
      if (speechSynthesizer == null)
        return;
      speechSynthesizer.Dispose();
    }

    public static void speakTextAsyncTeenFemale(string text)
    {
      SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
      speechSynthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen);
      speechSynthesizer.SetOutputToDefaultAudioDevice();
      speechSynthesizer.SpeakAsync(text);
      if (speechSynthesizer == null)
        return;
      speechSynthesizer.Dispose();
    }
  }
}
