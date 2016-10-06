//
//  ToDoListTableViewController.swift
//  To-Do
//
//  Created by Kaj Schermer Didriksen on 01/09/2016.
//  Copyright © 2016 Kaj Schermer Didriksen. All rights reserved.
//

import UIKit

class ParkinglotListTableViewController: UITableViewController, StateControllerDelegate {
    
    var rerfreshCtrl: UIRefreshControl!
    
    var stateController: ParkinglotStateController?
    var jsonDownloadController: JSONDownload?
    var tableViewDataSource: TableViewDataSource?
    var tableViewDelegate: TableViewDelegate?
    
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        self.rerfreshCtrl = UIRefreshControl()
        self.rerfreshCtrl.addTarget(self, action: #selector(ParkinglotListTableViewController.refreshTableView) , forControlEvents: .ValueChanged)
        self.refreshControl = self.rerfreshCtrl
        
        refreshTableView()
        
    }
    
    override func viewWillAppear(animated: Bool) {
        super.viewWillAppear(animated)
        tableView.reloadData()
    }
    
    func dataIsReady() {
        tableView.reloadData()
    }
    
    func refreshTableView() {
        let jsonDownloadController = JSONDownload(urlPath: "http://www.odaa.dk/api/action/datastore_search?resource_id=2a82a145-0195-4081-a13c-b0e587e9b89c")
        
        if let stateController = stateController {
            jsonDownloadController.delegate = stateController
            stateController.delegate = self
            tableViewDataSource = TableViewDataSource(tableView: tableView, stateController: stateController)
            tableViewDelegate = TableViewDelegate(tableView: tableView, stateController: stateController)
        }
        
        self.refreshControl?.endRefreshing()
    }
    
}
