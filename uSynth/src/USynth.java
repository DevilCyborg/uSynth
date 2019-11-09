import javax.sound.midi.*;
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
        Synthesizer synth = null;
        Transmitter t = null;
        Receiver r = null;
        try {
            synth = MidiSystem.getSynthesizer();
            if (!(synth.isOpen())){
                synth.open();
                r = synth.getReceiver();
            }
        } catch (MidiUnavailableException e) {
            System.err.println(e);
        }
        
        if (!(keyboard.isOpen())) {
            try {
                keyboard.open();
                t = keyboard.getTransmitter();
            } catch (MidiUnavailableException e) {
                System.err.println("2 Requested MIDI component cannot be opened or created as it is unavailable.");
            }
        }
        t.setReceiver(r);
        
        Instrument[] instruments = synth.getAvailableInstruments();
        for (Instrument instrument : instruments) {
            System.out.print(instrument.getName() + ", ");
        }
        synth.loadInstrument(instruments[9]);
        
        ShortMessage myMsg = new ShortMessage();
        try {
            myMsg.setMessage(ShortMessage.NOTE_ON, 0, 60, 93);
        } catch (InvalidMidiDataException e) {
            System.err.println(e);
        }
        
        long timeStamp = keyboard.getMicrosecondPosition();
        System.out.println(timeStamp);
        r.send(myMsg, timeStamp);
    }
    
    public static void main(String[] args) {
        USynth us = new USynth();
        
    }
    
}
