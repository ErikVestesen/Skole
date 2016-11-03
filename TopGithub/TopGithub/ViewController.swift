//
//  ViewController.swift
//  TopGithub
//
//  Created by DMU MAC 01 on 03/11/2016.
//  Copyright © 2016 E. All rights reserved.
//

import UIKit

class ViewController: UIViewController,  StateControllerDelegate {
  
  var stateController: StateController?
  
  func dataIsReady() {
    print("\(stateController?.repos)")
  }
  
  
  
}

//extension UITableViewDelegate, UITableViewDataSource {


//}

