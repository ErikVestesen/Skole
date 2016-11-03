//
//  Repo.swift
//  TopGithub
//
//  Created by DMU MAC 01 on 03/11/2016.
//  Copyright © 2016 E. All rights reserved.
//

import UIKit

struct Repo {
  let name: String
  let avatarURL: String
  let description: String
  
  var image: UIImage?
 
  init(name: String, avatarURL:String, description: String) {
    self.name = name
    self.avatarURL = avatarURL
    self.description = description
    self.image = nil
  }
  
}
