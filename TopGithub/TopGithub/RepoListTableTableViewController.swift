//
//  RepoListTableTableViewController.swift
//  TopGithub
//
//  Created by DMU MAC 01 on 03/11/2016.
//  Copyright © 2016 E. All rights reserved.
//

import UIKit

class RepoListTableTableViewController: UITableViewController, StateControllerDelegate {

  @IBOutlet weak var tableview: UITableView!
  var stateController: StateController?
  
  func dataIsReady() {
    tableview.reloadData()
  }
  
  override func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
    if let stateController = stateController {
      return stateController.repos.count
    } else {
      return 0
    }
  }
  
  override func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
    let cell = tableView.dequeueReusableCell(withIdentifier: "repoCell", for: indexPath)
    if let repo = stateController?.repos[indexPath.row] {
      cell.textLabel?.text = repo.name
      cell.detailTextLabel?.text = repo.description
      if repo.image == nil {
        //download image
        //set repo.image = downloadedimage
        if let imageURL = URL(string: repo.avatarURL) {
          URLSession.shared.dataTask(with: imageURL, completionHandler: { (data, URLResponse, error) in
            if error == nil {
              if let data = data {
                let image = UIImage(data: data)
                if let image = image{
                  //UpdateGUI on main thread
                  DispatchQueue.main.async {
                    cell.imageView?.image = image
                    self.tableview.reloadRows(at: [indexPath], with: UITableViewRowAnimation.fade)
                  }
                  
                  //update the repo in statecontroller
                  self.stateController?.updateRepoImage(index: indexPath, image: image)
                  
                }
              }
            }
          }).resume()
        }
        
        
      } else {
        //already have the image
        cell.imageView?.image = repo.image
      }
    }
    return cell
  }
}
