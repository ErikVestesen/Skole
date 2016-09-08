//
//  TableViewDelegate.swift
//  To-Do
//
//  Created by Erik Vestesen on 08/09/16.
//  Copyright © 2016 Erik Vestesen. All rights reserved.
//

import UIKit

class TableViewDelegate: NSObject {
    let stateController:StateController
    
    init(tableView: UITableView, stateController: StateController)  {
        self.stateController = stateController
        super.init()
        tableView.delegate = self
    }
}

extension TableViewDelegate: UITableViewDelegate {
    func tableView(tableView: UITableView, didSelectRowAtIndexPath indexPath: NSIndexPath) {
        tableView.deselectRowAtIndexPath(indexPath, animated: false)
        let tappedItem = stateController.items[indexPath.row]
        tappedItem.completed = !tappedItem.completed
        
        tableView.reloadRowsAtIndexPaths([], withRowAnimation: UITableViewRowAnimation.None)
    }
    
}