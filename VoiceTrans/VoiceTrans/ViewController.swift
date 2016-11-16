//
//  ViewController.swift
//  VoiceTrans
//
//  Created by Erik Vestesen on 10/11/16.
//  Copyright © 2016 Erik Vestesen. All rights reserved.
//

import UIKit
import Speech
import AVFoundation

class ViewController: UIViewController {

    let soundPath = Bundle.main.path(forResource: "lyden", ofType: "aiff")
    let soundURL = NSURL.fileURL(withPath: soundPath)
    
    let recognizer = SFSpeechRecognizer()
    let request = SFSpeechURLRecognitionRequest(url: soundURL)
    recognizer?.recognitionTask(with: request, resultHandler: { (result, error) in
    print (result?.bestTranscription.formattedString)
    })
    
}

