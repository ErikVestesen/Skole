//
//  ViewController.swift
//  Simon
//
//  Created by DMU MAC 01 on 10/11/2016.
//  Copyright © 2016 E. All rights reserved.
//

import UIKit
import AVFoundation

class ViewController: UIViewController {

  enum ButtonColor: Int {
    case red = 1
    case green = 2
    case blue = 3
    case yellow = 4
  }
  
  enum WhoseTurn {
    case human
    case computer
  }

  @IBOutlet weak var yellowButton: UIButton!
  @IBOutlet weak var blueButton: UIButton!
  @IBOutlet weak var redButton: UIButton!
  
  @IBAction func buttonTouched(_ sender: UIButton) {
    //determine which button was touched by looking at its tag
    let buttontag = sender.tag
  
    if let colorTouched = ButtonColor(rawValue: buttontag) {
      if currentPlayer == .computer {
        //Ignore touches while current player is computer
        return
      }
      
      if colorTouched == inputs[indexOfNextButtonToTouch] {
        // human touched the current button
        indexOfNextButtonToTouch += 1
        
        //determine if there are any more buttons left in the round
        if indexOfNextButtonToTouch == inputs.count {
          // human won the round
          if advanceGame() == false {
            //Player wins
            playerWins()
          }
          indexOfNextButtonToTouch = 0
        } else {
          //There are more buttons in the round to touch, so keep waiting
          //exercise
        }
      } else {
        //human looses - the wrong button was touched
        playerLooses()
        indexOfNextButtonToTouch = 0
        }
      }
  }
  
  
  @IBOutlet weak var greenButton: UIButton!
  @IBOutlet weak var startButton: UIBarButtonItem!
  @IBAction func startButtonClicked(_ sender: UIBarButtonItem) {
    startNewGame()
    sender.isEnabled = false // disables the start button
  }
  
  //Model related objects and properties
  let winningNumber:Int = 3
  var currentPlayer: WhoseTurn = .computer
  var inputs = [ButtonColor]()
  var indexOfNextButtonToTouch: Int = 0
  let highlightSquareTime:Double = 0.5
  
  var soundPlayer = AVAudioPlayer()
  
  func startNewGame() {
    inputs = [ButtonColor]()
    _ = advanceGame()
  }
  
  func advanceGame() -> Bool {
    var result = true
    
    if inputs.count == winningNumber {
      result = false
    } else {
      //add a random number to the list
      inputs += [randomButton()]
      
      //play the button sequence
      play(sequence:0, highlightTime: highlightSquareTime)
      
    }
    
    return result
  }
  
  func playerWins() {
    let alert = UIAlertController(title: "You Won!",
                                  message: "Congratulations!",
                                  preferredStyle: .alert)
    //alert button - start new game
    alert.addAction(UIAlertAction(title: "Play Again!",
                                  style: .default,
                                  handler: { action in
                                    self.startNewGame()
    }))
    //alert button - OK
    alert.addAction(UIAlertAction(title: "OK",
                                  style: .default,
                                  handler: {action in
                                    self.startButton.isEnabled = true
    }))
    
    self.present(alert, animated: true, completion: nil)
  }
  
  func playerLooses() {
    let alert = UIAlertController(title: "You Lose!",
                                  message: "Sorry!",
                                  preferredStyle: .alert)
    //alert button - start new game
    alert.addAction(UIAlertAction(title: "Play Again!",
                                  style: .default,
                                  handler: { action in
                                    self.startNewGame()
    }))
    //alert button - OK
    alert.addAction(UIAlertAction(title: "OK",
                                  style: .default,
                                  handler: {action in
                                    self.startButton.isEnabled = true
    }))
  }
  
  func play(sequence: Int, highlightTime: Double) {
    currentPlayer = .computer
    if sequence == inputs.count {
      currentPlayer = .human
      return;
    }
    
    let button = buttonBy(color: inputs[sequence])
    let originalColor = button.backgroundColor
    let highligtColor = UIColor.white
    
    //sounds here
    var soundName: String
    switch button {
    case redButton:
      soundName = "red"
    case blueButton:
      soundName = "blue"
    case yellowButton:
      soundName = "yellow"
    case greenButton:
      soundName = "green"
    
    default:
      soundName = ""
    }
    
    
    let soundPath = Bundle.main.path(forResource: soundName, ofType: "aiff")
    if let soundPath = soundPath {
      let soundURL = NSURL.fileURL(withPath: soundPath)
      do {
        try soundPlayer = AVAudioPlayer(contentsOf: soundURL)
        soundPlayer.prepareToPlay()
        soundPlayer.play()
      } catch {
        print("SoundPlayer is not available")
      }
    }
    
    
    UIView.animate(withDuration: highlightTime,
                   delay: 0.0,
                   options:UIViewAnimationOptions.curveLinear.intersection(.allowUserInteraction).intersection(.beginFromCurrentState),
                   animations: {button.backgroundColor = highligtColor},
                   completion: {finished in
                      button.backgroundColor = originalColor
                      let newIndex = sequence + 1
                      self.play(sequence: newIndex, highlightTime: highlightTime)
                   })
  }
  
  func buttonBy(color: ButtonColor ) -> UIButton {
    switch color {
    case .red:
        return redButton
    case .green:
        return greenButton
    case .blue:
        return blueButton
    case .yellow:
        return yellowButton
    }
  }
  
  func randomButton() -> ButtonColor {
    let v = Int(arc4random_uniform(UInt32(4))) + 1
    let result = ButtonColor(rawValue: v)
    return result!
  }
  
  
}

