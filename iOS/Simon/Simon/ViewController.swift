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
  
  @IBAction func buttonTouched(_ sender: AnyObject) {
  }
  
  
  @IBOutlet weak var greenButton: UIButton!
  @IBOutlet weak var startButton: UIBarButtonItem!
  @IBAction func startButtonClicked(_ sender: AnyObject) {
    
  }
  
  //Model related objects and properties
  let winningNumber:Int = 3
  var currentPlayer: WhoseTurn = .computer
  var inputs = [ButtonColor]()
  var indexOfNextButtonToTouch: Int = 0
  let highlightSquareTime:Double = 0.5
  
  var soundPlayer = AVAudioPlayer()
  
  func startGame() {
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
      playSequence(0,highlightTime: highlightSquareTime)
      
    }
    
    return result
  }
  
  func playSequence(_ index: Int, highlightTime: Double) {
    
  }
  
  func randomButton() -> ButtonColor {
    let v = Int(arc4random_uniform(UInt32(4))) + 1
    let result = ButtonColor(rawValue: v)
    return result!
  }
  
  
}

