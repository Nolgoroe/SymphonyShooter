using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class InstrumentDetector : MonoBehaviour
{
    [EventID]
    public string eventID;

    [EventID]
    public string eventIDSpan;

    int differenceFromStartToEndSample = 0;

    public WeaponSpawnerBase weapon;

    Koreography playingKoreo;

    //int pendingEventIdx = 0;
    //int currentSample = 0;

    //List<KoreographyEvent> rawEvents;
    // Start is called before the first frame update
    void Start()
    {
        Koreographer.Instance.RegisterForEvents(eventID, DetectPlayOneShot);
        Koreographer.Instance.RegisterForEvents(eventIDSpan, DetectPlaySpan);

        playingKoreo = Koreographer.Instance.GetKoreographyAtIndex(0);

        //KoreographyTrack rhythmTrack = playingKoreo.GetTrackByID(eventID);
        //rawEvents = rhythmTrack.GetAllEvents();

    }

    private void DetectPlayOneShot(KoreographyEvent evt)
    {
        //this is where we want to do something for the span of the whole event
        Debug.Log("Instrument: " + eventID + " One shot");

        if(weapon)
        {
            weapon.Spawn();
        }
    }
    private void DetectPlaySpan(KoreographyEvent evt)
    {
        differenceFromStartToEndSample = evt.StartSample - evt.EndSample;

        Koreography playingKoreo = Koreographer.Instance.GetKoreographyAtIndex(0);
        double samplesPerBeat = playingKoreo.GetSamplesPerBeat(0);

        float spanInBeatsOfNote = (float)differenceFromStartToEndSample / (float)samplesPerBeat;

        float beatsInAsecond = (float)playingKoreo.GetBPM(0) / 60;
        float seconds = Mathf.Abs(spanInBeatsOfNote) / beatsInAsecond;
        //Debug.Log("Instrument: " + eventID + " " + "Secods: " + seconds);

    }

    void OnDestroy()
    {
        // Sometimes the Koreographer Instance gets cleaned up before hand.
        //  No need to worry in that case.
        if (Koreographer.Instance != null)
        {
            Koreographer.Instance.UnregisterForAllEvents(this);
        }
    }
}
