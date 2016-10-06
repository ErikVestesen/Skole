//
//  JSONController.swift
//  To-Do
//
//  Created by Erik Vestesen on 22/09/16.
//  Copyright © 2016 Kaj Schermer Didriksen. All rights reserved.
//

import UIKit

class JSONController: UITableViewController {
        var stateController: StateController?
        var tableViewDataSource: TableViewDataSource?
        var tableViewDelegate: TableViewDelegate?
        
        override func viewDidLoad() {
            super.viewDidLoad()
            if let stateController = stateController {
                tableViewDataSource = TableViewDataSource(tableView: tableView, stateController: stateController)
                tableViewDelegate = TableViewDelegate(tableView: tableView, stateController: stateController)
            }
            //finished() ?
        }
        
        override func viewWillAppear(animated: Bool) {
            super.viewWillAppear(animated)
            tableView.reloadData() //tableview.GetJSONData
            if let stateController = stateController {
                stateController.getJSONData("http://www.odaa.dk/api/action/datastore_search?resource_id=2a82a145-0195-4081-a13c-b0e587e9b89c")
            }
    }
}
