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
                System.err.println("Requested MIDI component cannot be opened or created as it is unavailable.");
            }
           
            i++;
        }
        MidiDevice keyboard = midiDevices[4];
        
        if (!(keyboard.isOpen())) {
            try {
                keyboard.open();
            } catch (MidiUnavailableException e) {
                System.err.println("Requested MIDI component cannot be opened or created as it is unavailable.");
            }
        }
    }
    
    public static void main(String[] args) {
        USynth us = new USynth();
    }
    
}
