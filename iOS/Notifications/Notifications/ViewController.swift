//
//  ViewController.swift
//  Notifications
//
//  Created by DMU MAC 01 on 24/11/2016.
//  Copyright © 2016 E. All rights reserved.
//

import UIKit

class ViewController: UIViewController {
  
  
  @IBAction func datePickerDidSelectNewDate(_ sender: UIDatePicker) {
    let selectedDate = sender.date
    print("selected date \(selectedDate)")
  }
}

