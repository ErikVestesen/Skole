//
//  TableViewDataSource.swift
//  To-Do
//
//  Created by Kaj Schermer Didriksen on 08/09/2016.
//  Copyright © 2016 Kaj Schermer Didriksen. All rights reserved.
//

import UIKit

class TableViewDataSource: NSObject {
    let stateController: ParkinglotStateController
    
    init(tableView: UITableView, stateController: ParkinglotStateController){
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
        let parkinglotItem = stateController.items[indexPath.row]
        let cell = tableView.dequeueReusableCellWithIdentifier(ParkinglotCell.identifier, forIndexPath: indexPath) as! ParkinglotCell
        
        cell.vehicleCount = parkinglotItem.vehicleCount
        cell.totalSpace = parkinglotItem.totalSpace
        
        cell.name = "\(parkinglotItem.name) \(parkinglotItem.date)"
        cell.detail = "\(parkinglotItem.vehicleCount) out of \(parkinglotItem.totalSpace) parkinglots are used"
        
        
        return cell
    }
}

