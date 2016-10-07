//
//  TableViewDelegate.swift
//  To-Do
//
//  Created by Kaj Schermer Didriksen on 08/09/2016.
//  Copyright © 2016 Kaj Schermer Didriksen. All rights reserved.
//

import UIKit

class TableViewDelegate: NSObject {
    let stateController: StateController
    
    init(tableView: UITableView, stateController: StateController) {
        self.stateController = stateController
        super.init()
        tableView.delegate = self
    }

}

extension TableViewDelegate: UITableViewDelegate {
    
    func tableView(tableView: UITableView, didSelectRowAtIndexPath indexPath: NSIndexPath) {
        tableView.deselectRowAtIndexPath(indexPath, animated: false)
        //let tappedItem = stateController.items[indexPath.row]
        //tappedItem.completed = !tappedItem.completed
        tableView.reloadRowsAtIndexPaths([indexPath], withRowAnimation: UITableViewRowAnimation.None)
    }
    

    
    
}