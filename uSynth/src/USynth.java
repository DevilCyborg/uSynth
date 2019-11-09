import javax.sound.midi.*;
/**
 *
 * @author DevilCyborg
 */
public class USynth {
    
    
    public USynth() throws MidiUnavailableException, InvalidMidiDataException {
        MidiDevice.Info[] midiInfo = MidiSystem.getMidiDeviceInfo();
        MidiDevice[] midiDevices = new MidiDevice[midiInfo.length];
        int i = 0;
        for (MidiDevice.Info inf : midiInfo){
            midiDevices[i] = MidiSystem.getMidiDevice(inf);
            if (midiDevices[i] instanceof Sequencer){
                System.out.print("This is a sequencer -> ");
            } else if (midiDevices[i] instanceof Synthesizer) {
                System.out.print("This is a synthesizer -> ");
            } else {
                System.out.print("What is this? -> ");
            }
            System.out.println("Position " + i + ": " + inf.getName() + " and " + inf.getDescription());
            i++;
        }
        MidiDevice keyboard = midiDevices[1];
        Synthesizer synth = MidiSystem.getSynthesizer();
        if (!(synth.isOpen())){
            synth.open();
        }
        Receiver rsynth = synth.getReceiver();
        
        keyboard.open();
        Transmitter tport = keyboard.getTransmitter();
        
        tport.setReceiver(rsynth);
        
        Instrument[] instruments = synth.getAvailableInstruments();
        for (Instrument instrument : instruments) {
            System.out.print(instrument.getName() + ", ");
        }
        System.out.println("");
        synth.loadInstrument(instruments[9]);
        Soundbank soundbank = instruments[9].getSoundbank();
        System.out.println(synth.isSoundbankSupported(soundbank));
        
        System.out.println("Latency = " + synth.getLatency());
        System.out.println("Max Polyphony = " + synth.getMaxPolyphony());
    }
    
    public static void main(String[] args) {
        try {
            USynth us = new USynth();
            
        } catch (MidiUnavailableException | InvalidMidiDataException e) {
            System.err.println(e);
        }
        
    }
    
}
