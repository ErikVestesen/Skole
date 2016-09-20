//
//  AddToDoItemViewController.swift
//  To-Do
//
//  Created by Erik Vestesen on 15/09/16.
//  Copyright © 2016 Erik Vestesen. All rights reserved.
//

import UIKit

class AddToDoItemViewController: UIViewController {
    
    @IBOutlet weak var saveButton: UIBarButtonItem!
    @IBOutlet weak var cancelButton: UIBarButtonItem!
    @IBOutlet weak var nameTextField: UITextField!
    
    var stateController: StateController?
    
    //Clicking save or cancel executes a seque
    //this prepare... executes prioer to the seque
    override func prepareForSegue(segue: UIStoryboardSegue, sender: AnyObject?) {
        guard let tappedButton = sender as? UIBarButtonItem where tappedButton !=
            cancelButton else {
                return
        }
        
        guard let text = nameTextField.text else {
            return;
        }
        
        let todoItem = ToDoItem(name: text, creationDate: NSDate(), completed: false)
        
        //Optional chaining, bedre end (if item != null) item.add
        stateController?.addItem(todoItem)
    }
    
 
}