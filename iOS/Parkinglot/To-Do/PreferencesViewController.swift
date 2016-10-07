//
//  PreferencesViewController.swift
//  Parkinglot
//
//  Created by DMU MAC 01 on 06/10/2016.
//  Copyright © 2016 Kaj Schermer Didriksen. All rights reserved.
//

import UIKit

class PreferencesViewController: UIViewController {

  @IBAction func Camera(sender: UIBarButtonItem) {
  }
  @IBAction func Save(sender: UIBarButtonItem) {
      autoUpdate.on = true
  }
  
  @IBOutlet weak var autoUpdate: UISwitch!
  @IBOutlet weak var Username: UITextField!
  
  
    override func viewDidLoad() {
        super.viewDidLoad()
      
        Username.delegate = self
    }
}

extension PreferencesViewController: UITextFieldDelegate {
  func textFieldShouldReturn(textField: UITextField) -> Bool {
     // keyboard goes away here.
      textField.resignFirstResponder()
      return true
    }
  
  func textField(textField: UITextField, shouldChangeCharactersInRange range: NSRange, replacementString string: String) -> Bool {
    //Skifter f.eks. et bogstav ud med hvad man ønsker, hvis man nu skriver "a", så kan den skifte det ud med "hej"
    
    return true
  }
}
