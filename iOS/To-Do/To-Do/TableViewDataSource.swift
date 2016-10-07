//
//  TableViewDataSource.swift
//  To-Do
//
//  Created by Kaj Schermer Didriksen on 08/09/2016.
//  Copyright © 2016 Kaj Schermer Didriksen. All rights reserved.
//

import UIKit

class TableViewDataSource: NSObject {
    let stateController: StateController
    
    init(tableView: UITableView, stateController: StateController){
        self.stateController = stateController
        super.init()
        tableView.dataSource = self
    }
}

extension TableViewDataSource: UITableViewDataSource {
    
    func tableView(tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return stateController.items.count
    }
    
    func tableView(tableView: UITableView, cellForRowAtIndexPath indexPath: NSIndexPath) -> UITableViewCell {
        let parkingItem = stateController.items[indexPath.row]
        let cell = tableView.dequeueReusableCellWithIdentifier(ParkingLotItemCell.identifier, forIndexPath: indexPath) as! ParkingLotItemCell
        
        cell.garageCode = parkingItem.garageCode
        cell.date = parkingItem.date
        cell.totalSpaces = parkingItem.totalSpaces
        
        return cell
    }
    
    //delete
    
    func tableView(tableView: UITableView, commitEditingStyle editingStyle: UITableViewCellEditingStyle, forRowAtIndexPath indexPath: NSIndexPath) {
        if editingStyle == .Delete {
            // Delete the row from the data source
            stateController.removeItemAtIndex(indexPath.row)
            tableView.deleteRowsAtIndexPaths([indexPath], withRowAnimation: .Left)
        }
    }
 
    func tableView(tableView: UITableView, canEditRowAtIndexPath indexPath: NSIndexPath) -> Bool {
        return true
    }
}

