//
//  StateController.swift
//  TopGithub
//
//  Created by DMU MAC 01 on 03/11/2016.
//  Copyright © 2016 E. All rights reserved.
//

import UIKit

class StateController : JSONDownloadDelegate {
  
  var delegate: StateControllerDelegate?
  
  //getter is public, setter is private
  private(set) var repos = [Repo]()
  
  func add(repo: Repo) {
      repos.append(repo)
  }
  
  func updateRepoImage(index: Int, image: UIImage) {
      repos[index].image = image
  }
  
  func getData() {
    _ = JSONDownload(urlPath: "https://api.github.com/search/repositories?q=language:swift&sort=stars&order=desc", delegate: self)
  }
  
  func finishedDownloading(data: JSON) {
    
  }
}
