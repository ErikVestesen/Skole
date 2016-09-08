//
//  TableViewDataSource.swift
//  To-Do
//
//  Created by Erik Vestesen on 08/09/16.
//  Copyright © 2016 Erik Vestesen. All rights reserved.
//

import UIKit

class TableViewDataSource: NSObject {
    let stateController: StateController
    
    init(tableView: UITableView, stateController: StateController) {
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
        let toDoItem = stateController.items[indexPath.row]
        let cell  = tableView.dequeueReusableCellWithIdentifier(ToDoItemCell.identifier, forIndexPath: indexPath) as! ToDoItemCell
        
        cell.name = toDoItem.name
        cell.completed = toDoItem.completed
        
        return cell
    }
}