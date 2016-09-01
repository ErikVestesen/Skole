//
//  ViewController.swift
//  iArnold
//
//  Created by Erik Vestesen on 26/08/16.
//  Copyright © 2016 Erik Vestesen. All rights reserved.
//

import UIKit
import AVFoundation // <-- sound

class ViewController: UIViewController {

    @IBOutlet weak var arnoldImage: UIImageView!
    // model (UGLY code coming)
    let imageNames = ["action", "arnold", "commando", "conan","conan-the-barbarian","old","terminator" ]
    let soundNames = ["20centeuryFox","chopper","DoIt","boots", "Hasta la vista","noshit","talkToTheHand",
                      "tumor", "youareme"]
    
    var soundPlayer = AVAudioPlayer()
    
    override func viewDidLoad() {
        super.viewDidLoad()
       
        let aSelector = #selector(ViewController.reDisplay)
        let tapGesture1Click = UITapGestureRecognizer(target: self, action: aSelector)
        tapGesture1Click.numberOfTapsRequired = 1
        view.addGestureRecognizer(tapGesture1Click)
        
        
        reDisplay()
    }

    func reDisplay() {
        arnoldImage.image = UIImage(named:pickARandomImageFromModel())
        let soundPath = NSBundle.mainBundle().pathForResource(pickARandomSoundFromModel(), ofType: "aiff")
        if let soundPath = soundPath {
            let soundURL = NSURL.fileURLWithPath(soundPath)
            
            do {
                try soundPlayer = AVAudioPlayer(contentsOfURL: soundURL)
                soundPlayer.prepareToPlay()
                soundPlayer.play()
            } catch {
                print("Player not working")
            }
        }
    }
    
    //MARK: private methods
    private func pickARandomImageFromModel() -> String {
        return imageNames[Int(arc4random_uniform(UInt32(imageNames.count-1)))]
    }
    
    private func pickARandomSoundFromModel() -> String {
        return soundNames[Int(arc4random_uniform(UInt32(soundNames.count-1)))]
    }

}

