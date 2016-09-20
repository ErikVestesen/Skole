//
//  TodoListTableViewController.swift
//  To-Do
//
//  Created by Erik Vestesen on 01/09/16.
//  Copyright © 2016 Erik Vestesen. All rights reserved.
// M<-MC<-VC<-V      MVC ala Kaj

//Arduino mini /nano
//HM-10

import UIKit

class TodoListTableViewController: UITableViewController {
    
    var stateController : StateController?
    var tableViewDataSource: TableViewDataSource?
    var tableViewDelegate: TableViewDelegate?
    
    override func viewDidLoad() {
        super.viewDidLoad()
        if let stateController = stateController {
            tableViewDataSource = TableViewDataSource(tableView: tableView, stateController: stateController)
            tableViewDelegate = TableViewDelegate(tableView: tableView, stateController: stateController)
        }
    }
    
    override func viewWillAppear(animated: Bool) {
        super.viewWillAppear(animated)
        tableView.reloadData()
    }
    
    override func prepareForSegue(segue: UIStoryboardSegue, sender: AnyObject?) {
        if let navigationController = segue.destinationViewController as? UINavigationController,
            let addToDoItemViewController = navigationController.viewControllers.first as? AddToDoItemViewController {
                addToDoItemViewController.stateController = self.stateController
        }
    }
    
    @IBAction func unwindToList(segue : UIStoryboardSegue){
            
    }

}                               