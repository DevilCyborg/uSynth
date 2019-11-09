import javax.sound.midi.*;
import javax.sound.sampled.*;
/**
 *
 * @author DevilCyborg
 */
public class USynth {
    
    
    public USynth() {
        MidiDevice.Info[] midiInfo = MidiSystem.getMidiDeviceInfo();
        MidiDevice[] midiDevices = new MidiDevice[midiInfo.length];
        int i = 0;
        for (MidiDevice.Info inf : midiInfo){
            try {
                midiDevices[i] = MidiSystem.getMidiDevice(inf);
                System.out.println("Position " + i + ": " + inf.getName() + " and " + inf.getDescription());
            } catch (MidiUnavailableException e) {
                System.err.println("1 Requested MIDI component cannot be opened or created as it is unavailable.");
            }
           
            i++;
        }
        MidiDevice keyboard = midiDevices[1];
        MidiDevice synth = midiDevices[3];
        Transmitter t;
        Receiver r;
        
        if (!(keyboard.isOpen())) {
            try {
                keyboard.open();
                t = keyboard.getTransmitter();
            } catch (MidiUnavailableException e) {
                System.err.println("2 Requested MIDI component cannot be opened or created as it is unavailable.");
            }
        }
        
        if (!(synth.isOpen())){
            try {
                synth.open();
                r = synth.getReceiver();
            } catch (MidiUnavailableException e) {
                System.err.println("3 Requested MIDI component cannot be opened or created as it is unavailable.");
            }
        }
        
    }
    
    public static void main(String[] args) {
        USynth us = new USynth();
    }
    
}
