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
                if (midiDevices[i] instanceof Sequencer){
                    System.out.print("This is a sequencer -> ");
                } else if (midiDevices[i] instanceof Synthesizer) {
                    System.out.print("This is a synthesizer -> ");
                } else {
                    System.out.print("What is this? -> ");
                }
                System.out.println("Position " + i + ": " + inf.getName() + " and " + inf.getDescription());
            } catch (MidiUnavailableException e) {
                System.err.println("1 Requested MIDI component cannot be opened or created as it is unavailable.");
            }
           
            i++;
        }
        Sequencer seq = null;
        Synthesizer synth = null;
        MidiDevice keyboard = midiDevices[4];
        Transmitter t = null, tport = null;
        Receiver rsynth = null, rseq = null;
        try {
            synth = MidiSystem.getSynthesizer();
            if (!(synth.isOpen())){
                synth.open();
                rsynth = synth.getReceiver();
            }
        } catch (MidiUnavailableException e) {
            System.err.println(e);
        }
        
        try {
            seq = MidiSystem.getSequencer();
            System.out.println(seq.getDeviceInfo().getName());
            if (!(seq.isOpen())) {
                seq.open();
                t = seq.getTransmitter();
                rseq = seq.getReceiver();
                tport = keyboard.getTransmitter();
            }
        } catch (MidiUnavailableException e) {
            System.err.println(e);
        }
        t.setReceiver(rsynth);
        tport.setReceiver(rseq);
        
        Instrument[] instruments = synth.getAvailableInstruments();
        for (Instrument instrument : instruments) {
            System.out.print(instrument.getName() + ", ");
        }
        System.out.println("");
        synth.loadInstrument(instruments[9]);
        Soundbank soundbank = instruments[9].getSoundbank();
        System.out.println(synth.isSoundbankSupported(soundbank));
    }
    
    public static void main(String[] args) {
        USynth us = new USynth();
        
    }
    
}
