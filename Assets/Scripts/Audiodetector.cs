using UnityEngine;
using UnityEngine.Android;

public class Audiodetector : MonoBehaviour
{
    public int sampleWindow = 64;
    private AudioClip Microphoneclip;
    public float sensibility = 100;
    public float threshold = 0.1f;

    void Start()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }

        if (Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            microphoneToAudioclip();
        }
        else
        {
            Debug.LogError("Microphone permission not granted.");
        }
    }

    void Update()
    {
        // You can test IsLoud() here if needed
    }

    public void microphoneToAudioclip()
    {
        if (Microphone.devices.Length == 0)
        {
            Debug.LogError("No microphones detected.");
            return;
        }

        string microphoneName = Microphone.devices[0];
        Debug.Log("microphoneName: " + microphoneName);

        // Start the microphone with a valid sample rate
        Microphoneclip = Microphone.Start(microphoneName,true,20,AudioSettings.outputSampleRate);

        // Wait for the microphone to start recording
        while (Microphone.GetPosition(microphoneName) <= 0)
        {
            // Do nothing, just wait
        }

        Debug.Log("Microphone started successfully.");
    }

    public float getloudness()
    {
        int clipPosition = Microphone.GetPosition(Microphone.devices[0]);
        if (clipPosition <= 0)
        {
            Debug.LogWarning("Microphone is not capturing audio.");
            return 0f;
        }

        return getLoudnessForAudio(clipPosition, Microphoneclip);
    }

    public float getLoudnessForAudio(int clipPosition, AudioClip clip)
    {
        if (clip == null)
        {
            Debug.LogError("AudioClip is null.");
            return 0f;
        }

        int startPosition = Mathf.Clamp(clipPosition - sampleWindow, 0, clip.samples - sampleWindow);
        float[] waveData = new float[sampleWindow];
        clip.GetData(waveData, startPosition);

        float totalLoudness = 0;
        for (int i = 0; i < sampleWindow; i++)
        {
            totalLoudness += Mathf.Abs(waveData[i]);
        }

        return totalLoudness / sampleWindow;
    }

    public bool IsLoud()
    {
        float loudness = getloudness() * sensibility;
        Debug.Log("Loudness: " + loudness);
        return loudness > threshold;
    }
}